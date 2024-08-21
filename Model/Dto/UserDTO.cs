using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8WebAPI.Model
{
    public class UserDTO
    {

        public required string FirstName { get; set; } = string.Empty;    
        public string LastName { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
        public bool isActive { get; set; } = false;

    }
}
