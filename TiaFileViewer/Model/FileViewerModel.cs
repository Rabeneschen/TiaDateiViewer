// -----------------------------------------------------------------------------
//   Component       : TiaFileViewer
//   Name            : SharedFileViewerViewModel.cs
//   Last Author     : Spyra, Paul
//   Last modified   : 12/08/2021 13:06
// -----------------------------------------------------------------------------
namespace TiaFileViewer.Model
{
    using Microsoft.Win32;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using System.Xml.Linq;
    using TiaFileViewer.Annotations;

    /// <summary>
    /// Model for FileViewer
    /// </summary>
    public class FileViewerModel : INotifyPropertyChanged
    {
        private string myPathToFile;

        /// <summary>
        /// Full path to *.tia file
        /// </summary>
        public string PathToFile
        {
            get => this.myPathToFile;
            set
            {
                this.myPathToFile = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Standard Win32 OpenFileDialog 
        /// </summary>
        public void OpenFileDialog()
        {

            var aDialog = new OpenFileDialog
                              {
                                  Title = "Open TIA File",
                                  Filter = "TIA files|*.tia",
                                  InitialDirectory = @"C:\"
                              };
            if (aDialog.ShowDialog() == true)
            {
                this.PathToFile = aDialog.FileName;
            }

        }

        /// <summary>
        /// Reads node types from xml file at chosen path
        /// </summary>
        /// <returns>List of types</returns>
        public IList<string> ReadNodeTypesFromXml()
        {
            var aReader = XmlReader.Create(this.myPathToFile);
            var aNodeTypesList = new List<string>();

            while (aReader.Read())
            {
                if (aReader.NodeType == XmlNodeType.Element && aReader.Name == "node")
                {
                    aNodeTypesList.Add(aReader.GetAttribute("Type"));
                }
            }

            return aNodeTypesList;
        }

        /// <summary>
        /// Reads elements filtered by Type from xml
        /// </summary>
        /// <returns>List of device names/id´s</returns>
        public List<string> ReadElementsFromXml(string theGroupFilter)
        {


            var aList = XDocument.Load(this.PathToFile).Descendants("node").Where(theNode => theNode.FirstAttribute.Value == theGroupFilter)
                .Descendants("property").Where(theNode => theNode.Element("key")?.Value == "Name").Select(theNode => theNode.Element("value")?.Value)
                .ToList();

            if (aList.Count==0)
            {aList = XDocument.Load(this.PathToFile).Descendants("node").Where(theNode => theNode.FirstAttribute.Value == theGroupFilter)
                    .Descendants("property").Where(theNode => theNode.Element("key")?.Value == "Id").Select(theNode => theNode.Element("value")?.Value)
                    .ToList();}

            return aList;

        }
    

    public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string thePropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(thePropertyName));
        }
    }
    
}
