using Microsoft.AspNetCore.Components;

namespace BlazorMaterial
{
    public class MDCListDividerComponent : BlazorMaterialComponent
    {
        private static readonly ClassBuilder<MDCListDividerComponent> _classNameBuilder;

        [Parameter]
        protected bool Padded { get; set; }
        [Parameter]
        protected bool Inset { get; set; }

        protected string ClassString { get; private set; }

        static MDCListDividerComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCListDividerComponent>("mdc", "list-divider")
                .DefineClass("padded", c => c.Padded, PrefixSeparators.Modifier)
                .DefineClass("inset", (c) => c.Inset, PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this, this.Class);
        }
    }
}
