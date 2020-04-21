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
    public partial class SettingsUI : Form
    {
        private wxcPLSQLPlugin plugin;
        public SettingsUI()
        {
            InitializeComponent();
        }
        public void Show(wxcPLSQLPlugin plugin)
        {
            this.plugin = plugin;
            Text = plugin.Name;
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
