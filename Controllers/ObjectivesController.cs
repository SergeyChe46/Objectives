using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Objectives.Models;
using Objectives.Models.ViewModels;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Objectives.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost("createObjective")]
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
        [HttpGet("all")]
        public async Task<ActionResult<List<Objective>>> GetObjectives()
        {
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
        [HttpPatch("take")]
        public async Task<IActionResult> StartObjective(int objectiveId, int performerId)
        {
            await _objectivesRepository.StartObjectiveAsync(objectiveId, performerId);
            return Ok();
        }
    }
}
