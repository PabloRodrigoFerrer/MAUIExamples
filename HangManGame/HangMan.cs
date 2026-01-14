
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text;

namespace HangManGame
{
    internal class HangMan : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
    

        private void OnPropertyChange([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> _allWords = new()
        {
            "Camion", "Avion", "Bateau", "Voiture", "Velo", "Moto", "Train", "Bus", "Tracteur", "Scooter"
        };
        
        private string currentImage = "img0.jpg";
        public string CurrentImage
        {
            get => currentImage;
            private set
            {
                currentImage = value;
                OnPropertyChange();
            }
        }

        public string gameStatus => $"{Errors} of 6 erros.";

        private string gameOver = "";
        public string GameOver
        {
            get => gameOver;
            set
            {
                gameOver = value;
                OnPropertyChange();
            }
        }

        private int errors = 0;
        public int Errors
        {
            get => errors;
            private set
            {
                errors = value;
                OnPropertyChange();
                OnPropertyChange(nameof(gameStatus));
                OnPropertyChange(nameof(CurrentImage));
            }
        }

        public string Alphabet { get; } =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        private string secretWord = "ROCK";
        public string SecretWord
        {
            get
            {
              return secretWord;
            }
            set
            {
                secretWord = value;
                OnPropertyChange();
            }
        }

        private string spotLight = string.Empty;
        public string SpotLight
        {
            get => spotLight;
            set
            {
                spotLight = value;
                OnPropertyChange();
            }
        }

        ObservableCollection<char> tryes = new();

        public ObservableCollection<char> Tryes
        {
            get => tryes;
            set
            {
                tryes = value;
                OnPropertyChange();
            }
        }

        private ObservableCollection<char> successes = new();
        

        public ObservableCollection<char> Successes
        {
            get => successes;
            set
            {
                successes = value;
                OnPropertyChange();
            }
        }

        public void CalculateWord(char letterToCheck)
        {
            var check = SecretWord.IndexOf(letterToCheck);

            if (check >= 0)
            {
                successes.Add(letterToCheck);
                renderSpotlight();
                CheckWin();
            }
            else
            {
                Tryes.Add(letterToCheck);
                Errors++;
                setCurrentImage();
                CheckLoose();
            }
        }

        public void renderSpotlight()
        {
            var temp = secretWord.Select(x => successes.IndexOf(x) >= 0 ? x : '_').ToArray();
            SpotLight = string.Join(' ', temp);
        }

        public bool CheckLoose()
        {
            if (Errors > 5)
            {
                GameOver = "You Lost..!!";
                return true;
            }
            return false;
        }

        public bool CheckWin()
        {
            if(SpotLight.Replace(" ", "").Equals(secretWord))
            {
                GameOver = "You Win..!!";
                return true;
            }
            return false;
        }
        public void ResetGame()
        {
            Errors = 0;
            Tryes.Clear();
            Successes.Clear();
            GameOver = string.Empty;
            peekRandomWord();
            renderSpotlight();
            setCurrentImage();
        }

        private void peekRandomWord()
        {
            Random random = new();
            secretWord = _allWords[random.Next(0, _allWords.Count)].ToUpper();
        }

        private void setCurrentImage() => CurrentImage = $"img{Errors}.jpg";
    }
}
