namespace DataSetConverter.Tests
{
    internal class DataColumnConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DataColumn _expected = new();
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new List<JsonConverter>()
            {
                new DataTableConverter(),
            }
        };

        public DataColumnConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private DataTable SerializeRoundTrip(DataTable dataTable)
        {
            var json = JsonConvert.SerializeObject(dataTable, _settings);
            _output.WriteLine($"JSON: {json}");
            return JsonConvert.DeserializeObject<DataTable>(json, _settings);
        }
    }
}
