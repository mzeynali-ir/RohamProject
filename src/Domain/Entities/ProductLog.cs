namespace Domain.Entities
{
    public class ProductLog
    {

        public int Id { get; set; }

        public DateTime CreatedOn { get; init; } = DateTime.Now;

        public LogActionType Type { get; set; }

        public int CreatorId { get; init; }
        public User Creator { get; init; } = null!;

    }

}
