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

            //启动时打开窗口
            settingsToBeSaved["Startup"]["OpenWindowType"] = comboBoxStartup.SelectedIndex.ToString();

            //自动Commit
            settingsToBeSaved["Function"]["AutoCommit"] = comboBoxAfterExecute.SelectedIndex.ToString();

            //关闭时提示修改是否保存
            settingsToBeSaved["Other"]["AskOnClosing"] = comboBoxAskOnClosing.SelectedIndex.ToString();

            //关闭时提示修改是否保存
            settingsToBeSaved["Startup"]["MaximizeWindow"] = checkBoxMaximizeWindow.Checked ? "1" : "0";

            //写入配置文件
            parser.WriteFile(pluginSettingFile, settingsToBeSaved);

            plugin.RefreshSetting();
        }

        //加载事件
        private void SettingsUI_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData settings = parser.ReadFile(pluginSettingFile);

            //启动时打开窗口
            if (string.IsNullOrEmpty(settings["Startup"]["OpenWindowType"]))
            {
                comboBoxStartup.SelectedIndex = 0;
            }
            else
            {
                comboBoxStartup.SelectedIndex = int.Parse(settings["Startup"]["OpenWindowType"]);
            }

            //自动Commit
            if (string.IsNullOrEmpty(settings["Function"]["AutoCommit"]))
            {
                comboBoxAfterExecute.SelectedIndex = 0;
            }
            else
            {
                comboBoxAfterExecute.SelectedIndex = int.Parse(settings["Function"]["AutoCommit"]);
            }

            //关闭时提示修改是否保存
            if (string.IsNullOrEmpty(settings["Other"]["AskOnClosing"]))
            {
                comboBoxAskOnClosing.SelectedIndex = 0;
            }
            else
            {
                comboBoxAskOnClosing.SelectedIndex = int.Parse(settings["Other"]["AskOnClosing"]);
            }

            //最大化子窗口
            if (string.IsNullOrEmpty(settings["Startup"]["MaximizeWindow"]))
            {
                checkBoxMaximizeWindow.Checked = false;
            }
            else
            {
                checkBoxMaximizeWindow.Checked = (int.Parse(settings["Startup"]["MaximizeWindow"]) == 1) ? true : false;
            }


        }
    }
}
