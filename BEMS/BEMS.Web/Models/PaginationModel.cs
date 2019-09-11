using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEMS.Web.Models
{
    public class PaginationModel
    {
        public int TotalPages { get; set; }
        public int NewPage { get; set; }
        public int PageSize { get { return 20; } }
    }
}
