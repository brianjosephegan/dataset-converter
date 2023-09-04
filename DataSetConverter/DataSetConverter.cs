using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataSetConverter : JsonConverter<DataSet>
    {
        public override DataSet? ReadJson(JsonReader reader, Type objectType, DataSet? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, DataSet? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}