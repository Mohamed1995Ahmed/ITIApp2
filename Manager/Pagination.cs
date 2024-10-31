using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Pagination<T>
    {
        public int PageNumber { set; get; }
        public int TotalCount { set; get; }
        public int PageSize { set; get; }
        public T DAta { set; get; }
    }
}
