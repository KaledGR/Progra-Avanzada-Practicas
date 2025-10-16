using AP.Architecture;
using AP.Models.DTOs;
using AP.Mvc.ServiceLocator2;
using AP.ServiceLocator2.Helper;
using AP.ServiceLocator2.Services;
using AP.ServiceLocator2.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IInventorService, InventorService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestProvider, RestProvider>();
builder.Services.AddScoped<IServiceLocatorService, ServiceLocatorService>();
builder.Services.AddScoped<IServiceMapper, ServiceMapper>();
builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
builder.Services.AddScoped<IService<ComponentDTO>, ComponentService>();
builder.Services.AddScoped<IService<InventoryDTO>, InventorService>();
builder.Services.AddScoped<IService<ProductDTO>, ProductService>();
builder.Services.AddScoped<IService<RoleDTO>, RoleService>();
builder.Services.AddScoped<IService<TaskDTO>, TaskService>();
builder.Services.AddScoped<IService<UserDTO>, UserService>();

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

app.Run();
