namespace DataSetConverter.Tests
{
    public class DataSetConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DataSet _expected = new();
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new List<JsonConverter>()
            {
                new DataSetConverter(),
            }
        };

        public DataSetConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetDataSetName()
        {
            _expected.DataSetName = _fixture.Create<string>();

            var actual = SerializeRoundTrip(_expected);

            actual.DataSetName.Should().Be(_expected.DataSetName);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetNamespace()
        {
            _expected.Namespace = _fixture.Create<string>();

            var actual = SerializeRoundTrip(_expected);

            actual.Namespace.Should().Be(_expected.Namespace);
        }

        private DataSet SerializeRoundTrip(DataSet dataSet)
        {
            var json = JsonConvert.SerializeObject(dataSet, _settings);
            _output.WriteLine($"JSON: {json}");
            return JsonConvert.DeserializeObject<DataSet>(json, _settings);
        }
    }
}