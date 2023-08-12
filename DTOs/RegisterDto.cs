using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_6._0_JWT_Authentication.Models
{
    public class RegisterDto
    {




        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Sobrenome é obrigatório!")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Idade é obrigatório!")]
        public int Age { get; set; }



        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem!")]
        public string ConfirmPassword { get; set; }
    }
}
