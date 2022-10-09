using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.WPF.Stores;
using WaterNetwork.WPF.ViewModels.Consumers;

namespace WaterNetwork.WPF.Commands.Consumers
{
    public class LoadConsumersCommand : AsyncCommandbase
    {
        private readonly ConsumersListViewModel _viewModel;
        private readonly ConsumersStore _consumersStore;

        public LoadConsumersCommand(ConsumersListViewModel viewModel, ConsumersStore consumersStore)
        {
            _viewModel = viewModel;
            _consumersStore = consumersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;

            try
            {
                await _consumersStore.Load();
                _viewModel.UpdateConsumers(_consumersStore.Consumers);
            }
            catch (Exception)
            {
                //ToDo: errors like registrations
            }

            _viewModel.IsLoading = false;
        }
    }
}
