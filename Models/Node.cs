using System.Collections.ObjectModel;

namespace SAKD.Models
{
    public class Node
    {
        public string Name { get; set; }
        public int Int { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
