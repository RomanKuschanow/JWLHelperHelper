using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace JWLHalperHalper
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<KeyValuePair<string, string>> Files => new ObservableCollection<KeyValuePair<string, string>>(GetIniFiles.GetFiles());

        public ICommand Open => new RelayCommand(OpenExecute);

        private void OpenExecute(object obj)
        {
            var file = (obj as KeyValuePair<string, string>?).Value;
            try
            {
                foreach (var process in Process.GetProcessesByName("JWLHelper"))
                {
                    process.Kill();
                }
            }
            catch
            {

            }
            File.Copy(file.Value, file.Value.Replace(file.Key, "JWLHelper.ini"), true);
            Process.Start("C:\\Program Files\\JWLHelper\\JWLHelper.exe");
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion
    }
}
