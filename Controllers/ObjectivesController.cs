using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Objectives.Models;
using Objectives.Models.ViewModels;
using System;

namespace Objectives.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private IObjectiveRepository _objectivesRepository;
        public ObjectivesController(IObjectiveRepository objectiveRepository)
        {
            _objectivesRepository = objectiveRepository;
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
        /// Возвращает задачи с заданным заголовком.
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <returns></returns>
        [HttpGet("title/{title:alpha}")]
        public async Task<ActionResult<List<Objective>>> GetObjectives(string title)
        {
            if(title != null)
            {
                var objectives = await _objectivesRepository.GetObjectivesAsync(title);
                return objectives != null ? Ok(objectives) : NoContent();
            }
            return BadRequest();
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
        /// Возвращает задачи с заданным приоритетом.
        /// </summary>
        /// <param name="priority">Приоритет.</param>
        /// <returns></returns>
        [HttpGet("{priority:alpha}")]
        public async Task<ActionResult<List<Objective>>> GetObjectivesByPriority(string priority)
        {
            if(priority.Trim().ToLower() != "" || priority != null)
            {
                var objectives = await _objectivesRepository.GetObjectivesAsync(priority);
                return Ok(objectives);
            }
            return BadRequest(priority);
        }

        /// <summary>
        /// Возвращает все задачи исполнителя.
        /// </summary>
        /// <param name="id">Id исполнителя.</param>
        /// <returns></returns>
        [HttpGet("performer/{id:int}")]
        public async Task<ActionResult<List<Objective>>> GetObjectivesByPerformer(int id)
        {
            var objectives = await _objectivesRepository.GetObjectivesByPerformerAsync(id);
            return Ok(objectives);
        }

        /// <summary>
        /// Обновляет информацию о задаче.
        /// </summary>
        /// <param name="objective">Новая информация.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateObjective(Objective objective)
        {
            await _objectivesRepository.UpdateObjectiveAsync(objective);
            return Ok();
        }

        /// <summary>
        /// Устанавливает исполнителя.
        /// </summary>
        /// <param name="objectiveId"></param>
        /// <param name="performerId"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> StartObjective(int objectiveId, int performerId)
        {
            await _objectivesRepository.StartObjectiveAsync(objectiveId, performerId);
            return Ok();
        }
    }
}
