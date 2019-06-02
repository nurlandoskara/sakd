using System.Collections.ObjectModel;
using System.Windows;
using SAKD.Models;
using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddFile
    {
        public AddFile(ObservableCollection<File> files,
            File file = null)
        {
            InitializeComponent();
            DataContext = new AddFileViewModel(this, files, file);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
