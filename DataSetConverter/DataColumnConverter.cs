using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataColumnConverter : JsonConverter<DataColumn>
    {
        public override DataColumn ReadJson(JsonReader reader, Type objectType, DataColumn existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataColumn = new DataColumn();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.Path == nameof(DataColumn.ColumnName))
                {
                    dataColumn.ColumnName = reader.ReadAsString();
                }
            }

            return dataColumn;
        }

        public override void WriteJson(JsonWriter writer, DataColumn value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(DataColumn.ColumnName));
            writer.WriteValue(value.ColumnName);

            writer.WriteEndObject();
        }
    }
}
