using DataSetConverter.Tests.Extensions;

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
                new PropertyCollectionConverter(),
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

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.DataSetName.Should().Be(_expected.DataSetName);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetNamespace()
        {
            _expected.Namespace = _fixture.Create<string>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.Namespace.Should().Be(_expected.Namespace);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetExtendedProperties()
        {
            _expected.ExtendedProperties.Add(_fixture.Create<string>(), _fixture.Create<string>());
            _expected.ExtendedProperties.Add(_fixture.Create<string>(), _fixture.Create<int>());
            _expected.ExtendedProperties.Add(_fixture.Create<string>(), _fixture.Create<double>());
            _expected.ExtendedProperties.Add(_fixture.Create<string>(), _fixture.Create<bool>());

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.ExtendedProperties.Should().BeEquivalentTo(_expected.ExtendedProperties);
        }
    }
}