namespace AmazonClone.Presentation
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, AdminCategoryViewModel>()
                .ReverseMap();

            CreateMap<AdminUpsertProductViewModel, Product>()
                .ReverseMap();

            CreateMap<AdminDetailsProductViewModel, Product>()
                .ReverseMap();

            CreateMap<AdminUserViewModel, ApplicationUser>()
                .ReverseMap();

            CreateMap<CustomerDetailsProductViewModel, Product>()
                .ReverseMap();

            CreateMap<CustomerShipmentFormViewModel, Shipment>()
                .ReverseMap();

            CreateMap<CustomerOrderViewModel, Order>()
               .ReverseMap();

            CreateMap<CustomerOrderItemViewModel, OrderItem>()
               .ReverseMap();
        }
    }
}
