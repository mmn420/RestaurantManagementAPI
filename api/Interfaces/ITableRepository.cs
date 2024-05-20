using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Table;
using api.Models;

namespace api.Interfaces
{
    public interface ITableRepository
    {
        Task<List<TableDto>> GetAllTablesAsync();
        Task<TableDto?> GetTableByIdAsync(int id);
        Task<TableDto?> CreateTableAsync(Table table);
        Task<TableDto?> UpdateTableAsync(int id, CreateTableDto table);
        Task<TableDto?> DeleteTableAsync(int id);
    }
}