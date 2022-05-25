using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;

namespace API.Dtos
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public LeaveRequestTypeEnum LeaveRequestType { get; set; }
        public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        // public int? ApprovedByUserId  { get;set; }
        // public DateTime? ApprovedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }

    public class LeaveRequestSaveDto
    {
        public int EmployeeId { get; set; }
        public LeaveRequestTypeEnum LeaveRequestType { get; set; }
        //public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        // public int? ApprovedByUserId  { get;set; }
        // public DateTime? ApprovedDate { get; set; }
        public string Notes { get; set; }
    }
}