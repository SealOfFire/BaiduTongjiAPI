using Newtonsoft.Json.Converters;

namespace Baidu.Tongji.API.JSON.Report.DataStructure
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
