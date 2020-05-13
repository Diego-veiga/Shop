using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ente campo é obrigatório")]
        [MinLength(3,ErrorMessage ="Este campo deve ter no minimo 3 caratceres")]
        [MaxLength(60,ErrorMessage ="Este deve ter n maximo 60 caracteres ")]
        public String Title { get; set; }
        [MaxLength(1024,ErrorMessage ="Este campo deve conter n maximo 1024 caracteres ")]
        public string Descricao { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [Range(1,int.MaxValue,ErrorMessage ="Valor incorreto")]
        public decimal Precos { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório ")]
        [Range(1,int.MaxValue, ErrorMessage ="Valor invalido")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
