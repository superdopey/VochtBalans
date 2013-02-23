using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VochtBalans.Model;
using VochtBalans.Resources;
using VochtBalans.ViewModel;
using System.Data.Linq;
using System.Diagnostics;
using Microsoft.Phone.Controls.Primitives;
using VochtBalans.Utils;

namespace VochtBalans
{
    public partial class AddEventPage : BasePage
    {
        private const string DateFormat = "ddMMyyyyhh";
        private const int MinKolfMM = 1;
        private const int MaxKolfMM = 150;
        public AddEventPage():base()
        {
            InitializeComponent();

            ViewModel = new AddEventPageViewModel();

            //get date with ddMMyyyyhh Format
            ViewModel.Event.DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,0,0);

            BuildLocalizedApplicationBar();
            //kolfMMloopingSelector.DataSource = new IntLoopingDataSource() { MinValue = MinKolfMM, MaxValue = MaxKolfMM, SelectedItem = 20 };            
        }

        

        private AddEventPageViewModel ViewModel
        {
            get {
                return (AddEventPageViewModel)DataContext;
            }
            set {
                DataContext = value;
            }
        }

        protected void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                EventTypeView eventViewType = (EventTypeView)e.AddedItems[0];
                ViewModel.Event.Type = eventViewType.Type;

                SwitchChildPanels(eventViewType.Type);
            }         
        }

        private void SwitchChildPanels(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Borstvoeding:
                    borstvoedingPanel.Visibility = System.Windows.Visibility.Visible;
                    kolvenPanel.Visibility = System.Windows.Visibility.Collapsed;
                    luierPanel.Visibility = System.Windows.Visibility.Collapsed;
                    temperatuurPanel.Visibility = System.Windows.Visibility.Collapsed;
                    bijvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case EventType.Luier:
                     borstvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    kolvenPanel.Visibility = System.Windows.Visibility.Collapsed;
                    luierPanel.Visibility = System.Windows.Visibility.Visible;
                    temperatuurPanel.Visibility = System.Windows.Visibility.Collapsed;
                    bijvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case EventType.Temperatuur:
                     borstvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    kolvenPanel.Visibility = System.Windows.Visibility.Collapsed;
                    luierPanel.Visibility = System.Windows.Visibility.Collapsed;
                    temperatuurPanel.Visibility = System.Windows.Visibility.Visible;
                    bijvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case EventType.Kolven:
                    borstvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    kolvenPanel.Visibility = System.Windows.Visibility.Visible;
                    luierPanel.Visibility = System.Windows.Visibility.Collapsed;
                    temperatuurPanel.Visibility = System.Windows.Visibility.Collapsed;
                    bijvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case EventType.Bijvoeding:
                    borstvoedingPanel.Visibility = System.Windows.Visibility.Collapsed;
                    kolvenPanel.Visibility = System.Windows.Visibility.Collapsed;
                    luierPanel.Visibility = System.Windows.Visibility.Collapsed;
                    temperatuurPanel.Visibility = System.Windows.Visibility.Collapsed;
                    bijvoedingPanel.Visibility = System.Windows.Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
 
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton saveAppBarButton = new ApplicationBarIconButton(new Uri("/Assets/check.png", UriKind.Relative));
            saveAppBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(saveAppBarButton);

            saveAppBarButton.Click += SaveButton_Click;
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            SaveEvent();
         
            //MessageBox.Show("gebeurtenis opgeslagen");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveEvent();
        }

        private void SaveEvent()
        {
            ApplicationBarHelper.UpdateBindingOnFocussedControl();
            this.Focus();
            
            Debug.WriteLine(string.Format("events before:{0}", dataContext.Events.Count()));

            Event existingEvent = (from Event ev in dataContext.Events
                                   where ev.DateAndTime == ViewModel.Event.DateAndTime
                                   && ev.Type == ViewModel.Event.Type
                                   select ev).FirstOrDefault();

            if (existingEvent != null)
            {
                dataContext.Events.DeleteOnSubmit(existingEvent);
                dataContext.SubmitChanges();
            }


            dataContext.Events.InsertOnSubmit(ViewModel.Event);
            dataContext.SubmitChanges();
            
            Debug.WriteLine(string.Format("events after:{0}", dataContext.Events.Count()));
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}