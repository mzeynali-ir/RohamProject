using Application.Contracts.Repositories;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

    }
}
