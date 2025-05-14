using Microsoft.EntityFrameworkCore;
using LibraryApi.Data;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Filters;
using LibraryApi.Model.Core;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Service Registrierung - DbContext
builder.Services.AddDbContext<PersonalDataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("LibraryConnection")));


// Authorization
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<PersonalUser>().AddEntityFrameworkStores<PersonalDataContext>();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Service hinzufügen

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapIdentityApi<PersonalUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
