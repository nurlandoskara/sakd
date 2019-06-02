namespace SAKD.Models
{
    public class Offer
    {
        public string Combination => "Сұраным бойынша";
        public double Total { get; set; }
        public double Refinance { get; set; }
        public double EndTotal { get; set; }
        public int Months { get; set; }
        public double Monthly => EndTotal / Months;
    }
}
