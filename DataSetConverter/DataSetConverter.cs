using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataSetConverter : JsonConverter<DataSet>
    {
        public override DataSet? ReadJson(JsonReader reader, Type objectType, DataSet? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataSet = new DataSet();

            do
            {
                if (reader.Path == nameof(DataSet.DataSetName))
                {
                    dataSet.DataSetName = reader.ReadAsString();
                }
            } while (reader.Read());

            return dataSet;
        }

        public override void WriteJson(JsonWriter writer, DataSet? value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(DataSet.DataSetName));
            writer.WriteValue(value.DataSetName);

            writer.WriteEndObject();
        }
    }
}