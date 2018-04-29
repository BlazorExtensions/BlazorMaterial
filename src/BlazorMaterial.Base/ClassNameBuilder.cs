using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMaterial
{
    public class ClassBuilder<T> where T : BlazorComponent
    {
        private const char ClassNameSeparator = ' ';

        private const string DashSeparator = "-";
        // BEM Specific separators
        private const string ElementSeparator = "__";
        private const string ModifierSeparator = "--";

        private readonly StringBuilder builder = new StringBuilder(100);
        private readonly string _classNamePrefix = string.Empty;
        private readonly IList<(string Name, Func<T, string> ValueAccessor, Func<T, bool> Predicate, string PrefixSeparator)> classDefinitions = new List<(string, Func<T, string>, Func<T, bool>, string)>();

        public ClassBuilder(string componentLibraryPrefix = default, string componentPrefix = default)
        {
            this._classNamePrefix = componentLibraryPrefix;

            if (!string.IsNullOrWhiteSpace(componentPrefix))
            {
                if (!string.IsNullOrWhiteSpace(this._classNamePrefix))
                {
                    this._classNamePrefix += $"{DashSeparator}{componentPrefix}";
                }
                else
                {
                    this._classNamePrefix = componentLibraryPrefix;
                }
            }
        }

        public string Build(T component, bool addClassNamePrefix = true)
        {
            if (this.classDefinitions.Count == 0)
            {
                return string.Empty;
            }

            this.builder.Clear();

            if (addClassNamePrefix)
            {
                this.builder.Append($"{this._classNamePrefix}{ClassNameSeparator}");
            }

            foreach (var classDefinition in this.classDefinitions)
            {
                if (classDefinition.Predicate == null || (classDefinition.Predicate != null && classDefinition.Predicate(component)))
                {
                    if (classDefinition.ValueAccessor == null)
                    {
                        this.builder.Append(classDefinition.Name);
                    }
                    else
                    {
                        this.builder.Append($"{classDefinition.Name}{DashSeparator}{classDefinition.ValueAccessor(component)}{ClassNameSeparator}");
                    }
                }
            }

            return this.builder.ToString();
        }

        public ClassBuilder<T> DefineClass(Func<T, string> valueAccessor, Func<T, bool> predicate = default, PrefixSeparators prefixSeparator = PrefixSeparators.Dash)
        {
            if (valueAccessor == null)
            {
                throw new ArgumentNullException(nameof(valueAccessor));
            }

            this.classDefinitions.Add((this._classNamePrefix, valueAccessor, predicate, GetPrefixSeparator(prefixSeparator)));

            return this;
        }

        public ClassBuilder<T> DefineClass(string value, Func<T, bool> predicate = default, PrefixSeparators prefixSeparator = PrefixSeparators.Dash)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            //
            // Add class separator here, since this definition has no dynamic parts.
            //

            this.classDefinitions.Add(($"{this._classNamePrefix}{GetPrefixSeparator(prefixSeparator)}{value}{ClassNameSeparator}", default, predicate, string.Empty));

            return this;
        }

        private string GetPrefixSeparator(PrefixSeparators prefix)
        {
            switch (prefix)
            {
                case PrefixSeparators.Element:
                    return ElementSeparator;
                case PrefixSeparators.Modifier:
                    return ModifierSeparator;
                default:
                    // Dash is the default
                    return DashSeparator;
            }
        }
    }

    public enum PrefixSeparators
    {
        Dash,
        Element,
        Modifier
    }
}


//private static ClassBuilder = new ClassNamesBuilder()
//                    .WithClassPrefix(this.PrefixCls)
//                    .AddPrefix(BUTTON_CLASS)
//                    .AddPropertyPart((c) => c.GetTypeClass())
//                    .AddPropertyPart((c) => c.GetShapeClass(), (c) => c.Shape != ButtonShape.Undefined)
//                    .Build();