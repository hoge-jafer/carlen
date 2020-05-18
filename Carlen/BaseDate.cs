using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace Carlen
{
    public class BaseDate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnValueChanged([CallerMemberName]string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ObservableCollection<BaseTime> Time { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public ICommand Click
        {
            get => new ClickCommand(new Action<object>(OnClick));
        }
        public ICommand NextClick
        {
            get => new ClickCommand(new Action<object>(OnNextClick));
        }
        int monthcount = 0;
        private void OnNextClick(object N)
        {
            UpDateTime(N, 1);
            Month++;
            monthcount++;
            if (Month == 13)
            {
                Month = 1;

                this.Year += 1;
            }
            SetTime(this.Year, this.Month);
            UpDateTime(N);
            Clear();
            SetNorm();
            SetSelectTime();
        }
        public TimeSpan SelectTime
        {
            get; set;
        }
        private object _SelectDateTimeList;
        public Object SelectDateTimeList
        {
            get => _SelectDateTimeList;
            set
            {
                _SelectDateTimeList = value;
                OnValueChanged();
            }
        }
        public List<DateTime> SetSelectTime()
        {
            var ls = new List<DateTime>();
            if (StackBaseTimeList.Count >= 1)
            {
                var l = StackBaseTimeList.Last();
                var f = StackBaseTimeList.First();

                if (Year == 0 && Month == 0)
                {

                    if (StackBaseTimeList.Count == 1)
                    {
                        ls.Add(new DateTime(year2, month2, StackBaseTimeList.Last().Time));

                        return ls;
                    }
                    else
                    {

                        ls.Add(new DateTime(year2, month2, StackBaseTimeList.Last().Time));
                        ls.Add(new DateTime(year2, month2, StackBaseTimeList.First().Time));
                    }
                }
                else
                {
                    if (StackBaseTimeList.Count == 1)
                    {
                        ls.Add(new DateTime(Year, Month, StackBaseTimeList.Last().Time));
                        return ls;
                    }
                    else
                    {
                        ls.Add(new DateTime(Year, Month, StackBaseTimeList.Last().Time));
                        ls.Add(new DateTime(Year, Month, StackBaseTimeList.First().Time));
                    }
                }
            }
            return ls;
        }
        private void UpDateTime(object N, int i = 0)
        {
            var arr = N as object[];

            var r1 = arr[0] as Run;
            var r2 = arr[1] as Run;
            if (i == 1)
            {
                Year = Convert.ToInt32(r1.Text);
                Month = Convert.ToInt32(r2.Text);

                return;
            }
            r1.Text = Year.ToString();
            r2.Text = Month.ToString();
        }

        public ICommand PreviousClick
        {
            get => new ClickCommand(new Action<object>(OnPreviousClick));
        }

        private void OnPreviousClick(object N)
        {
            UpDateTime(N, 1);
            Month--;
            monthcount--;
            if (Month == 0)
            {
                Month = 12;

                this.Year -= 1;
            }
            SetTime(this.Year, this.Month);
            UpDateTime(N);
            Clear();
            SetNorm();
            SetSelectTime();
        }

        private void OnClick(object obj)
        {
            if (obj != null)
                QueueUpDate(obj as BaseTime);
        }
        private int year2, month2;
        public void SetTime(int year, int month)
        {
            year2 = year;
            month2 = month;
            Time.Clear();
            StackBaseTimeList.Clear();
            SetNorm();
            Clear();
            var day = Days_of_month(year, month);
            var nk = Day_of_week(year, month, 1);
            if (nk == 0)
                nk = 7;
            for (var i = 0; i < nk - 1; i++)
            {
                Time.Add(new BaseTime());
            }
            for (var i = 0; i < day; i++)
            {
                Time.Add(new BaseTime() { Time = i + 1 });
            }



        }
        ////返回这个月一共有多少天 
        int Days_of_month(int year, int month)
        {
            //存储平年每月的天数 
            int[] month_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (2 == month && DateTime.IsLeapYear(year))
                return 29; // 如果是闰年2月，返回29天 
            else
                return month_days[month - 1];  //正常返回 
        }
        int Days_of_year(int year, int month, int day)
        {
            int i;
            int days = 0;
            for (i = 1; i < month; i++)
            {
                days += Days_of_month(year, i);

            }
            return days + day;
        }

        //返回这一天从公元元年算起是第几天

        int Get_days(int year, int month, int day)
        {
            int days = Days_of_year(year, month, day);
            int temp = year - 1;
            return temp * 365 + temp / 4 - temp / 100 + temp / 400 + days;
        }

        int Day_of_week(int year, int month, int day)
        {
            return Get_days(year, month, day) % 7;
        }



        public BaseDate()
        {

            StackBaseTimeList = new Stack<BaseTime>();
            Time = new ObservableCollection<BaseTime>();
            for (var i = 0; i < 31; i++)
                if (i == 5)
                    Time.Add(new BaseTime() { Time = i + 1, IsChangTemplate = true });
                else
                    Time.Add(new BaseTime() { Time = i + 1 });
        }

        private void SetBackGround()
        {
            SetNorm();
            var f = StackBaseTimeList.First();
            var l = StackBaseTimeList.Last();
            var start = Time.IndexOf(l);
            var end = Time.IndexOf(f);
            if (l.Time < f.Time)
                for (var i = start; i < end + 1; i++)
                {
                    var item = Time[i];
                    item.BackGroundShowMode = ShowMode.Both;
                    if (item.Time == l.Time)
                    {
                        item.BackGroundShowMode = ShowMode.Right;
                    }
                    if (item.Time == f.Time)
                    {
                        item.BackGroundShowMode = ShowMode.Left;

                    }


                }
            SelectDateTimeList = SetSelectTime();
        }
        private void SetNorm()
        {
            foreach (var item in Time)
            {
                item.BackGroundShowMode = ShowMode.None;
            }
        }

        private Stack<BaseTime> StackBaseTimeList;

        private void Clear()
        {
            foreach (var item in Time)
                item.ItemIsSelected = false;
            StackBaseTimeList.Clear();
        }

        private void QueueUpDate(BaseTime bt)
        {
            if (bt.ItemIsSelected)
            {
                if (StackBaseTimeList.Count < 2)
                {
                    if (StackBaseTimeList.Count == 1)
                    {
                        var l = StackBaseTimeList.Last();

                        if (bt.Time > l.Time)
                            StackBaseTimeList.Push(bt);
                        else
                        {
                            Clear();
                            l.ItemIsSelected = true;
                            StackBaseTimeList.Push(l);
                        }
                    }
                    else
                        StackBaseTimeList.Push(bt);
                }
                else
                {
                    var f = StackBaseTimeList.First();
                    var l = StackBaseTimeList.Last();
                    if (bt.Time > l.Time)
                    {
                        var pop = StackBaseTimeList.Pop();
                        pop.ItemIsSelected = false;
                        StackBaseTimeList.Push(bt);
                    }
                    else
                    {
                        Clear();
                        SetNorm();
                        l.ItemIsSelected = true;
                        StackBaseTimeList.Push(l);
                    }
                }
            }
            else
            {
                var f = StackBaseTimeList.First();
                var l = StackBaseTimeList.Last();
                if (l.Time == bt.Time)
                {
                    Clear();
                    SetNorm();
                }
                else if (f.Time == bt.Time)
                {
                    StackBaseTimeList.Pop();
                    SetNorm();
                }
                else if (bt.Time <= l.Time)
                {
                    Clear();
                    SetNorm();
                }

            }
            if (StackBaseTimeList.Count == 2)
                SetBackGround();
            SelectDateTimeList = SetSelectTime();
        }
    }
}
