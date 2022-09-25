using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WaterNetwork.Domain.Commands.Registrations;
using WaterNetwork.Domain.Models;
using WaterNetwork.WPF.Commands;
using WaterNetwork.WPF.Stores;
using WaterNetworkProject.Services;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject.Commands
{
    public class MakeRegistrationCommand : AsyncCommandbase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private RegistrationsStore _registrationsStore;
        private readonly NavigationService _registartionNavigationService;

        private readonly IAddRegistrationCommand _addRegistrationCommand;

        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, RegistrationsStore registrationsStore, NavigationService registartionNavigationService)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _registrationsStore = registrationsStore;
            _registartionNavigationService = registartionNavigationService;

            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //ToDo: Update registration if exist
                Registration registration = new Registration(_makeRegistrationViewModel.UserId, _makeRegistrationViewModel.CounterLecture, _makeRegistrationViewModel.RegistrationDate);

                
                await _registrationsStore.Add(registration);

                //ToDo: Handle exception
                //await _addRegistrationCommand.Execute(registration);
                MessageBox.Show("تم التقييد بنجاح");

                _registartionNavigationService.Navigate();
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
