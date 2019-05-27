namespace SAKD.Models
{
    public class ContactPerson:BaseDbObject
    {
        public Enums.RelationType RelationType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string MobilePhone { get; set; }
    }
}
