namespace WinFormsPart
{
    partial class InitialSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSettings));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.gb_choose_fav_team = new System.Windows.Forms.GroupBox();
            this.rb_Male = new System.Windows.Forms.RadioButton();
            this.rb_Female = new System.Windows.Forms.RadioButton();
            this.gb_choose_language = new System.Windows.Forms.GroupBox();
            this.rb_English = new System.Windows.Forms.RadioButton();
            this.rb_Croatian = new System.Windows.Forms.RadioButton();
            this.gb_choose_fav_team.SuspendLayout();
            this.gb_choose_language.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btn_Exit, "btn_Exit");
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click_1);
            // 
            // btn_Save
            // 
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click_1);
            // 
            // gb_choose_fav_team
            // 
            this.gb_choose_fav_team.BackgroundImage = global::WinFormsPart.Properties.Resources.background_image1;
            this.gb_choose_fav_team.Controls.Add(this.rb_Male);
            this.gb_choose_fav_team.Controls.Add(this.rb_Female);
            this.gb_choose_fav_team.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gb_choose_fav_team, "gb_choose_fav_team");
            this.gb_choose_fav_team.ForeColor = System.Drawing.Color.Firebrick;
            this.gb_choose_fav_team.Name = "gb_choose_fav_team";
            this.gb_choose_fav_team.TabStop = false;
            // 
            // rb_Male
            // 
            resources.ApplyResources(this.rb_Male, "rb_Male");
            this.rb_Male.Name = "rb_Male";
            this.rb_Male.UseVisualStyleBackColor = true;
            // 
            // rb_Female
            // 
            resources.ApplyResources(this.rb_Female, "rb_Female");
            this.rb_Female.Checked = true;
            this.rb_Female.Name = "rb_Female";
            this.rb_Female.TabStop = true;
            this.rb_Female.UseVisualStyleBackColor = true;
            // 
            // gb_choose_language
            // 
            this.gb_choose_language.BackgroundImage = global::WinFormsPart.Properties.Resources.background_image1;
            this.gb_choose_language.Controls.Add(this.rb_English);
            this.gb_choose_language.Controls.Add(this.rb_Croatian);
            this.gb_choose_language.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gb_choose_language, "gb_choose_language");
            this.gb_choose_language.ForeColor = System.Drawing.Color.Firebrick;
            this.gb_choose_language.Name = "gb_choose_language";
            this.gb_choose_language.TabStop = false;
            // 
            // rb_English
            // 
            resources.ApplyResources(this.rb_English, "rb_English");
            this.rb_English.Name = "rb_English";
            this.rb_English.UseVisualStyleBackColor = true;
            // 
            // rb_Croatian
            // 
            this.rb_Croatian.BackColor = System.Drawing.Color.LightGray;
            this.rb_Croatian.Checked = true;
            resources.ApplyResources(this.rb_Croatian, "rb_Croatian");
            this.rb_Croatian.Name = "rb_Croatian";
            this.rb_Croatian.TabStop = true;
            this.rb_Croatian.UseVisualStyleBackColor = false;
            // 
            // InitialSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.gb_choose_fav_team);
            this.Controls.Add(this.gb_choose_language);
            this.Name = "InitialSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitialSettings_FormClosing);
            this.Load += new System.EventHandler(this.InitialSettings_Load);
            this.gb_choose_fav_team.ResumeLayout(false);
            this.gb_choose_fav_team.PerformLayout();
            this.gb_choose_language.ResumeLayout(false);
            this.gb_choose_language.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox gb_choose_fav_team;
        private System.Windows.Forms.RadioButton rb_Male;
        private System.Windows.Forms.RadioButton rb_Female;
        private System.Windows.Forms.GroupBox gb_choose_language;
        private System.Windows.Forms.RadioButton rb_English;
        private System.Windows.Forms.RadioButton rb_Croatian;
    }
}

