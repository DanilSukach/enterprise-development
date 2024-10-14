using StoreCashFlow.Api.Service;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<ProductAvailabilityService>();
builder.Services.AddSingleton<ProductTypeService>();
builder.Services.AddSingleton<SaleService>();
builder.Services.AddSingleton<StoreService>();
builder.Services.AddSingleton<RequestService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
