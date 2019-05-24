namespace SAKD.Models
{
    public class AdditionalService: BaseDbObject
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public double Price { get; set; }
        public double Percent { get; set; }
        public double TotalPrice => Price + Price * Percent / 100;
    }
}
