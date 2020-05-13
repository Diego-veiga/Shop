using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return new List<Category>();

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetPorId(int id)
        {
            return new Category();
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromBody] Category model,[FromServices]DataContext context)
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
            }catch(Exception e)
            {
                return BadRequest(new { message = " Infelizmente Não foi possvel cadastrar a categoria " });
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody]Category model)
        {
          if(id!= model.Id)
            {
                return NotFound(new { message = "Categoria não encntrada " });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(model);
        }
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Category>> deleta ()
        {
            return Ok();

        }


    }
}