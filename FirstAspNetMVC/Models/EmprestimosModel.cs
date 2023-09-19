using System.ComponentModel.DataAnnotations;

namespace FirstAspNetMVC.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Recebedor") ]
        public string Recebedor { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Fornecedor")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Titulo")]
        public string Titulo { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
