using System.Diagnostics;

namespace ThemerrDBHelper.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kill();
        }

        private static void Kill()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }
    }
}