using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sportsman.Data.Models
{
    /// <summary>
    /// Спортсмены.
    /// </summary>
    [Table("sportsmans")]
    public class Sportsman
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Column("name", TypeName = "varchar(150)")]
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Column("age", TypeName = "integer")]
        public int Age { get; set; }

        /// <summary>
        /// Опыт
        /// </summary>
        [Column("experience", TypeName = "numeric")]
        public double Experience { get; set; }

        [Column("team_id", TypeName = "integer")]
        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
