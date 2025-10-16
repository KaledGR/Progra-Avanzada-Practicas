using AP.Models.DTOs;

namespace AP.Mvc.Models
{
    public class TaskViewModel
    {
        public IEnumerable<TaskDTO> Task { get; set; } = [];
    }
}
