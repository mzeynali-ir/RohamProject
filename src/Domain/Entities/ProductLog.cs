namespace Domain.Entities
{
    public class ProductLog
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; init; } = DateTime.Now;

        public LogActionType Type { get; set; }

        public int CreatorId { get; init; }
        public User Creator { get; init; } = null!;

        public int ProductId { get; init; }
        public Product Product { get; init; } = null!;

    }

}
