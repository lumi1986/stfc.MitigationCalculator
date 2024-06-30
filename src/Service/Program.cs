using MediatR;
using Microsoft.AspNetCore.Mvc;
using stfc.MitigationCalculator.Application;
using stfc.MitigationCalculator.Common.Models;
using stfc.MitigationCalculator.Common.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayerServices();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("api/calculatebyvalues", async (MitigationByValues request, [FromServices] IMediator mediator) => 
{
    var result = await mediator.Send(new CalculateByValueRequest(request));
    return Results.Ok(result);
})
.WithName("CalculateByValues")
.WithOpenApi();

app.Run();

