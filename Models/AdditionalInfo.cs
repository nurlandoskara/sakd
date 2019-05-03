namespace SAKD.Models
{
    public class AdditionalInfo: BaseDbObject
    {
        public Enums.SourceInfo SourceInfo { get; set; }
        public bool IsAlcohol { get; set; }
        public bool IsAnotherPerson { get; set; }
        public bool IsInadequate { get; set; }
        public string Comments { get; set; }
    }
}
