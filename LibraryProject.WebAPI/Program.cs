using LibraryProject.BusinessLogic.Abstract;
using LibraryProject.BusinessLogic.Concrete;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DapperRepositoryBase>();
builder.Services.AddControllers();

builder.Services.AddTransient<IBookService, BooksManager>();
builder.Services.AddTransient<IBookDal, DpBookDal>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
