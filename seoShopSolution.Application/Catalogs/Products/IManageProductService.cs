﻿using seoShopSolution.ViewModel.Catalogs.ProductImage;
using seoShopSolution.ViewModel.Catalogs.Products;
using seoShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace seoShopSolution.Application.Catalogs.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<int> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<ProductViewModel> GetById(int productId, string languageId);

        //manager image
        Task<int> AddImages(int productId, ProductImageCreateRequest productImage);

        Task<int> RemoveImages(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest productImage);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
        Task<ProductImageViewModel> GetImageById(int imageId);
    }
}
