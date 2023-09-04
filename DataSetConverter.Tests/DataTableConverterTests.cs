namespace DataSetConverter.Tests
{
    public class DataTableConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DataTable _expected = new();
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new List<JsonConverter>()
            {
                new DataTableConverter(),
            }
        };

        public DataTableConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetTableName()
        {
            _expected.TableName = _fixture.Create<string>();

            var actual = SerializeRoundTrip(_expected);

            actual.TableName.Should().Be(_expected.TableName);
        }

        private DataTable SerializeRoundTrip(DataTable dataTable)
        {
            var json = JsonConvert.SerializeObject(dataTable, _settings);
            _output.WriteLine($"JSON: {json}");
            return JsonConvert.DeserializeObject<DataTable>(json, _settings);
        }
    }
}
