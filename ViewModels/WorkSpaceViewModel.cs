using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SAKD.Models;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class WorkSpaceViewModel:BaseViewModel
    {
        private Node _selectedNode;
        private string _statusTitle;
        private bool _isSearchVisible;
        private ObservableCollection<EnumListItem> _searchByParams;
        private ObservableCollection<Order> _orders;

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
                if(value == null) return;
                StatusTitle = value.Name;
                SetProperty(ref _selectedNode, value);
                LoadOrders(value.Int);
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

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }

        public Order SelectedOrder { get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public WorkSpaceViewModel()
        {
            SetUpMenu();
            SearchCommand = new Command(Search, CanExecuteCommand);
            FindCommand = new Command(Find, CanExecuteCommand);
            AddCommand = new Command(Add, CanExecuteCommand);
            EditCommand = new Command(Edit, CanExecuteCommand);
            UpdateCommand = new Command(Update, CanExecuteCommand);
        }

        private void Update(object parameter)
        {
            LoadOrders(SelectedNode.Int);
        }

        private void Edit(object parameter)
        {
            if(SelectedOrder == null) return;
            using (var context = new ModelContainer())
            {
                var selectedItem = context.Orders.FirstOrDefault(x => x.Id == SelectedOrder.Id);
                var anketa = new Anketa(selectedItem, context);
                anketa.ViewModel.OnClose += ViewModel_OnClose;
                anketa.ShowDialog();
            }
        }

        private void Add(object parameter) {
            using (var context = new ModelContainer())
            { 
                var clientSearch = new ClientSearch(context);
                clientSearch.ViewModel.OnClose += ViewModel_OnClose;
                clientSearch.ShowDialog();
            }
        }
        private void ViewModel_OnClose(object sender, CustomEventArgs.OnCloseFilterViewEventArgs args)
        {
            if (!(sender is BaseViewModel vm)) return;
            vm.OnClose -= ViewModel_OnClose;
            if (!args.IsApplied) return;
            LoadOrders(SelectedNode.Int);
        }

        private void LoadOrders(int status)
        {
            using (var db = new ModelContainer())
            {
                Orders = new ObservableCollection<Order>(db.Orders.Where(x => (int) x.Status == status)
                    .Include(x => x.Branch)
                    .Include(x => x.Client)
                    .Include(x => x.Client.Document)
                    .Include(x => x.Client.Citizenship)
                    .Include(x => x.Client.RegistrationAddress)
                    .Include(x => x.Client.RegistrationAddress.Region)
                    .Include(x => x.Client.RegistrationAddress.Area)
                    .Include(x => x.Client.RegistrationAddress.City)
                    .Include(x => x.Client.LivingAddress)
                    .Include(x => x.Client.LivingAddress.Region)
                    .Include(x => x.Client.LivingAddress.Area)
                    .Include(x => x.Client.LivingAddress.City)
                    .Include(x => x.Client.ContactPerson)
                    .Include(x => x.Client.Family)
                    .Include(x => x.Client.Job)
                    .Include(x => x.Client.Job.MainJob)
                    .Include(x => x.Client.Job.MainJob.Industry)
                    .Include(x => x.Client.Job.AdditionalJob)
                    .Include(x => x.Client.Job.AdditionalJob.Industry)
                    .Include(x => x.Client.AdditionalInfo)
                    .Include(x => x.Comissions)
                    .Include(x => x.Comissions.Select(y => y.ComissionType))
                    .Include(x => x.AdditionalServices)
                    .Include(x => x.AdditionalServices.Select(y => y.Service))
                    .Include(x => x.Files)
                    .ToList());
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
                        if (SearchText?.Length != 12)
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
            SelectedNode = Nodes.FirstOrDefault(x => x.Int == 1);
        }
    }
}
