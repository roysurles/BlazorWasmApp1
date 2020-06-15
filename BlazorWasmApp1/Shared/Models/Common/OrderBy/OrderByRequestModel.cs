using System;

using Newtonsoft.Json;

namespace BlazorWasmApp1.Shared.Models.Common.OrderBy
{
    /// <summary>
    /// Represents a generic item to sort by.
    /// </summary>
    /// <typeparam name="T">Desired Type</typeparam>
    [Serializable]
    public class OrderByRequestModel<T>
    {
        /// <summary>
        /// Generic Item
        /// </summary>
        [JsonProperty("item")]
        public T Item { get; set; }

        /// <summary>
        /// SortOrder Enumeration
        /// </summary>
        [JsonProperty("sortOrderType")]
        public SortOrderEnum SortOrder { get; set; }
    }
}
