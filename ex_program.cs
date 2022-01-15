using NTR.Data;
using Microsoft.EntityFrameworkCore;
using NTR;
using System.ComponentModel.DataAnnotations;
using MySQL.Data.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

Console.Write("dupa");

builder.Services.AddDbContext<DataContext>(options => options.UseMySQL("Host=localhost; Port=3306; Database=ntr; Username=root; Password=jwalcza3"));

builder.Services.AddScoped<IDataContext>(provider=> provider.GetService<DataContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
