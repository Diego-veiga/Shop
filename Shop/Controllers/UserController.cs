using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Shop.Data;
using Shop.Model;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> ListaUsuarios([FromServices]DataContext context)
        {
            var users = await context.User.AsNoTracking().ToListAsync();
            return users;

        }

        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<User>> CadastraUsuarios([FromServices]DataContext context,[FromBody] User model)
        {
            if (!ModelState.IsValid)
            
                return BadRequest(new { message = "Dados do usuário invalido" });

            
            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                BadRequest(new { message = "Não foi possivel cadastrar  o usuario " });
            }
            model.Password = "";
            return Ok(model);

        }
        [HttpPut]
        [Route("")]
        [Authorize(Roles ="manager")]
        public async Task<ActionResult<User>>AlteraUsuario([FromServices]DataContext context, int id, [FromBody]User model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(new { message = "Usuario invalido" });
            }
            if (model.Id != id)
            {
                BadRequest(new { message = "Id informado não corresponde com o id do usuario" });
            }
            try
            {
                context.Entry<User>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            catch (Exception)
            {
                BadRequest(new { Message = "Não foi possivel concluir a ateração " });

            }
            ;
            return Ok(model);
            
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<dynamic>>Authenticate ([FromServices]DataContext conext, [FromBody] User Model)
        {
            var user = await conext.User.AsNoTracking().Where(x => x.UserName == Model.UserName && x.Password == Model.Password).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { message = "Não foi possivel localizar o usuario" });
                
            }
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

       
    }
}