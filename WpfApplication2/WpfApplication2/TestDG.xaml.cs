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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for TestDG.xaml
    /// </summary>
    public partial class TestDG : Window
    {
        public TestDG(List<LinkItem>DataGridSource)
        {
            InitializeComponent();
            this.DataGridSource = DataGridSource;
        }

        public List<LinkItem> DataGridSource { get; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             dataGrid.ItemsSource = DataGridSource;
           // Width = dataGrid.Width;
          //  Height = dataGrid.Height;
        } 

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }
    }
}
