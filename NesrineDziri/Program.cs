using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NesrineDziri.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NesrineDziriContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NesrineDziriContext") ?? throw new InvalidOperationException("Connection string 'NesrineDziriContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/MakeUps/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MakeUps}/{action=Index}/{id?}");

app.Run();
