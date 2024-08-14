var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Register the controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Add Swagger generator

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI();  // Enable middleware to serve Swagger UI.
}

app.UseAuthorization();  // Optional: Add this if you plan to use authentication/authorization

app.MapControllers();  // Map controllers to routes

app.Run();