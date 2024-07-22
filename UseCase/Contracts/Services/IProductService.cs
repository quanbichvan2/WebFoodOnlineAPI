using Domain.Entity;
using UseCase.Models.Product;

namespace UseCase.Contracts.Services
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(CreateProductDto productDto);
    }
}
