using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorMaterial
{
    public class MDCDrawerComponent : BlazorMaterialComponent
    {
        private const string ATTACH_FUNCTION = "BlazorMaterialDrawerAttachTo";
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

        protected override void OnAfterRender()
        {
            if (this._isFirstRender)
            {
                this._isFirstRender = false;

                if (this.Type != MDCDrawerType.Permanent)
                {
                    var persistent = this.Type == MDCDrawerType.Persistent;
                    
                    JSRuntime.Current.InvokeAsync<bool>(ATTACH_FUNCTION, this._MDCDrawer, persistent);
                }
            }
        }
    }
}
