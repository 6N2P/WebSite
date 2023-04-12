using WebSite.Data;
using WebSite.interfaces;
using WebSite.mocks;
using Microsoft.EntityFrameworkCore;
using WebSite.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

//Получаю строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
//Подключение к БД
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));
//для связи и нтерфейсов  и класов
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
