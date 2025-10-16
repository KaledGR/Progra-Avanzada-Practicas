using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<CategoryDTO> Category { get; set; } = [];
    }
}
