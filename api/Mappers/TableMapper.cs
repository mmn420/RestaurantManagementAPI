using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Table;
using api.Models;

namespace api.Mappers
{
    public static class TableMapper
    {
        public static TableDto ToTableDto(this Table tableModel)
        {
            return new TableDto
            {
                Id = tableModel.Id,
                Capacity = tableModel.Capacity
            };
        }
    }
}