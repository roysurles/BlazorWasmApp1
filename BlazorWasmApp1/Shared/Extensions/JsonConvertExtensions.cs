
using Newtonsoft.Json;

namespace BlazorWasmApp1.Shared.Extensions
{
    public static class JsonConvertExtensions
    {
        public static string Serialize(this object obj) =>
            JsonConvert.SerializeObject(obj);

        public static T Deserialize<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json);
    }
}
