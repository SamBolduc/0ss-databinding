using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exercices.Annotations;

namespace Exercices
{
    public class Employee : INotifyPropertyChanged
    {
        private int age;
        public string Name { get; set; }
        public string LastName { get; set; }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string PicturePath { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}