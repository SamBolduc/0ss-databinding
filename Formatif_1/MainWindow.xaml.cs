using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Formatif_1.Annotations;
using Microsoft.Win32;

namespace Formatif_1
{
    
    public partial class MainWindow : INotifyPropertyChanged
    {
        
        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();

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
                Rate = 5,
                CoverPath = "images/shadow_of_mordor.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "Fortnite",
                Editor = "EpicGames",
                Description = "Cool la description",
                ReleaseDate = 2016,
                Console = "XBox",
                Rate = 8,
                CoverPath = "images/fortnite.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "BattleField 4",
                Editor = "EA",
                Description = "C vrm nice comme jeu",
                ReleaseDate = 207,
                Console = "XBox",
                Rate = 7,
                CoverPath = "images/bf4.jpg"
            });
            
            Games.Add(new Game()
            {
                Title = "Minecraft",
                Editor = "Microsoft",
                Description = "Un jeu de cube",
                ReleaseDate = 2009,
                Console = "Switch",
                Rate = 6,
                CoverPath = "images/minecraft.jpg"
            });

            this.CurrentGame = Games[0];
            
            InitializeComponent();
            slider.Maximum = Games.Count - 1;
        }

        private void onChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var newIndex = Convert.ToInt32(e.NewValue);
            this.CurrentGame = Games[newIndex];
            this.listView.SelectedIndex = newIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void onGameChange(object sender, SelectionChangedEventArgs e)
        {
            this.CurrentGame = e.AddedItems[0] as Game;
            if(this.slider != null)
                this.slider.Value = Games.IndexOf(CurrentGame);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            slider.Maximum += 1;
            Games.Add(new Game()
            {
                Title = "Undefined",
                Console = "Undefined",
                Rate = 0,
                CoverPath = "Undefined",
                Description = "Undefined",
                Editor = "Undefined",
                ReleaseDate = 1970
            });
        }

        private void TextboxEdit(object sender, MouseButtonEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.IsReadOnly = false;
            textBox.BorderThickness = new Thickness(1);
        }
        
        private void TextboxLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            var textBox = (TextBox)sender;
            textBox.IsReadOnly = true;
            textBox.BorderThickness = new Thickness(0);
        }
        
        private void TextboxConfirm(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            var textBox = (TextBox) sender;
            textBox.IsReadOnly = true;
            textBox.BorderThickness = new Thickness(0);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DescriptionChange(object sender, TextChangedEventArgs textChangedEventArgs)      {
            CurrentGame.Description = ((TextBox)sender).Text;
        }
        private void YearChange(object sender, TextChangedEventArgs e)
        {
            CurrentGame.ReleaseDate = int.Parse(((TextBox)sender).Text);
        }

        private void TitleChange(object sender, TextChangedEventArgs e)
        {
            CurrentGame.Title = ((TextBox)sender).Text;
        }

        private void EditorChange(object sender, TextChangedEventArgs e)
        {
            CurrentGame.Editor = ((TextBox)sender).Text;
        }

        private void EditCover(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png",
                InitialDirectory = @"C:\",
                Title = "Sélectionnez une image"
            };

            if (dialog.ShowDialog() != true) return;
            
            CurrentGame.CoverPath = dialog.FileName;
            OnPropertyChanged();
        }
    }
}