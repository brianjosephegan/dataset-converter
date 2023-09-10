using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace DataSetConverter
{
    public class DataSetConverter : JsonConverter<DataSet>
    {
        public override DataSet ReadJson(JsonReader reader, Type objectType, DataSet existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataSet = new DataSet();

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

                if (reader.Path == nameof(DataSet.DataSetName))
                {
                    dataSet.DataSetName = reader.ReadAsString();
                }
                else if (reader.Path == nameof(DataSet.Namespace))
                {
                    dataSet.Namespace = reader.ReadAsString();
                }
                else if (reader.Path == nameof(DataSet.ExtendedProperties))
                {
                    var extendedProperties = serializer.Deserialize<PropertyCollection>(reader);
                    foreach (DictionaryEntry extendedProperty in extendedProperties)
                    {
                        dataSet.ExtendedProperties.Add(extendedProperty.Key, extendedProperty.Value);
                    }
                }
            }

            return dataSet;
        }

        public override void WriteJson(JsonWriter writer, DataSet value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(DataSet.DataSetName));
            writer.WriteValue(value.DataSetName);

            writer.WritePropertyName(nameof(DataSet.Namespace));
            writer.WriteValue(value.Namespace);

            writer.WritePropertyName(nameof(DataSet.ExtendedProperties));
            serializer.Serialize(writer, value.ExtendedProperties, typeof(PropertyCollection));

            writer.WriteEndObject();
        }
    }
}