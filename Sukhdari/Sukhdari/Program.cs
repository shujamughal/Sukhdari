using Microsoft.AspNetCore.Identity;
using Sukhdari;
using Sukhdari.Client.Pages;
using Sukhdari.Data;
using Sukhdari.Service.IService;
using Sukhdari.Service;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Business.IRepo;
using Business;
using Microsoft.AspNetCore.HttpOverrides;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>

           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped<IStoreRepo, StoreRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductImageRepo, ProductImageRepo>();
builder.Services.AddScoped<IImageUpload, ImageUpload>();
builder.Services.AddScoped<IUserIPRepo, UserIPRepo>();
builder.Services.AddScoped<IStoreImageRepo, StoreImageRepo>();
builder.Services.AddScoped<ITagRepo, TagRepo>();
builder.Services.AddScoped<ITagTypeRepo, TagTypeRepo>();
builder.Services.AddScoped<IStoreTagRepo, StoreTagRepo>();
builder.Services.AddScoped<ICountDetailsRepo, CountDetailsRepo>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor(/*options => { options.IgnoreScriptIsolation = true; }*/);
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorPages();

//app.MapRazorComponents<App>()
//    .AddInteractiveWebAssemblyRenderMode()
//    .AddAdditionalAssemblies(typeof(Sukhdari.Client._Imports).Assembly);


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
    //.AddAdditionalAssemblies(typeof(Counter).Assembly);


app.Run();
