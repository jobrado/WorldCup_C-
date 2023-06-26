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
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamWindow(string data)
        {
            
            InitializeComponent();
            string[] d = data.Split('|');

            lbCode.Content = d[1];
            lbName.Content = d[0];
            lbPlGames.Content = d[2];
            lbWins.Content = d[3];
            lbLoses.Content = d[4];
            lbDraws.Content = d[5];
            lbGiven.Content = d[6];
            lbReceived.Content = d[7];
            lbDiff.Content = d[8];
        }
    }
}
