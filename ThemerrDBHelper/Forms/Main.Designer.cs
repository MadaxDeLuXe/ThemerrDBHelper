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
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 611);
            Controls.Add(lblThemesMissing);
            Controls.Add(activityBar);
            MinimumSize = new Size(1100, 650);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomProgressBar activityBar;
        private Label lblThemesMissing;
    }
}
