using Lesson_3.Abstraction;
using Lesson_3.Data;
using Lesson_3.Graph.Mutation;
using Lesson_3.Graph.Query;
using Lesson_3.Mapper;
using Lesson_3.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<StorageContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMemoryCache();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();
