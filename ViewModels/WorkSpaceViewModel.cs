using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SAKD.Models;

namespace SAKD.ViewModels
{
    public class WorkSpaceViewModel:BaseViewModel
    {
        private Node _selectedNode;
        private string _statusTitle;

        public string StatusTitle
        {
            get => _statusTitle;
            set => SetProperty(ref _statusTitle, value);
        }

        public ObservableCollection<Node> Nodes { get; set; }

        public Node SelectedNode
        {
            get => _selectedNode;
            set
            {
                StatusTitle = value?.Name;
                SetProperty(ref _selectedNode, value);
            }
        }

        public WorkSpaceViewModel()
        {
            SetUpMenu();
        }

        public void SetUpMenu()
        {
            var statusItems = EnumHelper.EnumList<Enums.Status>();
            Nodes = new ObservableCollection<Node>();
            var node = new Node
            {
                Name = "Белсенділер",
                Nodes = new ObservableCollection<Node>(statusItems.Where(x => x.Int > 0 && x.Int < 22)
                    .Select(x => new Node { Name = x.Name, Int = x.Int }).ToList())
            };
            Nodes.Add(node);
            node = new Node
            {
                Name = "Алдын ала мақұлданғандар",
                Nodes = new ObservableCollection<Node>(statusItems.Where(x => x.Int > 21 && x.Int < 25)
                    .Select(x => new Node { Name = x.Name, Int = x.Int }).ToList())
            };
            Nodes.Add(node);
            node = new Node
            {
                Name = "Аяқталғандар",
                Nodes = new ObservableCollection<Node>(statusItems.Where(x => x.Int > 24 && x.Int < 29)
                    .Select(x => new Node { Name = x.Name, Int = x.Int }).ToList())
            };
            Nodes.Add(node);
            node = new Node
            {
                Name = "Барлығы",
                Int = 0
            };
            Nodes.Add(node);
        }
    }
}
