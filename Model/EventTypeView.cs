using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VochtBalans.Model
{
    public class EventTypeView
    {
        public SolidColorBrush Color
        {
            get
            {
                return Event.GetColor(Type);
            }
        }

        
        public EventType Type { get; private set; }

        public EventTypeView(EventType type)
        {
            Type = type;
        }
    }
}
