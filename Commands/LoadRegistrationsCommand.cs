using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.WPF.Stores;
using WaterNetworkProject.ViewModels.Registrations;

namespace WaterNetwork.WPF.Commands
{

    public class LoadRegistrationsCommand : AsyncCommandbase
    {

        private readonly RegistrationListViewModel _viewModel;
        private readonly RegistrationsStore _registrationSore;

        public LoadRegistrationsCommand(RegistrationListViewModel viewModel, RegistrationsStore RegistrationsStore)
        {
            _registrationSore = RegistrationsStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;
            _viewModel.IsLoading = true;
            try
            {
                await _registrationSore.Load();

                _viewModel.UpdateRegistrations(_registrationSore.Registrations);
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Failed to load the reservations.";
            }

            _viewModel.IsLoading = false;
        }
    }
}
