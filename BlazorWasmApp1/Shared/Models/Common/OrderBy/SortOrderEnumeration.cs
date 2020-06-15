using BlazorWasmApp1.Shared.Models.Common.Enumeration;

namespace BlazorWasmApp1.Shared.Models.Common.OrderBy
{
    public class SortOrderEnumeration : BaseEnumeration<int>
    {
        public static readonly SortOrderEnumeration None = new SortOrderEnumeration(0, "None");

        public static readonly SortOrderEnumeration Ascending = new SortOrderEnumeration(1, "Ascending");

        public static readonly SortOrderEnumeration Descending = new SortOrderEnumeration(2, "Descending");

        public SortOrderEnumeration() { }

        protected SortOrderEnumeration(int value, string displayName) : base(value, displayName) { }
    }
}
