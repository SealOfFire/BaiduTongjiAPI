using System;
using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.DataStructure
{
    public class GranJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // throw new NotImplementedException();
            return objectType == typeof(Gran);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // throw new NotImplementedException();
            writer.WriteValue(Enum.GetName(typeof(Gran), (Gran)value).ToLower());
        }
    }
}
