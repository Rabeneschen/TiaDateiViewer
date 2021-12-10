// -----------------------------------------------------------------------------
//   Component       : TiaFileViewer
//   Name            : RelayCommand.cs
//   Last Author     : Spyra, Paul
//   Last modified   : 12/08/2021 13:06
// -----------------------------------------------------------------------------

namespace TiaFileViewer.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Base command for UI commands
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> myExecute;
        private Func<object, bool> myCanExecute;

        public RelayCommand(Action<object> theExecute, Func<object, bool> theCanExecute = null)
        {
            this.myExecute = theExecute;
            this.myCanExecute = theCanExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object theParameter)
        {
            return this.myCanExecute == null || this.myCanExecute(theParameter);
        }

        public void Execute(object theParameter)
        {
            this.myExecute(theParameter);
        }
    }
}
