using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IPagination
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}