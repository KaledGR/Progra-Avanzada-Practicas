using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class RoleViewModel
    {
        public IEnumerable<RoleDTO> Role { get; set; } = [];
    }
}
