namespace SAKD.Models
{
    public class Address: BaseDbObject
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Block { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
    }
}
