using seoShopSolution.ViewModel.Catalogs.Products;
using seoShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace seoShopSolution.Application.Catalogs.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingrequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
