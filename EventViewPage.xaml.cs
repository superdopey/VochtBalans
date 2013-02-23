using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VochtBalans.Model;
using VochtBalans.ViewModel;

namespace VochtBalans
{
    public partial class EventViewPage : BasePage
    {
        public EventViewPage()
        {
            InitializeComponent();

            ViewModel = new EventViewPageViewModel(GetEvents(DateTime.Today));
        }

        public EventViewPageViewModel ViewModel
        {
            get {
                return (EventViewPageViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }


        private List<Event>  GetEvents(DateTime dateTime)
        {
            DateTime fromDate = dateTime.AddSeconds(-1);
            DateTime till = dateTime.AddDays(1);

            List<Event> eventsThisDay = (from Event ev in dataContext.Events
                                               where ev.DateAndTime < till
                                               && ev.DateAndTime > fromDate
                                               select ev).ToList();

            return eventsThisDay;            
        }
    }
}