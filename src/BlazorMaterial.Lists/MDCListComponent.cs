using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorMaterial
{
    public class MDCListComponent : BlazorComponent
    {
        private static readonly ClassBuilder<MDCListComponent> _classNameBuilder;
        public bool NonInteractive { get; set; }
        public bool Dense { get; set; }
        public bool AvatarList { get; set; }
        public bool TwoLine { get; set; }

        public RenderFragment ChildContent { get; set; }

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
            this.ClassString = _classNameBuilder.Build(this);
        }
    }
}
