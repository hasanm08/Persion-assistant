using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Persion_Assistant08.Reminder
{
    public   class Reminder
    {
        public string name;
        public DateTime ReminderDate;
        public string ReminderText;
        public Reminder(string n,DateTime d,string t)
        {
            name = n;
            ReminderDate = d;
           ReminderText=t;
        }
        public static bool operator ==(Reminder R1, Reminder R2)
        {
            if (R1.name == R2.name && R1.ReminderDate == R2.ReminderDate && R1.ReminderText == R2.ReminderText)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Reminder R1, Reminder R2)
        {
            return !(R1 == R2);
        }
       
        public override int GetHashCode()
        {
            return base.GetHashCode();

        }
        public override bool Equals(object obj)
        {
            Reminder a = (Reminder)obj;
           
            return this==a;
        }

    }
    /// <summary>
    /// Interaction logic for Remember.xaml
    /// </summary>
    public partial class Remember : Window
    {
        public static  List<Reminder> rem = new List<Reminder>();
        public Remember()
        {
           
           
            
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            for(int i = 0; i < rem.Count; i++)
            {
                if (comboBox.SelectedItem.ToString() == rem[i].name)
                {
                    index = i;
                    label1.Content = (rem[i].ReminderDate - DateTime.Today).Days.ToString();
                    label.Text = rem[i].ReminderText;
                    return;
                }
            }
        }
        public int index;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.FlowDirection = FlowDirection.RightToLeft;
            for (int i = 0; i < rem.Count; i++)
            {
                
                comboBox.Items.Add(rem[i].name);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // comboBox.Items.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            rem.RemoveAt(index);
            Add_Reminder.Save();
            Hide();
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            rem[index].ReminderText = label.Text;
            Add_Reminder.Save();
            Hide();
            Close();
        }

        public Reminder field
        {
            get => default;
            set
            {
            }
        }
    }
}
