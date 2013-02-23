using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace VochtBalans.Model
{
    [Table]
    public class Event : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public Event()
        { 
        
        }

        #region Parent Properties
        private int eventId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int EventId
        {
            get { return eventId; }
            set
            {

                if (eventId != value)
                {
                    NotifyPropertyChanging("EventId");
                    eventId = value;
                    NotifyPropertyChanged("EventId");
                }

            }
        }

        private EventType type;

        [Column]
        public EventType Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    NotifyPropertyChanging("Type");
                    type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

   

        private DateTime dateAndTime;

        [Column]
        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set {
                if (dateAndTime != value)
                {
                    NotifyPropertyChanging("DateAndTime");
                    dateAndTime = value;
                    NotifyPropertyChanged("DateAndTime");
                }
            
            }
        }
        
        #endregion

        #region BorstVoeding Properties

        private bool fedLeft;

        [Column]
        public bool FedLeft
        {
            get { return fedLeft; }
            set {
                if (fedLeft != value)
                {
                    NotifyPropertyChanging("FedLeft");
                    fedLeft = value;
                    NotifyPropertyChanged("FedLeft");
                }
            
            }
        }

        private bool fedRight;

        [Column]
        public bool FedRight
        {
            get { return fedRight; }
            set
            {
                if (fedRight != value)
                {
                    NotifyPropertyChanging("FedRight");
                    fedRight = value;
                    NotifyPropertyChanged("FedRight");
                }
            }
        }
        
        #endregion

        #region Luier properties

        private bool urine;

        [Column]
        public bool Urine
        {
            get { return urine; }
            set {

                if (urine != value)
                {
                    NotifyPropertyChanging("Urine");
                    urine = value;
                    NotifyPropertyChanged("Urine");
                }
            }
        }

        private bool uraten;

        [Column]
        public bool Uraten
        {
            get { return uraten; }
            set
            {

                if (uraten != value)
                {
                    NotifyPropertyChanging("Uraten");
                    uraten = value;
                    NotifyPropertyChanged("Uraten");
                }
            }
        }

        private bool ontlasting;

        [Column]
        public bool Ontlasting
        {
            get { return ontlasting; }
            set
            {

                if (ontlasting != value)
                {
                    NotifyPropertyChanging("Ontlasting");
                    ontlasting = value;
                    NotifyPropertyChanged("Ontlasting");
                }
            }
        }

        #endregion

        #region Temperatuur properties

        private decimal? temperatuur;
        [Column]
        public decimal? Temperatuur
        {
            get { return temperatuur; }
            set {
                if (temperatuur != value)
                {
                    NotifyPropertyChanging("Temperatuur");
                    temperatuur = value;
                    NotifyPropertyChanged("Temperatuur");
                }
            }
        }

        #endregion

        #region Kolven

        private int? kolvenMM;
        [Column]
        public int? KolvenMM
        {
            get { return kolvenMM; }
            set {
                if (kolvenMM != value)
                {
                    NotifyPropertyChanging("KolvenMM");
                    kolvenMM = value;
                    NotifyPropertyChanged("KolvenMM");
                }
            }
        }

      

        #endregion

        //TODO: remove
        #region Bijvoeding
        private int? bijvoedingMM;
        [Column]
        public int? BijvoedingMM
        {
            get { return bijvoedingMM; }
            set
            {
                if (bijvoedingMM != value)
                {
                    NotifyPropertyChanging("BijvoedingMM");
                    bijvoedingMM = value;
                    NotifyPropertyChanged("BijvoedingMM");
                }
            }
        }
        

        #endregion

        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion        

        public static SolidColorBrush GetColor(EventType? type)
        {
            switch (type)
            {
                case EventType.Borstvoeding:
                    return new SolidColorBrush(Colors.Magenta);

                case EventType.Luier:
                    return new SolidColorBrush(Colors.Brown);

                case EventType.Temperatuur:
                    return new SolidColorBrush(Colors.Orange);

                case EventType.Kolven:
                    return new SolidColorBrush(Colors.Green);
                case EventType.Bijvoeding:
                    return new SolidColorBrush(Colors.Gray);

                case null:
                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }
    }
}
