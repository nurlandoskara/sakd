namespace SAKD.Models
{
    public class File: BaseNamedObject
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Path { get; set; }
        public Enums.FileType FileType { get; set; }
    }
}
