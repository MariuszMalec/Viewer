using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Viewer.Enums;
using Viewer.Models;
using Viewer.Service;

namespace Viewer.ViewModels
{
    public class ViewVarpoolModel : ViewModelBase
    {
        private string _varpoolFile = Path.Combine(@"C:\Users", Environment.UserName, @"Source\repos\Viewer\Viewer\SourceData", "A999999_varpool.xml");
        private VarpoolModel _currentDataFromVarpool { get; set; }

        public VarpoolModel CurrentDataFromVarpool
        {
            get { return _currentDataFromVarpool; }
            set { _currentDataFromVarpool = value; OnPropertyChanged(nameof(CurrentDataFromVarpool)); }
        }

        public ViewVarpoolModel()
        {
            CurrentDataFromVarpool = new VarpoolModel();
            LoadData();
        }

        private void LoadData()
        {
            var varpoolService = new VarpoolService(_varpoolFile);
            var xmlService = new XmlService(varpoolService);

            if (!File.Exists(_varpoolFile))
            {
                MessageBox.Show($"ups! {_varpoolFile}");
            }

            CurrentDataFromVarpool.VarpoolFile = _varpoolFile;
            CurrentDataFromVarpool.OrderName = xmlService.GetFromFileValue(VarpoolEnum.OrderName.ToString());
            CurrentDataFromVarpool.BmdType = xmlService.GetFromFileValue(VarpoolEnum.BmdType.ToString());
            CurrentDataFromVarpool.BladeMaterial = xmlService.GetFromFileValue(VarpoolEnum.BladeMaterial.ToString());
            CurrentDataFromVarpool.BladeOrientation = xmlService.GetFromFileValue(VarpoolEnum.BladeOrientation.ToString());
            CurrentDataFromVarpool.BROH = xmlService.GetFromFileValue(VarpoolEnum.BROH.ToString());
            CurrentDataFromVarpool.HROH = xmlService.GetFromFileValue(VarpoolEnum.HROH.ToString());
            CurrentDataFromVarpool.LROH = xmlService.GetFromFileValue(VarpoolEnum.LROH.ToString());

            OnPropertyChanged(nameof(CurrentDataFromVarpool));//TODO to zmienia texbox! Jak zrbic lepiej
        }
    }
}
