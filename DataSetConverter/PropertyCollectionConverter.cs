using Newtonsoft.Json;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace DataSetConverter
{
    public class PropertyCollectionConverter : JsonConverter<PropertyCollection>
    {
        public override PropertyCollection ReadJson(JsonReader reader, Type objectType, PropertyCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var propertyCollection = new PropertyCollection();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                var key = reader.Value;
                reader.Read();
                propertyCollection.Add(key, reader.Value);
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
