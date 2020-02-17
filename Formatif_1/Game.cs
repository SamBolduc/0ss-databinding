using System.ComponentModel;
using System.Runtime.CompilerServices;
using Formatif_1.Annotations;

namespace Formatif_1
{
    public class Game : INotifyPropertyChanged
    {
        private string title_, editor_, description_, console_, coverpath_;
        private double rate_;
        private int releasedate_;

        public string Title
        {
            get => title_;
            set
            {
                title_ = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }

        public string Editor
        {
            get => editor_;
            set
            {
                editor_ = value;
                OnPropertyChanged();
            }
        }        
        public string Description
        {
            get => description_;
            set
            {
                description_ = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }          
        
        public int ReleaseDate
        {
            get => releasedate_;
            set
            {
                releasedate_ = value;
                OnPropertyChanged();
            }
        }
        
        public string Console
        {
            get => console_;
            set
            {
                console_ = value;
                OnPropertyChanged();
            }
        }
        
        public string CoverPath
        {
            get => coverpath_;
            set
            {
                coverpath_ = value;
                OnPropertyChanged();
            }
        }

        public double Rate
        {
            get => rate_;
            set
            {
                rate_ = value;
                OnPropertyChanged();
            }
        }
        
        public string Info => $"{Title} : {Description}";
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}