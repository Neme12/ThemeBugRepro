using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThemeBugRepro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            SetTheme("Red");

            this.InitializeComponent();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            SetTheme("Red");
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            SetTheme("Blue");
        }

        private void SetTheme(string customTheme)
        {
            UpdateResources("Default", new Uri($"ms-appx:///CustomThemes/{customTheme}.xaml"));
            RefreshTheme();
        }

        private void UpdateResources(string theme, params Uri[] resourceUris)
        {
            var dictionaries = ((ResourceDictionary)Application.Current.Resources.ThemeDictionaries[theme]).MergedDictionaries;
            dictionaries.Clear();

            foreach (var resourceUri in resourceUris)
                dictionaries.Add(new ResourceDictionary { Source = resourceUri });
        }

        private void RefreshTheme()
        {
            if (RequestedTheme == ElementTheme.Dark)
            {
                RequestedTheme = ElementTheme.Light;
                RequestedTheme = ElementTheme.Dark;
            }
            else
            {
                RequestedTheme = ElementTheme.Dark;
                RequestedTheme = ElementTheme.Light;
            }
        }
    }
}
