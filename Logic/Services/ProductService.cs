using DataAccess.Entities;
using DataAccess.Interfaces;
using Logic.Interfaces;
using Shared.DTOs;
using Shared.Utilities;
using System.Data;

namespace Logic.Services
{
    public class ProductService(IProductRepository productRepository, IDbConnection dbConnection) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<ResponseDataDto<List<ProductDto>>> GetAllProductsAsync()
        {
            ResponseDataDto<List<ProductDto>> response = new();
            List<Product> products = await _productRepository.GetAllProducts();
            if (products == null || products.Count == 0)
            {
                response.Data = [];
                response.Message = "No se encontraron productos";
                response.Completed = true;
                return response;
            }
            response.Data = [.. products.Select(p => new ProductDto
                {
                    IdProduct = p.IdProduct,
                    ProductKey = p.ProductKey,
                    Name = p.Name,
                    Stock = p.Stock
                })];
            response.Message = "Productos obtenidos exitosamente";
            response.Completed = true;
            return response;
        }

        public async Task<ResponseDto> InsertProductAsync(ProductDto product)
        {
            ResponseDto response = new();
            _dbConnection.Open();
            using var transaction = _dbConnection.BeginTransaction();

            try
            {
                Product productEntitie = new()
                {
                    IdProduct = 0,
                    ProductKey = product.ProductKey,
                    Name = product.Name,
                    Stock = product.Stock,
                    IsActive = true
                };
                response.Completed = await _productRepository.InsertAsync(productEntitie, transaction);

                if (!response.Completed)
                {
                    response.Message = "No se pudo registrar el producto";
                    transaction.Rollback();
                    return response;
                }

                transaction.Commit();
                response.Message = "Se registro exitosamente el producto";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al registrar el producto: " + ex.Message;
                transaction.Rollback();
                return response;
            }
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
