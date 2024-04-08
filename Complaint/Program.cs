using Microsoft.EntityFrameworkCore;
using Complain.Data;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Db_ComplaintModel>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "UserName"; // ชื่อคุกกี้
            options.LoginPath = "/Account/Login"; // เส้นทางสำหรับเข้าสู่ระบบหากการยืนยันตัวตนล้มเหลว
            options.AccessDeniedPath = "/Account/Login"; // เส้นทางสำหรับเข้าถึงถูกปฏิเสธ
        });

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ใช้การยืนยันตัวตนก่อนการเรียกใช้ Routing
app.UseAuthorization(); // ใช้การอนุญาตหลังการเรียกใช้ Routing

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Complaint}/{action=Home}/{id?}");

app.Run();
