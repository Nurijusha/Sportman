using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportsman.Data.Models;
using Sportsmans.Mongo;
using Sportsman.Mongo.Model;
using Sportsman.Services;
using Microsoft.AspNetCore.Mvc;


namespace Sportsman.Controllers
{
    [Route("Events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventsService _eventService;

        public EventController(EventsService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Получение cпортсменов по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор спортсмена.</param>
        /// <returns>Модель судьи.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(string id)
        {
            var sportsmanDto = await _eventService.Get(id);
            return Ok(new { Success = true, Event = sportsmanDto });
        }

        /// <summary>
        /// Добавление спортсмена.
        /// </summary>
        /// <param name="sportsmanDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного спортсмена.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(Event sportsmanDto)
        {
            return Ok(new { Success = true, EventId = await _eventService.Create(sportsmanDto) });
        }

        /// <summary>
        /// Обновление спортсмена.
        /// </summary>
        /// <param name="sportsmanDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленного спортсмена.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(Event sportsmanDto)
        {
            await _eventService.Update(sportsmanDto);

            return Ok(new { Success = true });
        }

        /// <summary>
        /// Удаление спортсмена.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленного спортсмена</returns>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}
