using DataDashboard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataDashboard.Core.RequestFeatures
{
    public class PagedResults<T> where T : BaseEntity
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
