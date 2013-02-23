using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using VochtBalans.Data;

namespace VochtBalans.Model
{
    public class BasePage : PhoneApplicationPage, INotifyPropertyChanged
    {
        protected EventDataContext dataContext;

        public BasePage()
        {
            dataContext = new EventDataContext(EventDataContext.DBConnectionString);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
