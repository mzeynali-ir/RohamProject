namespace Application.Features.Products
{
    public class UpdateProductRequest
    {
        public int Id { get; private set; }
        public void SetId(int id) => this.Id = Id;

        public string Title { get; set; } = null!;
    }
}
