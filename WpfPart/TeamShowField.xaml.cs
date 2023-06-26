using DAL.Model;
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
using System.Windows.Shapes;
using System.IO;
using System.CodeDom;

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for TeamShowField.xaml
    /// </summary>
    public partial class TeamShowField : Window
    {
        private string MATCHES_PATH;
        private const string MALE_MATCHES_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WindowsFormsPart\\Paths\\men\\matches.json";
        private const string FEMALE_MATCHES_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WindowsFormsPart\\Paths\\women\\matches.json";
        private const string LANGUAGE_TEAM_SCREEN_PATH = "newlanguage.txt";
        private const string FAVORITETEAM_PATH = "favorite_team_new.txt";
        private string favTeam;
        private string oppTeam;
        private static List<Player> playersFromFav = new List<Player>();
        private static List<Player> playersFromOpp = new List<Player>();
        private string LANGUAGE;
        private const char DELIMITER = '|';
        private string lang;
        private string gen;
        private string screensize;
        public TeamShowField()
        {
            LoadSaved();
            InitializeComponent();
            findPlayers(favTeam, oppTeam);
 //           FillPlayersInField();


        }

        private void LoadSaved()
        {
            if (File.Exists(LANGUAGE_TEAM_SCREEN_PATH))
            {
                using (StreamReader sr = new StreamReader(LANGUAGE_TEAM_SCREEN_PATH))
                {
                    string det = sr.ReadToEnd();
                    string[] d = det.Split(DELIMITER);
                    screensize = d[0];
                    lang = d[1];
                    gen = d[2];
                }
            }
            if (gen == "M")
            {
                MATCHES_PATH = MALE_MATCHES_PATH;
            }
            else
            {
                MATCHES_PATH = FEMALE_MATCHES_PATH;
            }

            if (lang == "cro")
            {
                LANGUAGE = "hr";
            }
            else
            {
                LANGUAGE = "en";
            }
            if (gen == "M")
            {
                MATCHES_PATH = MALE_MATCHES_PATH;
              
            }
            else
            {
                MATCHES_PATH = FEMALE_MATCHES_PATH;
              
            }
            if (screensize == "Small")
            {
                Application.Current.MainWindow.Width = 800;
                Application.Current.MainWindow.Height = 640;
            }
            else if (screensize == "Big")
            {
                Application.Current.MainWindow.Width = 1920;
                Application.Current.MainWindow.Height = 1200;
            }
           

            using (StreamReader sr = new StreamReader(FAVORITETEAM_PATH))
            {
                string det = sr.ReadToEnd();
                string[] d = det.Split(DELIMITER);
                favTeam = d[0];
                oppTeam = d[1].Trim();

            }

        }

        private void FillPlayersInField()
        {
            foreach (Player player in playersFromOpp.Where(p => p.Position == "Goalie"))
            {
                UCPlayer pl = new UCPlayer(player)
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                pnlOppGoalie.Children.Add(pl);
            }

            foreach (Player player in playersFromOpp.Where(p => p.Position == "Defender"))
            {
                UCPlayer pl = new UCPlayer(player)
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                pnlOppDefender.Children.Add(pl);
            }

            foreach (Player player in playersFromOpp.Where(p => p.Position == "Midfield"))
            {
                UCPlayer pl = new UCPlayer(player)
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                pnlOppGoalie.Children.Add(pl);
            }

            foreach (Player player in playersFromOpp.Where(p => p.Position == "Forward"))
            {
                UCPlayer pl = new UCPlayer(player)
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                pnlOppGoalie.Children.Add(pl);
            }
        }
        private void FillFavs()
        {
       lblFavTeam.Content=favTeam;
            
            foreach (Player player in playersFromFav)
            {


                UCPlayer pl = new UCPlayer(player);
                pl.Margin = new Thickness(0, 10, 0, 10);


                if (player.Position == "Goalie")
                {
                    pnlGoalie.Children.Add(pl);
                }
                if (player.Position == "Defender")
                {
                    pnlDefender.Children.Add(pl);
                }
                if (player.Position == "Midfield")
                {
                    pnlMid.Children.Add(pl);

                }
                if (player.Position == "Forward")
                {
                    pnlAttack.Children.Add(pl);


                }}
            
      //      FillPlayersInField();
            
        }
        private void FillOpponent()
        {
       lblOppTeam.Content = oppTeam;
                foreach (Player player in playersFromOpp)
                 {
                     UCPlayer pl = new UCPlayer(player)
                     {
                         Margin = new Thickness(0, 10, 0, 10)
                     };

                     if (player.Position == "Goalie")
                     {
                         pnlOppGoalie.Children.Add(pl);
                     }
                     if (player.Position == "Defender")
                     {
                         pnlOppDefender.Children.Add(pl);
                     }
                     if (player.Position == "Midfield")
                     {
                         pnlOppMid.Children.Add(pl);
                     }
                     if (player.Position == "Forward")
                     {
                         pnlOppAttack.Children.Add(pl);
                     }

                 }
    //        FillPlayersInField();
        }
    
        private async void findPlayers(string favTeam1, string teamOpp1)
        {
            try
            {
         //       IList<HomeTeamStatisticsClass> awayTeam = new List<AwayTeamStatisticsClass>();

                IList<TeamStatistics> matches = await RepositoryFactory<TeamStatistics>.GetRepository().GetAll(MATCHES_PATH);
                List<StartingEleven> startingElevensFromFav = new List<StartingEleven>();
                List<StartingEleven> startingElevensFromOpp = new List<StartingEleven>();
                List<TeamEvent> teOpp = new List<TeamEvent>();
                List<TeamEvent> teFav = new List<TeamEvent>();
                List<AwayTeamStatisticsClass> teamStatisticsFav = new List<AwayTeamStatisticsClass>();
                List<AwayTeamStatisticsClass> teamStatisticsOpp = new List<AwayTeamStatisticsClass>();
                foreach (var item in matches)
                {


                    if (item.HomeTeamCountry == favTeam1 && item.AwayTeamCountry == teamOpp1)
                    {
                        teamStatisticsFav.Add(item.HomeTeamStatistics);
                        teamStatisticsOpp.Add(item.AwayTeamStatistics);
                        teFav.AddRange(item.HomeTeamEvents);
                        teOpp.AddRange(item.AwayTeamEvents);
                        
                    }

                }
                foreach (var item in teamStatisticsFav)
                {
                    startingElevensFromFav.AddRange(item.StartingEleven);
                } foreach (var item in teamStatisticsOpp)
                {
                    startingElevensFromOpp.AddRange(item.StartingEleven);
                }
              
                int temp = 0;
                int temp1 = 0;

                foreach (var player1 in startingElevensFromFav)
                {
                    foreach (var tevent in teFav)
                    {
                        if (player1.Name == tevent.Player && tevent.TypeOfEvent == "yellow-card")
                        {
                            temp++;
                        }
                        if (player1.Name == tevent.Player && tevent.TypeOfEvent == "goal")
                        {
                            temp1++;
                        }

                    }
                    Player player = new Player(player1.Name, player1.Captain, (int)player1.ShirtNumber, player1.Position.ToString(), temp, temp1);
                    playersFromFav.Add(player);
                }  foreach (var player1 in startingElevensFromOpp)
                {
                    foreach (var tevent in teOpp)
                    {
                        if (player1.Name == tevent.Player && tevent.TypeOfEvent == "yellow-card")
                        {
                            temp++;
                        }
                        if (player1.Name == tevent.Player && tevent.TypeOfEvent == "goal")
                        {
                            temp1++;
                        }

                    }
                    Player player = new Player(player1.Name, player1.Captain, (int)player1.ShirtNumber, player1.Position.ToString(), temp, temp1);
                    playersFromOpp.Add(player);
                }
                Console.WriteLine(playersFromOpp.Count);
                Console.WriteLine(playersFromFav.Count);
                FillFavs();

                FillOpponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            PopUpClose pop = new PopUpClose();
            pop.Show();
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            string gen1 = $"{(rbFemale.IsChecked == true ? "F" : "M")}";
            string lang1 = $"{(rbEng.IsChecked == true ? "en" : "cro")}";
            string screen1;
            if (rbMed.IsChecked == true)
            {
                this.WindowState = WindowState.Normal;
                screen1 = "Normal";
            }
            else if (rbBig.IsChecked == true)
            {

                screen1 = "Big";
                Application.Current.MainWindow.Width = 1920;
                Application.Current.MainWindow.Height = 1200;
            }
            else
            {

                screen1 = "Small";
                Application.Current.MainWindow.Width = 800;
                Application.Current.MainWindow.Height = 640;

            }


            if (File.Exists(LANGUAGE_TEAM_SCREEN_PATH))
            {
                File.Delete(LANGUAGE_TEAM_SCREEN_PATH);
                using (StreamWriter sw = new StreamWriter(LANGUAGE_TEAM_SCREEN_PATH))
                {
                    sw.Write(screen1);
                    sw.Write(DELIMITER);
                    sw.Write(lang1);
                    sw.Write(DELIMITER);
                    sw.Write(gen1);
                }

            }
            PopUpSaved pop = new PopUpSaved();
            pop.Show();
        }

        private void btnCancelSettings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
    
}
