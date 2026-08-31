using System;
using System.Windows.Input;

namespace TheMovies.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _doso;

        public RelayCommand(Action doso)
        {
            _doso = doso;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _doso();
        }
    }

}