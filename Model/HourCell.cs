using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VochtBalans.Model
{
    public class HourCell
    {
        private EventType? type{ get;set;}


        public SolidColorBrush Color
        {
            get;
            set;

        }
      
      
        public string Text { get; set; }


        public HourCell(EventType? type, string text,SolidColorBrush color)
        {
            Text = text;
            Color = color;
            this.type = type;
          
        }
    }
}
