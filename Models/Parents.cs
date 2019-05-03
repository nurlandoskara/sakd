namespace SAKD.Models
{
    public class Parents:BaseDbObject
    {
        public Enums.ParentsStatus ParentsStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public int LivingAddressId { get; set; }
        public Address LivingAddress { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Comments { get; set; }
    }
}
