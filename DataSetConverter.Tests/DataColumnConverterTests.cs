using DataSetConverter.Tests.Extensions;

namespace DataSetConverter.Tests
{
    public class DataColumnConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DataColumn _expected = new();
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerSettings _settings = new()
        {
            Converters = new List<JsonConverter>()
            {
                new DataColumnConverter(),
            }
        };

        public DataColumnConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetColumnName()
        {
            _expected.ColumnName = _fixture.Create<string>();

            var actual = _expected.SerializeDeserialize(_output, _settings);

            actual.ColumnName.Should().Be(_expected.ColumnName);
        }
    }
}
