using Core.Enums;

namespace Core.Entities
{
    public class Attendance: BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime Time { get; set; }    
        public TimeLogType TimeLogType { get; set; }
    }
}