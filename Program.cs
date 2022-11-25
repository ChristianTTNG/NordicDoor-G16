using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NordicDoorTestingrep.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NordicDoorTestingrepContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NordicDoorTestingrepContext") ?? throw new InvalidOperationException("Connection string 'NordicDoorTestingrepContext' not found.")));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Suggestions}/{action=Index}/{id?}");

app.Run();
