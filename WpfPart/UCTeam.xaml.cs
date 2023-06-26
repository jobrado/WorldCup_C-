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
    /// Interaction logic for UCTeam.xaml
    /// </summary>
    public partial class UCTeam : UserControl
    {
        private string country;
        private string fifaCode;
        private long gamesPlayed;
        private long wins;
        private long losses;
        private long draws;
        private long goalsFor;
        private long goalsAgainst;
        private long goalDifferential;

        public UCTeam()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            lblName.Content = country;
            lblCode.Content = fifaCode;
            lblNumberOfPlayedGames.Content = gamesPlayed;
            lblNumberofvitories.Content = wins;
            lblNumberofdefeats.Content = losses;
            lblNumberofundicaded.Content= draws; 
            lblNumberofgoals.Content = goalsFor;
            lblNumberoftakengoals.Content = goalsAgainst;
            lblGoaldiff.Content= goalDifferential;
         }

        public UCTeam(string country, string fifaCode, long gamesPlayed, long wins, long losses, long draws, long goalsFor, long goalsAgainst, long goalDifferential)
        {
            this.country = country;
            this.fifaCode = fifaCode;
            this.gamesPlayed = gamesPlayed;
            this.wins = wins;
            this.losses = losses;
            this.draws = draws;
            this.goalsFor = goalsFor;
            this.goalsAgainst = goalsAgainst;
            this.goalDifferential = goalDifferential;
        }

    }
}
