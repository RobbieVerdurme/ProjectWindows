﻿using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.View;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        private MainPageViewModel vm;
        private OndernemingRepository OndernemingRepo;
        private AccountRepository AccountRepo;

        public MainPage()
        {
            this.InitializeComponent();
            this.vm = new MainPageViewModel();
            OndernemingRepo = new OndernemingRepository();
            AccountRepo = new AccountRepository();
            DataContext = vm;
        }

        //meth
		private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
		{
			// set the initial SelectedItem
			foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
			{
				if (item is NavigationViewItem && item.Tag.ToString() == "Overzicht_Page")
				{
					nvTopLevelNav.SelectedItem = item;
					break;
				}
			}

			mainFrame.Navigate(typeof(OverzichtOndernemingen), OndernemingRepo);
		}

		private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			
			if (args.IsSettingsInvoked)
			{
				//mainFrame.Navigate(typeof(SettingsPage));
			}
			else
			{
				TextBlock ItemContent = args.InvokedItem as TextBlock;
				if (ItemContent != null)
				{
					switch (ItemContent.Tag)
					{
						case "Overzicht_Page":
							mainFrame.Navigate(typeof(OverzichtOndernemingen), OndernemingRepo);
							break;

						case "Toevoegen_Page":
							mainFrame.Navigate(typeof(OndernemingAanmaken), OndernemingRepo);
							break;

                        case "OverzichtPromoties_Page":
                            mainFrame.Navigate(typeof(OverzichtPromoties), OndernemingRepo);
                            break;

                        case "AankomendeEvents_Page":
                            mainFrame.Navigate(typeof(OverzichtEvents), OndernemingRepo);
                            break;

                        case "OverzichtAbonnementen_Page":
                            mainFrame.Navigate(typeof(OverzichtAbonnementen), OndernemingRepo);
                            break;
                    }
				}
			}
		}

        private void UserButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Login), new AccountDTO()
            {
                OndernemingRepository = this.OndernemingRepo,
                AccountRepository = this.AccountRepo
            });
        }
    }
}
