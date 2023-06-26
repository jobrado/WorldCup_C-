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
using WinFormsPart.Properties;

namespace WinFormsPart
{
    public partial class InitialSettings : Form
    {

        private const string HR = "hr";
        private const string EN = "en";
        private string LANGUAGE;

        private const string LANGUAGE_TXT = "language_team.txt";

        private const char DELIMITER = '|';

        private const string MALE_TEAM = "M";
        private const string FEMALE_TEAM = "F";
        private string TEAM;



        public InitialSettings()
        {
            if (!File.Exists(LANGUAGE_TXT))
            {
                this.BackgroundImage = Resources.background_image;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                InitializeComponent();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                Favorite_team ft = new Favorite_team();
                // ft.Show();


                ft.Show();


            }

        }

        private void InitialSettings_Load(object sender, EventArgs e)
        {
            SetCulture(EN);
        }

        private void SetCulture(string lan)
        {
            CultureInfo culture = new CultureInfo(lan);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            this.Controls.Clear();
            InitializeComponent();
        }


    

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            if (rb_Croatian.Checked)
            {
                LANGUAGE = HR;
            }
            else if (rb_English.Checked)
            {
                LANGUAGE = EN;
            }
            if (rb_Male.Checked)
            {
                TEAM = MALE_TEAM;
            }
            else if (rb_Female.Checked)
            {
                TEAM = FEMALE_TEAM;
            }


            YesNoForm yesNoForm = new YesNoForm();
            if (yesNoForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(LANGUAGE_TXT))
                    {
                        string data = LANGUAGE + DELIMITER + TEAM;
                        sw.WriteLine(data);

                    }
                    Favorite_team ft = new Favorite_team();
                    ft.Show();
                    this.WindowState = FormWindowState.Minimized;
                    this.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error, can't save file");
                }

            }
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            YesNoForm yesNoForm = new YesNoForm();
            if (yesNoForm.ShowDialog() == DialogResult.OK)
            {

                Environment.Exit(0);

            }
            else
                yesNoForm.Hide();
        }

        private void InitialSettings_FormClosing(object sender, FormClosingEventArgs e)
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
