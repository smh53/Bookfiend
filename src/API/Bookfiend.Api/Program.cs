using Bookfiend.Api.CustomMiddlewares;
using Bookfiend.Application;
using Bookfiend.Identity;
using Bookfiend.Infrastructure;
using Bookfiend.Persistence;
using Serilog;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
.WriteTo.Console()
.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);    
builder.Services.AddCors(options =>
{
    options.AddPolicy("All", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(options =>
{
   

    options.AddPolicy("BookQuoteListPermission", policy =>
        policy.RequireClaim(claimType:"bookQuote","list" ));

    options.AddPolicy("BookQuoteCreatePermission", policy =>
       policy.RequireClaim(claimType: "bookQuote", "create"));

    options.AddPolicy("BookQuoteUpdatePermission", policy =>
       policy.RequireClaim(claimType: "bookQuote", "update"));

    options.AddPolicy("BookQuoteDeletePermission", policy =>
       policy.RequireClaim(claimType: "bookQuote", "delete"));

    options.AddPolicy("BookListPermission", policy =>
        policy.RequireClaim(claimType: "book", "list"));

    options.AddPolicy("BookCreatePermission", policy =>
       policy.RequireClaim(claimType: "book", "create"));

    options.AddPolicy("BookUpdatePermission", policy =>
       policy.RequireClaim(claimType: "book", "update"));

    options.AddPolicy("BookDeletePermission", policy =>
       policy.RequireClaim(claimType: "book", "delete"));


    options.AddPolicy("AuthorListPermission", policy =>
        policy.RequireClaim(claimType: "author", "list"));

    options.AddPolicy("AuthorCreatePermission", policy =>
       policy.RequireClaim(claimType: "author", "create"));

    options.AddPolicy("AuthorUpdatePermission", policy =>
       policy.RequireClaim(claimType: "author", "update"));

    options.AddPolicy("AuthorDeletePermission", policy =>
       policy.RequireClaim(claimType: "author", "delete"));
});

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseCors("All");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
