using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Table;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableRepository _tableRepo;

        public TablesController(ITableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableRepo.GetAllTablesAsync();
            return Ok(tables);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTableById([FromRoute] int id)
        {
            var table = await _tableRepo.GetTableByIdAsync(id);
            if(table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTable([FromRoute] int id)
        {
            var table = await _tableRepo.DeleteTableAsync(id);
            if(table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] CreateTableDto tableDto)
        {
            Table newTable = new Table
            {
                Capacity = tableDto.Capacity
            };
            var table = await _tableRepo.CreateTableAsync(newTable);
            return Ok(table);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTable([FromRoute] int id, [FromBody] CreateTableDto tableDto)
        {
            var table = await _tableRepo.UpdateTableAsync(id, tableDto);
            if(table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
    }
}