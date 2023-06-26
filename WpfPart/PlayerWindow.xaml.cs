using DAL.Model;
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
using System.Xml.Linq;

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private const char DELIMITER = '|';

        public PlayerWindow(string player)
        {

            InitializeComponent();
            fillData(player);
        }

        private void fillData(string player)
        {
            string[] d = player.Split(DELIMITER);
            lbName.Content = d[0];
            lbShirtName.Content = d[1];
            lbPosition.Content = d[2];
            lbCaptain.Content = d[3];
            lbYellowCards.Content = d[4];
            lbNumberOfGoals.Content = d[5];
        }
    }
}
