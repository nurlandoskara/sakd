using SAKD.Models;
using SAKD.Views;
using System;
using System.Linq;

namespace SAKD.ViewModels
{
    public class ClientSearchViewModel: BaseViewModel
    {
        private readonly ClientSearch _view;
        private string _iin;
        private Client _client;

        public string Iin
        {
            get => _iin;
            set
            {
                SetProperty(ref _iin, value);
                if (value?.Length == 12)
                {
                    Find(_iin);
                }
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }

        public override event CustomEventArgs.OnCloseEvent OnClose = (sender, args) => { };

        public ClientSearchViewModel(ClientSearch view)
        {
            _view = view;
            OkCommand = new Command(Ok, CanExecuteCommand);
        }

        private void Find(string iin)
        {
            using (var db = new ModelContainer())
            {
                _client = db.Clients.FirstOrDefault(x => x.Iin == iin);
                if (_client != null)
                {
                    FirstName = _client.FirstName;
                    LastName = _client.LastName;
                    PatronymicName = _client.PatronymicName;
                }
            }
        }

        private void Ok(object parameter)
        {
            if(_client == null) _client = new Client
            {
                Iin = Iin
            };
            using (var db = new ModelContainer())
            {
                db.Orders.Add(new Order
                {
                    Status = Enums.Status.S1,
                    Client = _client,
                    BranchId = 1,
                    Date = DateTime.Now
                });
                db.SaveChanges();
            }
            _view.Close();
            OnClose.Invoke(this,
                new CustomEventArgs.OnCloseFilterViewEventArgs {IsApplied = true});
        }


    }
}
