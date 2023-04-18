using VendorAPI.Data.DB;
using Microsoft.EntityFrameworkCore;
using VendorAPI.Data.Interface;
using VendorAPI.Data.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VendorContext>(options =>
    options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<ICustomer,CustomerDB>();
builder.Services.AddTransient<IItemDB,ItemDB>();
builder.Services.AddTransient<IPurchaseDB,PurchaseDB>();
builder.Services.AddTransient<ICartDB,CartDB>();
builder.Services.AddTransient<IDirectMessagesDB, DirectMessageDB>();
builder.Services.AddTransient<IPostDB,PostDB>();
builder.Services.AddTransient<IVendor,VendorRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
