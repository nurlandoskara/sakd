using SAKD.Models;
using SAKD.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        private bool _isPhoto;
        private ImageSource _photo;
        private ObservableCollection<Citizenship> _citizenships;
        private ObservableCollection<EnumListItem> _sexes;
        private ObservableCollection<EnumListItem> _pensions;
        private ObservableCollection<EnumListItem> _educations;
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

        public ObservableCollection<Citizenship> Citizenships
        {
            get => _citizenships;
            set => SetProperty(ref _citizenships, value);
        }
        public Citizenship SelectedCitizenship { get; set; }

        public ObservableCollection<EnumListItem> Sexes
        {
            get => _sexes;
            set => SetProperty(ref _sexes, value);
        }
        public EnumListItem SelectedSex { get; set; }

        public ObservableCollection<EnumListItem> Pensions
        {
            get => _pensions;
            set => SetProperty(ref _pensions, value);
        }
        public EnumListItem SelectedPension { get; set; }

        public ObservableCollection<EnumListItem> Educations
        {
            get => _educations;
            set => SetProperty(ref _educations, value);
        }
        public EnumListItem SelectedEducation { get; set; }

        public ObservableCollection<Comission> Comissions { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }

        public bool IsPhoto
        {
            get => _isPhoto;
            set => SetProperty(ref _isPhoto, value);
        }

        public ImageSource Photo
        {
            get => _photo;
            set => SetProperty(ref _photo, value);
        }

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
            if (!string.IsNullOrEmpty(Order.Photo))
            {
                byte[] binaryData = Convert.FromBase64String(Order.Photo);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();
                Photo = bi;
                IsPhoto = true;
            }

            using (var db = new ModelContainer())
            { 
                Citizenships = new ObservableCollection<Citizenship>(db.Citizenships.ToList());
                SelectedCitizenship = Citizenships.FirstOrDefault(x => x.Id == Order.Client.CitizenshipId);
            }
            Sexes = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Sex>());
            SelectedSex = Sexes.FirstOrDefault(x => x.Int == (int) Order.Client.Sex);
            Pensions = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Pension>());
            SelectedPension = Pensions.FirstOrDefault(x => x.Int == (int)Order.Client.Pension);
            Educations = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.Education>());
            SelectedEducation = Educations.FirstOrDefault(x => x.Int == (int)Order.Client.Education);
            OkCommand = new Command(Save, CanExecuteCommand);
            AddServiceCommand = new Command(AddService, CanExecuteCommand);
            EditServiceCommand = new Command(EditService, CanExecuteCommand);
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
            if (Photo != null)
            {
                byte[] bytes = null;

                if (Photo is BitmapSource bitmapSource)
                {
                    var encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                    using (var stream = new MemoryStream())
                    {
                        encoder.Save(stream);
                        bytes = stream.ToArray();
                    }
                }

                if (bytes != null)
                {
                    var photoBase64String = Convert.ToBase64String(bytes);
                    Order.Photo = photoBase64String;
                }
            }

            Order.Client.Citizenship = SelectedCitizenship;
            Order.Client.Sex = (Enums.Sex) SelectedSex.Int;
            Order.Client.Pension = (Enums.Pension) SelectedPension.Int;
            Order.Client.Education = (Enums.Education) SelectedEducation.Int;
            _context.SaveChanges();
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
