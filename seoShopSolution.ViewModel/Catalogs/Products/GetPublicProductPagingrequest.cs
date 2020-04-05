using seoShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace seoShopSolution.ViewModel.Catalogs.Products
{
    public class GetPublicProductPagingrequest: PagingRequsetBase
    {
        public int? CategoryId { get; set; }
    }
}
