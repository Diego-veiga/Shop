using System.ComponentModel.DataAnnotations;

namespace Shop.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ente campo deve ser obrgatório ")]
        [MinLength(3,ErrorMessage ="Ente campo deve conter entre 3 a 60 caracteres ")]
        [MaxLength(60, ErrorMessage ="Este campo deve conter entre 3 á 60 caracteres")]
        public string  Title{ get; set; }
    }
}
