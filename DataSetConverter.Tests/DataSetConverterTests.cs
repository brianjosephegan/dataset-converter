using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using System.Data;
using Xunit.Abstractions;

namespace DataSetConverter.Tests
{
    public class DataSetConverterTests
    {
        private readonly ITestOutputHelper _output;
        private readonly Fixture _fixture = new();
        private readonly DataSetConverter _converter = new();

        public DataSetConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SerializeDeserialize_Should_SetDataSetName()
        {
            var expected = new DataSet(dataSetName: _fixture.Create<string>());

            var json = JsonConvert.SerializeObject(expected, _converter);

            _output.WriteLine($"JSON: {json}");

            var actual = JsonConvert.DeserializeObject<DataSet>(json, _converter);

            actual.DataSetName.Should().Be(expected.DataSetName);
        }
    }
}