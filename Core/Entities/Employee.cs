using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SuffixName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        public string PhilhealthNo { get; set; }
        public string TIN { get; set; }
        public string Gsis { get; set; }
        public string TelephoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime? DateHired { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public EmployeeAddress EmployeeAddress { get; set; }
    }
}