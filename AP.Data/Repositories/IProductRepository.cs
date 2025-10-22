using AP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Data.Repositories
{
    //Patrón de diseño: Repository Pattern
    //Motivo de eleccion: Esta patron se implementa para poder dar una interfaz mas limpia y organizada a la hora de interactuar con las fuentes de datos.
    //Justificacion tecnica: Con este patron hacemos que el acceso de los datos sea mas sencillo y mantenible, ya que encapsulamos la logica de
    //acceso a datos en una capa separada. Ademas esto faciliita la implementacion de los metodos y no tenemos que tener toda esta logica dentro del controller
    //lo que hace mas limpio el codigo, el problema se causa cuando toca hacer cambios en esta logica de acceso a datos, lo que poroduce que se tenga que reescribir mucho codigo.


    public interface IProductRepository
    {

        IEnumerable<Product> GetAllProducts();
        Product getById(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void save();

    }


    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product getById(int id)
        {
            return _context.Products.Find(id);
        }
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }

}
