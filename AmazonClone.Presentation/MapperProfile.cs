namespace AmazonClone.Presentation
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AdminUserViewModel, ApplicationUser>()
                .ReverseMap();


            CreateMap<AdminCategoryViewModel, Category>()
                .ReverseMap();

            CreateMap<AdminUpsertProductViewModel, Product>()
                .ReverseMap();

            CreateMap<AdminDetailsProductViewModel, Product>()
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
