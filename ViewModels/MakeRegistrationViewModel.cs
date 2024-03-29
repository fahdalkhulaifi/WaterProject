﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetworkProject.Commands;
using WaterNetworkProject.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;

namespace WaterNetworkProject.ViewModels
{
    public class MakeRegistrationViewModel : ViewModelBase
    {
        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        private int _counterLecture;
        public int CounterLecture
        {
            get
            {
                return _counterLecture;
            }
            set
            {
                _counterLecture = value;
                OnPropertyChanged(nameof(CounterLecture));
            }
        }

        private DateTime _registrationDate = DateTime.UtcNow;
        public DateTime RegistrationDate
        {
            get
            {
                return _registrationDate;
            }
            set
            {
                _registrationDate = value;
                OnPropertyChanged(nameof(RegistrationDate));
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeRegistrationViewModel(RegistrationsBook registrationsBook, NavigationService registrationNavigationService)
        {
            RegisterCommand = new MakeRegistrationCommand(this, registrationsBook, registrationNavigationService);
            CancelCommand = new NavigateCommand(registrationNavigationService);
        }
    }
}
