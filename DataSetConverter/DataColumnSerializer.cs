using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter
{
    public class DataColumnSerializer : JsonConverter<DataColumn>
    {
        public override DataColumn ReadJson(JsonReader reader, Type objectType, DataColumn existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, DataColumn value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
