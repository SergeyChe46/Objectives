using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objectives.Models;
using Objectives.Models.ViewModels;
using Serilog;

namespace Objectives.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private IObjectiveRepository _objectivesRepository;

        public ObjectivesController(IObjectiveRepository objectiveRepository)
        {
            _objectivesRepository = objectiveRepository;
            _logger = Log.Logger;
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
                _logger.Information("Objective {objId} was created", objective.Id);
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
            Log.Debug("Objectives done");
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
