namespace DataSetConverter.Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static T SerializeDeserialize<T>(this T t, ITestOutputHelper output, JsonSerializerSettings settings)
        {
            var json = JsonConvert.SerializeObject(t, settings);
            output.WriteLine($"JSON: {json}");
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
