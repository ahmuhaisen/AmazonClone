using System.Text.Json.Serialization;
using AmazonClone.Presentation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole();


builder.Services.AddControllers()
    .AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;

builder.Services.AddDbContext<AppDbContext>(o => {
        o.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection"));
    });


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();


builder.Services.AddAutoMapper(typeof(MapperProfile));



builder.Services.AddAuthentication().AddGoogle(options =>
{
    IConfigurationSection googleAuthSection = builder.Configuration.GetSection("Authentication:Google");

    options.ClientId = googleAuthSection["ClientId"]!;
    options.ClientSecret = googleAuthSection["ClientSecret"]!;

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


builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{area=Master}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
