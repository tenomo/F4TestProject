using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace F4TestProject.Infrastructure.JsonConverters
{
    public class TimeFormatConverter : JsonConverter<TimeSpan>
    {
        private const string TimeFormat = @"hh\:mm";


        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();

            if (string.IsNullOrWhiteSpace(stringValue) || !TimeSpan.TryParseExact(stringValue, TimeFormat, null, TimeSpanStyles.None, out var convertedValue))
            {
                throw new JsonException($"The input string doesn't match this format '{ TimeFormat}'");
            }

            return convertedValue;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {

            writer.WriteStringValue(value.ToString(
                TimeFormat, CultureInfo.InvariantCulture));
        }
    }
}
