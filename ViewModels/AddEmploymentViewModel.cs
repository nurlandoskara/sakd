using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SAKD.Models;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class AddEmploymentViewModel : BaseViewModel
    {
        private ObservableCollection<Industry> _industries;
        private readonly AddEmployment _view;
        private Employment _employment;
        private Industry _selectedIndustry;

        public Employment Employment
        {
            get => _employment;
            set => SetProperty(ref _employment, value);
        }

        public ObservableCollection<Industry> Industries
        {
            get => _industries;
            set => SetProperty(ref _industries, value);
        }

        public Industry SelectedIndustry
        {
            get => _selectedIndustry;
            set => SetProperty(ref _selectedIndustry, value);
        }

        public ICommand SaveCommand { get; set; }
        public override event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };
        public AddEmploymentViewModel(AddEmployment view, Employment employment)
        {
            _view = view;
            Employment = employment;
            using (var db = new ModelContainer())
            {
                Industries = new ObservableCollection<Industry>(db.Industries.ToList());
                SelectedIndustry = Industries.FirstOrDefault(x => x.Id == Employment.IndustryId);
            }
            SaveCommand = new Command(Save, CanExecuteCommand);
        }

        private void Save(object parameter)
        {
            Employment.Industry = SelectedIndustry;
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs { IsApplied = true });
        }
    }
}
