using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAsp.ViewModels
{
    public class PaginatedResultViewModel<T>
    {
        public List<T> results;
        public int page;
        public int pages;
        public int pageSize;
    }
}