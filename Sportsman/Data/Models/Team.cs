using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sportsman.Data.Models
{
    [Table("sports")]
    public class Team
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Column("name", TypeName = "varchar(200)")]
        public string Name { get; set; }


        /// <summary>
        /// Спорт
        /// </summary>
        [Column("sport", TypeName = "varchar(2000)")]
        public string Sport { get; set; }

        public virtual ICollection<Sportsman> Sportsmans { get; set; }
    }
}
