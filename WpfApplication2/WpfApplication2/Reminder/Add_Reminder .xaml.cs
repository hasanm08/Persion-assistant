using System;
using System.Windows;

namespace Persion_Assistant08.Reminder
{
    /// <summary>
    /// Interaction logic for Add_Reminder.xaml
    /// </summary>
    public partial class Add_Reminder : Window
    {
        string[] A = new string[30];
        public Add_Reminder()
        { 
            
          
            InitializeComponent();
        }

        public Reminder Reminder
        {
            get => default;
            set
            {
            }
        }

        bool Exist(Reminder r)
        {
            for(int i = 0; i < Remember.rem.Count; i++)
            {
                if(r == Remember.rem[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static void Save()
        {
            System.IO.StreamWriter W = new System.IO.StreamWriter(@"Reminder.txt", false);
            for (int i = 0; i < Remember.rem.Count; i++)
            {

                W.Write(Remember.rem[i].name);
                W.Write("@");

                W.Write(Remember.rem[i].ReminderText);
                W.Write("@");
                W.Write(Remember.rem[i].ReminderDate.Year.ToString());
                W.Write("@");
                W.Write(Remember.rem[i].ReminderDate.Month.ToString());
                W.Write("@");
                W.WriteLine(Remember.rem[i].ReminderDate.Day.ToString());



            }
            W.Dispose();
            W.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == false)
            {
                DateTime D = new DateTime(); ;
                DateTime d1 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                DateTime d2 = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day);
                TimeSpan s = d2 - d1;

                for (int i = 0; i < A.Length; i++)
                {
                    if (comboBox.SelectedItem.ToString() == A[i])
                    {
                        if (DateTime.Today.Day + i + 1 < s.Days)
                        {
                            D = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + i + 1);
                        }
                        else
                        {
                            D = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day + i + 1 - s.Days);
                        }


                    }
                }
                Reminder r = new Reminder(textBox.Text, D, textBox1.Text);
                if (!Exist(r))
                {
                    Remember.rem.Add(r);
                }
            }
            else
            {
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
                DateTime dateTime = persianCalendar.ToDateTime(int.Parse(Year.Text), int.Parse(Month.Text), int.Parse(Day.Text), 0, 0, 0, 0);
                Reminder r = new Reminder(textBox.Text, dateTime, textBox1.Text);
                if (!Exist(r))
                {
                    Remember.rem.Add(r);
                }
            }

            Save();
           
            MessageBox.Show("افزوده شد");
            Hide();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Year.Visibility = Visibility.Hidden;
            Month.Visibility = Visibility.Hidden;
            Day.Visibility = Visibility.Hidden;
            textBlockDay.Visibility = Visibility.Hidden;
            textBlockMonth.Visibility = Visibility.Hidden;
            textBlockYear.Visibility = Visibility.Hidden;

            this.FlowDirection = FlowDirection.RightToLeft;
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = (i + 1).ToString() + "روز اینده";
            }
            comboBox.ItemsSource = A;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Year.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;
            Day.Visibility = Visibility.Visible;
            textBlockDay.Visibility = Visibility.Visible;
            textBlockMonth.Visibility = Visibility.Visible;
            textBlockYear.Visibility = Visibility.Visible;

            comboBox.Visibility = Visibility.Hidden;
            textBlock2.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Year.Visibility = Visibility.Hidden;
            Month.Visibility = Visibility.Hidden;
            Day.Visibility = Visibility.Hidden;
            textBlockDay.Visibility = Visibility.Hidden;
            textBlockMonth.Visibility = Visibility.Hidden;
            textBlockYear.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Visible;
            textBlock2.Visibility = Visibility.Visible;
        }
    }
}
