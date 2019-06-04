using System;
using System.Collections.Generic;

namespace SAKD.Models
{
    public class Order: BaseDbObject
    {
        public DateTime Date { get; set; }
        public Enums.Status Status { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Enums.Product Product { get; set; }
        public Enums.Program Program { get; set; }
        public Enums.Method Method { get; set; }
        public Enums.Purpose Purpose { get; set; }
        public Enums.Currency Currency { get; set; }
        public int Months { get; set; }
        public int RequestSum { get; set; }
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Comission> Comissions { get; set; }
        public bool IsClientAccepted { get; set; }
        public int MonthlyDate { get; set; }
        public bool IsVisaInstant { get; set; }
        public string Pan { get; set; }
        public string Comment { get; set; }
        public string CodeWord { get; set; }
    }
}
