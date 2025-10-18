using AP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP.Models.DTOs
{
    public class CategoryDTO
    {
        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }


        [JsonPropertyName("products")]
        public List<ProductDTO>? Products { get; set; }


        public CategoryDTO() { }

        public CategoryDTO(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
            Description = category.Description;
            LastModified = category.LastModified;
            ModifiedBy = category.ModifiedBy;

            //Aqui hace la consulta de los productos relacionados a la categoria (Lazy Loading)
            Products = category.Products?.Select(p => new ProductDTO(p)).ToList();
        }

    }
}
