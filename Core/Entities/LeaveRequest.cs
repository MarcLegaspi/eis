using Core.Enums;

namespace Core.Entities
{
    public class LeaveRequest: BaseEntity
    {        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        //public int LeaveRequestTypeId { get; set; }
        public LeaveRequestTypeEnum LeaveRequestType { get; set; }
        public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        // public int? ApprovedByUserId  { get;set; }
        // public DateTime? ApprovedDate { get; set; }
        public string Notes { get; set; }
    }
}