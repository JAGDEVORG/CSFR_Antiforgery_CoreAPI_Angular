using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Web_CSRF_API.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery(option =>
{
    option.HeaderName = "x-xsrf-token";
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ValidateAntiForgeryTokenAttribute());
});

builder.Services.AddScoped<AntiforgeryMiddleware>();

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI: Antiforgery");
    });
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();



//app.UseCors(x => x
//            .SetIsOriginAllowed(origin => true)
//            .AllowAnyMethod()
//            //.AllowAnyHeader()
//            .AllowCredentials());


//app.MapGet("antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
//{
//    var tokens = forgeryService.GetAndStoreTokens(context);
//    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
//            new CookieOptions { HttpOnly = false });
//    return Results.Ok();
//}).RequireAuthorization();

//var antiforgery = app.Services.GetRequiredService<IAntiforgery>();

//app.Use((context, next) =>
//{
//    var requestPath = context.Request.Path.Value;

//    if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
//        || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
//    {
//        var tokenSet = antiforgery.GetAndStoreTokens(context);
//        context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
//            new CookieOptions { HttpOnly = false });
//    }

//    return next(context);
//});

app.Use((context, next) =>
{
    var requestPath = context.Request.Path.Value;
    return next(context);
});

app.UseMiddleware<AntiforgeryMiddleware>();

app.MapControllers();

app.Run();