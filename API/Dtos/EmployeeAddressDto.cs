using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeAddressDto
    {
        public string Address1 { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
    }
}