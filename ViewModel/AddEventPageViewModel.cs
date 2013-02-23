using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VochtBalans.Model;

namespace VochtBalans.ViewModel
{
    public class AddEventPageViewModel
    {

        public Event Event { get; private set; }

        //todo List Of complex type: color,text,eventtype
        public List<EventTypeView> Types
        { 
            get {
                return new List<EventTypeView>()
                {
                    new EventTypeView(EventType.Borstvoeding),
                    new EventTypeView(EventType.Luier),
                    new EventTypeView(EventType.Kolven),
                    new EventTypeView(EventType.Bijvoeding),                    
                    new EventTypeView(EventType.Temperatuur)
                };
            } 
        }

        public int Hour { get; set; }

        public AddEventPageViewModel()
        {
            Event = new Event();
        }
    }
}
