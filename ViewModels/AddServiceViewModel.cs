using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SAKD.Models;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class AddServiceViewModel:BaseViewModel
    {
        private readonly ObservableCollection<AdditionalService> _additionalServices;
        private readonly AddService _view;
        public ObservableCollection<Service> Services { get; set; }
        public Service SelectedService { get; set; }
        public AdditionalService AdditionalService { get; set; }
        public ICommand SaveCommand { get; set; }

        public AddServiceViewModel(AddService view, ObservableCollection<AdditionalService> additionalServices,
            AdditionalService additionalService = null)
        {
            _view = view;
            _additionalServices = additionalServices;
            AdditionalService = additionalService ?? new AdditionalService();
            using (var db = new ModelContainer())
            {
                Services = new ObservableCollection<Service>(db.Services.ToList());
            }

            SelectedService = Services.FirstOrDefault(x => x.Id == AdditionalService.ServiceId);
            SaveCommand = new Command(Save, CanExecuteCommand);
        }

        private void Save(object parameter)
        {
            if (SelectedService == null)
            {
                MessageBox.Show("Барлық мәліметтерді енгізіңіз");
                return;
            }

            AdditionalService.Service = SelectedService;
            _additionalServices.Add(AdditionalService);
            _view.Close();
        }
    }
}
