namespace Core.Entities
{
    public class LeaveRequest: BaseEntity
    {        
        public int EmployeeId { get; set; }
        public int LeveRequestTypeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Notes { get; set; }
    }
}