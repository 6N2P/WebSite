using WebSite.Data;
using WebSite.interfaces;
using WebSite.mocks;
using Microsoft.EntityFrameworkCore;
using WebSite.Data.Repository;
using WebSite.Migrations;
using WebSite.Models;
using ShopCart = WebSite.Models.ShopCart;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//Получаю строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//чтоб не отображалась одинаковаф корзина для разных леюдей
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
// Add services to the container.
builder.Services.AddControllersWithViews();
//Подключение к БД
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));
//для связи и нтерфейсов  и класов
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//При старте программы вызывается для загрузки данных из бд

using (var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
