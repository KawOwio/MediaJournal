using MediaJournal.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MediaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediaJournalDb"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
