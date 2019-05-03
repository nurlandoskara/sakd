using System.Collections.Generic;

namespace SAKD.Models
{
    public class Order: BaseDbObject
    {
        public Enums.Status Status { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Enums.Product Product { get; set; }
        public Enums.Program Program { get; set; }
        public Enums.Method Method { get; set; }
        public Enums.Purpose Purpose { get; set; }
        public int Months { get; set; }
        public int RequestSum { get; set; }
        public ICollection<AdditionalService> AdditionalServices { get; set; }
        public string Photo { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
