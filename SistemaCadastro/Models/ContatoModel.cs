using System.ComponentModel.DataAnnotations;

namespace SistemaCadastro.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome {get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O nome informado não e válido!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não e válido!")]
        public string Celular { get; set; }


    }
}
