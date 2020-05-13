using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices]DataContext context)
        {
           var categorias = await context.Category.AsNoTracking().ToListAsync();
            return Ok(categorias);
            

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetPorId(int id,[FromServices]DataContext context)
        {
            var categoria = await context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(categoria);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromBody] Category model, [FromServices]DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                context.Category.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possvel cadastrar a categoria " });
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody]Category model, [FromServices] DataContext context)
        {
            if (id != model.Id)
            {
                return NotFound(new { message = "Categoria não encntrada " });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(new { messsage = "Nao foi possivel atualizar a categoria " });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possivel atualizar a categoria" });
            }

            return Ok(model);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Deleta([FromServices]DataContext context, int id)
        {
            var categoria = await context.Category.SingleOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                BadRequest(new { message = "Categoria não encntrada" });
            }
            try
            {
                context.Category.Remove(categoria);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso" });
            }catch(Exception e)
            {
                return BadRequest(new {message= "Não foi possivel excluir a categoria" });
            }

            }





        }


    }
