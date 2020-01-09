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
using System.Windows.Shapes;
using WpfApplication2;

namespace Persion_Assistant08.Reminder
{
    /// <summary>
    /// Interaction logic for Reminder_DeadLine.xaml
    /// </summary>
    public partial class Reminder_DeadLine : Window
    {
        public  int Days = 0;
        public Reminder Reminder { get; set; }

        public Reminder Reminder1
        {
            get => default;
            set
            {
            }
        }

        public Reminder_DeadLine( Reminder reminder )
        {
            InitializeComponent();
            Reminder = reminder;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            A_Day.IsChecked = true;
            Title = "سررسید موعد";
            Reminder_T_Te.Text = Reminder.name;
            Reminder_Te_Te.Text = Reminder.ReminderText;
            System.DateTime time = System.DateTime.Now;
            System.IFormatProvider culture = new System.Globalization.CultureInfo("fa-FA"); 
            string fullDayMonthYearOnly = time.ToString("dd MMMM yyyy", culture);
            string s = fullDayMonthYearOnly;
            Something.Text = " امروز"+s+"\n "+" موعد یادآور زیر فرا رسیده است";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (A_Day.IsChecked == true)
            {
                Days = 1;
                // Reminder.ReminderDate.AddDays(1);
            }
            if (Two_Day.IsChecked == true)
            {
                Days = 2;
                //Reminder.ReminderDate.AddDays(2);
            }
            if (A_Week.IsChecked == true)
            {
                Days = 7;
               // Reminder.ReminderDate.AddDays(7);
            }
            if (A_Month.IsChecked == true)
            {
                Days = 30;
               // Reminder.ReminderDate.AddDays(30);
            }
            Hide();
            Close();
        }
    }
}
