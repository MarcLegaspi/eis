using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SuffixName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhilhealthNo { get; set; }
        public string TIN { get; set; }
        public string Gsis { get; set; }
        public string TelephoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EmployeeAddress EmployeeAddress { get;set; }
    }
}