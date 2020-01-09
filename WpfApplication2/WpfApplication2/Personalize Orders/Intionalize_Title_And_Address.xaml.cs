using System.Windows;
using System.Windows.Forms;

namespace Persion_Assistant08.Personalize_Orders
{
    /// <summary>
    /// Interaction logic for Intionalize_Title_And_Address.xaml
    /// </summary>
    public partial class Intionalize_Title_And_Address : Window
    {
       
        public Intionalize_Title_And_Address()
        {
            Order_Eror.Address = Order_Eror.title = null;
            InitializeComponent();
        }
      public OpenFileDialog openFileDialog = new OpenFileDialog();
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            
            openFileDialog.ShowDialog();
           Order_Eror. Address = openFileDialog.FileName;

        }

        public void Ok_Click(object sender, RoutedEventArgs e)
        {
          
            Close();
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(textBox.Text!=null&& textBox.Text != "")
                Order_Eror.title = textBox.Text;
            Edit_Orders.Edit( Order_Eror.Order, Order_Eror.Address, Order_Eror.title);
        }
    }
}
