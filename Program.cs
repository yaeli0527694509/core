var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// קוד שצריך למזג
// using Core.Middleware;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddMiddleware<ReceptionMiddleware>(); // why?

// builder.Services.AddControllers();
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
//    // app.UseOpenApi(); צריך את זה?
//     // app.UseSwaggerUi3(settings => צריך?
//     // {
//     //     settings.Path = "/swagger";
//     //     settings.DocumentPath = "/swagger/{documentName}/swagger.json";
//     // });
// }

// //swaggerOptions.RouteTemplate = "/swagger/{documentName}/swagger.json"; צריך את זה?

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
