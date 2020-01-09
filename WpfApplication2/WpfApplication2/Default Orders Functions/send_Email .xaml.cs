using System;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Persion_Assistant08.Default_Orders_Functions
{
    /// <summary>
    /// Interaction logic for send_Email.xaml
    /// </summary>
    public partial class send_Email : Window
    {
        public send_Email()
        {
            InitializeComponent();
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static void Send_Mail(string Email, string body)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mathinnature08@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "دستیار فارسی " + "MIN";
                
                StringBuilder S = new StringBuilder();
                mail.Body = body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mathinnature08@gmail.com", "24121377");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                Mouse.OverrideCursor = Cursors.Arrow;
                Persion_Assistant08.Toast_Notification.PYNotif.Email();
                // MessageBox.Show("ایمیل ارسال شد", "دستیار فارسی", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
        }

     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FlowDirection = FlowDirection.RightToLeft;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            if (IsValidEmail(textBox.Text))
            {

                Send_Mail(textBox.Text, textBox1.Text);
            }
            else
            {
                MessageBox.Show("ایمیل نامعتبر است"," دستیار فارسی",MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.OK,MessageBoxOptions.RightAlign);
            }
           
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.Current.CurrentInputLanguage = new System.Globalization.CultureInfo("en-US");
        }

        private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.Current.CurrentInputLanguage = new System.Globalization.CultureInfo("fa-IR");
        }
    }
}
