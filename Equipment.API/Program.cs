using Equipment.Persistence;
using Equipment.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Equipment.API.Utils;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Equipment.Application.Validators.Filters;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddTransient<StrategyConverter>();

builder.Services.AddValidatorsFromAssemblyContaining<FilterUnitPostBodyValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
        .AddCookie(options =>
          {
              options.LoginPath = "/login";
              options.ExpireTimeSpan = TimeSpan.FromDays(30);
              options.Cookie.MaxAge = options.ExpireTimeSpan;
              options.SlidingExpiration = true;
          });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RB API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapStaticAssets();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Company}/{action=Index}/{id?}")
//    .WithStaticAssets();

app.MapGet("/", async (context) =>
{
    context.Response.Redirect("/swagger");
});

app.Run();
