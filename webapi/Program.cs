using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using webapi.Data;
using webapi.Mappings;
using webapi.Models.Domain;
using webapi.Repository;
using webapi.Services;


JsonCleaner.JsonCleanerFiles(); //clean the Json file related to tickets and result data 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{

    options.SwaggerDoc( "v1", new OpenApiInfo { Title = "Lottery API", Version = "v1" } );
    options.ResolveConflictingActions( apiDescriptions => apiDescriptions.First() );
} );



// Register DataPersistance with the DI container and provide instances of List<Ticket> and List<Result>
builder.Services.AddSingleton<List<Ticket>>();// create a single instance of it 
builder.Services.AddSingleton<Result>(); 
builder.Services.AddScoped<DataPersistance>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<ResultService>();
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<ResultRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();


builder.Services.AddAutoMapper( typeof( AutoMapperProfiles ) );//injecting mapping into the controller 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors( options =>
{
    options.AllowAnyOrigin(); 
    options.AllowAnyMethod(); 
    options.AllowAnyHeader(); 
} );

app.UseAuthorization();

app.MapControllers();

app.Run();
