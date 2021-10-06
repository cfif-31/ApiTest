using Microsoft.EntityFrameworkCore;
using MobileApi.Entity.Types;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApi.Entity
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApiContext:DbContext
    {
        /// <summary>
        /// Описание таблицы поэтов
        /// </summary>
        public DbSet<Poet> Poets { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        /// <param name="options">Настройки соединяния с БД</param>
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
