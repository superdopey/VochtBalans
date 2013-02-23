using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VochtBalans.Model
{
    public class EventViewRow
    {
        public string Type { get; private set; }
        public Dictionary<int, HourCell> HourCells { get; private set; }

        public EventViewRow()
        {
            InitializeHourRows(true);
        }

        /*
        public EventViewRow(List<Event> events, EventType type)
        {
            Type = type.ToString();
            List<Event> eventsWithThisType = (from Event ev in events
                                              where ev.Type == type
                                              select ev).ToList();

            InitializeHourRows(false);

            
            foreach (Event ev  in eventsWithThisType)
            {
                string text = "";

                switch (type)
                {
                    case EventType.Borstvoeding:
                        if (ev.FedLeft)
                        {
                            text += "L";
                        }

                        if (ev.FedRight)
                        {
                            if (ev.FedLeft)
                            {
                                text += "/";
                            }

                            text += "R";
                        }

                        break;
                    case EventType.Bijvoeding:
                        if(ev.BijvoedingMM.HasValue)
                        {
                            text += ev.BijvoedingMM.ToString();
                        }
                        break;                
                    case EventType.Temperatuur:
                        if (ev.Temperatuur.HasValue)
                        {
                            text += ev.Temperatuur.ToString();
                        }
                        break;
                    case EventType.Kolven:
                        if (ev.KolvenMM.HasValue)
                        {
                            text += ev.KolvenMM.ToString();
                        }
                        break;
                    default:
                        break;
                }

                //HourCells[ev.DateAndTime.Hour] = new HourCell(ev.Type,"x",new SolidColorBrush(Colors.Magenta));
                HourCells[ev.DateAndTime.Hour] = new HourCell(ev.Type, text);
            }
                        
        }
        */
        public EventViewRow(List<Event> filteredEvents,SolidColorBrush color)
        {
            InitializeHourRows(false);

            foreach (Event ev in filteredEvents)
            {
                string text = "";

                switch (ev.Type)
                {
                    case EventType.Borstvoeding:
                        if (ev.FedLeft)
                        {
                            text += "L";
                        }

                        if (ev.FedRight)
                        {
                            if (ev.FedLeft)
                            {
                                text += "/";
                            }

                            text += "R";
                        }

                        break;
                    case EventType.Bijvoeding:
                        if (ev.BijvoedingMM.HasValue)
                        {
                            text += ev.BijvoedingMM.ToString();
                        }
                        break;
                    case EventType.Temperatuur:
                        if (ev.Temperatuur.HasValue)
                        {
                            text += ev.Temperatuur.ToString();
                        }
                        break;
                    case EventType.Kolven:
                        if (ev.KolvenMM.HasValue)
                        {
                            text += ev.KolvenMM.ToString();
                        }
                        break;
                    default:
                        break;
                }

                //HourCells[ev.DateAndTime.Hour] = new HourCell(ev.Type,"x",new SolidColorBrush(Colors.Magenta));
                HourCells[ev.DateAndTime.Hour] = new HourCell(ev.Type, text,color);
            }

        }

        private void InitializeHourRows(bool showIndex )
        {
            HourCells = new Dictionary<int, HourCell>();
            for (int i = 0; i < 24; i++)
            {

                if (showIndex)
                {
                    HourCells.Add(i, new HourCell(null, i.ToString(), new SolidColorBrush(Colors.Black)));
                }
                else
                {
                    HourCells.Add(i, new HourCell(null, null, new SolidColorBrush(Colors.Black)));
                }
            }
        }
    }
}
