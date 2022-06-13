using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Models;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject.Commands
{
    public class MakeRegistrationCommand : CommandBase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private RegistrationsBook _registrationsBook; 
        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, RegistrationsBook registrationsBook)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _registrationsBook = registrationsBook;

            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override void Execute(object parameter)
        {
            //ToDo: fetch user, and handle exception if user not found or negative counter lecture 
            Consumer consumer = new Consumer(GetTimestamp(DateTime.UtcNow) , "firstName_" + GetTimestamp(DateTime.UtcNow), "LastName_" + GetTimestamp(DateTime.UtcNow));

            Registration registration = new Registration(consumer, _makeRegistrationViewModel.CounterLecture, _makeRegistrationViewModel.RegistrationDate);

            _registrationsBook.MakeRegestration(registration);
        }

        public override bool CanExecute(object parameter)
        {
            return _makeRegistrationViewModel.UserId > 0 && base.CanExecute(parameter);
        }

        private long GetTimestamp(DateTime value)
        {
            return ((DateTimeOffset)value).ToUnixTimeMilliseconds(); 
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeRegistrationViewModel.UserId))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
