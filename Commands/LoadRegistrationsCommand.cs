using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.WPF.Stores;
using WaterNetworkProject.ViewModels;

namespace WaterNetwork.WPF.Commands
{

    public class LoadRegistrationsCommand : AsyncCommandbase
    {

        private readonly RegistrationListViewModel _viewModel;
        private readonly RegistrationsStore _hotelStore;

        public LoadRegistrationsCommand(RegistrationListViewModel viewModel, RegistrationsStore RegistrationsStore)
        {
            _hotelStore = RegistrationsStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;
            _viewModel.IsLoading = true;
            try
            {
                await _hotelStore.Load();

                _viewModel.UpdateRegistrations(_hotelStore.Registrations);
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Failed to load the reservations.";
            }

            _viewModel.IsLoading = false;
        }
    }
}
