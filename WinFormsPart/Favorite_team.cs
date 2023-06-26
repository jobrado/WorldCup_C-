using DAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPart
{

    private string LANGUAGE;

    private const string LANGUAGE_TXT = "language_team.txt";

    private const char DELIMITER = '|';

    private const string MALE_TEAM = "M";
    private const string FEMALE_TEAM = "F";
    private string TEAM;
    private string TEAM_PATH;
    private const string MALE_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WindowsFormsPart\\Paths\\men\\group_results.json";
    //  private const string MALE_PATH= "Paths\\men\\group_results.json";
    private const string FEMALE_PATH = @"C:\\Users\\Jo\\Desktop\\WorldCupInformation\\WindowsFormsPart\\Paths\\women\\group_results.json";
    private const string FAVORITE_TEAM_TXT = "favorite_team.txt";

    public Favorite_team()
    {
        if (!File.Exists(LANGUAGE_TXT))
        {
            MessageBox.Show("error, can't load fav team or language");
            Application.Exit();

        }
        if (!File.Exists(FAVORITE_TEAM_TXT))
        {


            this.BackgroundImage = Properties.Resources.background_image;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponent();

        }
        else
        {
            OmiljeniIgraci favoritePlayers = new OmiljeniIgraci();
            favoritePlayers.Show();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

    }
    private void SetCulture(string lan)
    {
        CultureInfo culture = new CultureInfo(lan);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        this.Controls.Clear();
        InitializeComponent();
    }
    private async void LoadTeams()
    {
        this.Visible = false;
        LoadForm Load = new LoadForm();
        Load.Show();

        try
        {
            var teams = await RepositoryFactory<OrderedTeam>.GetRepository().GetAll(TEAM_PATH);
            IList<National_Team> nt = new List<National_Team>();

            foreach (var item in teams)
            {
                List<National_Team> natteam = item.OrderedTeams;
                foreach (var team in natteam)
                {
                    nt.Add(team);

                }

            }
            Dictionary<string, string> dictionary = nt.ToDictionary(keySelector: m => m.FifaCode, elementSelector: m => m.Country);
            foreach (var item in dictionary)
            {
                cb_National_Team.Items.Add(item.Key + " " + DELIMITER + " " + item.Value);
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "error fav team 1"); }
        Load.Visible = false;
        this.Visible = true;

    }



    private void Favorite_team_Load(object sender, EventArgs e)
    {
        GetInfo();
        /*   if (File.Exists(FAVORITE_TEAM_TXT))
           {
               GetInfo();
               this.Hide();
                       FavoritePlayers fp = new FavoritePlayers();
                       fp.Show();
           }
    */

    }

    private void GetInfo()
    {
        try
        {
            using (StreamReader sr = new StreamReader(LANGUAGE_TXT))
            {
                string data = sr.ReadToEnd();
                string[] d = data.Split(DELIMITER);
                LANGUAGE = d[0];

                TEAM = d[1];
                SetCulture(LANGUAGE);

            }


            if (TEAM.Trim() == MALE_TEAM)
            {
                TEAM_PATH = MALE_PATH;
            }
            else
            {
                TEAM_PATH = FEMALE_PATH;
            }
            LoadTeams();
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message + " error can't load team - fav team 2");
        }
    }

    private void btn_Save_Click(object sender, EventArgs e)
    {
        if (cb_National_Team.SelectedItem != null)
        {
            string data = cb_National_Team.SelectedItem.ToString();
            string[] d = data.Split(DELIMITER);
            SavedData.Preferred_National_Team = d[0];
            YesNoForm yesNoForm = new YesNoForm();
            if (yesNoForm.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(FAVORITE_TEAM_TXT))
                {
                    sw.WriteLine(d[1]);

                }
                OmiljeniIgraci fp = new OmiljeniIgraci();

                fp.Show();
                this.Visible = false;
            }
        }
    }

    private void btn_Cancel_Click(object sender, EventArgs e)
    {
        YesNoForm yesNoForm = new YesNoForm();
        if (yesNoForm.ShowDialog() == DialogResult.OK)
        {
            if (File.Exists(FAVORITE_TEAM_TXT))
            {
                File.Delete(FAVORITE_TEAM_TXT);
            }
            else
            {
                MessageBox.Show("No favorite team yet!");
            }
        }
    }

    private void Favorite_team_FormClosing(object sender, FormClosingEventArgs e)
    {
        YesNoForm yesNoForm = new YesNoForm();
        if (yesNoForm.ShowDialog() == DialogResult.OK)
        {
            Environment.Exit(0);
        }
        else
            e.Cancel = true;
    }
}
}

}
