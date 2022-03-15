namespace CoreTempRemote
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sc_Data = new System.Windows.Forms.SplitContainer();
            this.tv_Cpu = new CoreTempRemote.DoubleBufferedTreeView();
            this.tv_Mem = new CoreTempRemote.DoubleBufferedTreeView();
            this.timer_Update = new System.Windows.Forms.Timer(this.components);
            this.ni_Power = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ni_Load = new System.Windows.Forms.NotifyIcon(this.components);
            this.ni_Frequency = new System.Windows.Forms.NotifyIcon(this.components);
            this.ni_Temp = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_Data)).BeginInit();
            this.sc_Data.Panel1.SuspendLayout();
            this.sc_Data.Panel2.SuspendLayout();
            this.sc_Data.SuspendLayout();
            this.cms_NotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(335, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openSettingsToolStripMenuItem.Text = "Open Settings...";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sc_Data);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 203);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red Data";
            // 
            // sc_Data
            // 
            this.sc_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Data.Location = new System.Drawing.Point(3, 16);
            this.sc_Data.Name = "sc_Data";
            // 
            // sc_Data.Panel1
            // 
            this.sc_Data.Panel1.Controls.Add(this.tv_Cpu);
            // 
            // sc_Data.Panel2
            // 
            this.sc_Data.Panel2.Controls.Add(this.tv_Mem);
            this.sc_Data.Size = new System.Drawing.Size(329, 184);
            this.sc_Data.SplitterDistance = 160;
            this.sc_Data.TabIndex = 0;
            // 
            // tv_Cpu
            // 
            this.tv_Cpu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Cpu.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_Cpu.Location = new System.Drawing.Point(0, 0);
            this.tv_Cpu.Name = "tv_Cpu";
            this.tv_Cpu.Size = new System.Drawing.Size(160, 184);
            this.tv_Cpu.TabIndex = 0;
            this.tv_Cpu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Data_AfterSelect);
            // 
            // tv_Mem
            // 
            this.tv_Mem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Mem.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_Mem.Location = new System.Drawing.Point(0, 0);
            this.tv_Mem.Name = "tv_Mem";
            this.tv_Mem.Size = new System.Drawing.Size(165, 184);
            this.tv_Mem.TabIndex = 1;
            this.tv_Mem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Data_AfterSelect);
            // 
            // timer_Update
            // 
            this.timer_Update.Interval = 1000;
            this.timer_Update.Tick += new System.EventHandler(this.timer_Update_Tick);
            // 
            // ni_Power
            // 
            this.ni_Power.ContextMenuStrip = this.cms_NotifyIcon;
            this.ni_Power.Text = "Core Temp Remote";
            this.ni_Power.Visible = true;
            this.ni_Power.DoubleClick += new System.EventHandler(this.zeigenVersteckenToolStripMenuItem_Click);
            // 
            // cms_NotifyIcon
            // 
            this.cms_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.cms_NotifyIcon.Name = "cms_NotifyIcon";
            this.cms_NotifyIcon.Size = new System.Drawing.Size(134, 48);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.zeigenVersteckenToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // ni_Load
            // 
            this.ni_Load.ContextMenuStrip = this.cms_NotifyIcon;
            this.ni_Load.Text = "Core Temp Remote";
            this.ni_Load.Visible = true;
            this.ni_Load.DoubleClick += new System.EventHandler(this.zeigenVersteckenToolStripMenuItem_Click);
            // 
            // ni_Frequency
            // 
            this.ni_Frequency.ContextMenuStrip = this.cms_NotifyIcon;
            this.ni_Frequency.Text = "Core Temp Remote";
            this.ni_Frequency.Visible = true;
            this.ni_Frequency.DoubleClick += new System.EventHandler(this.zeigenVersteckenToolStripMenuItem_Click);
            // 
            // ni_Temp
            // 
            this.ni_Temp.ContextMenuStrip = this.cms_NotifyIcon;
            this.ni_Temp.Text = "Core Temp Remote";
            this.ni_Temp.Visible = true;
            this.ni_Temp.DoubleClick += new System.EventHandler(this.zeigenVersteckenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Core Temp Remote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.sc_Data.Panel1.ResumeLayout(false);
            this.sc_Data.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_Data)).EndInit();
            this.sc_Data.ResumeLayout(false);
            this.cms_NotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer sc_Data;
        private DoubleBufferedTreeView tv_Cpu;
        private DoubleBufferedTreeView tv_Mem;
        private System.Windows.Forms.Timer timer_Update;
        private System.Windows.Forms.NotifyIcon ni_Power;
        private System.Windows.Forms.NotifyIcon ni_Load;
        private System.Windows.Forms.NotifyIcon ni_Frequency;
        private System.Windows.Forms.NotifyIcon ni_Temp;
        private System.Windows.Forms.ContextMenuStrip cms_NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
    }
}

