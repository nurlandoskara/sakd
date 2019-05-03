namespace SAKD.Models
{
    public class Area: BaseNamedObject
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
