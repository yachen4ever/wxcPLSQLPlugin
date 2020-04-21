using IniParser;
using IniParser.Model;
using System;
using System.Windows.Forms;

namespace wxcPLSQLPlugin
{
    public partial class SettingsUI : Form
    {
        private wxcPLSQLPlugin plugin;
        private string pluginSettingFile;
        public SettingsUI()
        {
            InitializeComponent();
        }

        public void Show(wxcPLSQLPlugin plugin)
        {
            this.plugin = plugin;
            this.pluginSettingFile = plugin.GetPluginSettingFile();
            Show();
        }

        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            this.Close();
        }

        //应用
        private void button3_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData settingsToBeSaved = new IniData();
            settingsToBeSaved["Startup"]["OpenWindowType"] = comboBoxStartup.SelectedIndex.ToString();

            parser.WriteFile(pluginSettingFile, settingsToBeSaved);
        }

        //加载事件
        private void SettingsUI_Load(object sender, EventArgs e)
        {
            Text = plugin.Name;
            var parser = new FileIniDataParser();
            IniData settings = parser.ReadFile(pluginSettingFile);
            comboBoxStartup.SelectedIndex = int.Parse(settings["Startup"]["OpenWindowType"]);
        }
    }
}
