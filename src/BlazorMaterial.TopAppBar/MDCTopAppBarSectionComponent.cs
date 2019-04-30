using Microsoft.AspNetCore.Components;
using System;

namespace BlazorMaterial
{
    public class MDCTopAppBarSectionComponent : BlazorMaterialComponent
    {
        private static readonly ClassBuilder<MDCTopAppBarSectionComponent> _classNameBuilder;

        [Parameter]
        protected MDCTopAppBarSectionAlignment Alignment { get; set; }
        [Parameter]
        protected RenderFragment ChildContent { get; set; }
        [Parameter]
        protected bool ShrinkToFit { get; set; }
        [Parameter]
        protected string Icon { get; set; }
        [Parameter]
        protected string Title { get; set; }
        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnIconClick { get; set; }

        protected string ClassString { get; set; }

        static MDCTopAppBarSectionComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCTopAppBarSectionComponent>("mdc", "top-app-bar__section")
                .DefineClass("shrink-to-fit", c => c.ShrinkToFit, PrefixSeparators.Modifier)
                .DefineClass(c => $"align-{c.Alignment.ToString().ToLowerInvariant()}", PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this, this.Class);
        }
    }
}
