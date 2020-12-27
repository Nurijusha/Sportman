
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Sportsman.Data.Dto;
using Sportsman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportsman.Controllers
{
    [Microsoft.AspNetCore.Components.Route("Sportsman")]
    [ApiController]
    public class SportsmanController : ControllerBase
    {
        private readonly ISportsmanService _sportsmanService;

        public SportsmanController(ISportsmanService sportsmanService)
        {
            _sportsmanService = sportsmanService;
        }

        /// <summary>
        /// Получение спортсмена по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор спортсмена.</param>
        /// <returns>Модель спортсмена.</returns>
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var sportsmanDto = await _sportsmanService.Get(id);
            return Ok(new { Success = true, Sportsman = sportsmanDto });
        }

        /// <summary> 
        /// Добавление спортсмена.
        /// </summary>
        /// <param name="sportsmanDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного спортсмена</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(SportsmanDto sportsmanDto)
        {
            return Ok(new { Success = true, SportsmanId = await _sportsmanService.Create(sportsmanDto) });
        }

        /// <summary> 
        /// Добавление спортсмена.
        /// </summary>
        /// <param name="sportsmanDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновления спортсмена.</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(SportsmanDto sportsmanDto)
        {
            return Ok(new { Success = true, SportsmanId = await _sportsmanService.Update(sportsmanDto) });
        }

        /// <summary>
        /// Удаление спортсмена.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленной спортсмена.</returns>
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sportsmanService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}
