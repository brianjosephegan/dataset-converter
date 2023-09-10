using DataSetConverter.Tests.Extensions;

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

            var actual = _expected.SerializeDeserialize(_output, _settings);

            actual.Should().BeEquivalentTo(_expected);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetPropertyCollection()
        {
            _expected.Add(_fixture.Create<string>(), _fixture.Create<string>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<int>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<double>());
            _expected.Add(_fixture.Create<string>(), _fixture.Create<bool>());

            var actual = _expected.SerializeDeserialize(_output, _settings);

            actual.Should().BeEquivalentTo(_expected);
        }
    }
}
