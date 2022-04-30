using MangoRestaurant.Web.Services;
using MangoRestaurant.Web.Services.Interfaces;
using MangoRestaurant.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add HTTP Clients
builder.Services.AddHttpClient<IProductService, ProductService>();

// Configure Base URLs
ApiHelper.ProductApiBase = builder.Configuration["APIBaseUrls:ProductAPI"];
ApiHelper.ShoppingCartApiBase = builder.Configuration["APIBaseUrls:ShoppingCartAPI"];

// Register Services
builder.Services.AddScoped<IProductService, ProductService>();

// Add Razor Pages
builder.Services.AddRazorPages();

// Configure Security
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies", options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(builder.Configuration["AuthSettings:TimeoutInMinutes"]));
})
.AddOpenIdConnect("oidc", options => 
{
    options.Authority = builder.Configuration["APIBaseUrls:IdentityAPI"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = builder.Configuration["AuthSettings:ClientId"];
    options.ClientSecret = builder.Configuration["AuthSettings:ClientSecret"];
    options.ResponseType = "code";
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add(builder.Configuration["AuthSettings:Scope"]);
    options.SaveTokens = true;
});

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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
