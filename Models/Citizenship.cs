namespace SAKD.Models
{
    public class Citizenship: BaseNamedObject
    {
        public int Code { get; set; }
        public string DisplayString => $"{Code} - {Name}";
    }
}
