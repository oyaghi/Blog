using Scalar.AspNetCore;
using Blog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddDefaultInfrastructure();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(o =>
    {
        o.WithTheme(ScalarTheme.Kepler);

        // Disable default fonts to avoid download uncessary fonts
        o.DefaultFonts = false;

        // Use similar layout to swagger
        o.Layout = ScalarLayout.Classic;
    });
}

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

app.UseHttpsRedirection();

app.Run();