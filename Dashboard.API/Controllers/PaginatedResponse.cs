using System.Linq;
using Dashboard.API.Models;

namespace Dashboard.API.Controllers
{
    internal class PaginatedResponse<T>
    {
        private IOrderedQueryable<Order> data;
        private int pageIndex;
        private int pageSize;

        public PaginatedResponse(IOrderedQueryable<Order> data, int pageIndex, int pageSize)
        {
            this.data = data;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }
    }
}