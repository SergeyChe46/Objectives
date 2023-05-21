using Microsoft.AspNetCore.Mvc;
using NLog;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly NLog.ILogger _logger;
        private readonly IPerformerRepository _performerRepository;

        public PerformersController(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
            _logger = LogManager.GetCurrentClassLogger();
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

        /// <summary>
        /// Создаёт нового исполнителя.
        /// </summary>
        /// <param name="performer">Данные нового исполнителя.</param>
        /// <returns></returns>
        [HttpPost("createPerfs")]
        public async Task<ActionResult<Performer>> Create(PerformerViewModel performer)
        {
            if (performer != null)
            {
                var newPerformer = new Performer { Name = performer.Name, Email = performer.Email };
                await _performerRepository.CreatePerformerAsync(newPerformer);
                return Ok(newPerformer);
            }
            return NoContent();
        }

        /// <summary>
        /// Возвращает исполнителя с заданным адресом.
        /// </summary>
        /// <param name="email">Адрес исполнителя.</param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<ActionResult<Performer?>> GetPerformer(string email)
        {
            var currentPerformer = await _performerRepository.GetPerformer(email);
            return currentPerformer != null ? Ok(currentPerformer) : NoContent();
        }
    }
}
