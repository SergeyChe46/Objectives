using Microsoft.AspNetCore.Mvc;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("allPerfs")]
        public async Task<ActionResult<List<Performer>>> GetAll()
        {
            var performers = await _performerRepository.GetAllPerformers();
            return Ok(performers);
        }

        /// <summary>
        /// Возвращает свободных исполнителей.
        /// </summary>
        /// <returns></returns>
        [HttpGet("freePerfs")]
        public async Task<ActionResult<List<Performer>>> GetFreePerformers()
        {
            var performers = await _performerRepository.GetFreePerformers();
            return Ok(performers);
        }

        [HttpPost("createPerfs")]
        public async Task<ActionResult<Performer>> Create(PerformerViewModel performer)
        {
            if (performer != null)
            {
                var newPerformer = new Performer
                {
                    Name = performer.Name,
                    Email = performer.Email
                };
                await _performerRepository.CreatePerformerAsync(newPerformer);
                return Ok(newPerformer);
            }
            return NoContent();
        }
    }
}
