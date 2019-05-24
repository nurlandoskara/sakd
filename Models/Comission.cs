namespace SAKD.Models
{
    public class Comission:BaseDbObject
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ComissionTypeId { get; set; }
        public ComissionType ComissionType { get; set; }
        public double Total => Order.RequestSum * ComissionType.ComissionPercent / 100;
    }
}
