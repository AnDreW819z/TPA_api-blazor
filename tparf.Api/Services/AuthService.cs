using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Api.Extensions;
using tparf.Models.Dtos.Auth;

namespace tparf.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly TparfDbContext _context;

        public AuthService(TparfDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AuthServiceResponseDto> MakeAdministratorAsync(UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.Email);

            if (user is null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, Role.Administrator);

            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User is now an ADMIN"
            };
        }

        public async Task<AuthServiceResponseDto> MakeModeratorAsync(UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByNameAsync(updatePermissionDto.Email);

            if (user is null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, Role.Moderator);

            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User is now an Moderator"
            };
        }

        public async Task<AuthServiceResponseDto> SeedRolesAsync()
        {
            bool isOwnerRoleExists = await _roleManager.RoleExistsAsync(Role.Moderator);
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(Role.Administrator);
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(Role.Member);

            if (isOwnerRoleExists && isAdminRoleExists && isUserRoleExists)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = true,
                    Message = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole<long>(Role.Member));
            await _roleManager.CreateAsync(new IdentityRole<long>(Role.Administrator));
            await _roleManager.CreateAsync(new IdentityRole<long>(Role.Moderator));

            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "Role Seeding Done Successfully"
            };
        }
    }
}
