using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using tparf.Models.Dtos.Auth;
using tparf.Web.AuthProviders;
using System.Net.Http.Headers;
using tparf.Web.Services.Contracts;

namespace tparf.Web.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly string baseUrl;
        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient= httpClient;
            _localStorage= localStorage;
            _authStateProvider = authStateProvider;
            baseUrl = "https://localhost:7187/api/Authorization";
        }
        public async Task<LoginResponse> Login(LoginModel model)
        {

            var loginResult = await _httpClient.PostAsJsonAsync($"{baseUrl}/login", model);
            if (!loginResult.IsSuccessStatusCode)
                return new LoginResponse { StatusCode = 0, Message = "Server error" };
            var loginResponseContent = await loginResult.Content.ReadFromJsonAsync<LoginResponse>();
            if (loginResponseContent != null)
            {
                _localStorage.SetItemAsync("accessToken", loginResponseContent.Token);
                ((AuthProvider)_authStateProvider).NotifyUserAuthentication(loginResponseContent.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponseContent.Token);
            }
            return loginResponseContent;

        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            ((AuthProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
