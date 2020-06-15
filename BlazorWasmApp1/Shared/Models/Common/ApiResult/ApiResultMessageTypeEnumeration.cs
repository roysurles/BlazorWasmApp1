using BlazorWasmApp1.Shared.Models.Common.Enumeration;

namespace BlazorWasmApp1.Shared.Models.Common.ApiResult
{
    public class ApiResultMessageTypeEnumeration : BaseEnumeration<int>
    {
        public static readonly ApiResultMessageTypeEnumeration Information = new ApiResultMessageTypeEnumeration(1, "Information");

        public static readonly ApiResultMessageTypeEnumeration Warning = new ApiResultMessageTypeEnumeration(2, "Warning");

        public static readonly ApiResultMessageTypeEnumeration Error = new ApiResultMessageTypeEnumeration(3, "Error");

        public static readonly ApiResultMessageTypeEnumeration UnhandledException = new ApiResultMessageTypeEnumeration(4, "UnhandledException");

        public static readonly ApiResultMessageTypeEnumeration Hidden = new ApiResultMessageTypeEnumeration(5, "Hidden");

        public static readonly ApiResultMessageTypeEnumeration Deprecated = new ApiResultMessageTypeEnumeration(6, "Deprecated");

        public ApiResultMessageTypeEnumeration() { }

        protected ApiResultMessageTypeEnumeration(int value, string displayName) : base(value, displayName) { }
    }
}
