using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;

namespace BlazorMaterial
{
    public class MDCToolbarSectionComponent : BlazorMaterialComponent
    {
        private static readonly ClassBuilder<MDCToolbarSectionComponent> _classNameBuilder;

        [Parameter]
        protected MDCToolbarSectionAlignment Alignment { get; set; }
        [Parameter]
        protected RenderFragment ChildContent { get; set; }
        [Parameter]
        protected bool ShrinkToFit { get; set; }
        [Parameter]
        protected string Icon { get; set; }
        [Parameter]
        protected string Title { get; set; }
        [Parameter]
        protected Action<UIMouseEventArgs> OnIconClick { get; set; }

        protected string ClassString { get; set; }

        static MDCToolbarSectionComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCToolbarSectionComponent>("mdc", "toolbar__section")
                .DefineClass("shrink-to-fit", c => c.ShrinkToFit, PrefixSeparators.Modifier)
                .DefineClass("align-start", c => c.Alignment == MDCToolbarSectionAlignment.Start, PrefixSeparators.Modifier)
                .DefineClass("align-end", c => c.Alignment == MDCToolbarSectionAlignment.End, PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this);
        }
    }
}
