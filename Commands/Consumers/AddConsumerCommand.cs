using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WaterNetwork.Domain.Commands.Consumers;
using WaterNetwork.Domain.Models;
using WaterNetwork.WPF.Stores;
using WaterNetwork.WPF.ViewModels.Consumers;
using WaterNetworkProject.Services;

namespace WaterNetwork.WPF.Commands.Consumers
{
    public class AddConsumerCommand : AsyncCommandbase
    {
        private AddConsumerViewModel _addConsumerViewModel;
        private ConsumersStore _consumersStore;
        private readonly NavigationService _consumerNavigationService;
        private readonly IAddConsumerCommand _addConsumerCommand;

        public AddConsumerCommand(AddConsumerViewModel addConsumerViewModel, ConsumersStore consumersStore, NavigationService consumerNavigationService, IAddConsumerCommand addConsumerCommand)
        {
            _addConsumerViewModel = addConsumerViewModel;
            _consumersStore = consumersStore;
            _consumerNavigationService = consumerNavigationService;
            _addConsumerCommand = addConsumerCommand;

            _addConsumerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //ToDo: check if consumer exists
                await _consumersStore.Load();

                //ToDo: addMapper maybe 
                Consumer consumer = new Consumer();

                consumer.FirstName = _addConsumerViewModel.FirstName;
                consumer.LastName = _addConsumerViewModel.LastName;

                await _consumersStore.AddConsumer(consumer);
                MessageBox.Show("تم أضافة المستخدم بنجاح");

            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ خلال أضافة المستخدم");
            }

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
