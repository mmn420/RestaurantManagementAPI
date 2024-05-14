using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.utils
{
    public class Utilities
    {
        public static DateOnly ParseDateInput(string dateInput)
        {
            return DateOnly.Parse(dateInput);
        }
    }
}