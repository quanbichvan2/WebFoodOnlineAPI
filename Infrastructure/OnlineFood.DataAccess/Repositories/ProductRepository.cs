using Domain.Entity;
using Domain.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using OnlineFood.Repository.Repositories.Base;
using OnlineFood.UseCase.Contracts.Repositories;

namespace OnlineFood.Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
        // IProductRepos để giảm độ phụ thuộc của code, dùng kế thừa BaseRepository để dùng lại những gì đã có
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
           return await CreateEntity(product);
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            return await DeleteEntity(product);
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.Where(x => x.Id == productId).Include(y => y.Category).FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                return await UpdateEntity(product);
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        async Task<Filter<Product>> IProductRepository.GetListPaginationAsync(IQueryable<Product> query, int page, int pageSize)
        {
            var totalItem = (query).Count();
            query = query.Skip((page -1) * pageSize);
            var result = await query.ToListAsync();
            var pagination = new Filter<Product>
            {
                Data = result,
                pageInfo = new PageInfo()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItem = totalItem
                }
            };
            return pagination;
        }
    }
}
