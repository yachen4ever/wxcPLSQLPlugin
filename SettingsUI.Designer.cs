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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxMaximizeWindow = new System.Windows.Forms.CheckBox();
            this.comboBoxAskOnClosing = new System.Windows.Forms.ComboBox();
            this.comboBoxAfterExecute = new System.Windows.Forms.ComboBox();
            this.comboBoxStartup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxMaximizeChildWindow = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(32, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxMaximizeChildWindow);
            this.tabPage1.Controls.Add(this.checkBoxMaximizeWindow);
            this.tabPage1.Controls.Add(this.comboBoxAskOnClosing);
            this.tabPage1.Controls.Add(this.comboBoxAfterExecute);
            this.tabPage1.Controls.Add(this.comboBoxStartup);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(525, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 启动设置 ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximizeWindow
            // 
            this.checkBoxMaximizeWindow.AutoSize = true;
            this.checkBoxMaximizeWindow.Location = new System.Drawing.Point(23, 149);
            this.checkBoxMaximizeWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxMaximizeWindow.Name = "checkBoxMaximizeWindow";
            this.checkBoxMaximizeWindow.Size = new System.Drawing.Size(188, 24);
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
            this.comboBoxAskOnClosing.Location = new System.Drawing.Point(224, 101);
            this.comboBoxAskOnClosing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxAskOnClosing.Name = "comboBoxAskOnClosing";
            this.comboBoxAskOnClosing.Size = new System.Drawing.Size(270, 28);
            this.comboBoxAskOnClosing.TabIndex = 1;
            // 
            // comboBoxAfterExecute
            // 
            this.comboBoxAfterExecute.FormattingEnabled = true;
            this.comboBoxAfterExecute.Items.AddRange(new object[] {
            "不自动Commit",
            "提示是否需要Commit",
            "自动Commit（在PLSQL14还会提示）"});
            this.comboBoxAfterExecute.Location = new System.Drawing.Point(224, 66);
            this.comboBoxAfterExecute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxAfterExecute.Name = "comboBoxAfterExecute";
            this.comboBoxAfterExecute.Size = new System.Drawing.Size(270, 28);
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
            this.comboBoxStartup.Location = new System.Drawing.Point(224, 30);
            this.comboBoxStartup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxStartup.Name = "comboBoxStartup";
            this.comboBoxStartup.Size = new System.Drawing.Size(270, 28);
            this.comboBoxStartup.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "执行SQL语句后：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "关闭程序时是否提示保存：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "启动时打开：";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(525, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "自动替换设置";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(88, 331);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(233, 331);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(379, 331);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 31);
            this.button3.TabIndex = 1;
            this.button3.Text = "应用";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxMaximizeChildWindow
            // 
            this.checkBoxMaximizeChildWindow.AutoSize = true;
            this.checkBoxMaximizeChildWindow.Location = new System.Drawing.Point(313, 149);
            this.checkBoxMaximizeChildWindow.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMaximizeChildWindow.Name = "checkBoxMaximizeChildWindow";
            this.checkBoxMaximizeChildWindow.Size = new System.Drawing.Size(181, 24);
            this.checkBoxMaximizeChildWindow.TabIndex = 2;
            this.checkBoxMaximizeChildWindow.Text = "默认最大化子查询窗口";
            this.checkBoxMaximizeChildWindow.UseVisualStyleBackColor = true;
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(596, 397);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsUI";
            this.Text = "wxcPLSQLPlugin设置界面";
            this.Load += new System.EventHandler(this.SettingsUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxStartup;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboBoxAfterExecute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAskOnClosing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMaximizeWindow;
        private System.Windows.Forms.CheckBox checkBoxMaximizeChildWindow;
    }
}