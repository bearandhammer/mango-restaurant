using MangoRestaurant.Web.Services;
using MangoRestaurant.Web.Services.Interfaces;
using MangoRestaurant.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add HTTP Clients
builder.Services.AddHttpClient<IProductService, ProductService>();

// Configure Base URLs
ApiHelper.ProductApiBase = builder.Configuration["APIBaseUrls:ProductAPI"];

// Register Services
builder.Services.AddScoped<IProductService, ProductService>();

// Add Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
