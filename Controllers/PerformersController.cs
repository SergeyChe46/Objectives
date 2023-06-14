using Microsoft.AspNetCore.Mvc;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly IPerformerRepository _performerRepository;

        public PerformersController(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        /// <summary>
        /// Возвращает всех исполнителей.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Performer>>> GetAll()
        {
            var performers = await _performerRepository.GetAllPerformers();
            return Ok(performers);
        }

        /// <summary>
        /// Возвращает свободных исполнителей.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/free")]
        public async Task<ActionResult<List<Performer>>> GetFreePerformers()
        {
            var performers = await _performerRepository.GetFreePerformers();
            return Ok(performers);
        }

        /// <summary>
        /// Создаёт нового исполнителя.
        /// </summary>
        /// <param name="performer">Данные нового исполнителя.</param>
        /// <returns></returns>
        //[HttpPost("/create")]
        //public async Task<ActionResult<Performer>> Create([FromBody] PerformerViewModel performer)
        //{
        //    if (performer != null)
        //    {
        //        var newPerformer = new Performer { Email = performer.Email };
        //        await _performerRepository.CreatePerformerAsync(newPerformer);
        //        return CreatedAtAction(nameof(Create), newPerformer);
        //    }
        //    return BadRequest();
        //}

        /// <summary>
        /// Возвращает исполнителя с заданным адресом.
        /// </summary>
        /// <param name="email">Адрес исполнителя.</param>
        /// <returns></returns>
        [HttpGet("/{email:alpha}")]
        public async Task<ActionResult<Performer?>> GetPerformer(string email)
        {
            var currentPerformer = await _performerRepository.GetPerformer(email);
            return currentPerformer != null ? Ok(currentPerformer) : NoContent();
        }
    }
}
