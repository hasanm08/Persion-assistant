using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using WpfApplication2;

namespace Persion_Assistant08.Default_Orders_Functions
{
    public class Helper
    {
        public string دستور { get; set; }
            public string کارکرد { get; set; }

        public Help Save_informations
        {
            get => default;
            set
            {
            }
        }

        public Helper(string c, string w)
        {
            دستور = c;
            کارکرد = w;
        }
    }
  public  class Helper2
    {
        public string دکمه {get; set;}
            public string عملکرد {get; set;}

        public Help Save_informations
        {
            get => default;
            set
            {
            }
        }

        public Helper2(string k, string w)
        {
            دکمه = k;
            عملکرد = w;


    }
}
   
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public bool Player = false;
        public   List<Helper> h = new List<Helper>();
        public List<Helper2> h2 = new List<Helper2>();
        public Help()
        {
            this.Title = "راهنما";
            this.FlowDirection = FlowDirection.RightToLeft;
           
            h.Add(new Helper("یاداوری","مشاهده و ساخت یاداورها"));
            h.Add(new Helper("رزرو - تغذیه", "بازکردن سایت اتوماسیون تغذیه"));
            h.Add(new Helper("الو", "بازکردن الو وب"));
            h.Add(new Helper("میهن بلاگ", "بازکردن میهن بلاگ"));
            h.Add(new Helper("کوئرا"+"-"+"کویرا", "باز کردن کوئرا"));
            h.Add(new Helper("مفشو", "باز کردن وبلاگ مفشو"));
            h.Add(new Helper("درباره", "درباره ی ما"));
            h.Add(new Helper("واتساپ", "بازکردن واتساپ وب"));

           
         


            h.Add(new Helper("گوگل", "باز کردن گوگل"));
            h.Add(new Helper("ریاضی در زندگی", "باز کردن وبلاگ محبوب ریاضی در زندگی"));
            h.Add(new Helper("ساختمان داده", "پخش فیلم های ساختمان داده"));
            h.Add(new Helper("ایمیل", "ارسال ایمیل"));
            h.Add(new Helper("دانلود فیلم" + "-" + "دف", "دانلود فیلم مشخص شده"));
            h.Add(new Helper("دانلود اهنگ" + "-" + "دا", "جستجوی اهنگ مشخص شده"));
            for (int i = 0; i < Persion_Assistant08.Personalize_Orders.Edit_Orders.orders.Count; i++)
            {
                h.Add(new Helper(Persion_Assistant08.Personalize_Orders.Edit_Orders.orders[i].Title, Persion_Assistant08.Personalize_Orders.Edit_Orders.orders[i].Address));
            }
            h.Add(new Helper("بستن", "بستن دستیار"));
           



            h2.Add(new Helper2("جهت راست", "5 ثانیه عقب بردن"));
            h2.Add(new Helper2("جهت چپ", "5ثانیه جلو بردن "));
            h2.Add(new Helper2("جهت بالا", "اقزایش صدا"));
            h2.Add(new Helper2("جهت پایین", "کاهش صدا"));
            h2.Add(new Helper2("شیفت راست", "نام فایل"));
            h2.Add(new Helper2("یک کیبورد ماشین حساب", "تاگل اندازه"));
            h2.Add(new Helper2("صفر کیبورد ماشین حساب", "تاگل نشان دادن دکمه ها"));
            h2.Add(new Helper2("اسپیس", "تاگل بین پخش ومکث"));
            h2.Add(new Helper2("اینتر", "بازکردن زیرنویس"));
            h2.Add(new Helper2("دو کیبورد ماشین حساب", "راهنما"));
            h2.Add(new Helper2("کنترل راست", "بستن"));
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.FlowDirection = FlowDirection.RightToLeft;
            if (!Player)
            {
                dataGrid.ItemsSource = h;
            }
            else
            {
                dataGrid.ItemsSource = h2;
            }
          
            
           
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string result;
            var cellInfo = dataGrid.SelectedCells[0];

            var content =( cellInfo.Column.GetCellContent(dataGrid.SelectedItem) as System.Windows.Controls.TextBlock).Text;
            MainWindow mainWindow = new MainWindow();
            if (content.Contains("-"))
            {
                result = (content.Split('-'))[1];
              result=  System.Text.RegularExpressions.Regex.Replace(result, "[ ]", "");
               
            }
            else
            {
                result = content as string;
            }
            MessageBox.Show(result);
            mainWindow.textBox.Text = result;
            mainWindow.button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

        }
    }
}
