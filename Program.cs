using RegistroPersona.Data;
using Microsoft.EntityFrameworkCore;
using RegistroPersona.DAL;
using RegistroPersona.Models;
using RegistroPersona.BLL;
using Radzen.Blazor;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(Options =>
    Options.UseSqlite(ConStr)
);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<OcupacionesBLL>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<PersonasBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
