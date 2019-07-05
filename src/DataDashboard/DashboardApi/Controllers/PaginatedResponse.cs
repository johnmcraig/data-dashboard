using System.Collections.Generic;
using System.Linq;
using DashboardApi.Models;

namespace DashboardApi.Controllers
{
    public class PaginatedResponse<T>
    {
        // private IOrderedQueryable<Order> data;
        // private int pageIndex;
        // private int pageSize;

        public PaginatedResponse(IEnumerable<T> data,  int i, int len)
        {
            Data = data.Skip((i - 1) * len).Take(len).ToList();
            Total = data.Count();
        }

        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }

        // public PaginatedResponse(IOrderedQueryable<Order> data, int pageIndex, int pageSize)
        // {
        //     this.pageIndex = pageIndex;
        //     this.pageSize = pageSize;
        // }
    }
}