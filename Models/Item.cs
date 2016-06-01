using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmLightUwpExample.Annotations;

namespace MvvmLightUwpExample.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (Title == value) return;

                _title = value;
                OnPropertyChanged();
            }
        }

        private string _subtitle;

        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                if (Subtitle == value) return;

                _subtitle = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}