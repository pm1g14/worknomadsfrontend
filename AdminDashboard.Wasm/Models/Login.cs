using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Wasm.Models
{
    public class Login
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}