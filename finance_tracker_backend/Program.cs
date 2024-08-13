var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Register the controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();  // Optional: Add this if you plan to use authentication/authorization

app.MapControllers();  // Map controllers to routes

app.Run();
