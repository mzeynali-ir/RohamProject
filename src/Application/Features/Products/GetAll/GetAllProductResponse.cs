namespace Application.Features.Products
{
    public class GetAllProductResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; } = null!;

        public string CreatorFullName { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        public string? LastModifierFullName { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
