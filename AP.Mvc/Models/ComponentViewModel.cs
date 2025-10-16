using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class ComponentViewModel
    {
        public IEnumerable<ComponentDTO> Component { get; set; } = [];
    }
}
