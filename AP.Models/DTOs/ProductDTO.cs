
using AP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AP.Models.DTOs
{
    public class ProductDTO
    {
        [JsonPropertyName("productId")]
        public int? ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string? ProductName { get; set; }

        [JsonPropertyName("inventoryId")]
        public int? InventoryId { get; set; }

        [JsonPropertyName("supplierId")]
        public int? SupplierId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("rating")]
        public decimal? Rating { get; set; }

        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

       


        public ProductDTO() { }
        public ProductDTO(Product product)
        {
            (ProductId, ProductName, InventoryId, SupplierId, Description, Rating, CategoryId, LastModified, ModifiedBy) = (product.ProductId, product.ProductName, product.InventoryId, product.SupplierId, product.Description, product.Rating, product.CategoryId, product.LastModified, product.ModifiedBy);
        }
    }
}
