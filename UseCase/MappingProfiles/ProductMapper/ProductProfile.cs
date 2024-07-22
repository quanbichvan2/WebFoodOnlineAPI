using AutoMapper;
using Domain.Entity;
using UseCase.Models.Product;

namespace UseCase.MappingProfiles.ProductMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            init();
        }

        private void init()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
