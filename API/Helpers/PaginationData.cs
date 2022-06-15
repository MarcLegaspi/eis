using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;

namespace API.Helpers
{
    public class PaginationData<T>//: IPagination where T: class
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}