// -----------------------------------------------------------------------------
//   Component       : TiaFileViewer
//   Name            : SharedFileViewerViewModel.cs
//   Last Author     : Spyra, Paul
//   Last modified   : 12/08/2021 13:06
// -----------------------------------------------------------------------------

namespace TiaFileViewer.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using TiaFileViewer.Annotations;
    using TiaFileViewer.Commands;
    using TiaFileViewer.Model;

    /// <summary>
    /// ViewModel for FileViewer
    /// </summary>
    public class FileViewerViewModel : INotifyPropertyChanged
    {

        private readonly FileViewerModel myFileViewerModel;
        private RelayCommand myOpenFileDialogCommand;
        private Visibility myTypesVisibility= Visibility.Collapsed;
        private Visibility myElementsVisibility = Visibility.Collapsed;
        private string myFileName;
        private ObservableCollection<TypeGroupItem> myListOfItems;
        private ObservableCollection<string> myListOfElements;
        private TypeGroupItem mySelectedTypeGroupItem;

        /// <summary>
        /// FileName to display in Window title
        /// </summary>
        public string FileName
        {
            get => this.myFileName;
            set
            {
                this.myFileName = value;
                this.OnPropertyChanged();
            }
        }
        /// <summary>
        /// Binding to currently selected typeItem listbox
        /// </summary>
        public TypeGroupItem SelectedTypeGroupItem
        {
            get => this.mySelectedTypeGroupItem;
            set
            {
                this.mySelectedTypeGroupItem = value;
                
                this.OnPropertyChanged();
                this.ListOfElements.Clear();
                this.FillElementsListBox();
            }
        }

        /// <summary>
        /// Binding to Visibility property of TypeItem listbox
        /// </summary>
        public Visibility TypesVisibility
        {
            get => this.myTypesVisibility;
            set
            {
                this.myTypesVisibility = value;
                this.OnPropertyChanged();
            }
        }
        /// <summary>
        /// Binding to Visibility property of Name/Id listbox
        /// </summary>
        public Visibility ElementsVisibility
        {
            get => this.myElementsVisibility;
            set
            {
                this.myElementsVisibility = value;
                this.OnPropertyChanged();
            }
        }
        public ObservableCollection<TypeGroupItem> ListOfItems
        {
            get => this.myListOfItems;
            set
            {
                this.myListOfItems = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ListOfElements
        {
            get => this.myListOfElements;
            set
            {
                this.myListOfElements = value;
                this.OnPropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public FileViewerViewModel()
        {
            this.myFileViewerModel = new FileViewerModel();
            this.ListOfItems = new ObservableCollection<TypeGroupItem>();
            this.ListOfElements = new ObservableCollection<string>();
            this.SelectedTypeGroupItem= new TypeGroupItem();
        }


        /// <summary>
        /// Command Opening tia file and filling header listbox
        /// </summary>
        public RelayCommand OpenFileDialogCommand
        {
            get
            {
                return this.myOpenFileDialogCommand ?? (this.myOpenFileDialogCommand = new RelayCommand(
                                                            theO =>
                                                                {
                                                                    this.ListOfItems.Clear();

                                                                    this.myFileViewerModel.OpenFileDialog();

                                                                    this.SetFileName();

                                                                    this.FillTypeItemListBox();
                                                                },
                                                            theO => true));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string thePropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(thePropertyName));
        }

        private void FillTypeItemListBox()
        {
            
            var aNodeList = this.myFileViewerModel.ReadNodeTypesFromXml();
            var aTypeItemList = from aNodeType in aNodeList
                                group aNodeType by aNodeType
                                into aGroup
                                select new TypeGroupItem
                                           {
                                               Type = aGroup.Key,
                                               Count = aGroup.Count()
                                           };


            foreach (var aItem in aTypeItemList)
            {
                this.ListOfItems.Add(aItem);
            }
            this.TypesVisibility = Visibility.Visible;
        }

        private void FillElementsListBox()
        {   

            if (SelectedTypeGroupItem?.Type == null)
                return;
            
            var aElementList = this.myFileViewerModel.ReadElementsFromXml(this.SelectedTypeGroupItem.Type);


            foreach (var aItem in aElementList)
            {
                this.ListOfElements.Add(aItem);
            }
            this.ElementsVisibility = Visibility.Visible;
        }

        private void SetFileName()
        {
            var aPathToFile = this.myFileViewerModel.PathToFile;
            this.FileName = Path.GetFileName(aPathToFile);
        }

        
    }

  
}
