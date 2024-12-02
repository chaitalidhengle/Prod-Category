using Microsoft.EntityFrameworkCore;
using ProductsAndCategory.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ContextDemo>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("scon")));
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
