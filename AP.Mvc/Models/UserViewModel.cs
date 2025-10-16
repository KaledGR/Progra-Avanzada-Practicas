using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class UserViewModel
    {
        public IEnumerable<UserDTO> User { get; set; } = [];
    }
}
