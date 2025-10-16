using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class InventorViewModel
    {
        public IEnumerable<InventoryDTO> Inventor { get; set; } = [];
    }
}
