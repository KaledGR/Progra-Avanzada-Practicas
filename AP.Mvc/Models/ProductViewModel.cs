using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDTO> Product { get; set; } = [];
    }
}
