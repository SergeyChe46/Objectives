using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objectives.Helpers.Logger;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IObjectiveRepository _objectivesRepository;

        public ObjectivesController(IObjectiveRepository objectiveRepository, ILoggerManager logger)
        {
            _objectivesRepository = objectiveRepository;
            _logger = logger;
        }

        /// <summary>
        /// Создаёт новую задачу.
        /// </summary>
        /// <param name="newObjective">Новая задача.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(ObjectiveViewModel newObjective)
        {
            if (newObjective != null)
            {
                Objective objective = new Objective
                {
                    Title = newObjective.Title,
                    Description = newObjective.Description,
                    Priority = newObjective.Priority
                };
                await _objectivesRepository.CreateObjectiveAsync(objective);
                _logger.LogInfo("Created");
                return Ok(objective);
            }
            return BadRequest();
        }

        /// <summary>
        /// Возвращает задачу по Id.
        /// </summary>
        /// <param name="id">Id задачи.</param>
        /// <returns></returns>
        [HttpGet("objective/{id:int}")]
        public async Task<IActionResult> GetObjective(Guid id)
        {
            var objective = await _objectivesRepository.GetObjectiveAsync(id);
            return objective != null ? Ok(objective) : NoContent();
        }

        /// <summary>
        /// Возвращает все задачи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Objective>> GetObjectives()
        {
            _logger.LogInfo("Get all Info");
            _logger.LogDebug("Get all Debug");
            _logger.LogError("Get all Error");
            return await _objectivesRepository.GetObjectivesAsync();
        }

        /// <summary>
        /// Обновляет информацию о задаче.
        /// </summary>
        /// <param name="objective">Новая информация.</param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateObjective(Objective objective)
        {
            await _objectivesRepository.UpdateObjectiveAsync(objective);
            return Ok();
        }

        /// <summary>
        /// Устанавливает исполнителя.
        /// </summary>
        /// <param name="objectiveId">Id задачи.</param>
        /// <param name="performerId">Id исполнителя.</param>
        /// <returns></returns>
        [HttpPatch("start")]
        public async Task<IActionResult> StartObjective(Guid objectiveId, Guid performerId)
        {
            await _objectivesRepository.StartObjectiveAsync(objectiveId, performerId);
            return Ok();
        }
    }
}
