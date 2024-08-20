using FinanceTrackerBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddControllers();  // Register the controllers
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();  // Add Swagger generator
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39)) // Specify your MySQL version
    ));

var app = builder.Build();

//app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI();  // Enable middleware to serve Swagger UI.
}

app.UseAuthorization();  // Optional: Add this if you plan to use authentication/authorization

app.MapControllers();  // Map controllers to routes

app.Run();