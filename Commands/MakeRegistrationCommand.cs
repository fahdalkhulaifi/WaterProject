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
using WaterNetworkProject.ViewModels.Registrations;

namespace WaterNetworkProject.Commands
{
    public class MakeRegistrationCommand : AsyncCommandbase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private RegistrationsStore _registrationsStore;
        private ConsumersStore _consumerStore;

        private readonly NavigationService _registartionNavigationService;

        private readonly IAddRegistrationCommand _addRegistrationCommand;

        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, RegistrationsStore registrationsStore, ConsumersStore consumersStore, NavigationService registartionNavigationService)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _registrationsStore = registrationsStore;
            _consumerStore = consumersStore;
            _registartionNavigationService = registartionNavigationService;

            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //ToDo: Update registration if exist
                await _consumerStore.Load();

                var existedConsumer = _consumerStore.Find(_makeRegistrationViewModel.UserId);

                if(existedConsumer != null)
                {
                    Registration registration = new Registration(_makeRegistrationViewModel.UserId, _makeRegistrationViewModel.CounterLecture, _makeRegistrationViewModel.RegistrationDate);

                    registration.Consumer = existedConsumer;
                    registration.ConsumerId = existedConsumer.Id;
                    registration.ConsumerName = existedConsumer.FirstName;

                    await _registrationsStore.AddRegistration(registration);

                    //ToDo: Handle exception
                    //await _addRegistrationCommand.Execute(registration);
                    MessageBox.Show("تم التقييد بنجاح");

                    _registartionNavigationService.Navigate();
                }
                else 
                {
                    MessageBox.Show(".المستخدم غير موجود");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
