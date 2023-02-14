 using System.Reflection;
using UI.Interfaces;
using UI.Services;
using UI.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAutherService, AutherService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
