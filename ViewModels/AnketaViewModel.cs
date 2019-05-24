using SAKD.Models;
using SAKD.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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
        private readonly ModelContainer _context;
        public override event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };
        public Order Order { get; set; }
        public ObservableCollection<AdditionalService> AdditionalServices { get; set; }

        public ObservableCollection<EnumListItem> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public EnumListItem SelectedProduct { get; set; }

        public ObservableCollection<EnumListItem> Programs
        {
            get => _programs;
            set => SetProperty(ref _programs, value);
        }
        public EnumListItem SelectedProgram { get; set; }

        public ObservableCollection<EnumListItem> Methods
        {
            get => _methods;
            set => SetProperty(ref _methods, value);
        }

        public EnumListItem SelectedMethod { get; set; }

        public ObservableCollection<EnumListItem> Purposes
        {
            get => _purposes;
            set => SetProperty(ref _purposes, value);
        }
        public EnumListItem SelectedPurpose { get; set; }

        public ObservableCollection<EnumListItem> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }
        public EnumListItem SelectedCurrency { get; set; }

        public ObservableCollection<Comission> Comissions { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }
        public ICommand TakeCommand { get; set; }

        public AnketaViewModel(Anketa view, Order order, ModelContainer context)
        {
            _view = view;
            _context = context;
            Order = order;
            Products = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Product>());
            SelectedProduct = Products.FirstOrDefault(x => x.Int == (int)Order.Product);
            Programs = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Program>());
            SelectedProgram = Programs.FirstOrDefault(x => x.Int == (int) Order.Program);
            Methods = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Method>());
            SelectedMethod = Methods.FirstOrDefault(x => x.Int == (int) Order.Method);
            Purposes = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Purpose>());
            SelectedPurpose = Purposes.FirstOrDefault(x => x.Int == (int) Order.Purpose);
            Currencies = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Currency>());
            SelectedCurrency = Currencies.FirstOrDefault(x => x.Int == (int) Order.Currency);
            Comissions = new ObservableCollection<Comission>(Order.Comissions);
            AdditionalServices = new ObservableCollection<AdditionalService>(Order.AdditionalServices);
            OkCommand = new Command(Save, CanExecuteCommand);
            AddServiceCommand = new Command(AddService, CanExecuteCommand);
            EditServiceCommand = new Command(EditService, CanExecuteCommand);
            TakeCommand = new Command(TakePhoto, CanExecuteCommand);
        }

        private void TakePhoto(object parameter)
        {
        }

        private void EditService(object parameter)
        {
            
        }

        private void AddService(object parameter)
        {
            var view = new AddService(AdditionalServices);
            view.ShowDialog();
        }

        private void Save(object parameter)
        {
            if (SelectedPurpose == null || SelectedMethod == null || SelectedCurrency == null ||
                SelectedProduct == null || SelectedProgram == null)
            {
                MessageBox.Show("Барлық мәліметтерді енгізіңіз");
                return;
            }

            Order.Purpose = (Enums.Purpose)SelectedPurpose.Int;
            Order.Program = (Enums.Program)SelectedProgram.Int;
            Order.Product = (Enums.Product)SelectedProduct.Int;
            Order.Currency = (Enums.Currency)SelectedCurrency.Int;
            Order.Method = (Enums.Method)SelectedMethod.Int;
            Order.Comissions = Comissions.ToList();
            Order.AdditionalServices = AdditionalServices.ToList();
            _context.SaveChanges();
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
