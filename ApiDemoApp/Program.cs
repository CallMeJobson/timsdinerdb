using DataLibrary.Data;
using DataLibrary.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(new ConnectionStringData
{
    SqlConnectionName = "Default"
});

builder.Services.AddSingleton<IDataAccess, SqlDb>();
builder.Services.AddSingleton<IFoodData, FoodData>(); 
builder.Services.AddSingleton<IOrderData, OrderData>();
// CORS Cross-Origin-Resource-Sharing
builder.Services.AddCors(options =>
{
    // This policy can be named to your liking.
    // Anyone can access our API 
    options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// The policy must match the policy name above. 
// you well need change the web config file for 
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
