using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório ")]
        [MaxLength(20,ErrorMessage ="Est7e campo deve ter n maximo 20 caracteres")]
        [MinLength(3,ErrorMessage ="Este campo deve conter no minimo 3 caractres")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório ")]
        [MaxLength(20, ErrorMessage = "Est7e campo deve ter n maximo 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no minimo 3 caractres")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
