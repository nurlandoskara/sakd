namespace SAKD.Models
{
    public class Address: BaseDbObject
    {
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
        public int? AreaId { get; set; }
        public virtual Area Area { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Block { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }

        public string DisplayString =>
            $"{Region?.Name}, {Area?.Name}, {City?.Name}, {Street}, {House}, {Block}, {Building}, {Apartment}";
    }
}
