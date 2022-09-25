using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Commands.Consumers;
using WaterNetwork.Domain.Models;
using WaterNetwork.Domain.Queries;

namespace WaterNetwork.WPF.Stores
{
    public class ConsumersStore
    {
        private IGetAllConsumersQuery getAllConsumersQuery;
        private IAddConsumerCommand addConsumerCommand;
        private IDeleteConsumerCommand deleteConsumerCommand;

        private Lazy<Task> _initializeLazy;
        private readonly List<Consumer> _consumers;
        public IEnumerable<Consumer> Consumers => _consumers;


        public event Action ConsumersLoaded;
        public event Action<Consumer> ConsumerAdded;
        //public event Action<Registration> YouTubeViewerUpdated;
        public event Action<int> ConsumerDeleted;

        public ConsumersStore(IGetAllConsumersQuery getAllConsumersQuery, IAddConsumerCommand addConsumerCommand, IDeleteConsumerCommand deleteConsumerCommand)
        {
            this.getAllConsumersQuery = getAllConsumersQuery;
            this.addConsumerCommand = addConsumerCommand;
            this.deleteConsumerCommand = deleteConsumerCommand;

            _initializeLazy = new Lazy<Task>(Initialize);
            _consumers = new List<Consumer>();
        }

        public async Task Initialize()
        {
            var consumers = await getAllConsumersQuery.Execute();

            _consumers.Clear();

            _consumers.AddRange(consumers);
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
                //RegistrationsLoaded?.Invoke();
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }
    }
}
