using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SAKD.Models;

namespace SAKD.ViewModels
{
    public class WorkSpaceViewModel:BaseViewModel
    {
        private Node _selectedNode;
        private string _statusTitle;
        private bool _isSearchVisible;
        private ObservableCollection<EnumListItem> _searchByParams;

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

        public bool IsSearchVisible
        {
            get => _isSearchVisible;
            set => SetProperty(ref _isSearchVisible, value);
        }

        public ObservableCollection<EnumListItem> SearchByParams
        {
            get => _searchByParams;
            set => SetProperty(ref _searchByParams, value);
        }

        public EnumListItem SelectedSearchByParam { get; set; }
        public string SearchText { get; set; }

        public ObservableCollection<Order> Orders { get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand FindCommand { get; set; }

        public WorkSpaceViewModel()
        {
            SetUpMenu();
            SearchCommand = new Command(Search, CanExecuteCommand);
            FindCommand = new Command(Find, CanExecuteCommand);
            using (var db = new ModelContainer())
            {
                Orders = new ObservableCollection<Order>(db.Orders.ToList());
            }
        }

        private void Find(object parameter)
        {
            using (var db = new ModelContainer())
            {
                List<Order> orders;
                switch ((Enums.SearchByParam)SelectedSearchByParam.Int)
                {
                    case Enums.SearchByParam.Iin:
                        if (SearchText.Length != 12)
                        {
                            MessageBox.Show("ИИН дұрыс емес");
                        }
                        orders = db.Orders.Where(x => x.Client.Iin.Contains(SearchText)).ToList();
                        if (orders.Any() && orders.Any(x =>
                                x.Status != Enums.Status.Accepted || x.Status != Enums.Status.Cancelled &&
                                x.Status != Enums.Status.CancelledByClient &&
                                x.Status != Enums.Status.CancelledByThird))
                        {
                            MessageBox.Show("Клиентте аяқталмаған сұраныстар бар!");
                        }
                        break;
                    case Enums.SearchByParam.Branch:
                        orders = db.Orders.Where(x => x.Branch.Name.Contains(SearchText)).ToList();
                        break;
                    case Enums.SearchByParam.Lastname:
                        orders = db.Orders.Where(x => x.Client.LastName.Contains(SearchText)).ToList();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Orders = new ObservableCollection<Order>(orders);
            }
        }


        private void SwitchVisibilities(Enums.Visibilities visible)
        {
            IsSearchVisible = visible == Enums.Visibilities.Search;
            StatusTitle = "Іздеу";
        }

        private void Search(object parameter)
        {
            SwitchVisibilities(Enums.Visibilities.Search);
            SearchByParams = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.SearchByParam>());
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
