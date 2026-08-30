using BCP_BL.AdminService.CenterActivity.Implementation;
using BCP_BL.AdminService.CenterActivity.Interface;
using BCP_BL.AdminService.CenterDashBoard.Implementation;
using BCP_BL.AdminService.CenterDashBoard.Interface;
using BCP_BL.AdminService.StockMatrix.Interface;
using BCP_BL.AdminService.StockMatrix.Implementation;
using BCP_Frontend.Components;
using BCP_BL.AdminService.StockStatus.Interface;
using BCP_BL.AdminService.StockStatus.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7251/");
});


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ICenterActivityService, CenterActivityService>();
builder.Services.AddScoped<ICenterDashboardService, CenterDashboardService>();
builder.Services.AddScoped<IStockMatrixService, StockMatrixService>();
builder.Services.AddScoped<IStockStatusService, StockStatusService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
