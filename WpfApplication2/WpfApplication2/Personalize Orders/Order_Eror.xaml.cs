using System.Windows;

namespace Persion_Assistant08.Personalize_Orders
{
    /// <summary>
    /// Interaction logic for Order_Eror.xaml
    /// </summary>
    public partial class Order_Eror : Window
    {
        public static  string Address { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public static  string title { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public static  Order Order { get; set; }
        public Order_Eror( Order order)
        {
            Order = order;
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Intionalize_Title_And_Address intionalize_Title_And_Address = new Intionalize_Title_And_Address();
            MessageBox.Show("برای اینکه تنها مکان ویرایش شود جعبه متن را خالی بگذارید", "ویرایشگر دستیار", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RtlReading);
            intionalize_Title_And_Address.ShowDialog();
           
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("دوباره میبینمتون","ویرایش کننده دستیار",MessageBoxButton.OK,MessageBoxImage.Information,MessageBoxResult.OK,MessageBoxOptions.RtlReading);
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FlowDirection = FlowDirection.RightToLeft;
        }
    }
}
