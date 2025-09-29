namespace Application.Features.Products
{
    public class CreateProductRequest
    {
        public string Title { get; set; } = null!;
        public int? ParentId { get; set; }
    }
}
