using GenialNetBackend.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using GenialNetBackend.Application.Produtos.Repository;
using GenialNetBackend.Application.Fornecedor.Repository;
using GenialNetBackend.Services;
using GenialNetBackend.Application.Fornecedor.Commands;
using GenialNetBackend.Application.Fornecedor.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IValidator<CreateFornecedorCommand>, CreateFornecedorCommandValidator>();
builder.Services.AddControllers();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<FornecedorRepository>();
builder.Services.AddHttpClient<ViaCepService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
