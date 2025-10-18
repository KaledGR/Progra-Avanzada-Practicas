using AP.Core.BusinessLogic;
using AP.Data.Models;
using AP.Data.Repositories;
using AP.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Se agrega el uso de lazy Loading Virtual Proxy, que es una de las formas para implementar la carga diferida de datos, este se menciona en
// en el catalogo de patrones de diseño, este UseLazyLoadingProxies se agrega en el contexto de la base de datos y para su uso se debe de instalar el nugget
// Microsoft.EntityFrameworkCore.Proxies , pero el verdadero uso de este patron se hace en la clase CategoryDTO en models en la propiedad Products donde se hace uso de
// virtual para que funcione el lazy loading.
//Porque se escogio este patron:
//Este ayuda a mejorar el rendimiento de la aplicacion y optimizar los recursos, porque este lo que hace es cargar los datos solo cuando estos realmente se necesitan
//en lugar de tener que tenerlo todo guardado desde el inicio, lo que nos da la ventaja de que no tenemos que manejar tanta informacion en nuestro entorno . Este se puede notar de mejor manera si
//se piensa en u entorno donde se generen consultas muy pesadas, este patron distribuye estas consultas de una manera mas eficiente, haciendo asi que el sistema sea mas rapido
//y responda mejor ante grandes volumenes de informacion. Pero es muy importante tener en cuenta cuando conviene hacer uso del lazy loading y cuando no, ya que en algunos casos
//puede llegar a generar consultas innecesarias.

builder.Services.AddDbContext<ProductDbContext>(options =>
    options
    .UseLazyLoadingProxies(true)
    .UseSqlServer("Server=DESKTOP-PE6BDTN;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;"));





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

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteCategory(int id, ProductDbContext db)
{
    if (await db.Categories.FindAsync(id) is Category category)
    {
        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}



