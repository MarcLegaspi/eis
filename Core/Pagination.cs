namespace Core
{
    public class Pagination// where T: class
    {
        private int currentPageIndex = 1;
        private int maxPageSize = 10;
        public int PageIndex
        {
            get
            {
                return currentPageIndex;
            }
            set
            {
                if (value > 1)
                {
                    currentPageIndex = value;
                }
            }
        }
        public int PageSize
        {
            get
            {
                return maxPageSize;
            }
            set
            {
                if (value > 1)
                {
                    maxPageSize = value;
                }
            }
        }
        public int Count { get; set; }
        //   public IReadOnlyList<T> Data { get; set; }
    }
}