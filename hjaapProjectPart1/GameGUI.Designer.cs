
namespace hjaapProjectPart2
{
    partial class GameGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameGUI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.enemyHPLbl3 = new System.Windows.Forms.Label();
            this.enemyHPLbl2 = new System.Windows.Forms.Label();
            this.enemyHPLbl1 = new System.Windows.Forms.Label();
            this.enemyPB1 = new System.Windows.Forms.PictureBox();
            this.enemyPB2 = new System.Windows.Forms.PictureBox();
            this.enemyPB3 = new System.Windows.Forms.PictureBox();
            this.heroPB2 = new System.Windows.Forms.PictureBox();
            this.heroPB3 = new System.Windows.Forms.PictureBox();
            this.heroPB1 = new System.Windows.Forms.PictureBox();
            this.actionsGB = new System.Windows.Forms.GroupBox();
            this.specialBtn = new System.Windows.Forms.Button();
            this.defendBtn = new System.Windows.Forms.Button();
            this.attackBtn = new System.Windows.Forms.Button();
            this.statsGB = new System.Windows.Forms.GroupBox();
            this.heroSP3 = new System.Windows.Forms.Label();
            this.heroSP2 = new System.Windows.Forms.Label();
            this.heroSP1 = new System.Windows.Forms.Label();
            this.heroHP3 = new System.Windows.Forms.Label();
            this.heroHP2 = new System.Windows.Forms.Label();
            this.heroHP1 = new System.Windows.Forms.Label();
            this.heroLbl3 = new System.Windows.Forms.Label();
            this.heroLbl2 = new System.Windows.Forms.Label();
            this.heroLbl1 = new System.Windows.Forms.Label();
            this.battleLogGB = new System.Windows.Forms.GroupBox();
            this.battleLogText = new System.Windows.Forms.TextBox();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB1)).BeginInit();
            this.actionsGB.SuspendLayout();
            this.statsGB.SuspendLayout();
            this.battleLogGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highScoresToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // highScoresToolStripMenuItem
            // 
            this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
            this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.highScoresToolStripMenuItem.Text = "High Scores";
            this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.instructionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel.BackgroundImage")));
            this.backgroundPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backgroundPanel.Controls.Add(this.enemyHPLbl3);
            this.backgroundPanel.Controls.Add(this.enemyHPLbl2);
            this.backgroundPanel.Controls.Add(this.enemyHPLbl1);
            this.backgroundPanel.Controls.Add(this.enemyPB1);
            this.backgroundPanel.Controls.Add(this.enemyPB2);
            this.backgroundPanel.Controls.Add(this.enemyPB3);
            this.backgroundPanel.Controls.Add(this.heroPB2);
            this.backgroundPanel.Controls.Add(this.heroPB3);
            this.backgroundPanel.Controls.Add(this.heroPB1);
            this.backgroundPanel.Location = new System.Drawing.Point(0, 27);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(800, 280);
            this.backgroundPanel.TabIndex = 1;
            // 
            // enemyHPLbl3
            // 
            this.enemyHPLbl3.AutoSize = true;
            this.enemyHPLbl3.ForeColor = System.Drawing.Color.White;
            this.enemyHPLbl3.Location = new System.Drawing.Point(704, 190);
            this.enemyHPLbl3.Name = "enemyHPLbl3";
            this.enemyHPLbl3.Size = new System.Drawing.Size(0, 15);
            this.enemyHPLbl3.TabIndex = 8;
            // 
            // enemyHPLbl2
            // 
            this.enemyHPLbl2.AutoSize = true;
            this.enemyHPLbl2.ForeColor = System.Drawing.Color.White;
            this.enemyHPLbl2.Location = new System.Drawing.Point(674, 23);
            this.enemyHPLbl2.Name = "enemyHPLbl2";
            this.enemyHPLbl2.Size = new System.Drawing.Size(0, 15);
            this.enemyHPLbl2.TabIndex = 7;
            // 
            // enemyHPLbl1
            // 
            this.enemyHPLbl1.AutoSize = true;
            this.enemyHPLbl1.ForeColor = System.Drawing.Color.White;
            this.enemyHPLbl1.Location = new System.Drawing.Point(564, 145);
            this.enemyHPLbl1.Name = "enemyHPLbl1";
            this.enemyHPLbl1.Size = new System.Drawing.Size(0, 15);
            this.enemyHPLbl1.TabIndex = 6;
            // 
            // enemyPB1
            // 
            this.enemyPB1.BackColor = System.Drawing.Color.Transparent;
            this.enemyPB1.Location = new System.Drawing.Point(552, 163);
            this.enemyPB1.Name = "enemyPB1";
            this.enemyPB1.Size = new System.Drawing.Size(64, 64);
            this.enemyPB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyPB1.TabIndex = 5;
            this.enemyPB1.TabStop = false;
            this.enemyPB1.Tag = "";
            this.enemyPB1.Click += new System.EventHandler(this.EnemyPB1_Click);
            // 
            // enemyPB2
            // 
            this.enemyPB2.BackColor = System.Drawing.Color.Transparent;
            this.enemyPB2.Location = new System.Drawing.Point(662, 41);
            this.enemyPB2.Name = "enemyPB2";
            this.enemyPB2.Size = new System.Drawing.Size(64, 64);
            this.enemyPB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyPB2.TabIndex = 4;
            this.enemyPB2.TabStop = false;
            this.enemyPB2.Tag = "";
            this.enemyPB2.Click += new System.EventHandler(this.EnemyPB2_Click);
            // 
            // enemyPB3
            // 
            this.enemyPB3.BackColor = System.Drawing.Color.Transparent;
            this.enemyPB3.Location = new System.Drawing.Point(694, 208);
            this.enemyPB3.Name = "enemyPB3";
            this.enemyPB3.Size = new System.Drawing.Size(64, 64);
            this.enemyPB3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyPB3.TabIndex = 3;
            this.enemyPB3.TabStop = false;
            this.enemyPB3.Tag = "";
            this.enemyPB3.Click += new System.EventHandler(this.EnemyPB3_Click);
            // 
            // heroPB2
            // 
            this.heroPB2.BackColor = System.Drawing.Color.Transparent;
            this.heroPB2.Location = new System.Drawing.Point(103, 153);
            this.heroPB2.Name = "heroPB2";
            this.heroPB2.Size = new System.Drawing.Size(64, 64);
            this.heroPB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.heroPB2.TabIndex = 2;
            this.heroPB2.TabStop = false;
            this.heroPB2.Click += new System.EventHandler(this.HeroPB2_Click);
            // 
            // heroPB3
            // 
            this.heroPB3.BackColor = System.Drawing.Color.Transparent;
            this.heroPB3.Location = new System.Drawing.Point(33, 208);
            this.heroPB3.Name = "heroPB3";
            this.heroPB3.Size = new System.Drawing.Size(64, 64);
            this.heroPB3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.heroPB3.TabIndex = 1;
            this.heroPB3.TabStop = false;
            this.heroPB3.Click += new System.EventHandler(this.HeroPB3_Click);
            // 
            // heroPB1
            // 
            this.heroPB1.BackColor = System.Drawing.Color.Transparent;
            this.heroPB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.heroPB1.Location = new System.Drawing.Point(174, 204);
            this.heroPB1.Name = "heroPB1";
            this.heroPB1.Size = new System.Drawing.Size(64, 64);
            this.heroPB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.heroPB1.TabIndex = 0;
            this.heroPB1.TabStop = false;
            this.heroPB1.Click += new System.EventHandler(this.HeroPB1_Click);
            // 
            // actionsGB
            // 
            this.actionsGB.Controls.Add(this.specialBtn);
            this.actionsGB.Controls.Add(this.defendBtn);
            this.actionsGB.Controls.Add(this.attackBtn);
            this.actionsGB.ForeColor = System.Drawing.Color.Gray;
            this.actionsGB.Location = new System.Drawing.Point(0, 305);
            this.actionsGB.Name = "actionsGB";
            this.actionsGB.Size = new System.Drawing.Size(97, 146);
            this.actionsGB.TabIndex = 2;
            this.actionsGB.TabStop = false;
            this.actionsGB.Text = "Actions";
            // 
            // specialBtn
            // 
            this.specialBtn.BackColor = System.Drawing.Color.LightGray;
            this.specialBtn.ForeColor = System.Drawing.Color.Black;
            this.specialBtn.Location = new System.Drawing.Point(7, 108);
            this.specialBtn.Name = "specialBtn";
            this.specialBtn.Size = new System.Drawing.Size(75, 23);
            this.specialBtn.TabIndex = 2;
            this.specialBtn.Text = "Special";
            this.specialBtn.UseVisualStyleBackColor = false;
            this.specialBtn.Click += new System.EventHandler(this.specialBtn_Click);
            // 
            // defendBtn
            // 
            this.defendBtn.BackColor = System.Drawing.Color.LightGray;
            this.defendBtn.ForeColor = System.Drawing.Color.Black;
            this.defendBtn.Location = new System.Drawing.Point(7, 65);
            this.defendBtn.Name = "defendBtn";
            this.defendBtn.Size = new System.Drawing.Size(75, 23);
            this.defendBtn.TabIndex = 1;
            this.defendBtn.Text = "Defend";
            this.defendBtn.UseVisualStyleBackColor = false;
            this.defendBtn.Click += new System.EventHandler(this.defendBtn_Click);
            // 
            // attackBtn
            // 
            this.attackBtn.BackColor = System.Drawing.Color.LightGray;
            this.attackBtn.ForeColor = System.Drawing.Color.Black;
            this.attackBtn.Location = new System.Drawing.Point(7, 23);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(75, 23);
            this.attackBtn.TabIndex = 0;
            this.attackBtn.Text = "Attack";
            this.attackBtn.UseVisualStyleBackColor = false;
            this.attackBtn.Click += new System.EventHandler(this.attackBtn_Click);
            // 
            // statsGB
            // 
            this.statsGB.Controls.Add(this.heroSP3);
            this.statsGB.Controls.Add(this.heroSP2);
            this.statsGB.Controls.Add(this.heroSP1);
            this.statsGB.Controls.Add(this.heroHP3);
            this.statsGB.Controls.Add(this.heroHP2);
            this.statsGB.Controls.Add(this.heroHP1);
            this.statsGB.Controls.Add(this.heroLbl3);
            this.statsGB.Controls.Add(this.heroLbl2);
            this.statsGB.Controls.Add(this.heroLbl1);
            this.statsGB.ForeColor = System.Drawing.Color.Gray;
            this.statsGB.Location = new System.Drawing.Point(103, 305);
            this.statsGB.Name = "statsGB";
            this.statsGB.Size = new System.Drawing.Size(283, 146);
            this.statsGB.TabIndex = 3;
            this.statsGB.TabStop = false;
            this.statsGB.Text = "Stats";
            // 
            // heroSP3
            // 
            this.heroSP3.AutoSize = true;
            this.heroSP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroSP3.ForeColor = System.Drawing.Color.LightGray;
            this.heroSP3.Location = new System.Drawing.Point(191, 116);
            this.heroSP3.Name = "heroSP3";
            this.heroSP3.Size = new System.Drawing.Size(67, 15);
            this.heroSP3.TabIndex = 8;
            this.heroSP3.Text = "SP: 100/100";
            // 
            // heroSP2
            // 
            this.heroSP2.AutoSize = true;
            this.heroSP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroSP2.ForeColor = System.Drawing.Color.LightGray;
            this.heroSP2.Location = new System.Drawing.Point(191, 69);
            this.heroSP2.Name = "heroSP2";
            this.heroSP2.Size = new System.Drawing.Size(67, 15);
            this.heroSP2.TabIndex = 7;
            this.heroSP2.Text = "SP: 100/100";
            // 
            // heroSP1
            // 
            this.heroSP1.AutoSize = true;
            this.heroSP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroSP1.ForeColor = System.Drawing.Color.LightGray;
            this.heroSP1.Location = new System.Drawing.Point(191, 22);
            this.heroSP1.Name = "heroSP1";
            this.heroSP1.Size = new System.Drawing.Size(67, 15);
            this.heroSP1.TabIndex = 6;
            this.heroSP1.Text = "SP: 100/100";
            // 
            // heroHP3
            // 
            this.heroHP3.AutoSize = true;
            this.heroHP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroHP3.ForeColor = System.Drawing.Color.LightGray;
            this.heroHP3.Location = new System.Drawing.Point(91, 116);
            this.heroHP3.Name = "heroHP3";
            this.heroHP3.Size = new System.Drawing.Size(70, 15);
            this.heroHP3.TabIndex = 5;
            this.heroHP3.Text = "HP: 100/100";
            // 
            // heroHP2
            // 
            this.heroHP2.AutoSize = true;
            this.heroHP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroHP2.ForeColor = System.Drawing.Color.LightGray;
            this.heroHP2.Location = new System.Drawing.Point(91, 69);
            this.heroHP2.Name = "heroHP2";
            this.heroHP2.Size = new System.Drawing.Size(70, 15);
            this.heroHP2.TabIndex = 4;
            this.heroHP2.Text = "HP: 100/100";
            // 
            // heroHP1
            // 
            this.heroHP1.AutoSize = true;
            this.heroHP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroHP1.ForeColor = System.Drawing.Color.LightGray;
            this.heroHP1.Location = new System.Drawing.Point(91, 22);
            this.heroHP1.Name = "heroHP1";
            this.heroHP1.Size = new System.Drawing.Size(70, 15);
            this.heroHP1.TabIndex = 3;
            this.heroHP1.Text = "HP: 100/100";
            // 
            // heroLbl3
            // 
            this.heroLbl3.AutoSize = true;
            this.heroLbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroLbl3.ForeColor = System.Drawing.Color.Silver;
            this.heroLbl3.Location = new System.Drawing.Point(7, 116);
            this.heroLbl3.Name = "heroLbl3";
            this.heroLbl3.Size = new System.Drawing.Size(37, 15);
            this.heroLbl3.TabIndex = 2;
            this.heroLbl3.Text = "Cleric";
            // 
            // heroLbl2
            // 
            this.heroLbl2.AutoSize = true;
            this.heroLbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroLbl2.ForeColor = System.Drawing.Color.LightGray;
            this.heroLbl2.Location = new System.Drawing.Point(7, 69);
            this.heroLbl2.Name = "heroLbl2";
            this.heroLbl2.Size = new System.Drawing.Size(37, 15);
            this.heroLbl2.TabIndex = 1;
            this.heroLbl2.Text = "Mage";
            // 
            // heroLbl1
            // 
            this.heroLbl1.AutoSize = true;
            this.heroLbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.heroLbl1.ForeColor = System.Drawing.Color.LightGray;
            this.heroLbl1.Location = new System.Drawing.Point(7, 22);
            this.heroLbl1.Name = "heroLbl1";
            this.heroLbl1.Size = new System.Drawing.Size(46, 15);
            this.heroLbl1.TabIndex = 0;
            this.heroLbl1.Text = "Warrior";
            // 
            // battleLogGB
            // 
            this.battleLogGB.Controls.Add(this.battleLogText);
            this.battleLogGB.ForeColor = System.Drawing.Color.Gray;
            this.battleLogGB.Location = new System.Drawing.Point(392, 305);
            this.battleLogGB.Name = "battleLogGB";
            this.battleLogGB.Size = new System.Drawing.Size(405, 146);
            this.battleLogGB.TabIndex = 4;
            this.battleLogGB.TabStop = false;
            this.battleLogGB.Text = "Battle Log";
            // 
            // battleLogText
            // 
            this.battleLogText.Location = new System.Drawing.Point(6, 22);
            this.battleLogText.Multiline = true;
            this.battleLogText.Name = "battleLogText";
            this.battleLogText.ReadOnly = true;
            this.battleLogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.battleLogText.Size = new System.Drawing.Size(393, 118);
            this.battleLogText.TabIndex = 0;
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // GameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.battleLogGB);
            this.Controls.Add(this.statsGB);
            this.Controls.Add(this.actionsGB);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameGUI";
            this.Text = "You know how Waffle House be";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroPB1)).EndInit();
            this.actionsGB.ResumeLayout(false);
            this.statsGB.ResumeLayout(false);
            this.statsGB.PerformLayout();
            this.battleLogGB.ResumeLayout(false);
            this.battleLogGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.GroupBox actionsGB;
        private System.Windows.Forms.GroupBox statsGB;
        private System.Windows.Forms.GroupBox battleLogGB;
        private System.Windows.Forms.Button specialBtn;
        private System.Windows.Forms.Button defendBtn;
        private System.Windows.Forms.Button attackBtn;
        private System.Windows.Forms.TextBox battleLogText;
        private System.Windows.Forms.Label heroLbl1;
        private System.Windows.Forms.Label heroHP1;
        private System.Windows.Forms.Label heroLbl3;
        private System.Windows.Forms.Label heroLbl2;
        private System.Windows.Forms.Label heroSP3;
        private System.Windows.Forms.Label heroSP2;
        private System.Windows.Forms.Label heroSP1;
        private System.Windows.Forms.Label heroHP3;
        private System.Windows.Forms.Label heroHP2;
        private System.Windows.Forms.PictureBox heroPB1;
        private System.Windows.Forms.PictureBox heroPB3;
        private System.Windows.Forms.PictureBox heroPB2;
        private System.Windows.Forms.PictureBox enemyPB3;
        private System.Windows.Forms.PictureBox enemyPB2;
        private System.Windows.Forms.PictureBox enemyPB1;
        private System.Windows.Forms.Label enemyHPLbl3;
        private System.Windows.Forms.Label enemyHPLbl2;
        private System.Windows.Forms.Label enemyHPLbl1;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
    }
}

