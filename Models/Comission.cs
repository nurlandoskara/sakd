namespace SAKD.Models
{
    public class Comission:BaseDbObject
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ComissionTypeId { get; set; }
        public virtual ComissionType ComissionType { get; set; }
        public double Total => ComissionType.ComissionPercent / 100;
    }
}
