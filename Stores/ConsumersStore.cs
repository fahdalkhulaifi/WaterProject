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
        private IGetConsumerQuery GetConsumerQuery;
        private IGetAllConsumersQuery GetAllConsumersQuery;
        private IAddConsumerCommand AddConsumerCommand;
        private IDeleteConsumerCommand DeleteConsumerCommand;
        

        private Lazy<Task> _initializeLazy;
        private readonly List<Consumer> _consumers;
        public IEnumerable<Consumer> Consumers => _consumers;


        public event Action ConsumersLoaded;
        public event Action<Consumer> ConsumerAdded;
        //public event Action<Registration> YouTubeViewerUpdated;
        public event Action<int> ConsumerDeleted;

        public ConsumersStore(IGetAllConsumersQuery getAllConsumersQuery, IGetConsumerQuery getConsumerQuery, IAddConsumerCommand addConsumerCommand, IDeleteConsumerCommand deleteConsumerCommand)
        {
            GetAllConsumersQuery = getAllConsumersQuery;
            GetConsumerQuery = getConsumerQuery;
            AddConsumerCommand = addConsumerCommand;
            DeleteConsumerCommand = deleteConsumerCommand;

            _initializeLazy = new Lazy<Task>(Initialize);
            _consumers = new List<Consumer>();
        }

        public async Task Initialize()
        {
            var consumers = await GetAllConsumersQuery.Execute();

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
                //throw;
            }
        }

        public Consumer Find(int id)
        {
            try
            {
                 return _consumers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public async Task AddConsumer(Consumer consumer)
        {
            await AddConsumerCommand.Execute(consumer);

            _consumers.Add(consumer);

            ConsumerAdded?.Invoke(consumer);
        }

        public bool VerifyConsumerExists(Consumer consumer)
        {
            var existingConsumer = _consumers.FirstOrDefault(c => c.FirstName == consumer.FirstName && c.LastName == consumer.LastName);

            if (existingConsumer != null)
                return true;

            return false;
        }
    }
}
