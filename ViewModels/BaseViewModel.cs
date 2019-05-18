using System.Windows.Input;

namespace SAKD.ViewModels
{
    public class BaseViewModel: BaseBindableViewModel
    {
        public virtual event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };
        public ICommand OkCommand { get; set; }
    }
}
