using SistemaDeProdutividade.API.Filters;
using SistemaDeProdutividade.Application;
using SistemaDeProdutividade.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddTiaIdentity().AddCookie(x =>
{
    //x.LoginPath = "/Autenticacao/Login";
    //x.AccessDeniedPath = "/Home/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseTiaIdentity();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
