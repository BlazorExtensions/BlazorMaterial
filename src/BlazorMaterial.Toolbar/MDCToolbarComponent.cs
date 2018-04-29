using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System.Threading;

namespace BlazorMaterial
{
    public class MDCToolbarComponent : BlazorComponent
    {
        private const string ATTACH_FUNCTION = "BlazorMaterial.Toolbar.AttachTo";
        private static readonly ClassBuilder<MDCToolbarComponent> _classNameBuilder;
        public MDCToolbarStyle Style { get; set; }        

        public RenderFragment ChildContent { get; set; }

        protected string ClassString { get; set; }

        private Timer _attachTimer;

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

        protected void AttachTo()
        {
            // Hack: Remove once the OnRendered event is published.
            this._attachTimer = new Timer(_ => {
                RegisteredFunction.Invoke<bool>(ATTACH_FUNCTION);
                this._attachTimer.Dispose();
            }, null, 500, Timeout.Infinite);
        }
    }
}
