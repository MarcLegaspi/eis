namespace Core.Entities
{
    public class Attendance: BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime TimeIn { get; set; }    
        public DateTime TimeOut { get; set; }
    }
}