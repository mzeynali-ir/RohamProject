using Domain.Entities.Common;
using Domain.Entities.Products;
using Domain.Entities.Users;

namespace Domain.Entities.ProductLogs
{
    public class ProductLog: BaseEntity<int>
    {

        public DateTime CreatedOn { get; init; } = DateTime.Now;

        public LogActionType Type { get; set; }

        public int CreatorId { get; init; }
        public User Creator { get; init; } = null!;

        public int ProductId { get; init; }
        public Product Product { get; init; } = null!;

    }

}
