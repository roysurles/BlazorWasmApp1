namespace BlazorWasmApp1.Shared.Models.Common
{
    public class ContentType : BaseEnumeration
    {
        public static readonly ContentType ApplicationJson = new ContentType(1, "ApplicationJson", "application/json");

        protected ContentType(int value, string displayName, string text) : base(value, displayName) { Text = text; }

        public string Text { get; }
    }
}
