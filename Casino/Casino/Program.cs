using Casino.BLL;
using Casino.BLL_EF;
using Casino.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddDbContext<CasinoDbContext>();
builder.Services.AddScoped<IUser,UserEF >();
builder.Services.AddScoped<IGame,GameEF >();
builder.Services.AddScoped<IResults,ResultEF >();
builder.Services.AddScoped<ITransactions,TransactionsEF >();

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
