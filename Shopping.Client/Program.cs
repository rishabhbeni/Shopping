using Shopping.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("ShoppingAPIClient" ,httpClient =>
{
    // httpClient.BaseAddress = new Uri("http://localhost:5000/");
    httpClient.BaseAddress = new Uri(builder.Configuration["ShoppingAPIUrl"]);
});

// builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
