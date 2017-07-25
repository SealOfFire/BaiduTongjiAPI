using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Baidu.Tongji.API.JSON.Report.DataStructure
{
    public class MetricsJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // throw new NotImplementedException();
            return objectType == typeof(Metrics);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // throw new NotImplementedException();
            // writer.WriteValue(Enum.GetName(typeof(Gran), (Gran)value).ToLower());
            // (HashSet<Metrics>)value;
            string[] values = new string[((SortedSet<Metrics>)value).Count];
            int index = 0;
            foreach (Metrics m in ((SortedSet<Metrics>)value))
            {
                switch (m)
                {
                    case Metrics.AVGVisitTime:
                        values[index] = "avg_visit_time";
                        break;
                    case Metrics.BounceRatio:
                        values[index] = "bounce_ratio";
                        break;
                    case Metrics.ContriPageView:
                        values[index] = "contri_pv";
                        break;
                    case Metrics.IPCount:
                        values[index] = "ip_count";
                        break;
                    case Metrics.PageViewCount:
                        values[index] = "pv_count";
                        break;
                    case Metrics.TransCount:
                        values[index] = "trans_count";
                        break;
                    case Metrics.VisitorCount:
                        values[index] = "visitor_count";
                        break;
                }
                index++;
            }
            writer.WriteValue(string.Join(",", values));
        }
    }
}
