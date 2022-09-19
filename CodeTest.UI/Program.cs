using CodeTestV2.Application.Models;
using CodeTestV2.Application.Repositories;
using CodeTestV2.Application.Services;
using CodeTestV2.Core.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<EmployeeContext>();
builder.Services.AddScoped<IEmployeeService<Employee>, EmployeeService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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