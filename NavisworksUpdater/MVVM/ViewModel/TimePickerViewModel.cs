using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisworksUpdater.MVVM.ViewModel
{
    public class TimePickerViewModel : ViewModelBase
    {
        public List<int> Hours => Enumerable.Range(1, 12).ToList();
        public List<int> Minutes => Enumerable.Range(0, 60).ToList();
        public List<string> AmPmOptions => new List<string> { "AM", "PM" };

        private int _hour; 
        private int _minute;
        private string _amPm;

     

        public int Hour
        {
            get => _hour;
            set
            {
                if (_hour != value)
                {
                    _hour = value;
                    OnPropertyChanged(nameof(Hour));
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }

        public int Minute
        {
            get => _minute;
            set
            {
                if (_minute != value)
                {
                    _minute = value;
                    OnPropertyChanged(nameof(Minute));
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }

        public string AmPm
        {
            get => _amPm;
            set
            {
                if (_amPm != value)
                {
                    _amPm = value;
                    OnPropertyChanged(nameof(AmPm));
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }

        public DateTime SelectedTime
        {
            get
            {
                int hour = AmPm == "PM" && Hour != 12 ? Hour + 12 :
                           AmPm == "AM" && Hour == 12 ? 0 : Hour;

                return DateTime.Today.AddHours(hour).AddMinutes(Minute);
            }
            set
            {
                Hour = value.Hour % 12 == 0 ? 12 : value.Hour % 12;
                Minute = value.Minute;
                AmPm = value.Hour >= 12 ? "PM" : "AM";
            }
        }

    }

}
