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
        Task<List<Table>> GetAllTablesAsync();
        Task<Table?> GetTableByIdAsync(int id);
        Task<Table?> CreateTableAsync(Table table);
        Task<Table?> UpdateTableAsync(int id, CreateTableDto table);
        Task<Table?> DeleteTableAsync(int id);
    }
}