using System.Windows.Input;
using Viewer.Enums;
using Viewer.Models;
using Viewer.Service;

namespace Viewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); }
        }

        //commands
        public ICommand ShowVarpoolViewCommand { get; }
        public ICommand ShowInputDataXmlViewCommand { get; }

        public MainViewModel()
        {
            ShowVarpoolViewCommand = new ViewModelCommand(ExecuteShowVarpoolViewCommand);
            ShowInputDataXmlViewCommand = new ViewModelCommand(ExecuteShowInputDataXmlViewCommand);

            //Default view
            //ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowInputDataXmlViewCommand(object obj)
        {
            CurrentChildView = new ViewInputDataXmlModel();
        }

        private void ExecuteShowVarpoolViewCommand(object obj)
        {
            CurrentChildView = new ViewVarpoolModel();
        }
    }
}
