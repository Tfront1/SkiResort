using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts;

public class PaginationSortingRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "Id";
    public bool Ascending { get; set; } = true;
}
