using Microsoft.EntityFrameworkCore;
using asp_member_prac.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// 從應用程式設定中獲取連接字串。
var connectionString = builder.Configuration.GetConnectionString("WebDatabase");
// 將 EmployeeDbContext 服務添加到依賴注入容器中，並配置使用 MySQL 作為資料庫提供程序。
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
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
