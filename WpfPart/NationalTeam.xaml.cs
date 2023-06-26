using DAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.IO.Packaging;
using System.Linq.Expressions;

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for NationalTeam.xaml
    /// </summary>
    public partial class NationalTeam : Window
    {
        private const string HR = "hr";
        private const string EN = "en";
        private const char DELIMITER = '|';
        private const string MALE_TEAM = "M";
        private string TEAM_PATH;
        private const string LANGUAGE_PATH = "newlanguage.txt";
        private const string MALE_PATH = @"C:\\Users\\Jo\\Desktop\\JovanaObradovicWorldCup\Paths\\men\\group_results.json";
        //  private const string MALE_PATH= "Paths\\men\\group_results.json";
        private const string FEMALE_PATH = @"C:\\Users\\Jo\\Desktop\\JovanaObradovicWorldCup\\Paths\\women\\group_results.json";
        private const string FAVORITE_TEAM_TXT = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WindowsFormsPart\\bin\\Debug\\favorite_team1.txt";
        private const string MALE_PATH_MATCH = @"C:\\Users\\Jo\\Desktop\\JovanaObradovicWorldCup\\Paths\\men\\matches.json";
        private const string FEMALE_PATH_MATCH = @"C:\\Users\\Jo\\Desktop\\JovanaObradovicWorldCup\\Paths\\women\\matches.json";
        private string TEAM_PATH_MATCH;
        private Team favTeam;
        public static National_Team favNatTeam;
        private string screen;
        private string lang;
        private string LANGUAGE;
        private string gen;
      
        private string FAV_TEAM;
        private const string FAVORITE_TEAM_NEW_PATH = "favorite_team_new.txt";

        public NationalTeam()
        {
         
            
            InitializeComponent();
            Load();

            GetFavTeams();
            FillFavoriteTeam();
            GetOppontentTeams(FAV_TEAM);
        }

     

        private void FillFavoriteTeam()
        {
            if (File.Exists(FAVORITE_TEAM_TXT))
            {
                using (StreamReader sr = new StreamReader(FAVORITE_TEAM_TXT))
                {
                    FAV_TEAM = sr.ReadToEnd().Trim();
                    
                   
                }
            }
     

        }

        private void btnNatTeam_Click(object sender, RoutedEventArgs e)
        {
            string data = $"{favNatTeam.Country}|{favNatTeam.FifaCode}|{favNatTeam.GamesPlayed}|{favNatTeam.Wins}|{favNatTeam.Losses}|{favNatTeam.Draws}|{favNatTeam.GoalsFor}|{favNatTeam.GoalsAgainst}|{favNatTeam.GoalDifferential}";
            TeamWindow teamWindow = new TeamWindow(data);
            teamWindow.Show();
        }
       
        private void btnOppTeam_Click(object sender, RoutedEventArgs e)
        {
            getNationalOppTeam();
           
        }
       public static National_Team teamOpp = new National_Team();
        private async void getNationalOppTeam()
        {
            var teams = await RepositoryFactory<OrderedTeam>.GetRepository().GetAll(TEAM_PATH);
            List<National_Team>nt= new List<National_Team>();
            foreach (var item in teams)
            {
                List<National_Team> natteam = item.OrderedTeams;
                foreach (var team in natteam)
                {
                    if (team.Country == opp.Country )
                    {
                        teamOpp = team;
                       string  dataForOpp = $"{team.Country}|{team.FifaCode}|{team.GamesPlayed}|{team.Wins}|{team.Losses}|{team.Draws}|{team.GoalsFor}|{team.GoalsAgainst}|{team.GoalDifferential}";
                        TeamWindow teamWindow = new TeamWindow(dataForOpp);
                        
                        teamWindow.Show();

                    }

                }
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FAVORITE_TEAM_NEW_PATH))
            {
                using (StreamWriter sw = new StreamWriter(FAVORITE_TEAM_NEW_PATH))
                {
                    string det = favNatTeam.Country + DELIMITER + teamOpp1;
                    sw.WriteLine(det);
                }
            }
            else if (File.Exists(FAVORITE_TEAM_NEW_PATH))
            {
                File.Delete(FAVORITE_TEAM_NEW_PATH);
                using (StreamWriter sw = new StreamWriter(FAVORITE_TEAM_NEW_PATH))
                {
                    string det = favNatTeam.Country + DELIMITER + teamOpp1;
                    sw.WriteLine(det);
                }
            }
            TeamShowField teamShowField = new TeamShowField();
            teamShowField.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private async void GetOppontentTeams(string fav)
        {
            
            var matches = await RepositoryFactory<Match>.GetRepository().GetAll(TEAM_PATH_MATCH);
            
            foreach (var item in matches)
            {
                if (item.HomeTeam.Country == fav && !cbOppTeam.Items.Contains(item.AwayTeam))
                {
                    favTeam = item.HomeTeam;
                   
                    cbOppTeam.Items.Add(item.AwayTeam);
      
                }
                if (item.AwayTeam.Country == fav && !cbOppTeam.Items.Contains(item.HomeTeam))
                {
                    favTeam = item.AwayTeam;

                    cbOppTeam.Items.Add(item.HomeTeam);
                }
            }
        }
       
        private async void GetFavTeams()
        {
            try
            {
                var teams = await RepositoryFactory<OrderedTeam>.GetRepository().GetAll(TEAM_PATH);

                List<National_Team> nt = new List<National_Team>();
                foreach (var item in teams)
                {
                    List<National_Team> natteam = item.OrderedTeams;
                    foreach (var team in natteam)
                    {
                        nt.Add(team);
                        cbNatTeam.Items.Add(team);

                    }
                  
                }
                foreach (var item1 in cbNatTeam.Items)
                {
                    Console.WriteLine(item1);
                    int i = item1.ToString().Length;
                    string it = item1.ToString().Split('|').Last();
                    if (it.Trim().Equals(FAV_TEAM))
                    {
                        cbNatTeam.SelectedItem = item1;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error fav team 1"); }
        }

        private void Load()
        {
            {
                if (File.Exists(LANGUAGE_PATH))
                {
                    using (StreamReader sr = new StreamReader(LANGUAGE_PATH))
                    {
                        string data = sr.ReadToEnd();
                        string[] d = data.Split(DELIMITER);
                        screen = d[0];
                        lang = d[1];
                        gen = d[2];
                    }

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
                    TEAM_PATH = MALE_PATH;
                    TEAM_PATH_MATCH = MALE_PATH_MATCH;
                }
                else
                {
                    TEAM_PATH = FEMALE_PATH;
                    TEAM_PATH_MATCH = FEMALE_PATH_MATCH;
                }
                if (screen == "Small")
                {
                    Application.Current.MainWindow.Width = 800;
                    Application.Current.MainWindow.Height = 640;
                }
                else if(screen == "Big"){
                    Application.Current.MainWindow.Width = 1920;
                    Application.Current.MainWindow.Height = 1200;
                }
                if (gen == "M")
                {
                    TEAM_PATH = MALE_PATH;
                }
                else
                {
                    TEAM_PATH = FEMALE_PATH;
                }


                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LANGUAGE);
                       Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(LANGUAGE);
            }
        }

        private void cbNatTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbOppTeam.SelectedIndex = -1;
                cbOppTeam.Items.Clear();
            btnOppTeam.Content = "";
            btnNatTeam.Content = "";
            lblNatTeamScore_Copy.Content = "";
            lblOppTeamScore.Content = "";
            //   cbOppTeam.SelectedItem = null;
            btnNatTeam.Content = cbNatTeam.SelectedItem.ToString();
            FAV_TEAM = cbNatTeam.SelectedItem.ToString().Substring(5).Trim();
            favNatTeam = (National_Team)cbNatTeam.SelectedItem;
            Console.Write(FAV_TEAM);
            cbOppTeam.Items.Clear();
            GetOppontentTeams(FAV_TEAM);
        }
        Team opp = new Team();
        string teamOpp1;
        private void cbOppTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOppTeam.SelectedIndex >= 0 )
            {
                lblNatTeamScore_Copy.Content = "";
                lblOppTeamScore.Content = "";
                teamOpp1 = cbOppTeam.SelectedItem.ToString();
                btnOppTeam.Content = cbOppTeam.SelectedItem.ToString().Substring(0, 3).ToUpper() + " " + DELIMITER + " " + cbOppTeam.SelectedItem.ToString();

                opp = (Team)cbOppTeam.SelectedItem;
                lblOppTeamScore.Content = opp.Goals;
                lblNatTeamScore_Copy.Content = favTeam.Goals;
            }
           
    
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


            if (File.Exists(LANGUAGE_PATH))
            {
                File.Delete(LANGUAGE_PATH);
                using (StreamWriter sw = new StreamWriter(LANGUAGE_PATH))
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            PopUpClose pop = new PopUpClose();
            pop.Show();
        }
    } }

