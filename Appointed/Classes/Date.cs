﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointed.Events;
using System.Globalization;

namespace Appointed.Classes
{
    public class Date : ObservableObject
    {
        int _day;
        int _month;
        int _year;

        int _time24Hr;


        /// <summary>
        /// Invoked whenever the active date is changed
        /// </summary>
        public event EventHandler<EventArgs> ActiveDateChanged;

        // This is meant to be used within the current sidebar context. Ie, if hasChanged is set to true during some operation
        // with sidebar "x" active, sidebar "x" will use that information and subsequently set hasChanged back to false before it
        // goes out of context.

        // Specifically used to signal the DatePicker within the ModifyAppointmentDetails sidebar when a date is selected in the
        // mini calendar popup rather than the window just being closed. If the calendar popup modifies DIVM._activeDate, it sets
        // hasChanged to true so the date picker knows to use the value in DIVM._activeDate and so if the modifications are saved,
        // the modification takes into account the date change.
        bool _hasChanged;

        public Date()
        {
        }

        public int Day
        {
            get { return _day; }

            set
            {
                _day = value;
                RaisePropertyChangedEvent("Day");
                RaisePropertyChangedEvent("DateTimeStr");
                ActiveDateChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public int Month
        {
            get { return _month; }

            set
            {
                _month = value;
                RaisePropertyChangedEvent("Month");
                RaisePropertyChangedEvent("DateTimeStr");
                ActiveDateChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public int Year
        {
            get { return _year; }

            set
            {
                _year = value;
                RaisePropertyChangedEvent("Year");
                RaisePropertyChangedEvent("DateTimeStr");
                ActiveDateChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public int Time24Hr
        {
            get { return _time24Hr; }

            set
            {
                _time24Hr = value;
                RaisePropertyChangedEvent("Time24Hr");
                ActiveDateChanged?.Invoke(this, EventArgs.Empty);
            }
        }



        public bool HasChanged
        {
            get { return _hasChanged; }
            set { _hasChanged = value; }
        }

        public override string ToString()
        {
            return _year + "-" + (_month < 10 ? "0" + _month : _month.ToString()) + "-" + (_day < 10 ? "0" + _day : _day.ToString());
        }


        public string DateTimeStr
        {
            get
            {
                string dTS = Year.ToString() + '-' + Month.ToString() + "-" + Day.ToString();
                return dTS;
            }
        }


        public void SetDateAndTime(DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            Time24Hr = (dt.Hour * 100) + dt.Minute;
        }


        public void SetDate(DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
        }



    }
}
