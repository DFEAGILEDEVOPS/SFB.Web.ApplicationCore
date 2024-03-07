using System;
using Newtonsoft.Json;

namespace SFB.Web.ApplicationCore.Entities.Converters
{
    public class Int32JsonConverter: JsonConverter<int?>
    {
        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer)
        {
            // default
            serializer.Serialize(writer, value);
        }

        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            
            return Convert.ToInt32(reader.Value?.ToString());
        }
    }
}