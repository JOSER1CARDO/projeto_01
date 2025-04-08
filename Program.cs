using System;
using Microsoft.EntityFrameworkCore;
using Projeto02.Data;
using Projeto02.Data.Configurations;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationContext>(options =>
 //   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


SQLitePCL.Batteries.Init();

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});



// Add services to the container.
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


//popula a base de dados na maquina 
app.UseDbMigrationHelper();


app.Run();
