namespace Domain.Entity.Base
{
    public abstract class EntityAuditBase
    // dùng abstract để tránh việc khởi tạo đối tượng bậy bạ
    {
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;

        public Guid? CreateBy { get; set; } // người đầu tiên thì null

        public DateTimeOffset? UpdateDate { get; set; } = DateTimeOffset.Now;

        public Guid? UpdateBy { get; set; }

        // đoạn này biết được ai thay đổi, ai khởi tạo
    }
}
