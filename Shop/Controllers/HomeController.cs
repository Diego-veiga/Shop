using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Model;

namespace Shop.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
       public async Task<ActionResult<dynamic>> CadastroInicial([FromServices]DataContext context)
        {
            var employee = new User() { Id = 1, UserName = "employee Padrão", Password = "123", Role="emplyee" };
            var manager = new User() { Id = 2, UserName = "manager Padrão", Password = "123", Role = "manager" };
            var categoria = new Category() { Id = 1, Title = "Categoria Padrão" };
            var produto = new Product() { Id = 1, Descricao = "Produto padrão", Category = categoria, Precos = 299 };

            context.User.Add(employee);
            context.User.Add(manager);
            context.Category.Add(categoria);
            context.Product.Add(produto);
           await context.SaveChangesAsync();

            return Ok(new { messsage = "Objectos primariso configurados" });
        }
    }
}