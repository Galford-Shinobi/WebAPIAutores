using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.Common.Applications.Interfaces;
using WebAPIAutores.Common.Entities;

namespace WebAPIAutores.Controllers
{

    public class AutoresController : BaseApiController
    {
        private readonly IAuthorRepository _authorRepository;

        public AutoresController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public async  Task<ActionResult<List<Autor>>> Get()
        {
           var result = await  _authorRepository.GetAllAuthorsAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.ListResults);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor model) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exist = await _authorRepository.RecordExistsAsync(model);

                    if (exist.IsSuccess)
                    {
                        return BadRequest(exist.ErrorMessage);
                    }

                    var result = await _authorRepository.AddAsync(model);

                    if (!result.IsSuccess)
                    {
                        return BadRequest(exist.ErrorMessage);
                    }
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor model, int id)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest("the author's id does not match the url's!");
                }

                if (ModelState.IsValid)
                {
                    var exist = await _authorRepository.RecordExistsAsync(model);

                    if (exist.IsSuccess)
                    {
                        return BadRequest(exist.ErrorMessage);
                    }

                    var result = await _authorRepository.UpdateAsync(model);

                    if (!result.IsSuccess)
                    {
                        return BadRequest(exist.ErrorMessage);
                    }
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")] // api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _authorRepository.GetAuthorByIdAsync(id);

            if (!existe.IsSuccess)
            {
                return NotFound();
            }

            //context.Remove(new Autor() { Id = id });
            var result = await _authorRepository.DeleteAsync(existe.Result);
            if (!result.IsSuccess) {
                return BadRequest(result.ErrorMessage);
            }
            return NoContent();
        }
    }
}
