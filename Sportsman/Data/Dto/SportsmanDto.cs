using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportsman.Data.Dto
{
    /// <summary>
    /// Спортсмен.
    /// </summary>
    public class SportsmanDto
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Опыт
        /// </summary>
        public double Experience { get; set; }

        /// <summary>
        /// Идентификатор вида спорта.
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public string TeamName { get; set; }
    }
}
