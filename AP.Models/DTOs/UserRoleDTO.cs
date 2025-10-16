using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP.Models.DTOs
{
    public class UserRoleDTO
    {
        [JsonPropertyName("id")]
        public decimal? Id { get; set; }

        [JsonPropertyName("roleId")]
        public decimal? RoleID { get; set; }

        [JsonPropertyName("userId")]
        public decimal? UserID { get; set; }
    }
}
