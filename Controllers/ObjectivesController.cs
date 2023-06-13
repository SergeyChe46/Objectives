using Microsoft.AspNetCore.Mvc;
using NLog;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly NLog.ILogger logger;
        private IObjectiveRepository _objectivesRepository;

        public ObjectivesController(IObjectiveRepository objectiveRepository)
        {
            _objectivesRepository = objectiveRepository;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Создаёт новую задачу.
        /// </summary>
        /// <param name="newObjective">Новая задача.</param>
        /// <returns></returns>
        [HttpPost]
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
                return Ok(objective);
            }
            logger.Trace($"Wrong objective - {newObjective}");
            return NoContent();
        }

        /// <summary>
        /// Возвращает задачу по Id.
        /// </summary>
        /// <param name="id">Id задачи.</param>
        /// <returns></returns>
        [HttpGet("objective/{id:int}")]
        public async Task<IActionResult> GetObjective(int id)
        {
            var objective = await _objectivesRepository.GetObjectiveAsync(id);
            return objective != null ? Ok(objective) : NoContent();
        }

        /// <summary>
        /// Возвращает все задачи.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Objective>>> GetObjectives([FromRoute]int page = 1, [FromRoute]int pageCapacity = 5)
        {
            return await _objectivesRepository.GetObjectivesAsync(page, pageCapacity);
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
        public async Task<IActionResult> StartObjective(int objectiveId, int performerId)
        {
            await _objectivesRepository.StartObjectiveAsync(objectiveId, performerId);
            return Ok();
        }
    }
}
