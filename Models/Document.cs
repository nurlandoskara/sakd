using System;

namespace SAKD.Models
{
    public class Document : BaseDbObject
    {
        public Enums.DocumentType Type { get; set; }
        public string Number { get; set; }
        public Enums.DocumentOrganization Organization { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
