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

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for PopUpSaved.xaml
    /// </summary>
    public partial class PopUpClose : Window
    {
        public PopUpClose()
        {
            InitializeComponent();
        }

    
        private void btnOk_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                Environment.Exit(0);
            }
            if (e.Key == Key.Escape)
            {

                this.Close();
            }
        }
    }
}
