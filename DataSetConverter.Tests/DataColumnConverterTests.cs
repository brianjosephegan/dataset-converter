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
                new PropertyCollectionConverter(),
            }
        };

        public DataColumnConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetCaption()
        {
            _expected.Caption = _fixture.Create<string>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.Caption.Should().Be(_expected.Caption);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetColumnName()
        {
            _expected.ColumnName = _fixture.Create<string>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.ColumnName.Should().Be(_expected.ColumnName);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetAllowDBNull()
        {
            _expected.AllowDBNull = _fixture.Create<bool>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.AllowDBNull.Should().Be(_expected.AllowDBNull);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetAutoIncrement()
        {
            _expected.AutoIncrement = _fixture.Create<bool>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.AutoIncrement.Should().Be(_expected.AutoIncrement);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetAutoIncrementSeed()
        {
            _expected.AutoIncrementSeed = _fixture.Create<long>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.AutoIncrementSeed.Should().Be(_expected.AutoIncrementSeed);
        }

        [Fact]
        public void SerializeDeserialize_Should_SetAutoIncrementStep()
        {
            _expected.AutoIncrementStep = _fixture.Create<long>();

            var actual = _expected.SerializeDeSerialize(_output, _settings);

            actual.AutoIncrementStep.Should().Be(_expected.AutoIncrementStep);
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
