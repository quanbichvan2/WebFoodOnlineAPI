namespace OnlineFood.UseCase.Contracts.Repositories.Base
{
    public interface IBaseRepository<TEntity>
        // bản chất thêm 1 sản phẩm dùng trong useCase mà trong service đó thì cần tầng repository để tưởng tác vs db.
        // việc tách riêng ra như vậy thì sau này chỉ cần đổi bất kì repos trong Infrastructure thì ko có ảnh hưởng tới tầng useCase
    // mục đích tạo IBaseRepository để tránh sự phụ thuộc của cấp nhỏ hơn khi muốn repository. Giảm sự phụ thuộc 1 tầng theo quy tắc só 3 L của SOLID
    {
        Task<TEntity> CreateEntity(TEntity entity);
        Task<TEntity> UpdateEntity(TEntity entity);
        Task<bool> DeleteEntity(TEntity entity);
        Task<TEntity> GetEntityById(Guid id);
        Task<TEntity> GetListPagination(IQueryable<TEntity> query, int page, int pageSize);
    }
}
