using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorWasmApp1.Shared.Models.Common.Enumeration
{
    public class EnumerationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => (objectType == typeof(EnumerationJsonConverter));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string jsonValue = JToken.Load(reader).ToString();
            var enumClass = existingValue as IEnumerationJson;
            return enumClass.ReadJson(jsonValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumClass = value as IEnumerationJson;
            JToken.FromObject(enumClass.WriteJson()).WriteTo(writer);
        }
    }
}
