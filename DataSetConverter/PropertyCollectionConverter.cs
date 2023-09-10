using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class PropertyCollectionConverter : JsonConverter<PropertyCollection>
    {
        public override PropertyCollection ReadJson(JsonReader reader, Type objectType, PropertyCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var propertyCollection = new PropertyCollection();

            object key = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    continue;
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    key = reader.Value;
                }
                else
                {
                    propertyCollection.Add(key, reader.Value);
                }
            }

            return propertyCollection;
        }

        public override void WriteJson(JsonWriter writer, PropertyCollection value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            foreach (var key in value.Keys)
            {
                writer.WritePropertyName(key.ToString());
                writer.WriteValue(value[key]);
            }

            writer.WriteEndObject();
        }
    }
}
