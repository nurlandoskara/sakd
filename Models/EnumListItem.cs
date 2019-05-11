namespace SAKD.Models
{
    public class EnumListItem
    {
        public int Int { get; set; }
        public string Name { get; set; }

        public EnumListItem(int id, string description)
        {
            Int = id;
            Name = description;
        }
    }
}
