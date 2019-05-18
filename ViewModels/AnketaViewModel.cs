using System.Collections.ObjectModel;
using SAKD.Models;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class AnketaViewModel: BaseViewModel
    {
        private readonly Anketa _view;
        private ObservableCollection<EnumListItem> _products;
        private ObservableCollection<EnumListItem> _programs;
        private ObservableCollection<EnumListItem> _methods;
        private ObservableCollection<EnumListItem> _purposes;
        private ObservableCollection<EnumListItem> _currencies;
        public override event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };
        public Order Order { get; set; }

        public ObservableCollection<EnumListItem> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ObservableCollection<EnumListItem> Programs
        {
            get => _programs;
            set => SetProperty(ref _programs, value);
        }

        public ObservableCollection<EnumListItem> Methods
        {
            get => _methods;
            set => SetProperty(ref _methods, value);
        }

        public ObservableCollection<EnumListItem> Purposes
        {
            get => _purposes;
            set => SetProperty(ref _purposes, value);
        }

        public ObservableCollection<EnumListItem> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }

        public AnketaViewModel(Anketa view, Order order)
        {
            _view = view;
            Order = order;
            Products = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Product>());
            Programs = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Program>());
            Methods = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Method>());
            Purposes = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Purpose>());
            Currencies = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Currency>());
            OkCommand = new Command(Save, CanExecuteCommand);
        }

        private void Save(object parameter)
        {
            using (var db = new ModelContainer())
            {
                db.SaveChanges();
            }
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
