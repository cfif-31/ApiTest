using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileApi.Entity;
using MobileApi.Entity.Types;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApi.Controllers
{
    /// <summary>
    /// Конструктор контроллера - принимает контекст БД
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PoetsController : ControllerBase
    {
        private readonly ApiContext _DbContext;

        /// <summary>
        /// Конструктор контроллера - принимает контекст БД
        /// </summary>
        /// <param name="DbContext"></param>
        public PoetsController(ApiContext DbContext)
        {
            _DbContext = DbContext;
        }

        /// <summary>
        /// Получение списка поэтов
        /// </summary>
        /// <param name="search">Поисковой запрос</param>
        /// <returns>Список поэтов</returns>
        [HttpGet]
        public IEnumerable<Poet> Get(string search = "")
        {
            return _DbContext.Poets.Where(
                p=>p.FirstName.ToLower().Contains(search.ToLower()) || 
                   p.LastName.ToLower().Contains(search.ToLower()) ||
                   p.MiddleName.ToLower().Contains(search.ToLower())
                );
        }

        /// <summary>
        /// Получение поэта по id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<Poet> Get(int id)
        {
            return await _DbContext.Poets.FindAsync(id);
        }

        /// <summary>
        /// Создание нового поэта
        /// </summary>
        /// <param name="poet">Информация о поэте</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Poet poet)
        {
            _DbContext.Poets.Add(poet);
            await _DbContext.SaveChangesAsync();
            return Accepted();
        }

        /// <summary>
        /// Изменение поэта
        /// </summary>
        /// <param name="id">Идентификатор поэта</param>
        /// <param name="poet">Информация о поэте</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Poet poet) {
            if (id != poet.Id)
                return BadRequest();

            Poet SelectPoet = await _DbContext.Poets.FindAsync(poet.Id);
            if (SelectPoet == null)
                return NotFound();

            SelectPoet.FirstName = poet.LastName;
            SelectPoet.LastName = poet.LastName;
            SelectPoet.MiddleName = poet.MiddleName;
            SelectPoet.BirthDate = poet.BirthDate;
            SelectPoet.DeadDate = poet.DeadDate;
            SelectPoet.Description = poet.Description;
            
            await _DbContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Удаление поэта
        /// </summary>
        /// <param name="Id">Идентификатор поэта</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id) {
            Poet SelectPoet = await _DbContext.Poets.FindAsync(Id);
            if (SelectPoet == null)
                return NotFound();

            _DbContext.Poets.Remove(SelectPoet);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
