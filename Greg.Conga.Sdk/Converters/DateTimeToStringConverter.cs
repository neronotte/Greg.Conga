using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Greg.Conga.Sdk.Converters
{
	internal class DateTimeToStringConverter : JsonConverter
	{
		public DateTimeToStringConverter(string format)
		{
			Format = format;
		}

		public string Format { get; }



		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var stringValue = reader.ReadAsString();
			if (stringValue == null && objectType == typeof(DateTime?)) 
				return null;

			if (stringValue == null && objectType == typeof(DateTime)) 
				return default(DateTime);

			if (DateTime.TryParseExact(stringValue, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
				return result;

			if (objectType == typeof(DateTime?))
				return null;

			if (objectType == typeof(DateTime))
				return default(DateTime);

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is DateTime dateTime)
				writer.WriteRawValue("\"" + dateTime.ToString(Format, CultureInfo.InvariantCulture) + "\"");
			else
				writer.WriteNull();
		}
	}
}
