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
        private IniData settings;
        private FileIniDataParser parser;
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确定
        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonApply_Click(sender, e);
            this.Close();

        }

        //应用
        private void buttonApply_Click(object sender, EventArgs e)
        {
            //启动时打开窗口
            settings["Startup"]["OpenWindowType"] = comboBoxStartup.SelectedIndex.ToString();

            //自动Commit
            settings["Function"]["AutoCommit"] = comboBoxAfterExecute.SelectedIndex.ToString();

            //关闭时提示修改是否保存
            settings["Other"]["AskOnClosing"] = comboBoxAskOnClosing.SelectedIndex.ToString();

            //默认最大化PL/SQL窗口
            settings["Startup"]["MaximizeWindow"] = checkBoxMaximizeWindow.Checked ? "1" : "0";

            //默认最大化PL/SQL窗口
            settings["Startup"]["MaximizeChildWindow"] = checkBoxMaximizeChildWindow.Checked ? "1" : "0";

            //启用自动替换
            settings["Startup"]["EnableAutoReplace"] = checkBoxEnableAutoReplace.Checked ? "1" : "0";

            //写入配置文件
            parser.WriteFile(pluginSettingFile, settings);
           
            plugin.RefreshSetting();
        }

        //加载事件
        private void SettingsUI_Load(object sender, EventArgs e)
        {
            parser = new FileIniDataParser();
            settings = parser.ReadFile(pluginSettingFile);

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

            //最大化PL/SQL窗口
            if (string.IsNullOrEmpty(settings["Startup"]["MaximizeWindow"]))
            {
                checkBoxMaximizeWindow.Checked = false;
            }
            else
            {
                checkBoxMaximizeWindow.Checked = (int.Parse(settings["Startup"]["MaximizeWindow"]) == 1) ? true : false;
            }

            //最大化子窗口
            if (string.IsNullOrEmpty(settings["Startup"]["MaximizeChildWindow"]))
            {
                checkBoxMaximizeChildWindow.Checked = false;
            }
            else
            {
                checkBoxMaximizeChildWindow.Checked = (int.Parse(settings["Startup"]["MaximizeChildWindow"]) == 1) ? true : false;
            }

            //启用自动替换
            if (string.IsNullOrEmpty(settings["Startup"]["EnableAutoReplace"]))
            {
                checkBoxEnableAutoReplace.Checked = false;
            }
            else
            {
                checkBoxEnableAutoReplace.Checked = (int.Parse(settings["Startup"]["EnableAutoReplace"]) == 1) ? true : false;
            }

            //自动替换界面初始化
            foreach (KeyData kv in settings["AutoReplace"])
            {
                listBoxAutoReplaceKey.Items.Add(kv.KeyName);
            }
            //如果有直接选中第一个
            if (listBoxAutoReplaceKey.Items.Count > 0)
            {
                listBoxAutoReplaceKey.SelectedIndex = 0;
            }
        }

        private void listBoxAutoReplaceKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAutoReplaceKey.SelectedItem != null)
            {
                textBoxAutoReplaceValue.Text = settings["AutoReplace"][listBoxAutoReplaceKey.SelectedItem.ToString()];
            }
        }

        private void textBoxAutoReplaceValue_TextChanged(object sender, EventArgs e)
        {
            if (listBoxAutoReplaceKey.SelectedItem != null)
            {
                settings["AutoReplace"][listBoxAutoReplaceKey.SelectedItem.ToString()] = textBoxAutoReplaceValue.Text;
            }
        }

        private void buttonAddKey_Click(object sender, EventArgs e)
        {
            if (textBoxToBeAdded.TextLength > 0)
            {
                listBoxAutoReplaceKey.Items.Add(textBoxToBeAdded.Text.Trim());
                settings["AutoReplace"][textBoxToBeAdded.Text.Trim()] = "";
                listBoxAutoReplaceKey.SelectedIndex = listBoxAutoReplaceKey.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Key不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxToBeAdded.Focus();
            }
        }

        private void buttonDelKey_Click(object sender, EventArgs e)
        {
            if (settings["AutoReplace"].ContainsKey(listBoxAutoReplaceKey.SelectedItem.ToString()))
            {
                settings["AutoReplace"].RemoveKey(listBoxAutoReplaceKey.SelectedItem.ToString());
            }
            if (listBoxAutoReplaceKey.SelectedItem != null && listBoxAutoReplaceKey.SelectedIndex > -1)
            {
                listBoxAutoReplaceKey.Items.Remove(listBoxAutoReplaceKey.SelectedItem);
            }
        
        }
    }
}
