using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WaterNetworkProject.Models;
using WaterNetworkProject.Services;
using WaterNetworkProject.ViewModels;

namespace WaterNetworkProject.Commands
{
    public class MakeRegistrationCommand : CommandBase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private RegistrationsBook _registrationsBook;
        private readonly NavigationService _registartionService;

        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, RegistrationsBook registrationsBook, NavigationService registartionService)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;
            _registrationsBook = registrationsBook;
            this._registartionService = registartionService;
            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override void Execute(object parameter)
        {
            try
            {
                

                var consumer = _registrationsBook.GetConsumerById(_makeRegistrationViewModel.UserId);


                //ToDo: customize exception, user not found
                if (consumer == null)
                    throw new Exception();

                //ToDo: Update registration if exist
                Registration registration = new Registration(consumer, _makeRegistrationViewModel.CounterLecture, _makeRegistrationViewModel.RegistrationDate);

                _registrationsBook.MakeRegestration(registration);

                MessageBox.Show("تم التقييد بنجاح");

                _registartionService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show(".حدث خطأ ما");
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
