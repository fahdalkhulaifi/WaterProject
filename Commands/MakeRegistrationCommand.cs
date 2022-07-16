using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WaterNetwork.Domain.Commands.Registrations;
using WaterNetwork.Domain.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject.Commands
{
    public class MakeRegistrationCommand : CommandBase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private RegistrationsBook _registrationsBook;
        private readonly NavigationService _registartionService;

        private readonly IAddRegistrationCommand _addRegistrationCommand;

        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, RegistrationsBook registrationsBook, NavigationService registartionService, IAddRegistrationCommand addRegistrationCommand)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _registrationsBook = registrationsBook;
            _registartionService = registartionService;
            _addRegistrationCommand = addRegistrationCommand;
            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }


        public override void Execute(object parameter)
        {
            try
            {
                //ToDo: Update registration if exist
                Registration registration = new Registration(_makeRegistrationViewModel.UserId, _makeRegistrationViewModel.CounterLecture, _makeRegistrationViewModel.RegistrationDate);

                _registrationsBook.AddRegistration(registration);

                //ToDo: Handle exception
                _addRegistrationCommand.Execute(registration);
                MessageBox.Show("تم التقييد بنجاح");

                _registartionService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show(".حدث خطأ ما");
            }
            
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
