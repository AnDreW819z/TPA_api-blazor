using Microsoft.AspNetCore.Components;
using tparf.Models.Dtos;

namespace tparf.WebClient.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
