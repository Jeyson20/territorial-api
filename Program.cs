using TerritorialAPi.Services;
using TerritorialAPi.Services.Interfaces;
using TerritorialAPi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TerritorialConfig>(builder.Configuration.GetSection("TerritorialConfig"));

builder.Services.AddScoped<ITerritorialService, TerritorialService>();
builder.Services.AddHttpClient<IHttpService, HttpService>();

builder.Services.AddRouting(o => o.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(e =>
{
	e.EnableAnnotations();
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

app.Run();
