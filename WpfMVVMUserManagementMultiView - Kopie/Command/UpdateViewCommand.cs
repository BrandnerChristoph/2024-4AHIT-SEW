using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMUserManagementMultiView.ViewModel;

namespace WpfMVVMUserManagementMultiView.Command
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Commands für die Menüleiste (siehe MainWindow.xaml in den MenuItems.Command und MenuItems.CommandParameter) 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            if(parameter.ToString() == "CloseApp")
                Environment.Exit(0);
            else if (parameter.ToString() == "About")
                viewModel.SelectedViewModel = new AboutViewModel();
            else if (parameter.ToString() == "Person")
                viewModel.SelectedViewModel = new PersonViewModel();
            else if (parameter.ToString() == "Dashboard")
                viewModel.SelectedViewModel = new DashboardViewModel();
        }
    }
}
