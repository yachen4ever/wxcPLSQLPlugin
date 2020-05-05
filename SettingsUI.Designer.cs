namespace wxcPLSQLPlugin
{
    partial class SettingsUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.checkBoxMaximizeChildWindow = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableAutoReplace = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximizeWindow = new System.Windows.Forms.CheckBox();
            this.comboBoxAskOnClosing = new System.Windows.Forms.ComboBox();
            this.comboBoxAfterExecute = new System.Windows.Forms.ComboBox();
            this.comboBoxStartup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAutoReplace = new System.Windows.Forms.TabPage();
            this.buttonDelKey = new System.Windows.Forms.Button();
            this.buttonAddKey = new System.Windows.Forms.Button();
            this.textBoxAutoReplaceValue = new System.Windows.Forms.TextBox();
            this.listBoxAutoReplaceKey = new System.Windows.Forms.ListBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageAutoReplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageCommon);
            this.tabControl1.Controls.Add(this.tabPageAutoReplace);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(24, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 229);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.checkBoxMaximizeChildWindow);
            this.tabPageCommon.Controls.Add(this.checkBoxEnableAutoReplace);
            this.tabPageCommon.Controls.Add(this.checkBoxMaximizeWindow);
            this.tabPageCommon.Controls.Add(this.comboBoxAskOnClosing);
            this.tabPageCommon.Controls.Add(this.comboBoxAfterExecute);
            this.tabPageCommon.Controls.Add(this.comboBoxStartup);
            this.tabPageCommon.Controls.Add(this.label2);
            this.tabPageCommon.Controls.Add(this.label3);
            this.tabPageCommon.Controls.Add(this.label1);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 29);
            this.tabPageCommon.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageCommon.Size = new System.Drawing.Size(392, 196);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = " 常规设置 ";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximizeChildWindow
            // 
            this.checkBoxMaximizeChildWindow.AutoSize = true;
            this.checkBoxMaximizeChildWindow.Location = new System.Drawing.Point(235, 119);
            this.checkBoxMaximizeChildWindow.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMaximizeChildWindow.Name = "checkBoxMaximizeChildWindow";
            this.checkBoxMaximizeChildWindow.Size = new System.Drawing.Size(147, 21);
            this.checkBoxMaximizeChildWindow.TabIndex = 2;
            this.checkBoxMaximizeChildWindow.Text = "默认最大化子查询窗口";
            this.checkBoxMaximizeChildWindow.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableAutoReplace
            // 
            this.checkBoxEnableAutoReplace.AutoSize = true;
            this.checkBoxEnableAutoReplace.Location = new System.Drawing.Point(17, 146);
            this.checkBoxEnableAutoReplace.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxEnableAutoReplace.Name = "checkBoxEnableAutoReplace";
            this.checkBoxEnableAutoReplace.Size = new System.Drawing.Size(99, 21);
            this.checkBoxEnableAutoReplace.TabIndex = 2;
            this.checkBoxEnableAutoReplace.Text = "启用自动替换";
            this.checkBoxEnableAutoReplace.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximizeWindow
            // 
            this.checkBoxMaximizeWindow.AutoSize = true;
            this.checkBoxMaximizeWindow.Location = new System.Drawing.Point(17, 119);
            this.checkBoxMaximizeWindow.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMaximizeWindow.Name = "checkBoxMaximizeWindow";
            this.checkBoxMaximizeWindow.Size = new System.Drawing.Size(152, 21);
            this.checkBoxMaximizeWindow.TabIndex = 2;
            this.checkBoxMaximizeWindow.Text = "默认最大化PL/SQL窗口";
            this.checkBoxMaximizeWindow.UseVisualStyleBackColor = true;
            // 
            // comboBoxAskOnClosing
            // 
            this.comboBoxAskOnClosing.FormattingEnabled = true;
            this.comboBoxAskOnClosing.Items.AddRange(new object[] {
            "默认（发生变动则提示）",
            "永远提示",
            "永远不提示"});
            this.comboBoxAskOnClosing.Location = new System.Drawing.Point(168, 81);
            this.comboBoxAskOnClosing.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAskOnClosing.Name = "comboBoxAskOnClosing";
            this.comboBoxAskOnClosing.Size = new System.Drawing.Size(204, 25);
            this.comboBoxAskOnClosing.TabIndex = 1;
            // 
            // comboBoxAfterExecute
            // 
            this.comboBoxAfterExecute.FormattingEnabled = true;
            this.comboBoxAfterExecute.Items.AddRange(new object[] {
            "不自动Commit",
            "提示是否需要Commit",
            "自动Commit（在PLSQL14还会提示）"});
            this.comboBoxAfterExecute.Location = new System.Drawing.Point(168, 53);
            this.comboBoxAfterExecute.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAfterExecute.Name = "comboBoxAfterExecute";
            this.comboBoxAfterExecute.Size = new System.Drawing.Size(204, 25);
            this.comboBoxAfterExecute.TabIndex = 1;
            // 
            // comboBoxStartup
            // 
            this.comboBoxStartup.FormattingEnabled = true;
            this.comboBoxStartup.Items.AddRange(new object[] {
            "不打开窗口",
            "SQL Window",
            "Test Window",
            "Procedure Window",
            "Command Window",
            "Plan Window",
            "Report Window",
            "HTML Window"});
            this.comboBoxStartup.Location = new System.Drawing.Point(168, 24);
            this.comboBoxStartup.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStartup.Name = "comboBoxStartup";
            this.comboBoxStartup.Size = new System.Drawing.Size(204, 25);
            this.comboBoxStartup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "执行SQL语句后：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "关闭程序时是否提示保存：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "启动时打开：";
            // 
            // tabPageAutoReplace
            // 
            this.tabPageAutoReplace.Controls.Add(this.buttonDelKey);
            this.tabPageAutoReplace.Controls.Add(this.buttonAddKey);
            this.tabPageAutoReplace.Controls.Add(this.textBoxAutoReplaceValue);
            this.tabPageAutoReplace.Controls.Add(this.listBoxAutoReplaceKey);
            this.tabPageAutoReplace.Location = new System.Drawing.Point(4, 29);
            this.tabPageAutoReplace.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAutoReplace.Name = "tabPageAutoReplace";
            this.tabPageAutoReplace.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAutoReplace.Size = new System.Drawing.Size(392, 196);
            this.tabPageAutoReplace.TabIndex = 1;
            this.tabPageAutoReplace.Text = "自动替换设置";
            this.tabPageAutoReplace.UseVisualStyleBackColor = true;
            // 
            // buttonDelKey
            // 
            this.buttonDelKey.Location = new System.Drawing.Point(85, 164);
            this.buttonDelKey.Name = "buttonDelKey";
            this.buttonDelKey.Size = new System.Drawing.Size(51, 23);
            this.buttonDelKey.TabIndex = 2;
            this.buttonDelKey.Text = "删除";
            this.buttonDelKey.UseVisualStyleBackColor = true;
            // 
            // buttonAddKey
            // 
            this.buttonAddKey.Location = new System.Drawing.Point(18, 164);
            this.buttonAddKey.Name = "buttonAddKey";
            this.buttonAddKey.Size = new System.Drawing.Size(51, 23);
            this.buttonAddKey.TabIndex = 2;
            this.buttonAddKey.Text = "新增";
            this.buttonAddKey.UseVisualStyleBackColor = true;
            // 
            // textBoxAutoReplaceValue
            // 
            this.textBoxAutoReplaceValue.Location = new System.Drawing.Point(167, 17);
            this.textBoxAutoReplaceValue.Multiline = true;
            this.textBoxAutoReplaceValue.Name = "textBoxAutoReplaceValue";
            this.textBoxAutoReplaceValue.Size = new System.Drawing.Size(204, 140);
            this.textBoxAutoReplaceValue.TabIndex = 1;
            this.textBoxAutoReplaceValue.TextChanged += new System.EventHandler(this.textBoxAutoReplaceValue_TextChanged);
            // 
            // listBoxAutoReplaceKey
            // 
            this.listBoxAutoReplaceKey.FormattingEnabled = true;
            this.listBoxAutoReplaceKey.ItemHeight = 17;
            this.listBoxAutoReplaceKey.Location = new System.Drawing.Point(18, 17);
            this.listBoxAutoReplaceKey.Name = "listBoxAutoReplaceKey";
            this.listBoxAutoReplaceKey.Size = new System.Drawing.Size(118, 140);
            this.listBoxAutoReplaceKey.TabIndex = 0;
            this.listBoxAutoReplaceKey.SelectedIndexChanged += new System.EventHandler(this.listBoxAutoReplaceKey_SelectedIndexChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOK.Location = new System.Drawing.Point(66, 265);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 25);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(175, 265);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonApply.Location = new System.Drawing.Point(284, 265);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(2);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 25);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(447, 318);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsUI";
            this.Text = "wxcPLSQLPlugin设置界面";
            this.Load += new System.EventHandler(this.SettingsUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.tabPageAutoReplace.ResumeLayout(false);
            this.tabPageAutoReplace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageAutoReplace;
        private System.Windows.Forms.ComboBox comboBoxStartup;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboBoxAfterExecute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAskOnClosing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMaximizeWindow;
        private System.Windows.Forms.CheckBox checkBoxMaximizeChildWindow;
        private System.Windows.Forms.TextBox textBoxAutoReplaceValue;
        private System.Windows.Forms.ListBox listBoxAutoReplaceKey;
        private System.Windows.Forms.Button buttonDelKey;
        private System.Windows.Forms.Button buttonAddKey;
        private System.Windows.Forms.CheckBox checkBoxEnableAutoReplace;
    }
}