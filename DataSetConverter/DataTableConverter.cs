using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataTableConverter : JsonConverter<DataTable>
    {
        public override DataTable? ReadJson(JsonReader reader, Type objectType, DataTable? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataTable = new DataTable();

            do
            {
                System.Diagnostics.Debug.WriteLine(reader.Path);

                if (reader.Path == nameof(DataTable.TableName))
                {
                    dataTable.TableName = reader.ReadAsString();
                }
                else if (reader.Path == nameof(DataTable.Namespace))
                {
                    dataTable.Namespace = reader.ReadAsString();
                }
            } while (reader.Read());

            return dataTable;
        }

        public override void WriteJson(JsonWriter writer, DataTable? value, JsonSerializer serializer)
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
