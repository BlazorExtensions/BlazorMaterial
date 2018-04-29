using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Threading;

namespace BlazorMaterial
{
    public class MDCButtonComponent : BlazorComponent
    {
        private const string ADD_RIPPLE_FUNCTION = "BlazorMaterial.AddRipple";
        private static readonly ClassBuilder<MDCButtonComponent> _classNameBuilder;
        public MDCButtonType Type { get; set; }
        public MDCButtonStyle Style { get; set; }
        public Action<UIMouseEventArgs> OnClick { get; set; }
        public Action<UIMouseEventArgs> OnMouseUp { get; set; }
        public Action<UIMouseEventArgs> OnMouseDown { get; set; }
        public Action<UIKeyboardEventArgs> OnKeyPress { get; set; }
        public Action<UIKeyboardEventArgs> OnKeyDown { get; set; }
        public Action<UIKeyboardEventArgs> OnKeyUp { get; set; }
        public string Icon { get; set; }
        public bool Disabled { get; set; }
        public bool Dense { get; set; }
        public string HRef { get; set; }

        public RenderFragment ChildContent { get; set; }

        protected string ClassString { get; private set; }

        private Timer _rippleTimer;

        static MDCButtonComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCButtonComponent>("mdc", "button")
                .DefineClass("dense", c => c.Dense, PrefixSeparators.Modifier)
                .DefineClass((c) => c.Style.ToString().ToLowerInvariant(), (c) => c.Style != MDCButtonStyle.Default)
                .DefineClass("icon", (c) => c.ChildContent == null && !string.IsNullOrWhiteSpace(c.Icon), PrefixSeparators.Element);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this);
        }

        protected void AddRipple()
        {
            // Hack: Remove once the OnRendered event is published.
            this._rippleTimer = new Timer(_ => {
                RegisteredFunction.Invoke<bool>(ADD_RIPPLE_FUNCTION);
                this._rippleTimer.Dispose();
            }, null, 500, Timeout.Infinite);
            
        }
    }
}
