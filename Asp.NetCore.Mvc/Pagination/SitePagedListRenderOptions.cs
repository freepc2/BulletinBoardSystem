using PagedList.Core.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc.Pagination
{
    public class SitePagedListRenderOptions
    {
        public static PagedListRenderOptions Boostrp
        { 
            get 
            {
                var option = PagedListRenderOptions.Bootstrap4Minimal;
                option.MaximumPageNumbersToDisplay = 5;
                return option;
            }
        }
    }
}
