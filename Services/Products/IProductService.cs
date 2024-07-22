﻿using Model.Models;
using Repository.Products;

namespace Services.Products
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        List<ProductQuantity> getMostSaleProduct(int count, int subcate);
        IEnumerable<Product> FilterProducts(
        int? categoryId = null,
        int? subCategoryId = null,
        int? metaltypeId = null,
        int? sizeId = null,
        decimal? minPrice = null,
        decimal? maxPrice = null
        );
        IEnumerable<Product> FilterProductsAd(
    int? categoryId = null,
    int? subCategoryId = null,
    int? metaltypeId = null,
    int? sizeId = null,
    decimal? minPrice = null,
    decimal? maxPrice = null,
    string? sortOrder = null,
    List<int>? sizeIds = null,
    List<int>? metaltypeIds = null,
    List<string>? diamondShapes = null,
    int? pageNumber = null,
    int? pageSize = null);

        decimal GetProductTotal(int productId);
        Product GetExistingProduct(int coverId, int diamondId, int metaltypeId, int sizeId);
        Product UpdateProduct(Product produdct);
        Product AddProduct(Product produdct);
        Category GetCategoryById(int categoryId);
    }
}
