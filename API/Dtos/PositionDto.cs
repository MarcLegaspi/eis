using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public string Department { get; set; }
    }
}