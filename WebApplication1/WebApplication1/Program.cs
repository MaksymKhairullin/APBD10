using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddDbContext<DatabaseContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/accounts/{accountid:int}", async (int accountid, IAccountService serrvice) =>
    {
        return Results.Ok(await serrvice.GetAccountWithIdAsync(accountid));
    }
);

app.Run();
