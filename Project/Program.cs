using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
 ));
builder.Services.AddTransient<DbRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
