using DataSetConverter.Tests.Extensions;

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

            var actual = _expected.SerializeDeserialize(_output, _settings);

            actual.TableName.Should().Be(_expected.TableName);
        }

        [Fact]
        public void SerializeDeSerialize_Should_SetNamespace()
        {
            _expected.Namespace = _fixture.Create<string>();

            var actual = _expected.SerializeDeserialize(_output, _settings);

            actual.Namespace.Should().Be(_expected.Namespace);
        }
    }
}
