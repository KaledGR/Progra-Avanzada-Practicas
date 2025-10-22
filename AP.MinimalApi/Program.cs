
using AP.Data.Models;
using AP.Models.DTOs;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Patrón de diseño: Lazy Loading Virtual Proxy
// Motivo de elección: Este patrón ayuda a mejorar el rendimiento de la aplicación y optimizar recursos.
// Justificación técnica: Se implementa en el contexto de base de datos usando UseLazyLoadingProxies, y requiere instalar el paquete NuGet Microsoft.EntityFrameworkCore.Proxies.
// El verdadero uso se hace en la clase CategoryDTO (en Models), en la propiedad Products, donde se usa 'virtual' para habilitar la carga diferida.
// Este patrón permite cargar los datos solo cuando realmente se necesitan, lo que mejora el rendimiento en entornos con consultas pesadas.
// Sin embargo, es importante evaluar cuándo conviene usarlo, ya que en algunos casos puede generar consultas innecesarias.

builder.Services.AddDbContext<ProductDbContext>(options =>
    options
    .UseLazyLoadingProxies(true)
    .UseSqlServer("Server=DESKTOP-PE6BDTN;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();



RouteGroupBuilder productsItems = app.MapGroup("/productsItems");

productsItems.MapGet("/", GetProducts);
productsItems.MapGet("/{id}", GetProduct);
productsItems.MapPost("/", CreateProduct);
productsItems.MapPut("/{id}", UpdateProduct);
productsItems.MapDelete("/{id}", DeleteProduct);


RouteGroupBuilder categoryItems = app.MapGroup("/categoryItems");

categoryItems.MapGet("/", GetCategories);
categoryItems.MapGet("/{id}", GetCategory);
categoryItems.MapPost("/", CreateCategory);
categoryItems.MapPut("/{id}", UpdateCategory);
categoryItems.MapDelete("/{id}", DeleteCategory);

  



app.Run();

static async Task<IResult> GetProducts(ProductDbContext db )
{
    return TypedResults.Ok(await db.Products.Select(x => new ProductDTO(x)).ToArrayAsync());
}

static async Task<IResult> GetProduct(int id, ProductDbContext db)
{
    return await db.Products.FindAsync(id)
        is Product product
            ? TypedResults.Ok(new ProductDTO(product))
            : TypedResults.NotFound();
}

static async Task<IResult> CreateProduct(ProductDTO productDTO, ProductDbContext db)
{
    var product = new Product
    {
       ProductName = productDTO.ProductName,
       InventoryId = productDTO.InventoryId,
       SupplierId = productDTO.SupplierId,
       Description = productDTO.Description,
       Rating = productDTO.Rating,
       CategoryId = productDTO.CategoryId,
       LastModified = DateTime.Now,
       ModifiedBy = productDTO.ModifiedBy
    };

    db.Products.Add(product);
    await db.SaveChangesAsync();

    productDTO = new ProductDTO(product);

    return TypedResults.Created($"/products/{product.ProductId}", productDTO);
}

static async Task<IResult> UpdateProduct(int id, ProductDTO productDTO, ProductDbContext db)
{
    var product = await db.Products.FindAsync(id);

    if (product is null) return TypedResults.NotFound();

    product.ProductName = productDTO.ProductName;
    product.InventoryId = productDTO.InventoryId;
    product.SupplierId = productDTO.SupplierId;
    product.Description = productDTO.Description;
    product.Rating = productDTO.Rating;
    product.CategoryId = productDTO.CategoryId;
    product.LastModified = DateTime.Now;
    product.ModifiedBy = productDTO.ModifiedBy;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteProduct(int id, ProductDbContext db)
{
    if (await db.Products.FindAsync(id) is Product product)
    {
        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

// Category Endpoints

static async Task<IResult> GetCategories(ProductDbContext db)
{

    var categories = await db.Categories.ToListAsync(); 
    var dtos = categories.Select(c => new CategoryDTO(c)); 
    return TypedResults.Ok(dtos);
}

    static async Task<IResult> GetCategory(int id, ProductDbContext db)
{
    return await db.Categories.FindAsync(id)
        is Category category
            ? TypedResults.Ok(new CategoryDTO(category))
            : TypedResults.NotFound();
}

static async Task<IResult> CreateCategory(CategoryDTO categoryDTO, ProductDbContext db)
{
    var category = new Category
    {
        CategoryName = categoryDTO.CategoryName,
        Description = categoryDTO.Description,  
        LastModified = DateTime.Now,
        ModifiedBy = categoryDTO.ModifiedBy
    };

    db.Categories.Add(category);
    await db.SaveChangesAsync();

    categoryDTO = new CategoryDTO(category);

    return TypedResults.Created($"/category/{category.CategoryId}", categoryDTO);
}

static async Task<IResult> UpdateCategory(int id, CategoryDTO categoryDTO, ProductDbContext db)
{
    var category = await db.Categories.FindAsync(id);

    if (category is null) return TypedResults.NotFound();

    category.CategoryName = categoryDTO.CategoryName;
    category.Description = categoryDTO.Description; 
    category.LastModified = DateTime.Now;
    category.ModifiedBy = categoryDTO.ModifiedBy;

    await db.SaveChangesAsync();

    return TypedResults.Ok();
}

static async Task<IResult> DeleteCategory(int id, ProductDbContext db)
{
    if (await db.Categories.FindAsync(id) is Category category)
    {
        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        return TypedResults.Ok();
    }

    return TypedResults.NotFound();
}



