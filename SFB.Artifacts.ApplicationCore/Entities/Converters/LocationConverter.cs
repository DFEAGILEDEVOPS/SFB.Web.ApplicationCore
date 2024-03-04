using System;
using Newtonsoft.Json;

namespace SFB.Web.ApplicationCore.Entities.Converters
{
    public class LocationConverter : JsonConverter<LocationDataObject>
    {
        public override void WriteJson(
            JsonWriter writer,
            LocationDataObject value,
            JsonSerializer serializer)
        {
            // default
            serializer.Serialize(writer, value);
        }

        public override LocationDataObject ReadJson(
            JsonReader reader,
            Type objectType,
            LocationDataObject existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    // some GIAS data may be double-encoded Location JSON, so attempt to parse as a string if so
                    return JsonConvert.DeserializeObject<LocationDataObject>((string)reader.Value ?? string.Empty);
                case JsonToken.StartObject:
                    // otherwise, attempt to deserialize as JSON as per the default JsonConverter
                    return serializer.Deserialize<LocationDataObject>(reader);
                default:
                    return null;
            }
        }
    }
}