namespace SAKD.Models
{
    public class City: BaseNamedObject
    {
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
