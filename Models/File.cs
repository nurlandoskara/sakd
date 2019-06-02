using System;

namespace SAKD.Models
{
    public class File: BaseNamedObject
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public string FileType { get; set; }
    }
}
