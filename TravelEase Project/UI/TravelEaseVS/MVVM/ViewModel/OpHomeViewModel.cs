﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;

namespace TravelEaseVS.MVVM.ViewModel
{
    public class OpHomeViewModel: INotifyPropertyChanged
    {
        public OpHomeViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
