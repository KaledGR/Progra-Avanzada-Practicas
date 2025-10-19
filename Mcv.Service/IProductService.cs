using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcv.Service
{

    // Patrón de diseño: Service Layer
    // Motivo de elección: Este patrón es muy parecido a cómo hemos trabajado con el Service Locator, separando los modelos y servicios en distintas capas.
    // Justificación técnica: Se implementa dentro del MVC para organizar mejor el código. Es útil cuando una acción empieza a ser robusta y necesitamos separar la lógica de negocio del controlador.
    // Esto permite tener funcionalidades encapsuladas en los servicios, evitando saturar el controlador con lógica compleja y organizar de una mejor manera el codigo.



    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
    }

    public class ProductService(ProductDbContext context) : IProductService
    {

        private readonly ProductDbContext _context = context;

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
