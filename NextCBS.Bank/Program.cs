using Bank.Data;
using NextCBS.Bank.Abstractions;
using NextCBS.Bank.Api;
using NextCBS.Bank.Data;
using NextCBS.Bank.Intercom;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<DbOption>(builder.Configuration.GetSection("DbServer"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUserMeta, UserMeta>();
builder.Services.AddScoped<IMicroServiceMeta, MicroServiceMeta>();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.ConfiguredServices(builder.Configuration);
builder.Services.UserIntercomDi();


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
