using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace F4TestProject.Infrastructure.JsonConverters
{
    public class DateFormatConverter : JsonConverter<DateTime>
    {
        private const string DataFormat = "dd-MM-yyyy hh:mm";


        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();

            if (string.IsNullOrWhiteSpace(stringValue) || !DateTime.TryParseExact(stringValue, DataFormat, null, DateTimeStyles.None, out var convertedValue))
            {
                throw new JsonException($"The input string doesn't match this format '{ DataFormat}'");
            }

            return convertedValue;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {

            writer.WriteStringValue(value.ToString(
                 DataFormat, CultureInfo.InvariantCulture));
        }
    }
}
