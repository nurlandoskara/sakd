using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAKD.Models
{
    public class Branch: BaseDbObject
    {
        public int Number { get; set; }
        public string Address { get; set; }
        public string DisplayString => $"Филиал #{Number} - {Address}";
    }
}
