using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApi.Entity.Types
{
    /// <summary>
    /// Поэт
    /// </summary>
    public class Poet
    {
        /// <summary>
        /// Идентификатор поэта
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required, MaxLength(32)]
        public string FirstName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required, MaxLength(32)]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Required, MaxLength(32)]
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required, Column(TypeName ="Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Дата смерти
        /// </summary>
        [Column(TypeName = "Date"), DataType(DataType.Date)]
        public DateTime DeadDate { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [MaxLength(1024)]
        public string Description { get; set; }
    }
}
