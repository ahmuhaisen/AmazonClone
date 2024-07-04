var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole();


builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;


builder.Services.AddApplicationDbContext();

builder.Services.AddApplicationUser();

builder.Services.AddScopedDependencies();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddExternalAuthentications();

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
