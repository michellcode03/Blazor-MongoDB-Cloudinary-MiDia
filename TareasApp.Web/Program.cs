using TareasApp.Web.Components;
using TareasApp.Infrastructure;
using TareasApp.Infrastructure.Repositories;
using TareasApp.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Primero el contexto de Mongo
builder.Services.AddSingleton<MongoDbContext>(new MongoDbContext(
    builder.Configuration.GetConnectionString("MongoDb")!,
    builder.Configuration["MongoDbSettings:DatabaseName"]!
));

builder.Services.AddSingleton<CloudinaryService>(new CloudinaryService(
    builder.Configuration["Cloudinary:CloudName"]!,
    builder.Configuration["Cloudinary:ApiKey"]!,
    builder.Configuration["Cloudinary:ApiSecret"]!
));

// Luego el repositorio y el servicio
builder.Services.AddSingleton<TareaRepository>();
builder.Services.AddSingleton<TareaService>();
builder.Services.AddSingleton<ReflexionRepository>();
builder.Services.AddSingleton<ReflexionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
