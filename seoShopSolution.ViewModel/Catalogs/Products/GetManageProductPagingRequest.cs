using seoShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace seoShopSolution.ViewModel.Catalogs.Products
{
    public class GetManageProductPagingRequest : PagingRequsetBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
