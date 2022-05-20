using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}