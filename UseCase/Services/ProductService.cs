using AutoMapper;
using Domain.Entity;
using FluentValidation;
using OnlineFood.UseCase.Contracts.Repositories;
using UseCase.Contracts.Services;
using UseCase.Models.Product;

namespace UseCase.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<CreateProductDto> _validator;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IValidator<CreateProductDto> validator, IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(CreateProductDto productDto)
        {
            try
            {
                var isValid = _validator.Validate(productDto);
                if (!isValid.IsValid)
                {
                    throw new ArgumentNullException(nameof(productDto));
                }

                Product product = _mapper.Map<Product>(productDto);

                await _productRepository.CreateProductAsync(product);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
