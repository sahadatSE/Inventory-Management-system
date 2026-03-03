using Business.Services;
using Database.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<IMSContext>();

builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<OfferService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderDetailesService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization(); // middleware

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
