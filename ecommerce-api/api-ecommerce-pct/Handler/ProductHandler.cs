using api_ecommerce_pct.Interfaces.Handler;
using api_ecommerce_pct.Interfaces.Repository;
using ecommerce_core.Dtos.pct;
using ecommerce_core.Models.ProductsCategories;
using ecommerce_core.Models;
using Mapster;

namespace api_ecommerce_pct.Handler;

public class ProductHandler(IProductRepository productRepository) : IProductHandler
{
    public async Task<ResponseApp<object>> AddProductAsync(ProductDTO product)
    {
        ProductModel productModel = product.Adapt<ProductModel>();

        await productRepository.AddProductAsync(productModel);

        return new()
        {
            Message = "Produto criado com sucesso!",
        };
    }

    public async Task<ResponseApp<object>> UpdateProductAsync(ProductDTO product)
    {
        if (string.IsNullOrEmpty(product.Id))
            throw new BadHttpRequestException("O id do produto não pode ser nulo ou vazio.");

        ProductModel productModel = await productRepository.GetProductAsync(product.Id);

        productModel.Name = product.Name;
        productModel.UpdatedIn = DateTime.UtcNow;
        productModel.Description = product.Description;
        productModel.Price = product.Price;
        productModel.Sku = product.Sku;

        await productRepository.UpdateProductAsync(productModel);

        return new()
        {
            Message = "Produto atualizado com sucesso!"
        };
    }

    public async Task<ResponseApp<ProductDTO>> GetProductById(string productId)
    {
        ProductModel product = await productRepository.GetProductAsync(productId);

        var response = product.Adapt<ProductDTO>();

        return new()
        {
            Data = response
        };
    }

    public async Task<ResponseApp<PaginationInputModel>> GetProducts(PaginationModel pagination, IQueryCollection query)
    {
        var responsePagination = await productRepository.GetProductsAsync(query, pagination.Page, pagination.PageSize);

        return new()
        {
            Data = responsePagination
        };
    }
}
