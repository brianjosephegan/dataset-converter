using DataSetConverter.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace DataSetConverter
{
    public class DataColumnConverter : JsonConverter<DataColumn>
    {
        public override DataColumn ReadJson(JsonReader reader, Type objectType, DataColumn existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataColumn = new DataColumn();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.Path == nameof(DataColumn.ColumnName))
                {
                    dataColumn.ColumnName = reader.ReadAsString();
                }
                else if (reader.Path == nameof(DataColumn.AllowDBNull))
                {
                    dataColumn.AllowDBNull = reader.ReadAsBoolean().GetValueOrDefault();
                }
                else if (reader.Path == nameof(DataColumn.AutoIncrement))
                {
                    dataColumn.AutoIncrement = reader.ReadAsBoolean().GetValueOrDefault();
                }
                else if (reader.Path == nameof(DataColumn.AutoIncrementSeed))
                {
                    dataColumn.AutoIncrementSeed = reader.ReadAsLong();
                }
                else if (reader.Path == nameof(DataColumn.AutoIncrementStep))
                {
                    dataColumn.AutoIncrementStep = reader.ReadAsLong();
                }
                else if (reader.Path == nameof(DataColumn.ExtendedProperties))
                {
                    var extendedProperties = serializer.Deserialize<PropertyCollection>(reader);
                    foreach (DictionaryEntry extendedProperty in extendedProperties)
                    {
                        dataColumn.ExtendedProperties.Add(extendedProperty.Key, extendedProperty.Value);
                    }
                }
            }

            return dataColumn;
        }

        public override void WriteJson(JsonWriter writer, DataColumn value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(DataColumn.ColumnName));
            writer.WriteValue(value.ColumnName);

            writer.WritePropertyName(nameof(DataColumn.AllowDBNull));
            writer.WriteValue(value.AllowDBNull);

            writer.WritePropertyName(nameof(DataColumn.AutoIncrement));
            writer.WriteValue(value.AutoIncrement);

            writer.WritePropertyName(nameof(DataColumn.AutoIncrementSeed));
            writer.WriteValue(value.AutoIncrementSeed);

            writer.WritePropertyName(nameof(DataColumn.AutoIncrementStep));
            writer.WriteValue(value.AutoIncrementStep);

            writer.WritePropertyName(nameof(DataColumn.ExtendedProperties));
            serializer.Serialize(writer, value.ExtendedProperties, typeof(PropertyCollection));

            writer.WriteEndObject();
        }
    }
}
