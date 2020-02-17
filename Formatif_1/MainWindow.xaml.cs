using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Formatif_1.Annotations;

namespace Formatif_1
{
    
    public partial class MainWindow : INotifyPropertyChanged
    {
        public List<Game> Games = new List<Game>();

        private Game currentGame;

        public Game CurrentGame
        {
            get => currentGame;
            set
            {
                currentGame = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            Games.Add(new Game()
            {
                Title = "Shadow Of Mordor",
                Editor = "Feral Interactive",
                Description = "Je test une description :)",
                ReleaseDate = 2014,
                Console = "PS4",
                Cote = 5,
                CoverPath = "images/shadow_of_mordor.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "Fortnite",
                Editor = "EpicGames",
                Description = "Cool la description",
                ReleaseDate = 2016,
                Console = "XBox",
                Cote = 8,
                CoverPath = "images/fortnite.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "BattleField 4",
                Editor = "EA",
                Description = "C vrm nice comme jeu",
                ReleaseDate = 207,
                Console = "XBox",
                Cote = 7,
                CoverPath = "images/bf4.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "Minecraft",
                Editor = "Microsoft",
                Description = "Un jeu de cube",
                ReleaseDate = 2009,
                Console = "Switch",
                Cote = 6,
                CoverPath = "images/minecraft.jpg"
            });

            this.CurrentGame = Games[0];
            
            InitializeComponent();
            slider.Maximum = Games.Count - 1;
        }

        private void onChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.CurrentGame = Games[Convert.ToInt32(e.NewValue)];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}