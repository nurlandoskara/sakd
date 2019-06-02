using Microsoft.Win32;
using SAKD.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using File = SAKD.Models.File;

namespace SAKD.ViewModels
{
    public class AddFileViewModel : BaseViewModel
    {
        private readonly ObservableCollection<File> _files;
        private readonly AddFile _view;
        private string _filepath;
        public File DFile { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public string Filepath
        {
            get => _filepath;
            set => SetProperty(ref _filepath, value);
        }

        public AddFileViewModel(AddFile view, ObservableCollection<File> files, File file = null)
        {
            _view = view;
            _files = files;
            DFile = file ?? new File
            {
                Date = DateTime.Now
            };
            Filepath = DFile.Path;
            
            SaveCommand = new Command(Save, CanExecuteCommand);
            AddCommand = new Command(Upload, CanExecuteCommand);
        }

        private void Upload(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var newDir = AppDomain.CurrentDomain.BaseDirectory + "Files";
                if (!Directory.Exists(newDir)) Directory.CreateDirectory(newDir);
                var curFile = openFileDialog.FileName;
                var newPathToFile = Path.Combine(newDir, Guid.NewGuid() + ".pdf");
                System.IO.File.Copy(curFile, newPathToFile);
                DFile.Path = newPathToFile;
                Filepath = DFile.Path;
            }
        }

        private void Save(object parameter)
        {
            _files.Add(DFile);
            _view.Close();
        }
    }
}
