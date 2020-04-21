using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wxcPLSQLPlugin
{
    public partial class AboutForm : Form
    {
        private wxcPLSQLPlugin plugin;
        public AboutForm()
        {
            InitializeComponent();
        }

        public void Show(wxcPLSQLPlugin plugin)
        {
            this.plugin = plugin;
            Text = plugin.Name;
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label2.Text += this.plugin.GetPluginVersion();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
