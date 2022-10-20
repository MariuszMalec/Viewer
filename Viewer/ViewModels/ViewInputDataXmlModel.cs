using System;
using System.IO;
using Viewer.Enums;
using Viewer.Models;
using Viewer.Service;

namespace Viewer.ViewModels
{
    public class ViewInputDataXmlModel : ViewModelBase
    {
        private string _inputDataXml = Path.Combine(@"C:\Users", Environment.UserName, @"Source\repos\Viewer\Viewer\SourceData", "inputdata.xml");
        private InputDataXml _currentDataFromInputXml { get; set; }
        public InputDataXml CurrentDataFromInputXml
        {
            get { return _currentDataFromInputXml; }
            set { _currentDataFromInputXml = value; OnPropertyChanged(nameof(CurrentDataFromInputXml)); }
        }

        public ViewInputDataXmlModel()
        {
            CurrentDataFromInputXml = new InputDataXml();
            LoadData();
        }

        private void LoadData()
        {
            var inputDataXmlService = new InputDataXmlService(_inputDataXml);
            var xmlService = new XmlService(inputDataXmlService);

            CurrentDataFromInputXml.outfile = _inputDataXml;
            CurrentDataFromInputXml.infile = xmlService.GetFromFileValue(InputXmlEnum.infile.ToString());
            CurrentDataFromInputXml.machine = xmlService.GetFromFileValue(InputXmlEnum.machine.ToString());
            CurrentDataFromInputXml.Clampingmethod = xmlService.GetFromFileValue(InputXmlEnum.Clampingmethod.ToString());
            CurrentDataFromInputXml.TypeBlade = xmlService.GetFromFileValue(InputXmlEnum.TypeBlade.ToString());
        }
    }
}
