using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace esercizio_1.Entities.Settings
{
    public class BaseOrderSettings
    {
        public string By { get; set; } = string.Empty;
        public bool Ascending { get; set; } = false;
        public List<string> Allow { get; set; } = [];
    }
}