using EstoqueAPI.AutoMapper;
using EstoqueAPI.Contract.Categoria;
using EstoqueAPI.Contract.MovimentacaoEstoque;
using EstoqueAPI.Contract.Produto;
using EstoqueAPI.Data;
using EstoqueAPI.Domain.Models;
using EstoqueAPI.Domain.Repository.Class;
using EstoqueAPI.Domain.Repository.Interface;
using EstoqueAPI.Domain.Service.Class;
using EstoqueAPI.Domain.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()  // Permite qualquer origem
                   .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
                   .AllowAnyHeader(); // Permite qualquer cabeçalho
        });
});

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PADRAO"));
});

builder.Services.AddAutoMapper(
    typeof(ProdutoProfile),
    typeof(CategoriaProfile),
    typeof(MovimentacaoEstoqueProfile)
    );

builder.Services.AddScoped<IBaseRepository<Produto, int>, ProdutoRepository>();
builder.Services.AddScoped<IBaseService<ProdutoRequestContract, ProdutoResponseContract, int>, ProdutoService>();
builder.Services.AddScoped<IBaseRepository<Categoria, int>, CategoriaRepository>();
builder.Services.AddScoped<IBaseService<CategoriaRequestContract, CategoriaResponseContract, int>, CategoriaService>();
builder.Services.AddScoped<IBaseRepository<MovimentacaoEstoque, int>, MovimentacaoEstoqueRepository>();
builder.Services.AddScoped<IBaseService<MovimentacaoEstoqueRequestContract, MovimentacaoEstoqueResponseContract, int>, MovimentacaoEstoqueService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
