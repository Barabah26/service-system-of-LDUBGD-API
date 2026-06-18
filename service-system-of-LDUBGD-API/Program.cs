using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.MappingProfiles;
using service_system_of_LDUBGD_API.Application.Services;
using service_system_of_LDUBGD_API.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("StatementServiceConnectionString");
builder.Services.AddDbContext<ServiceSystemDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ServiceSystemDbContext>();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IStatementService, StatementService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg => { }, typeof(StatementMappingProfile).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

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
