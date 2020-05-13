using System;
using System.ComponentModel;

namespace PriceCalculator.Windows.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private DateTime insertDate;
        public DateTime InsertDate
        {
            get { return insertDate; }
            set
            {
                if (insertDate != value)
                {
                    insertDate = value;
                    OnPropertyChanged("InsertDate");
                }
            }
        }

        private DateTime? lastChangeDate;
        public DateTime? LastChangeDate
        {
            get { return lastChangeDate; }
            set
            {
                if (lastChangeDate != value)
                {
                    lastChangeDate = value;
                    OnPropertyChanged("LastChangeDate");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
