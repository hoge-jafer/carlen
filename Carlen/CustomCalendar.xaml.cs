using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carlen
{
    /// <summary>
    /// CustomCalendar.xaml 的交互逻辑
    /// </summary>
    public partial class CustomCalendar : UserControl
    {
        public CustomCalendar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DateTimeFontSizeProperty = DependencyProperty.Register("DateTimeFontSize", typeof(int), typeof(CustomCalendar), new PropertyMetadata(27));

        public int DateTimeFontSize
        {
            get => Convert.ToInt32(GetValue(DataContextProperty));
            set => SetValue(DataContextProperty, value);
        }

        public static readonly DependencyProperty BackGroundEllipesStretchProperty = DependencyProperty.Register("BackGroundEllipesStretch", typeof(Stretch), typeof(CustomCalendar), new PropertyMetadata(Stretch.UniformToFill));

        public Stretch BackGroundEllipesStretch
        {
            get => (Stretch)GetValue(BackGroundEllipesStretchProperty);
            set => SetValue(BackGroundEllipesStretchProperty, value);
        }

        public static readonly DependencyProperty SelectItemBackGroundProperty = DependencyProperty.Register("SelectItemBackGround", typeof(SolidColorBrush), typeof(CustomCalendar), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public SolidColorBrush SelectItemBackGround
        {
            get => (SolidColorBrush)GetValue(SelectItemBackGroundProperty);
            set => SetValue(SelectItemBackGroundProperty, value);
        }

        public static readonly DependencyProperty BackGroundEllipesSizeProperty = DependencyProperty.Register("BackGroundEllipesSize", typeof(double), typeof(CustomCalendar), new PropertyMetadata(25.0));

        public double BackGroundEllipesSize
        {
            get => Convert.ToDouble(GetValue(BackGroundEllipesSizeProperty));
            set => SetValue(BackGroundEllipesSizeProperty, value);
        }

        public static readonly DependencyProperty SelectItemListBackGroundProperty = DependencyProperty.Register("SelectItemListBackGround", typeof(SolidColorBrush), typeof(CustomCalendar), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public SolidColorBrush SelectItemListBackGround
        {
            get => (SolidColorBrush)GetValue(SelectItemListBackGroundProperty);
            set => SetValue(SelectItemListBackGroundProperty, value);
        }

        public static readonly DependencyProperty BackGroundShowModeProperty = DependencyProperty.Register("BackGroundShowMode", typeof(ShowMode), typeof(CustomCalendar), new PropertyMetadata(ShowMode.None));

        public ShowMode BackGroundShowMode
        {
            get => (ShowMode)GetValue(BackGroundShowModeProperty);
            set => SetValue(BackGroundShowModeProperty, value);
        }
        public static readonly DependencyProperty SetYearProperty = DependencyProperty.Register("SetYear", typeof(int), typeof(CustomCalendar), new PropertyMetadata(DateTime.Now.Year));

        public int SetYear
        {
            get => Convert.ToInt32(GetValue(SetYearProperty));
            set => SetValue(SetYearProperty, value);
        }
        public static readonly DependencyProperty SetMonthProperty = DependencyProperty.Register("SetMonth", typeof(int), typeof(CustomCalendar), new PropertyMetadata(DateTime.Now.Month));

        public int SetMonth
        {
            get => Convert.ToInt32(GetValue(SetMonthProperty));
            set => SetValue(SetMonthProperty, value);
        }
        //DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))
        public static readonly DependencyProperty SelectDateTimePropery = DependencyProperty.Register("SelectDateTime", typeof(List<DateTime>), typeof(CustomCalendar), new PropertyMetadata(new List<DateTime>() { }));

        public List<DateTime> SelectDateTime
        {
            get => (List<DateTime>)GetValue(SelectDateTimePropery);
            set => SetValue(SelectDateTimePropery, value);
        }
    }
}
