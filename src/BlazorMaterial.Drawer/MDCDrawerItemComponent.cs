using Microsoft.AspNetCore.Components;

namespace BlazorMaterial
{
    public class MDCDrawerItemComponent : BlazorMaterialComponent
    {
        private static readonly ClassBuilder<MDCDrawerItemComponent> _classNameBuilder;

        [Parameter]
        protected string HRef { get; set; }
        [Parameter]
        protected string Icon { get; set; }
        [Parameter]
        protected string Width { get; set; }
        [Parameter]
        protected string Height { get; set; }
        [Parameter]
        protected string Text { get; set; }
        [Parameter]
        protected bool Activated { get; set; }

        protected string ClassString { get; set; }

        static MDCDrawerItemComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCDrawerItemComponent>("mdc", "list-item")
                .DefineClass("activated", c => c.Activated, PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this, this.Class);
        }
    }
}
