namespace SAKD.Models
{
    public class Employment: BaseNamedObject
    {
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string PositionCategory { get; set; }
        public int WorkExperience { get; set; }
        public int CompanyEmployeesCount { get; set; }
    }
}
