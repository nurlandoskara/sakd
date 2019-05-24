using System;

namespace SAKD.Models
{
    public class ComissionType: BaseDbObject
    {
        public string Name { get; set; }
        public bool SingleTime { get; set; }
        public double ComissionPercent { get; set; }
        public DateTime DateModified { get; set; }
    }
}
