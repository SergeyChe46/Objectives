using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Objectives.Models;

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
        [HttpGet("all")]
        public async Task<ActionResult<List<Performer>>> GetAll()
        {
            var performers = await _performerRepository.GetAllPerformers();
            return Ok(performers);
        }

        /// <summary>
        /// Возвращает свободных исполнителей.
        /// </summary>
        /// <returns></returns>
        [HttpGet("free")]
        public async Task<ActionResult<List<Performer>>> GetFreePerformers()
        {
            var performers = await _performerRepository.GetFreePerformers();
            return Ok(performers);
        }

    }
}
