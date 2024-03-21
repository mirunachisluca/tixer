using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tixer.Context;
using Tixer.Repositories;
using Tixer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.ReturnHttpNotAcceptable = true;
})
.ConfigureApiBehaviorOptions(opt =>
{
    opt.InvalidModelStateResponseFactory = context =>
    {
        var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
        var validationProblemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

        validationProblemDetails.Status = StatusCodes.Status422UnprocessableEntity;

        return new UnprocessableEntityObjectResult(validationProblemDetails);
    };
});

builder.Services.AddDbContext<TixerDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("database")));

builder.Services.AddTransient<ITicketsRepository, TicketsRepository>();
builder.Services.AddTransient<ITicketsService, TicketsService>();

builder.Services.AddAutoMapper(typeof(Program));

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
