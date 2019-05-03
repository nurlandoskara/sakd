using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAKD.Models
{
    public class AdditionalService: BaseDbObject
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public double Price { get; set; }
        public double Percent { get; set; }
        public double TotalPrice => Price + Price * Percent / 100;
    }
}
