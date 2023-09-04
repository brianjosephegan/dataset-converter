using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using System.Data;

namespace DataSetConverter.Tests
{
    public class DataSetConverterTests
    {
        private readonly Fixture _fixture = new();
        private readonly DataSetConverter _converter = new();

        [Fact]
        public void SerializeDeserialize_Should_SetDataSetName()
        {
            var expected = new DataSet(dataSetName: _fixture.Create<string>());

            var actual = JsonConvert.DeserializeObject<DataSet>(
                JsonConvert.SerializeObject(expected, _converter),
                _converter);

            actual.DataSetName.Should().Be(expected.DataSetName);
        }
    }
}