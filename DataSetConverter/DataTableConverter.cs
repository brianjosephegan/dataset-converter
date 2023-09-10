using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataTableConverter : JsonConverter<DataTable>
    {
        public override DataTable ReadJson(JsonReader reader, Type objectType, DataTable existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataTable = new DataTable();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.Path == nameof(DataTable.TableName))
                {
                    dataTable.TableName = reader.ReadAsString();
                }
                else if (reader.Path == nameof(DataTable.Namespace))
                {
                    dataTable.Namespace = reader.ReadAsString();
                }
            }

            return dataTable;
        }

        public override void WriteJson(JsonWriter writer, DataTable value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(DataTable.TableName));
            writer.WriteValue(value.TableName);

            writer.WritePropertyName(nameof(DataTable.Namespace));
            writer.WriteValue(value.Namespace);

            writer.WriteEndObject();
        }
    }
}
