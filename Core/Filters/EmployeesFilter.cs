using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Filters
{
    public class EmployeesFilter//: IPagination
    {
        public string Search { get; set; }
        public int? DepartmentId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}