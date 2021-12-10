// -----------------------------------------------------------------------------
//   Component       : TiaFileViewer
//   Name            : TypeGroupItem.cs
//   Last Author     : Spyra, Paul
//   Last modified   : 12/10/2021 23:45
// -----------------------------------------------------------------------------

namespace TiaFileViewer
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using TiaFileViewer.Annotations;

    /// <summary>
    /// TypeGroupItems for Header ListBox
    /// </summary>
    public class TypeGroupItem: INotifyPropertyChanged
    {
        private int myCount;
        private string myType;

        /// <summary>
        /// Specific node type
        /// </summary>
        public string Type
        {
            get => this.myType;
            set
            {
                this.myType = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Count of nodes of chosen type
        /// </summary>
        public int Count 
        { 
            get => this.myCount;
            set
            {
                this.myCount = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string thePropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(thePropertyName));
        }
    }
}
