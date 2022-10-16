using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterNetwork.Domain.Models;
using WaterNetworkProject.Commands.Consumers;
using WaterNetworkProject.Stores;
using WaterNetworkProject.Commands;
using WaterNetworkProject.Services;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject.ViewModels.Consumers
{
    public class ConsumersListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ConsumerViewModel> _consumers;

        private ConsumersStore _consumerStore;

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public IEnumerable<ConsumerViewModel> Consumers => _consumers;

       

        public ICommand AddConsumerCommand { get; }
        public ICommand LoadConsumersCommand { get; }   


        public ConsumersListViewModel(ConsumersStore consumersStore, NavigationService addConsumerNavigationService)
        {
            _consumerStore = consumersStore;
            _consumers = new ObservableCollection<ConsumerViewModel>();

            AddConsumerCommand = new NavigateCommand(addConsumerNavigationService);
            LoadConsumersCommand = new LoadConsumersCommand(this, _consumerStore);
        }

        internal void UpdateConsumers(IEnumerable<Consumer> consumers)
        {
            _consumers.Clear();

            foreach (var consumer in consumers)
            {
                ConsumerViewModel consumerViewModel = new ConsumerViewModel(consumer);
                
                _consumers.Add(consumerViewModel);
            }
        }

        public static ConsumersListViewModel LoadViewModel(ConsumersStore consumersStore, AddConsumerViewModel addConsumerViewModel, NavigationService navigationService)
        {
            ConsumersListViewModel viewModel = new ConsumersListViewModel(consumersStore, navigationService);

            viewModel.LoadConsumersCommand.Execute(null);

            return viewModel;
        }
    }
}
