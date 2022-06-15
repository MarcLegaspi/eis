using Core.Enums;

namespace API.Dtos
{
    public class TimeLogDto
    {
        public DateTime Time { get; set; }
        public TimeLogType TimeLogType { get; set; }
    }
}