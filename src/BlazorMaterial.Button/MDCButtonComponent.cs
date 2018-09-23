using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;

namespace BlazorMaterial
{
    public class MDCButtonComponent : BlazorMaterialComponent
    {
        private const string ADD_RIPPLE_FUNCTION = "BlazorMaterialAddRipple";
        private static readonly ClassBuilder<MDCButtonComponent> _classNameBuilder;

        [Parameter]
        protected MDCButtonType Type { get; set; }
        [Parameter]
        protected MDCButtonStyle Style { get; set; }
        [Parameter]
        protected Action<UIMouseEventArgs> OnClick { get; set; }
        [Parameter]
        protected Action<UIMouseEventArgs> OnMouseUp { get; set; }
        [Parameter]
        protected Action<UIMouseEventArgs> OnMouseDown { get; set; }
        [Parameter]
        protected Action<UIKeyboardEventArgs> OnKeyPress { get; set; }
        [Parameter]
        protected Action<UIKeyboardEventArgs> OnKeyDown { get; set; }
        [Parameter]
        protected Action<UIKeyboardEventArgs> OnKeyUp { get; set; }
        [Parameter]
        protected string Icon { get; set; }
        [Parameter]
        protected bool Disabled { get; set; }
        [Parameter]
        protected bool Dense { get; set; }
        [Parameter]
        protected string HRef { get; set; }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected string ClassString { get; private set; }

        protected ElementRef _MDCButton;
        private bool _isFirstRender = true;

        static MDCButtonComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCButtonComponent>("mdc", "button")
                .DefineClass("dense", c => c.Dense, PrefixSeparators.Modifier)
                .DefineClass((c) => c.Style.ToString().ToLowerInvariant(), (c) => c.Style != MDCButtonStyle.Default, PrefixSeparators.Modifier);
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
                JSRuntime.Current.InvokeAsync<bool>(ADD_RIPPLE_FUNCTION, this._MDCButton);
            }
        }
    }
}
