namespace ThemerrDBHelper.CustomControls
{
    public class CustomProgressBar : ProgressBar
    {
        public enum Act
        {
            Start = 0,
            Stop = 1,
            Continue = 2,
            Reset = 3,
        }

        public enum ProgressBarDisplayText
        {
            Percent = 0,
            CustomText = 1,
            Both = 2
        }

        private System.Windows.Forms.Timer t = new();

        public int TimerInterval
        { get { return t.Interval; } set { t.Interval = value; } }

        public ProgressBarDisplayText DisplayStyle { get; set; }
        public Font TextFont = new Font(FontFamily.GenericSerif, 10);
        public Brush TextBrush = Brushes.Black;
        public string BarText { get; set; } = " ";

        public CustomProgressBar()
        {
            // Modify the ControlStyles flags
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            t.Tick += new EventHandler(t_Tick);
            t.Interval = 100;
        }

        private void t_Tick(object? sender, EventArgs e)
        {
            Invalidate();
            Application.DoEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string toDraw = " ";
            int percent = (int)(((double)this.Value / (double)this.Maximum) * 100);

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { OnPaint(e); });
                return;
            }

            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);

            if (Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }

            if (percent <= 0) { percent = 0; }
            else if (percent >= 100) { percent = 100; }

            switch (DisplayStyle)
            {
                case ProgressBarDisplayText.Percent:
                    toDraw = percent.ToString() + '%';
                    break;

                case ProgressBarDisplayText.CustomText:
                    toDraw = BarText;
                    break;

                case ProgressBarDisplayText.Both:
                    toDraw = $"{BarText} {percent} %";
                    break;
            }

            SizeF len = g.MeasureString(toDraw, TextFont);
            Point location = new Point(ThemerrDBHelper.Helpers.Forms.CenterControlX(Width, (int)len.Width), ThemerrDBHelper.Helpers.Forms.CenterControlY(Height, (int)len.Height));

            g.DrawString(toDraw, TextFont, TextBrush, location);
        }

        internal void Init(ProgressBarDisplayText Type, int maxValue, string Text = " ", Font? TextFont = null, Brush? TextBrush = null)
        {
            if (InvokeRequired)
            {
                Invoke(() => new object[] { Type, maxValue, Text, TextFont, TextBrush });
                return;
            }

            DisplayStyle = Type;
            Maximum = maxValue;
            BarText = Text;
            this.TextFont = TextFont ?? new Font(FontFamily.GenericSerif, 10);
            this.TextBrush = TextBrush ?? Brushes.Black;
        }

        internal void SetMax(int maxValue)
        {
            if (InvokeRequired)
            {
                Invoke(() => new object[] { maxValue });
                return;
            }
            Maximum = maxValue;
        }

        internal void SetValue(int Value)
        {
            if (InvokeRequired)
            {
                Invoke(() => new object[] { Value });
                return;
            }
            this.Value = Value;
        }

        internal void CountUp()
        {
            if (InvokeRequired)
            {
                Invoke(CountUp);
                return;
            }
            Value++;
        }

        internal void Action(Act Action, int maxValue = 1000, string Text = " ")
        {
            if (InvokeRequired)
            {
                Invoke(() => new object[] { Action, maxValue, Text });
                return;
            }

            Maximum = maxValue;
            BarText = Text;

            if (Action == Act.Start)
            {
                Visible = true;
                Value = 0;
                t.Start();
            }
            else if (Action == Act.Stop)
            {
                t.Stop();
            }
            else if (Action == Act.Continue)
            {
                t.Start();
            }
            else if (Action == Act.Reset)
            {
                t.Stop();
                Value = 0;
                BarText = " ";
                Invalidate();
            }
        }
    }
}