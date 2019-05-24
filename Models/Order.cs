using System;
using System.Collections.Generic;

namespace SAKD.Models
{
    public class Order: BaseDbObject
    {
        public DateTime Date { get; set; }
        public Enums.Status Status { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Enums.Product Product { get; set; }
        public Enums.Program Program { get; set; }
        public Enums.Method Method { get; set; }
        public Enums.Purpose Purpose { get; set; }
        public Enums.Currency Currency { get; set; }
        public int Months { get; set; }
        public int RequestSum { get; set; }
        public ICollection<AdditionalService> AdditionalServices { get; set; }
        public string Photo { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Comission> Comissions { get; set; }
    }
}
