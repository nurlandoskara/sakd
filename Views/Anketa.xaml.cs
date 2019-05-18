using SAKD.Models;
using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for Anketa.xaml
    /// </summary>
    public partial class Anketa
    {
        public AnketaViewModel ViewModel { get; set; }
        public Anketa(Order order)
        {
            InitializeComponent();
            DataContext = ViewModel = new AnketaViewModel(this, order);
        }
    }
}
