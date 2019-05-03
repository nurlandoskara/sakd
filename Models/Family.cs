namespace SAKD.Models
{
    public class Family : BaseDbObject
    {
        public Enums.FamilyStatus FamilyStatus { get; set; }
        public int DependantsCount { get; set; }
        public bool HasRealProperty { get; set; }
        public bool HasMovableProperty { get; set; }
    }
}
