namespace DataSetConverter.Tests
{
    public class PropertyCollectionConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PropertyCollection _expected = new();
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new List<JsonConverter>()
            {
                new PropertyCollectionConverter(),
            }
        };

        public PropertyCollectionConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetPropertyCollection_When_Empty()
        {
            _expected.Clear();

            var actual = SerializeRoundTrip(_expected);

            actual.Should().BeEquivalentTo(_expected);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetPropertyCollection()
        {
            _expected.Add(_fixture.Create<string>(), _fixture.Create<string>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<int>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<double>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<bool>());

            var actual = SerializeRoundTrip(_expected);

            actual.Should().BeEquivalentTo(_expected);
        }

        private PropertyCollection SerializeRoundTrip(PropertyCollection propertyCollection)
        {
            var json = JsonConvert.SerializeObject(propertyCollection, _settings);
            _output.WriteLine($"JSON: {json}");
            return JsonConvert.DeserializeObject<PropertyCollection>(json, _settings);
        }
    }
}
