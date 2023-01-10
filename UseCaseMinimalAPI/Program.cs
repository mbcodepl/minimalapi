using UseCaseMinimalAPI.EndpointDefinitions;
using UseCaseMinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinitions(typeof(CustomerEndpointDefinitions));

var app = builder.Build();

app.UseEndpointDefinitions();

app.Run();