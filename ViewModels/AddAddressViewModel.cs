using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SAKD.Models;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class AddAddressViewModel: BaseViewModel
    {
        private ObservableCollection<Region> _regions;
        private ObservableCollection<Area> _areas;
        private ObservableCollection<City> _cities;
        private readonly AddAddress _view;
        public Address _address;

        public ObservableCollection<Region> Regions
        {
            get => _regions;
            set => SetProperty(ref _regions, value);
        }
        public Region SelectedRegion { get; set; }
        public ObservableCollection<Area> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value);
        }
        public Area SelectedArea { get; set; }

        public ObservableCollection<City> Cities
        {
            get => _cities;
            set => SetProperty(ref _cities, value);
        }
        public City SelectedCity { get; set; }
        public ICommand SaveCommand { get; set; }
        public override event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };
        public AddAddressViewModel(AddAddress view, Address address)
        {
            _view = view;
            _address = address;
            using (var db = new ModelContainer())
            {
                Regions = new ObservableCollection<Region>(db.Regions.ToList());
                SelectedRegion = Regions.FirstOrDefault(x => x.Id == _address.RegionId);
                Areas = new ObservableCollection<Area>(db.Areas.ToList());
                SelectedArea = Areas.FirstOrDefault(x => x.Id == _address.AreaId);
                Cities = new ObservableCollection<City>(db.Cities.ToList());
                SelectedCity = Cities.FirstOrDefault(x => x.Id == _address.CityId);
            }
            SaveCommand = new Command(Save, CanExecuteCommand);
        }

        private void Save(object parameter)
        {
            _address.Region = SelectedRegion;
            _address.Area = SelectedArea;
            _address.City = SelectedCity;
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
