using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;

namespace BlazorMaterial
{
    public class MDCDrawerComponent : BlazorMaterialComponent
    {
        private const string ATTACH_PERSIST_DRAWER_FUNCTION = "mdc.drawer.MDCPersistentDrawer.attachTo";
        private const string ATTACH_TEMPORARY_DRAWER_FUNCTION = "mdc.drawer.MDCTemporaryDrawer.attachTo";

        private static readonly ClassBuilder<MDCDrawerComponent> _classNameBuilder;

        [Parameter]
        protected MDCDrawerType Type { get; set; }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected string ClassString { get; private set; }

        protected ElementRef _MDCDrawer;
        private bool _isFirstRender = true;

        static MDCDrawerComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCDrawerComponent>("mdc", "drawer")
                .DefineClass((c) => c.Type.ToString().ToLowerInvariant(), PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this, this.Class);
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (this._isFirstRender)
            {
                this._isFirstRender = false;

                if (this.Type != MDCDrawerType.Permanent)
                {
                    if (this.Type == MDCDrawerType.Persistent)
                    {
                        await JSRuntime.Current.InvokeAsync<bool>(ATTACH_PERSIST_DRAWER_FUNCTION, this._MDCDrawer);
                    }
                    else
                    {
                        await JSRuntime.Current.InvokeAsync<bool>(ATTACH_TEMPORARY_DRAWER_FUNCTION, this._MDCDrawer);
                    }
                }
            }
        }
    }
}
