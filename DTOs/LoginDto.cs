using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_6._0_JWT_Authentication.Models
{
    public class LoginDto
    {


        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string Password { get; set; }
        
    }
}
