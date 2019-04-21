using Microsoft.AspNetCore.Components;

namespace BlazorMaterial
{
    public class MDCListComponent : BlazorMaterialComponent
    {
        private static readonly ClassBuilder<MDCListComponent> _classNameBuilder;
        [Parameter]
        protected bool NonInteractive { get; set; }
        [Parameter]
        protected bool Dense { get; set; }
        [Parameter]
        protected bool AvatarList { get; set; }
        [Parameter]
        protected bool TwoLine { get; set; }
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected string ClassString { get; private set; }

        static MDCListComponent()
        {
            _classNameBuilder = new ClassBuilder<MDCListComponent>("mdc", "list")
                .DefineClass("non-interactive", c => c.NonInteractive, PrefixSeparators.Modifier)
                .DefineClass("dense", c => c.Dense, PrefixSeparators.Modifier)
                .DefineClass("avatar-list", c => c.AvatarList, PrefixSeparators.Modifier)
                .DefineClass("two-line", c => c.TwoLine, PrefixSeparators.Modifier);
        }

        protected override void OnInit()
        {
            this.ClassString = _classNameBuilder.Build(this, this.Class);
        }
    }
}
