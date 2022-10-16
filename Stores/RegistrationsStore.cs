using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Commands.Registrations;
using WaterNetwork.Domain.Models;
using WaterNetwork.Domain.Queries;

namespace WaterNetworkProject.Stores
{
    public class RegistrationsStore
    {
        private readonly IGetAllRegistrationsQuery _getAllRegistrationsQuery;
        private readonly IAddRegistrationCommand _addRegistrationCommand;
        private readonly IDeleteRegistrationCommand _deleteRegistrationCommand;

        private Lazy<Task> _initializeLazy;
        private readonly List<Registration> _registrations;
        public IEnumerable<Registration> Registrations => _registrations;


        public event Action RegistrationsLoaded;
        public event Action<Registration> RegistrationAdded;
        public event Action<int> RegistrationDeleted;

        public RegistrationsStore(IGetAllRegistrationsQuery getAllRegistrationsQuery, IAddRegistrationCommand addRegistrationCommand, IDeleteRegistrationCommand deleteRegistrationCommand)
        {
            _getAllRegistrationsQuery = getAllRegistrationsQuery;
            _addRegistrationCommand = addRegistrationCommand;
            _deleteRegistrationCommand = deleteRegistrationCommand;

            _initializeLazy = new Lazy<Task>(Initialize);
            _registrations = new List<Registration>();
        }

        private async Task Initialize()
        {
            IEnumerable<Registration> registrations = await _getAllRegistrationsQuery.Execute();

            _registrations.Clear();

            _registrations.AddRange(registrations);

        }



        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
                RegistrationsLoaded?.Invoke();
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }

        public async Task AddRegistration(Registration registration)
        {
            await _addRegistrationCommand.Execute(registration);

            _registrations.Add(registration);

            RegistrationAdded?.Invoke(registration);
        }

        //public async Task Update(YouTubeViewer youTubeViewer)
        //{
        //    await _updateYouTubeViewerCommand.Execute(youTubeViewer);

        //    int currentIndex = _youTubeViewers.FindIndex(y => y.Id == youTubeViewer.Id);

        //    if (currentIndex != -1)
        //    {
        //        _youTubeViewers[currentIndex] = youTubeViewer;
        //    }
        //    else
        //    {
        //        _youTubeViewers.Add(youTubeViewer);
        //    }

        //    YouTubeViewerUpdated?.Invoke(youTubeViewer);
        //}

        public async Task DeleteRegistration(int id)
        {
            await _deleteRegistrationCommand.Execute(id);

            _registrations.RemoveAll(y => y.Id == id);

            RegistrationDeleted?.Invoke(id);
        }
    }
}
