using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace API.Dtos
{
    public class EmployeeFormDto
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SuffixName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhilhealthNo { get; set; }
        public string Pagibig { get; set; }
        public string TIN { get; set; }
        public string Sss { get; set; }
        public string Gsis { get; set; }
        public string TelephoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public int PositionId { get; set; }
        public DateTime DateHired { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonCellphoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public ContactPersonRelationshipEnum? ContactPersonRelationship { get; set; }
        public EmployeeAddressDto EmployeeAddress { get;set; }
    }
}