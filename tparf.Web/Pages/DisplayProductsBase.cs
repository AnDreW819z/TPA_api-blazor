using Microsoft.AspNetCore.Components;
using tparf.Models.Dtos;

namespace tparf.Web.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
