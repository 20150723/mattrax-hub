using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Hub
{
    public sealed partial class SettingsPage : Page
    {
        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public SettingsPage()
        {
            this.InitializeComponent();
            SettingUserUPN.Text = localSettings.Values["userUPN"] as string;
            SettingManagementURL.Text = localSettings.Values["managementServer"] as string;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["userUPN"] = SettingUserUPN.Text;
            localSettings.Values["managementServer"] = SettingManagementURL.Text;

            App.IsNavigationEnabled = true;
        }
    }
}
