﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class Score : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int NumberOfEatenFoods { get; private set; }
        public int NumberOfDeadSnakes { get; private set; }

        public Score()
        {
            NumberOfEatenFoods = 0;
            NumberOfDeadSnakes = 0;
        }
        private void NotifyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void IncreaseFoodScore()
        {
            NumberOfEatenFoods++;
            NotifyPropertyChanged();
        }

        public void IncreaseNumberOfDeaths()
        {
            NumberOfDeadSnakes++;
            NotifyPropertyChanged();
        }
    }
}
