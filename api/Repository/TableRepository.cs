using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Table;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDBContext _context;

        public TableRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TableDto?> CreateTableAsync(Table table)
        {

            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
            return table.ToTableDto();
        }

        public async Task<TableDto?> DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if(table == null)
            {
                return null;
            }
            else
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
                return table.ToTableDto();
            }
        }

        public async Task<List<TableDto>> GetAllTablesAsync()
        {
            var tables = await _context.Tables.ToListAsync();
            return tables.Select(x => x.ToTableDto()).ToList();
        }

        public async Task<TableDto?> GetTableByIdAsync(int id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if(table == null)
            {
                return null;
            }
            else
            {
                return table.ToTableDto();
            }
        }

        public async Task<TableDto?> UpdateTableAsync(int id, CreateTableDto table)
        {
            var existingTable = await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if(existingTable == null)
            {
                return null;
            }
            else
            {
                existingTable.Capacity = table.Capacity;
                await _context.SaveChangesAsync();
                return existingTable.ToTableDto();
            }
        }
    }
}