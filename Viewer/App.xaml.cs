using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Viewer.Views;

namespace Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new MainView();
            loginView.Show();
        }

        private string fileLog = @"C:/temp/Viewer.log";
        public App()
        {
            this.DispatcherUnhandledException += this.App_DispatcherUnhandledException;
            try
            {
                //App.Settings = new Settings();
                //App.Settings.Load(); // this creates default settings.json file if does not exist
            }
            catch (Exception exception)
            {
                this.SaveException(exception);
                App.Current.Shutdown();
            }
        }
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            this.SaveException(e.Exception);
            MessageBox.Show($"Aplikacja zostanie zamknieta. Wystapil nie oczekiwany blad!" +
                $"Sprawdz plik {fileLog}", "UWAGA!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void SaveException(Exception exception)
        {
            string text = $"{exception.Message}{Environment.NewLine}{exception.StackTrace}";
            File.WriteAllText(fileLog, text);
        }
    }
}
