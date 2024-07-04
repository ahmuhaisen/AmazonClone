using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Drawing;

namespace AmazonClone.Presentation
{
    public static class ProgramExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection collection, string constr)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            collection.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlServer(
                    constr
                       //configuration.GetConnectionString("DefaultConnection")
                       );
            });
        }

        public static void AddApplicationUser(this IServiceCollection collection)
        {
            collection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
        }

        public static void AddScopedDependencies(this IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork, UnitOfWork>();
            collection.AddScoped<ICategoryService, CategoryService>();
            collection.AddScoped<IProductService, ProductService>();
            collection.AddScoped<IWishlistService, WishlistService>();
            collection.AddScoped<ICartService, CartService>();
            collection.AddScoped<ICheckoutService, CheckoutService>();
            collection.AddScoped<IShipmentService, ShipmentService>();
            collection.AddScoped<IPaymentService, PaymentService>();
            collection.AddScoped<IOrderService, OrderService>();
            collection.AddScoped<IOrderItemService, OrderItemService>();
        }

        public static void AddGoogleAsAnExternalAuthentication(this IServiceCollection collection, WebApplicationBuilder builder)
        {
            collection.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!; ;
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!; 

                options.ClaimActions.MapJsonKey("urn:google:given_name", "given_name", "string");
                options.ClaimActions.MapJsonKey("urn:google:family_name", "family_name", "string");
                options.ClaimActions.MapJsonKey("urn:google:profilepicture", "picture", "url");

                options.SaveTokens = true;

                options.Events.OnCreatingTicket = ctx =>
                {
                    List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();
                    tokens.Add(new AuthenticationToken()
                    {
                        Name = "TicketCreated",
                        Value = DateTime.UtcNow.ToString()
                    });

                    ctx.Properties.StoreTokens(tokens);

                    return Task.CompletedTask;
                };
            });

        }
    }
}
