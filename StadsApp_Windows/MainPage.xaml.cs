using StadsApp_Windows.View;
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

namespace StadsApp_Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(OverzichtOndernemingen/*Page*/)); //navigeren naar pag
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(OndernemingAanmaken));
        }

        private void StackPanel_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Login));
        }
    }
}
