using Newtonsoft.Json;

namespace DataSetConverter.Extensions
{
    public static class JsonReaderExtensions
    {
        public static long ReadAsLong(this JsonReader jsonReader)
        {
            return long.Parse(jsonReader.ReadAsString());
        }

        public static async Task<long> ReadAsLongAsync(this JsonReader jsonReader)
        {
            return long.Parse(await jsonReader.ReadAsStringAsync());
        }
    }
}
