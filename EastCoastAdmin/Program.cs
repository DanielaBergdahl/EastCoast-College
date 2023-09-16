using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICourseService, CourseService>(c =>
c.BaseAddress = new Uri("https://localhost:7021/"));

builder.Services.AddHttpClient<ITeacherService, TeacherService>(c =>
c.BaseAddress = new Uri("https://localhost:7021/"));

builder.Services.AddHttpClient<IStudentService, StudentService>(c =>
c.BaseAddress = new Uri("https://localhost:7021/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//DELETE?
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
