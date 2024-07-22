using Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Discount : EntityAuditBase
    {
        // discount ở đây sẽ theo giá, theo % và thêm 1 bảng giảm tới mức độ như thế nào
        [Key]
        public Guid Id { get; set; }

    }
}
