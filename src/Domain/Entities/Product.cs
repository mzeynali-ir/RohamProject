using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
    }
}
