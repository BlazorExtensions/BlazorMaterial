using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorMaterial
{
    public class MDCToolbarComponent : BlazorMaterialComponent
    {
        private const string ATTACH_FUNCTION = "BlazorMaterial.Toolbar.AttachTo";
        private static readonly ClassBuilder<MDCToolbarComponent> _classNameBuilder;

        [Parameter]
        protected MDCToolbarStyle Style { get; set; }        

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected string ClassString { get; set; }

        protected ElementRef _MDCToolbar;
        private bool _isFirstRender = true;

        static MDCToolbarComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCToolbarComponent>("mdc", "toolbar")
                .DefineClass("fixed", c => c.Style == MDCToolbarStyle.Fixed, PrefixSeparators.Modifier)
                .DefineClass("waterfall", c => c.Style == MDCToolbarStyle.Waterfall, PrefixSeparators.Modifier)
                .DefineClass("fixed-lastrow-only", c => c.Style == MDCToolbarStyle.FixedLastRowOnly, PrefixSeparators.Modifier)
                .DefineClass("flexible", c => c.Style == MDCToolbarStyle.Flexible, PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this);
        }

        protected override void OnAfterRender()
        {
            if (this._isFirstRender)
            {
                this._isFirstRender = false;
                RegisteredFunction.Invoke<bool>(ATTACH_FUNCTION, this._MDCToolbar);
            }
        }
    }
}
