using Microsoft.EntityFrameworkCore;
using GamingCafeAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Add database
builder.Services.AddDbContext<GamingCafeContext>(options =>
    options.UseSqlite("Data Source=gaming_cafe.db"));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure pipeline - ORDER MATTERS!
app.UseCors("AllowAll");

// Static files configuration - ADD THIS
app.UseDefaultFiles();  // Serves index.html as default
app.UseStaticFiles();   // Serves files from wwwroot

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GamingCafeContext>();
    context.Database.EnsureCreated();
}

app.Run();
