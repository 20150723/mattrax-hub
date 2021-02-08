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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["managementServer"] as string == "")
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            } else
            {
                // App.IsNavigationEnabled = true;
                ContentFrame.Navigate(typeof(HomePage));
            }
           
        }

        private void Navigation_Invoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            var pageType =
                label == "Home" ? typeof(HomePage) :
                label == "Applications" ? typeof(ApplicationsPage) :
                label == "My Device" ? typeof(MyDevicePage) :
                args.InvokedItem == Navigation.SettingsItem ? typeof(SettingsPage) : null;
            if (pageType != null && pageType != ContentFrame.CurrentSourcePageType)
            {
                ContentFrame.Navigate(pageType);
            }
        }
    }
}
