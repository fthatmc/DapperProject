using DapperProject.Context;
using DapperProject.Services.AdServices;
using DapperProject.Services.AgentServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.ProductServices;
using DapperProject.Services.SliderServices;
using DapperProject.Services.StiuationService;
using DapperProject.Services.TestimonialServcies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAdService, AdService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IStiuationService, StiuationService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
