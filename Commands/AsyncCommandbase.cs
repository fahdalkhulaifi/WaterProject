using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Commands;

namespace WaterNetwork.WPF.Commands
{
    public abstract class AsyncCommandbase : CommandBase
    {
        private bool IsExecuting;
        private bool MyProperty
        {
            get { return IsExecuting; }
            set
            {
                IsExecuting = value;
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
