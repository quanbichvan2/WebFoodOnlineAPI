using Domain.Entity;
using OnlineFood.UseCase.Contracts.Repositories.Base;

namespace OnlineFood.UseCase.Contracts.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Product product);
        Task<Product> GetProductByIdAsync(Guid productId);
        // Task<Filter<Product>> GetAllProducts(FilterProduct filter);
        // hold lại khi nào FE làm phần hiển thị DTO thì nhét vào FilterProduct trong DTO của product
        Task<Filter<Product>> GetListPaginationAsync(IQueryable<Product> query, int page, int pageSize);
    }
}
