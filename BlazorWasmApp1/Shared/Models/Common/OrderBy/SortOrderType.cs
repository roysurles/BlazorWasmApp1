namespace BlazorWasmApp1.Shared.Models.Common.OrderBy
{
    public class SortOrderType : BaseEnumeration
    {
        public static readonly SortOrderType None = new SortOrderType(0, "None");

        public static readonly SortOrderType Ascending = new SortOrderType(1, "Ascending");

        public static readonly SortOrderType Descending = new SortOrderType(2, "Descending");

        protected SortOrderType(int value, string displayName) : base(value, displayName) { }
    }
}
