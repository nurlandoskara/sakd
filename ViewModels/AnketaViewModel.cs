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
using ControlzEx.Standard;
using File = SAKD.Models.File;

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
        private ObservableCollection<EnumListItem> _documentTypes;
        private ObservableCollection<EnumListItem> _documentOrganizations;
        private bool _isLivingAddressRegistration;
        private bool _isNotLivingAddressRegistration;
        private Address _registrationAddress;
        private Address _livingAddress;
        private string _registrationString;
        private string _livingString;
        private ObservableCollection<EnumListItem> _relationTypes;
        private string _mainJobString;
        private string _additionalJobString;
        private Employment _mainJob;
        private Employment _additionalJob;
        private ObservableCollection<File> _files;
        private bool _status81;
        private Offer _selectedOffer;
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

        public ObservableCollection<EnumListItem> DocumentTypes
        {
            get => _documentTypes;
            set => SetProperty(ref _documentTypes, value);
        }
        public EnumListItem SelectedDocumentType { get; set; }

        public ObservableCollection<EnumListItem> DocumentOrganizations
        {
            get => _documentOrganizations;
            set => SetProperty(ref _documentOrganizations, value);
        }
        public EnumListItem SelectedDocumentOrganization { get; set; }

        public ObservableCollection<Comission> Comissions { get; set; }

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

        public ObservableCollection<EnumListItem> FamilyStatuses { get; set; }
        public EnumListItem SelectedFamilyStatus { get; set; }

        public bool IsLivingAddressRegistration
        {
            get => _isLivingAddressRegistration;
            set
            {
                SetProperty(ref _isLivingAddressRegistration, value);
                IsNotLivingAddressRegistration = !_isLivingAddressRegistration;
                if (_isLivingAddressRegistration)
                {
                    LivingAddress = RegistrationAddress;
                }
            }
        }

        public bool IsNotLivingAddressRegistration
        {
            get => _isNotLivingAddressRegistration;
            set => SetProperty(ref _isNotLivingAddressRegistration, value);
        }

        public Address RegistrationAddress
        {
            get => _registrationAddress;
            set => SetProperty(ref _registrationAddress, value);
        }

        public Address LivingAddress
        {
            get => _livingAddress;
            set => SetProperty(ref _livingAddress, value);
        }

        public string RegistrationString
        {
            get => _registrationString;
            set => SetProperty(ref _registrationString, value);
        }

        public string LivingString
        {
            get => _livingString;
            set => SetProperty(ref _livingString, value);
        }

        public string MainJobString
        {
            get => _mainJobString;
            set => SetProperty(ref _mainJobString, value);
        }

        public string AdditionalJobString
        {
            get => _additionalJobString;
            set => SetProperty(ref _additionalJobString, value);
        }

        public ObservableCollection<EnumListItem> RelationTypes
        {
            get => _relationTypes;
            set => SetProperty(ref _relationTypes, value);
        }
        public EnumListItem SelectedRelationType { get; set; }

        public ObservableCollection<EnumListItem> SourceInfos { get; set; }
        public EnumListItem SelectedSourceInfo { get; set; }

        public ICommand AddServiceCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }
        public ICommand AddRegistrationAddressCommand { get; set; }
        public ICommand AddLivingAddressCommand { get; set; }
        public ICommand AddMainJobCommand { get; set; }
        public ICommand AddAdditionalJobCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand AddFileCommand { get; set; }

        public bool Status1 { get; set; }
        public bool Status2 { get; set; }
        public bool Status81 { get; set; }
        public bool Status12 { get; set; }

        public bool StatusResponse
        {
            get => _status81;
            set => SetProperty(ref _status81, value);
        }

        private void Offer()
        {
            Offers = new ObservableCollection<Offer>();
            for (var i = 12; i < 60; i+=3)
            {
                Offers.Add(new Offer
                {
                    Total = Order.RequestSum,
                    Refinance = 0,
                    EndTotal = Order.RequestSum - (Order.AdditionalServices.Sum(x => x.TotalPrice) -
                               Order.Comissions.Sum(x => x.ComissionType.ComissionPercent / 100 * Order.RequestSum)),
                    Months = i
                });
            }
        }

        public ObservableCollection<File> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }
        public ObservableCollection<Offer> Offers { get; set; }

        public Offer SelectedOffer
        {
            get => _selectedOffer;
            set => SetProperty(ref _selectedOffer, value);
        }

        public AnketaViewModel(Anketa view, Order order, ModelContainer context)
        {
            _view = view;
            _context = context;
            Order = order;
            Status1 = Order.Status == Enums.Status.S1;
            Status2 = Order.Status == Enums.Status.S2;
            Status81 = Order.Status == Enums.Status.S81;
            if (Status81)
            {
                var monthly = (Order.RequestSum / Order.Months) / Order.Client.Job.TotalSalary * 100;
                if (monthly > 50)
                {
                    MessageBox.Show("Несиеден бас тартылды! Клиенттің ай сайынғы табысы жеткіліксіз");
                    Order.Status = Enums.Status.Cancelled;
                }
                else if (Order.Client.Job.WorkExperience < 6)
                {
                    MessageBox.Show("Несиеден бас тартылды! Клиенттің еңбек өтілі жеткіліксіз");
                    Order.Status = Enums.Status.Cancelled;
                }
                else if (Order.Client.AdditionalInfo.IsAlcohol || Order.Client.AdditionalInfo.IsAnotherPerson || Order.Client.AdditionalInfo.IsInadequate)
                {
                    MessageBox.Show("Несиеден бас тартылды! Клиенттің еңбек өтілі жеткіліксіз");
                    Order.Status = Enums.Status.Cancelled;
                }

                if (Order.Status == Enums.Status.Cancelled)
                {
                    Offer();
                }
            }
            Status12 = Order.Status == Enums.Status.S12;
            StatusResponse = Status81 || Status12;
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
            DocumentTypes = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.DocumentType>());
            SelectedDocumentType = DocumentTypes.FirstOrDefault(x => x.Int == (int) Order.Client.Document.Type);
            DocumentOrganizations =
                new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.DocumentOrganization>());
            SelectedDocumentOrganization =
                DocumentOrganizations.FirstOrDefault(x => x.Int == (int) Order.Client.Document.Organization);
            IsLivingAddressRegistration = Order.Client.IsLivingAddressRegistration;
            RegistrationAddress = Order.Client.RegistrationAddress;
            LivingAddress = Order.Client.LivingAddress;
            RegistrationString = RegistrationAddress.DisplayString;
            LivingString = LivingAddress.DisplayString;
            RelationTypes = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.RelationType>());
            SelectedRelationType =
                RelationTypes.FirstOrDefault(x => x.Int == (int) Order.Client.ContactPerson.RelationType);
            FamilyStatuses = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.FamilyStatus>());
            SelectedFamilyStatus = FamilyStatuses.FirstOrDefault(x => x.Int == (int) Order.Client.Family.FamilyStatus);
            MainJob = Order.Client.Job.MainJob;
            MainJobString = MainJob?.DisplayString;
            AdditionalJob = Order.Client.Job.AdditionalJob;
            AdditionalJobString = AdditionalJob?.DisplayString;
            SourceInfos = new ObservableCollection<EnumListItem>(EnumHelper.EnumList<Enums.SourceInfo>());
            SelectedSourceInfo = SourceInfos.FirstOrDefault(x => x.Int == (int) Order.Client.AdditionalInfo.SourceInfo);
            Files = Order.Files != null
                ? new ObservableCollection<File>(Order.Files)
                : new ObservableCollection<File>();
            const double tolerance = 0.01;
            SelectedOffer = Offers?.FirstOrDefault(x => Math.Abs(x.Months - Order.Months) < tolerance);

            OkCommand = new Command(Save, CanExecuteCommand);
            AddServiceCommand = new Command(AddService, CanExecuteCommand);
            EditServiceCommand = new Command(EditService, CanExecuteCommand);
            AddRegistrationAddressCommand = new Command(AddRegistrationAddress, CanExecuteCommand);
            AddLivingAddressCommand = new Command(AddLivingAddress, CanExecuteCommand);
            AddMainJobCommand = new Command(AddMainJob, CanExecuteCommand);
            AddAdditionalJobCommand = new Command(AddAdditionalJob, CanExecuteCommand);
            NextCommand = new Command(Next, CanExecuteCommand);
            AddFileCommand = new Command(AddFileVoid, CanExecuteCommand);
        }
        
        private void Next(object parameter)
        {
            switch (Order.Status)
            {
                case Enums.Status.S2:
                    Order.Status = Enums.Status.S81;
                    break;
                case Enums.Status.S81:
                    Order.Status = Enums.Status.S12;
                    break;
                case Enums.Status.S12:
                    Order.Status = Order.IsClientAccepted == false ? Enums.Status.CancelledByClient : Enums.Status.S17;
                    break;
                case Enums.Status.S17:
                    Order.Status = Enums.Status.Accepted;
                    break;
                case Enums.Status.Cancelled:
                    if (SelectedOffer != null)
                    {
                        Order.Status = Enums.Status.S12;
                    }
                    break;
                default:
                    Order.Status = Order.Status + 1;
                    break;
            }

            SaveExit();
        }

        private void AddRegistrationAddress(object parameter)
        {
            var view = new AddAddress(RegistrationAddress);
            view.ViewModel.OnClose += AddRegistration_OnClose;
            view.ShowDialog();
        }

        private void AddRegistration_OnClose(object sender, CustomEventArgs.OnCloseFilterViewEventArgs args)
        {
            if (!(sender is BaseViewModel vm)) return;
            vm.OnClose -= AddRegistration_OnClose;
            if (!args.IsApplied) return;
            RegistrationString = RegistrationAddress.DisplayString;
        }
        private void AddLivingAddress(object parameter)
        {
            var view = new AddAddress(LivingAddress);
            view.ViewModel.OnClose += AddLiving_OnClose;
            view.ShowDialog();
        }

        private void AddLiving_OnClose(object sender, CustomEventArgs.OnCloseFilterViewEventArgs args)
        {
            if (!(sender is BaseViewModel vm)) return;
            vm.OnClose -= AddLiving_OnClose;
            if (!args.IsApplied) return;
            LivingString = LivingAddress.DisplayString;
        }

        public Employment MainJob
        {
            get => _mainJob;
            set => SetProperty(ref _mainJob, value);
        }

        private void AddMainJob(object parameter)
        {
            var view = new AddEmployment(MainJob);
            view.ViewModel.OnClose += AddMainJob_OnClose;
            view.ShowDialog();
        }
        
        private void AddMainJob_OnClose(object sender, CustomEventArgs.OnCloseFilterViewEventArgs args)
        {
            if (!(sender is BaseViewModel vm)) return;
            vm.OnClose -= AddMainJob_OnClose;
            if (!args.IsApplied) return;
            MainJobString = MainJob.DisplayString;
        }

        public Employment AdditionalJob
        {
            get => _additionalJob;
            set => SetProperty(ref _additionalJob, value);
        }

        private void AddAdditionalJob(object parameter)
        {
            var view = new AddEmployment(AdditionalJob);
            view.ViewModel.OnClose += AddAdditionalJob_OnClose;
            view.ShowDialog();
        }

        private void AddAdditionalJob_OnClose(object sender, CustomEventArgs.OnCloseFilterViewEventArgs args)
        {
            if (!(sender is BaseViewModel vm)) return;
            vm.OnClose -= AddAdditionalJob_OnClose;
            if (!args.IsApplied) return;
            AdditionalJobString = AdditionalJob.DisplayString;
        }
        private void EditService(object parameter)
        {
            
        }

        private void AddService(object parameter)
        {
            var view = new AddService(AdditionalServices);
            view.ShowDialog();
        }

        private void AddFileVoid(object parameter)
        {
            var view = new AddFile(Files);
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
            Order.Client.RegistrationAddress = RegistrationAddress;
            Order.Client.LivingAddress = LivingAddress;
            Order.Client.ContactPerson.RelationType = (Enums.RelationType) SelectedRelationType.Int;
            Order.Client.Family.FamilyStatus = (Enums.FamilyStatus) SelectedFamilyStatus.Int;
            Order.Client.Job.MainJob = MainJob;
            Order.Client.Job.AdditionalJob = AdditionalJob;
            Order.Client.AdditionalInfo.SourceInfo = (Enums.SourceInfo) SelectedSourceInfo.Int;
            Order.Files = Files;
            Order.Months = SelectedOffer?.Months ?? Order.Months;
            SaveExit();
        }

        private void SaveExit()
        {
            _context.SaveChanges();
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
