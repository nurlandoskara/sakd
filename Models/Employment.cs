namespace SAKD.Models
{
    public class Employment: BaseNamedObject
    {
        public int? IndustryId { get; set; }
        public virtual Industry Industry { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PositionCategory { get; set; }
        public int WorkExperience { get; set; }
        public int CompanyEmployeesCount { get; set; }
        public string DisplayString => $"{Industry?.Name} - {PositionCategory}";
    }
}
