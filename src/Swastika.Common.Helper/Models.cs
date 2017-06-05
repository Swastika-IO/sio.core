using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Common.Helper
{
    public class PaginationModel<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalItems { get; set; }

        public PaginationModel()
        {
            PageIndex = 0;
            PageSize = 0;
            TotalItems = 0;
            TotalPage = 1;
            Items = new List<T>();
        }
    }
}
