using AutoMapper;
using dapperwebapi.Data;
using dapperwebapi.Mapper;
using dapperwebapi.Repository;
using dapperwebapi.Servcies;
using dapperwebapi.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SqlConnectionsSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDbConnectionProvider, DbConnectionProvider>();

var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(typeof(MappingProfile));
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

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
