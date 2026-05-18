using MediaJournal.Api.Data;
using MediaJournal.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MediaJournal.API", Version = "v1" });
});

builder.Services.AddDbContext<MediaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediaJournalDb"));
});

builder.Services.AddScoped<IGameRepository, SQLGameRepository>()
    .AddScoped<IGameGenreRepository, SQLGameGenreRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediaJournal.API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();
