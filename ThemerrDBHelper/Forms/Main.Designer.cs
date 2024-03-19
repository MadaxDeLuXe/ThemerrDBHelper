namespace ThemerrDBHelper.Forms
{
    partial class Main
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
            activityBar = new CustomControls.CustomProgressBar();
            lblThemesMissing = new Label();
            dgvThemerrData = new DataGridView();
            oID = new DataGridViewTextBoxColumn();
            msTopMenu = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            beendenToolStripMenuItem = new ToolStripMenuItem();
            dgvVideos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvThemerrData).BeginInit();
            msTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).BeginInit();
            SuspendLayout();
            // 
            // activityBar
            // 
            activityBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            activityBar.BarText = " ";
            activityBar.DisplayStyle = CustomControls.CustomProgressBar.ProgressBarDisplayText.Percent;
            activityBar.Location = new Point(684, 587);
            activityBar.Margin = new Padding(0);
            activityBar.Name = "activityBar";
            activityBar.Size = new Size(400, 24);
            activityBar.TabIndex = 0;
            activityBar.TimerInterval = 100;
            // 
            // lblThemesMissing
            // 
            lblThemesMissing.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblThemesMissing.AutoSize = true;
            lblThemesMissing.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThemesMissing.Location = new Point(3, 591);
            lblThemesMissing.Name = "lblThemesMissing";
            lblThemesMissing.Size = new Size(120, 17);
            lblThemesMissing.TabIndex = 2;
            lblThemesMissing.Text = "lblThemesMissing";
            lblThemesMissing.Visible = false;
            // 
            // dgvThemerrData
            // 
            dgvThemerrData.AllowUserToAddRows = false;
            dgvThemerrData.AllowUserToDeleteRows = false;
            dgvThemerrData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvThemerrData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThemerrData.Columns.AddRange(new DataGridViewColumn[] { oID });
            dgvThemerrData.Location = new Point(11, 26);
            dgvThemerrData.Margin = new Padding(2);
            dgvThemerrData.MultiSelect = false;
            dgvThemerrData.Name = "dgvThemerrData";
            dgvThemerrData.ReadOnly = true;
            dgvThemerrData.RowHeadersVisible = false;
            dgvThemerrData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThemerrData.Size = new Size(253, 563);
            dgvThemerrData.TabIndex = 3;
            // 
            // oID
            // 
            oID.DataPropertyName = "Id";
            oID.HeaderText = "oID";
            oID.Name = "oID";
            oID.ReadOnly = true;
            oID.Visible = false;
            // 
            // msTopMenu
            // 
            msTopMenu.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem });
            msTopMenu.Location = new Point(0, 0);
            msTopMenu.Name = "msTopMenu";
            msTopMenu.Size = new Size(1084, 24);
            msTopMenu.TabIndex = 4;
            msTopMenu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { beendenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.Size = new Size(180, 22);
            beendenToolStripMenuItem.Text = "Beenden";
            beendenToolStripMenuItem.Click += BeendenToolStripMenuItem_Click;
            // 
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AllowUserToDeleteRows = false;
            dgvVideos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideos.Location = new Point(269, 27);
            dgvVideos.MultiSelect = false;
            dgvVideos.Name = "dgvVideos";
            dgvVideos.ReadOnly = true;
            dgvVideos.RowHeadersVisible = false;
            dgvVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVideos.Size = new Size(432, 277);
            dgvVideos.TabIndex = 9;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 611);
            Controls.Add(dgvVideos);
            Controls.Add(dgvThemerrData);
            Controls.Add(lblThemesMissing);
            Controls.Add(activityBar);
            Controls.Add(msTopMenu);
            MainMenuStrip = msTopMenu;
            MinimumSize = new Size(1100, 650);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)dgvThemerrData).EndInit();
            msTopMenu.ResumeLayout(false);
            msTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomProgressBar activityBar;
        private Label lblThemesMissing;
        private DataGridView dgvThemerrData;
        private DataGridViewTextBoxColumn oID;
        private MenuStrip msTopMenu;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem beendenToolStripMenuItem;
        private DataGridView dgvVideos;
    }
}
