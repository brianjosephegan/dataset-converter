using Newtonsoft.Json;
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
                if (reader.TokenType == JsonToken.EndObject)
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

            writer.WritePropertyName(nameof(DataSet.Tables));
            writer.WriteStartArray();
            for (var i = 0; i < value.Tables.Count; i++)
            {
                serializer.Serialize(writer, value.Tables[i], typeof(DataTable));
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}