namespace BlazorWasmApp1.Shared.Models.Common.ApiResult
{
    public class ApiResultMessageType : BaseEnumeration
    {
        public static readonly ApiResultMessageType Information = new ApiResultMessageType(1, "Information");

        public static readonly ApiResultMessageType Warning = new ApiResultMessageType(2, "Warning");

        public static readonly ApiResultMessageType Error = new ApiResultMessageType(3, "Error");

        public static readonly ApiResultMessageType UnhandledException = new ApiResultMessageType(4, "UnhandledException");

        public static readonly ApiResultMessageType Hidden = new ApiResultMessageType(5, "Hidden");

        public static readonly ApiResultMessageType Deprecated = new ApiResultMessageType(6, "Deprecated");

        protected ApiResultMessageType(int value, string displayName) : base(value, displayName) { }
    }
}
