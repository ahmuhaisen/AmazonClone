using AmazonClone.Domain.ViewModels.Admin;

namespace AmazonClone.Presentation.DTOs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<AdminUpsertProductVM, Product>()
                .ReverseMap();

            CreateMap<AdminDetailsProductVM, Product>()
                .ReverseMap();

        }
    }
}
