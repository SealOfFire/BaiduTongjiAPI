using System;
using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.DataStructure
{
    public class EnumJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // throw new NotImplementedException();
            return objectType == typeof(Enum);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // throw new NotImplementedException();
            if (value is Gran)
                writer.WriteValue(Enum.GetName(typeof(Gran), value).ToLower());
            if (value is Visitor)
                writer.WriteValue(Enum.GetName(typeof(Visitor), value).ToLower());
        }
    }
}
