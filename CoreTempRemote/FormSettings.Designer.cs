namespace CoreTempRemote
{
    partial class FormSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nud_IP4 = new System.Windows.Forms.NumericUpDown();
            this.nud_IP3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_IP2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_IP1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Port = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_StartMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Address:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.nud_IP4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_IP3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_IP2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_IP1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 20);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // nud_IP4
            // 
            this.nud_IP4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_IP4.Location = new System.Drawing.Point(198, 0);
            this.nud_IP4.Margin = new System.Windows.Forms.Padding(0);
            this.nud_IP4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_IP4.Name = "nud_IP4";
            this.nud_IP4.Size = new System.Drawing.Size(56, 20);
            this.nud_IP4.TabIndex = 8;
            this.nud_IP4.Enter += new System.EventHandler(this.IP_OnFocus);
            // 
            // nud_IP3
            // 
            this.nud_IP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_IP3.Location = new System.Drawing.Point(132, 0);
            this.nud_IP3.Margin = new System.Windows.Forms.Padding(0);
            this.nud_IP3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_IP3.Name = "nud_IP3";
            this.nud_IP3.Size = new System.Drawing.Size(56, 20);
            this.nud_IP3.TabIndex = 6;
            this.nud_IP3.Enter += new System.EventHandler(this.IP_OnFocus);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(188, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_IP2
            // 
            this.nud_IP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_IP2.Location = new System.Drawing.Point(66, 0);
            this.nud_IP2.Margin = new System.Windows.Forms.Padding(0);
            this.nud_IP2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_IP2.Name = "nud_IP2";
            this.nud_IP2.Size = new System.Drawing.Size(56, 20);
            this.nud_IP2.TabIndex = 4;
            this.nud_IP2.Enter += new System.EventHandler(this.IP_OnFocus);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(122, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_IP1
            // 
            this.nud_IP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_IP1.Location = new System.Drawing.Point(0, 0);
            this.nud_IP1.Margin = new System.Windows.Forms.Padding(0);
            this.nud_IP1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_IP1.Name = "nud_IP1";
            this.nud_IP1.Size = new System.Drawing.Size(56, 20);
            this.nud_IP1.TabIndex = 0;
            this.nud_IP1.Enter += new System.EventHandler(this.IP_OnFocus);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(56, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_Port
            // 
            this.nud_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_Port.Location = new System.Drawing.Point(3, 16);
            this.nud_Port.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nud_Port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Port.Name = "nud_Port";
            this.nud_Port.Size = new System.Drawing.Size(254, 20);
            this.nud_Port.TabIndex = 1;
            this.nud_Port.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nud_Port);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 39);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Port:";
            // 
            // cb_StartMinimized
            // 
            this.cb_StartMinimized.AutoSize = true;
            this.cb_StartMinimized.Location = new System.Drawing.Point(12, 12);
            this.cb_StartMinimized.Name = "cb_StartMinimized";
            this.cb_StartMinimized.Size = new System.Drawing.Size(94, 17);
            this.cb_StartMinimized.TabIndex = 4;
            this.cb_StartMinimized.Text = "start minimized";
            this.cb_StartMinimized.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.cb_StartMinimized);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(99999, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 170);
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown nud_IP4;
        private System.Windows.Forms.NumericUpDown nud_IP3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_IP2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_IP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_StartMinimized;
    }
}