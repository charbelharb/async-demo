using Microsoft.OpenApi.Models;
using SomeExternalLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IExample, Example>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example", Version = "v1" });
});
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


// NEVER DO THAT
Console.WriteLine($"Max Processor {Environment.ProcessorCount}");
ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
Console.WriteLine($"Worker threads {workerThreads}");
Console.WriteLine($"Async I/O threads {completionPortThreads}");
var max = ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
Console.WriteLine(max);

app.Run();