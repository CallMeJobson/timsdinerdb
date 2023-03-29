using DataLibrary.Data;
using DataLibrary.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//one instance of this. One instance will be running for the life cycle of the app. 
builder.Services.AddSingleton(new ConnectionStringData
{
    SqlConnectionName = "Default"
});

//Out puts a SQL 
builder.Services.AddSingleton<IDataAccess, SqlDb>();
builder.Services.AddSingleton<IFoodData, FoodData>();
builder.Services.AddSingleton<IOrderData, OrderData>();

var app = builder.Build();
//app.Services.AddRazorPages();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
