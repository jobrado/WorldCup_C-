
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string HR = "hr";
        private const string EN = "en";
        private string LANGUAGE;
        private const char DELIMITER = '|';
        private string TEAM;
        private const string MALE_TEAM = "M";
        private string TEAM_PATH;
        private const string LANGUAGE_PATH = "newlanguage.txt";
        private const string MALE_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WinFormsPart\\Paths\\men\\group_results.json";
        //  private const string MALE_PATH= "Paths\\men\\group_results.json";
        private const string FEMALE_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WinFormsPart\\Paths\\women\\group_results.json";
        private const string LANGUAGE_TXT_PATH = "C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WinFormsPart\\bin\\Debug\\language_team.txt";
        public MainWindow()
        {
            InitializeComponent();
            CheckLanguageAndTeam();
        }

        private void CheckLanguageAndTeam()
        {
            if (File.Exists(LANGUAGE_TXT_PATH))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(LANGUAGE_TXT_PATH))
                    {
                        string data = sr.ReadToEnd();
                        string[] d = data.Split(DELIMITER);
                        LANGUAGE = d[0];

                        TEAM = d[1];

                        if (LANGUAGE == HR)
                        {
                            rbCro.IsChecked = true;
                        }
                        else
                            rbEng.IsChecked = true;
                        if (TEAM == MALE_TEAM)
                        {
                            rbMale.IsChecked = true;
                        }
                        else
                            rbFemale.IsChecked = true;
                        
                    }

                 
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + " error can't load team - fav team 2");
                }
            }
            else if (File.Exists(LANGUAGE_PATH))
            {
                NationalTeam nt = new NationalTeam();
                nt.Show();
                this.Hide();
            }
           
        }
   /*     private void SetCulture(string lan)
        {
            CultureInfo culture = new CultureInfo(lan);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;


            InitializeComponent();
        }*/
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private string screen;
        private string gen;
        private string lang;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            gen = $"{(rbFemale.IsChecked == true ? "F" : "M")}";
            lang = $"{(rbEng.IsChecked == true ? "en" : "cro")}";
            NationalTeam nt = new NationalTeam();
            if (rbMed.IsChecked == true)
            {
                nt.WindowState = WindowState.Normal;
                screen = "Normal";
            }
            else if (rbBig.IsChecked == true)
            {
            
                screen = "Big";
             //   Application.Current.MainWindow.Width = 1920;
           //     Application.Current.MainWindow.Height = 1200;
            }
            else
            {
        
                screen = "Small";
            //    Application.Current.MainWindow.Width = 800;
           //     Application.Current.MainWindow.Height = 640;
       
            }
            if (File.Exists(LANGUAGE_TXT_PATH))
            {
                File.Delete(LANGUAGE_TXT_PATH);
            }
            using (StreamWriter sw = new StreamWriter(LANGUAGE_PATH))
            {
                sw.Write(screen);
                sw.Write(DELIMITER);
                sw.Write(lang);
                sw.Write(DELIMITER);
                sw.Write(gen);
            }
                nt.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            PopUpClose pop = new PopUpClose();
            pop.Show();
        }
    }
}

