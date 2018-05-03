using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorMaterial
{
    public class BlazorMaterialComponent : BlazorComponent
    {
        [Parameter]
        protected string Class { get; set; }
    }
}
