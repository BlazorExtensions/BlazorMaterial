using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;

namespace BlazorMaterial.Toolbar
{
    public class MDCToolbarSectionComponent : BlazorComponent
    {
        private static readonly ClassBuilder<MDCToolbarSectionComponent> _classNameBuilder;

        public MDCToolbarSectionAlignment Alignment { get; set; }
        public RenderFragment ChildContent { get; set; }
        public bool ShrinkToFit { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public Action<UIMouseEventArgs> OnIconClick { get; set; }

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
