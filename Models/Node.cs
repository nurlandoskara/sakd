using System.Collections.ObjectModel;
using System.Windows;

namespace SAKD.Models
{
    public class Node
    {
        public string Name { get; set; }
        public int Int { get; set; }
        public FontWeight FontWeight { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
