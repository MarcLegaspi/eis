namespace Core
{
    public class Pagination// where T: class
    {
        private int currentPageIndex = 1;
        private int _pageSize;
        const int MAX_PAGESIZE = 10;


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
                return _pageSize;
            }
            set
            {
                if (value > 1)
                {
                    _pageSize = value > MAX_PAGESIZE ? MAX_PAGESIZE: value;
                }
            }
        }
    }
}