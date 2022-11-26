using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Services;
using WaterNetworkProject.Stores;
using WaterNetworkProject.ViewModels.Consumers;

namespace WaterNetworkProject.Commands.Consumers
{
    public class DeleteConsumerCommand : AsyncCommandbase
    {
        private ConsumersListViewModel ConsumersListViewModel;
        private ConsumersStore ConsumerStore;
        private NavigationService ConsumersNavigationService;

        public DeleteConsumerCommand(ConsumersListViewModel consumersListViewModel, ConsumersStore consumerStore, NavigationService consumersNavigationService)
        {
            ConsumersListViewModel = consumersListViewModel;
            ConsumerStore = consumerStore;
            ConsumersNavigationService = consumersNavigationService;

            consumersListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if(e.PropertyName == nameof(AddConsumerViewModel.Id))
            //{
            OnCanExecutedChanged();
            //}
        }
    }
}
