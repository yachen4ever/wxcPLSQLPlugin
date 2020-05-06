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
            this.textBoxToBeAdded = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.tabControl1.Location = new System.Drawing.Point(48, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 494);
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
            this.tabPageCommon.Location = new System.Drawing.Point(4, 43);
            this.tabPageCommon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageCommon.Size = new System.Drawing.Size(792, 447);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = " 常规设置 ";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximizeChildWindow
            // 
            this.checkBoxMaximizeChildWindow.AutoSize = true;
            this.checkBoxMaximizeChildWindow.Location = new System.Drawing.Point(470, 238);
            this.checkBoxMaximizeChildWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMaximizeChildWindow.Name = "checkBoxMaximizeChildWindow";
            this.checkBoxMaximizeChildWindow.Size = new System.Drawing.Size(286, 35);
            this.checkBoxMaximizeChildWindow.TabIndex = 2;
            this.checkBoxMaximizeChildWindow.Text = "默认最大化子查询窗口";
            this.checkBoxMaximizeChildWindow.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableAutoReplace
            // 
            this.checkBoxEnableAutoReplace.AutoSize = true;
            this.checkBoxEnableAutoReplace.Location = new System.Drawing.Point(34, 292);
            this.checkBoxEnableAutoReplace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEnableAutoReplace.Name = "checkBoxEnableAutoReplace";
            this.checkBoxEnableAutoReplace.Size = new System.Drawing.Size(190, 35);
            this.checkBoxEnableAutoReplace.TabIndex = 2;
            this.checkBoxEnableAutoReplace.Text = "启用自动替换";
            this.checkBoxEnableAutoReplace.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximizeWindow
            // 
            this.checkBoxMaximizeWindow.AutoSize = true;
            this.checkBoxMaximizeWindow.Location = new System.Drawing.Point(34, 238);
            this.checkBoxMaximizeWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMaximizeWindow.Name = "checkBoxMaximizeWindow";
            this.checkBoxMaximizeWindow.Size = new System.Drawing.Size(297, 35);
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
            this.comboBoxAskOnClosing.Location = new System.Drawing.Point(336, 162);
            this.comboBoxAskOnClosing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAskOnClosing.Name = "comboBoxAskOnClosing";
            this.comboBoxAskOnClosing.Size = new System.Drawing.Size(404, 39);
            this.comboBoxAskOnClosing.TabIndex = 1;
            // 
            // comboBoxAfterExecute
            // 
            this.comboBoxAfterExecute.FormattingEnabled = true;
            this.comboBoxAfterExecute.Items.AddRange(new object[] {
            "不自动Commit",
            "提示是否需要Commit",
            "自动Commit（在PLSQL14还会提示）"});
            this.comboBoxAfterExecute.Location = new System.Drawing.Point(336, 106);
            this.comboBoxAfterExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAfterExecute.Name = "comboBoxAfterExecute";
            this.comboBoxAfterExecute.Size = new System.Drawing.Size(404, 39);
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
            this.comboBoxStartup.Location = new System.Drawing.Point(336, 48);
            this.comboBoxStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxStartup.Name = "comboBoxStartup";
            this.comboBoxStartup.Size = new System.Drawing.Size(404, 39);
            this.comboBoxStartup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "执行SQL语句后：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "关闭程序时是否提示保存：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "启动时打开：";
            // 
            // tabPageAutoReplace
            // 
            this.tabPageAutoReplace.Controls.Add(this.label4);
            this.tabPageAutoReplace.Controls.Add(this.textBoxToBeAdded);
            this.tabPageAutoReplace.Controls.Add(this.buttonDelKey);
            this.tabPageAutoReplace.Controls.Add(this.buttonAddKey);
            this.tabPageAutoReplace.Controls.Add(this.textBoxAutoReplaceValue);
            this.tabPageAutoReplace.Controls.Add(this.listBoxAutoReplaceKey);
            this.tabPageAutoReplace.Location = new System.Drawing.Point(4, 43);
            this.tabPageAutoReplace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAutoReplace.Name = "tabPageAutoReplace";
            this.tabPageAutoReplace.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAutoReplace.Size = new System.Drawing.Size(792, 447);
            this.tabPageAutoReplace.TabIndex = 1;
            this.tabPageAutoReplace.Text = "自动替换设置";
            this.tabPageAutoReplace.UseVisualStyleBackColor = true;
            // 
            // buttonDelKey
            // 
            this.buttonDelKey.Location = new System.Drawing.Point(166, 368);
            this.buttonDelKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonDelKey.Name = "buttonDelKey";
            this.buttonDelKey.Size = new System.Drawing.Size(102, 46);
            this.buttonDelKey.TabIndex = 2;
            this.buttonDelKey.Text = "删除";
            this.buttonDelKey.UseVisualStyleBackColor = true;
            this.buttonDelKey.Click += new System.EventHandler(this.buttonDelKey_Click);
            // 
            // buttonAddKey
            // 
            this.buttonAddKey.Location = new System.Drawing.Point(36, 368);
            this.buttonAddKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonAddKey.Name = "buttonAddKey";
            this.buttonAddKey.Size = new System.Drawing.Size(102, 46);
            this.buttonAddKey.TabIndex = 2;
            this.buttonAddKey.Text = "新增";
            this.buttonAddKey.UseVisualStyleBackColor = true;
            this.buttonAddKey.Click += new System.EventHandler(this.buttonAddKey_Click);
            // 
            // textBoxAutoReplaceValue
            // 
            this.textBoxAutoReplaceValue.Location = new System.Drawing.Point(348, 34);
            this.textBoxAutoReplaceValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxAutoReplaceValue.Multiline = true;
            this.textBoxAutoReplaceValue.Name = "textBoxAutoReplaceValue";
            this.textBoxAutoReplaceValue.Size = new System.Drawing.Size(390, 308);
            this.textBoxAutoReplaceValue.TabIndex = 1;
            this.textBoxAutoReplaceValue.TextChanged += new System.EventHandler(this.textBoxAutoReplaceValue_TextChanged);
            // 
            // listBoxAutoReplaceKey
            // 
            this.listBoxAutoReplaceKey.FormattingEnabled = true;
            this.listBoxAutoReplaceKey.ItemHeight = 31;
            this.listBoxAutoReplaceKey.Location = new System.Drawing.Point(36, 34);
            this.listBoxAutoReplaceKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxAutoReplaceKey.Name = "listBoxAutoReplaceKey";
            this.listBoxAutoReplaceKey.Size = new System.Drawing.Size(232, 252);
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
            this.buttonOK.Location = new System.Drawing.Point(126, 568);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 50);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(350, 568);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonApply.Location = new System.Drawing.Point(568, 568);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(150, 50);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textBoxToBeAdded
            // 
            this.textBoxToBeAdded.Location = new System.Drawing.Point(134, 303);
            this.textBoxToBeAdded.Name = "textBoxToBeAdded";
            this.textBoxToBeAdded.Size = new System.Drawing.Size(134, 39);
            this.textBoxToBeAdded.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "新增Key:";
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(894, 670);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox textBoxToBeAdded;
        private System.Windows.Forms.Label label4;
    }
}