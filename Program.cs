using Microsoft.EntityFrameworkCore;
using RepairNinjaMVC.Data;


var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers();

builder.Services.AddDbContext<RepairNinjaContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("RepairNinjaDb")));

builder.Services.AddScoped<IRNRepository, RNRepository>();
builder.Services.AddMvc();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run(); 
