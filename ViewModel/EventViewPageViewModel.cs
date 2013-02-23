using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VochtBalans.Model;

namespace VochtBalans.ViewModel
{
   public class EventViewPageViewModel
   {
       #region Properties

       #endregion

       public List<Event> Events{ get; set; }
       public List<EventViewRow> EventViewRows { get; private set; }

        #region constructor
        public EventViewPageViewModel(List<Event> events)
        {
                      
            List<Event> borstVoedingEvents = (from Event ev in events
                                              where ev.Type == EventType.Borstvoeding
                                              select ev).ToList();

            List<Event> bijVoedingEvents = (from Event ev in events
                                              where ev.Type == EventType.Bijvoeding
                                              select ev).ToList();

            List<Event> luierUrine = (from Event ev in events
                                            where ev.Type == EventType.Luier
                                            && ev.Urine == true
                                            select ev).ToList();

            List<Event> luierOnt = (from Event ev in events
                                      where ev.Type == EventType.Luier
                                      && ev.Ontlasting == true
                                      select ev).ToList();

            List<Event> kolvenEvents = (from Event ev in events
                                            where ev.Type == EventType.Kolven
                                            select ev).ToList();

            List<Event> tempEvents = (from Event ev in events
                                        where ev.Type == EventType.Temperatuur
                                        select ev).ToList();

            

            EventViewRows = new List<EventViewRow>();
            EventViewRows.Add(new EventViewRow());
            EventViewRows.Add(new EventViewRow(borstVoedingEvents, Event.GetColor(EventType.Borstvoeding)));
            EventViewRows.Add(new EventViewRow(bijVoedingEvents, Event.GetColor(EventType.Bijvoeding)));
            EventViewRows.Add(new EventViewRow(luierUrine, new SolidColorBrush(Colors.Yellow)));
            EventViewRows.Add(new EventViewRow(luierOnt,Event.GetColor(EventType.Luier)));
            EventViewRows.Add(new EventViewRow(kolvenEvents,Event.GetColor(EventType.Kolven)));
            EventViewRows.Add(new EventViewRow(tempEvents,Event.GetColor(EventType.Temperatuur)));


            /*
            EventViewRows.Add(new EventViewRow(events,EventType.Borstvoeding));
            EventViewRows.Add(new EventViewRow(events, EventType.Bijvoeding));
            EventViewRows.Add(new EventViewRow(events, EventType.Luier));            
            EventViewRows.Add(new EventViewRow(events, EventType.Kolven));
            EventViewRows.Add(new EventViewRow(events, EventType.Temperatuur));
             */ 
            
        }
        #endregion
    }
}
