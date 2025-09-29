namespace Application.Features.Products
{
    public class UpdateProductRequest
    {
        public int Id { get; private set; }
        public void SetId(int id) => this.Id = Id;

        public int? ParentId { get; set; }

        public string Title { get; set; } = null!;
    }
}
