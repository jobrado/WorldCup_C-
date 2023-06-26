using DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for UCPlayer.xaml
    /// </summary>
    public partial class UCPlayer : UserControl
    {
        private const char DELIMITER = '|';
        private Player Pl;
        public UCPlayer(Player pl)
        {
            this.Pl = pl;
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            PlName.Content= Pl.Name;
            PlNumber.Content= Pl.ShirtNumber;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string AllPlayerData = Pl.Name + DELIMITER +
                                   Pl.ShirtNumber.ToString() + DELIMITER +
                                   Pl.Position + DELIMITER +
                                   Pl.Captain + DELIMITER +
                                   Pl.YellowCardsInThisMatch + DELIMITER +
                                   Pl.GoalsInThisMatch;
            new PlayerWindow(AllPlayerData).Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
