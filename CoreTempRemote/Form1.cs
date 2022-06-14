#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace CoreTempRemote
{
    public partial class Form1 : Form
    {
        #region --- Variablen ---

        JValues m_pJValues = new JValues();
        TreeNode m_tnCpuName;
        TreeNode m_tnCpuLoad;
        TreeNode m_tnCpuTemp;
        TreeNode m_tnCpuVID;
        TreeNode m_tnCpuFrequency;
        TreeNode m_tnCpuMultiplier;
        TreeNode m_tnCpuPower;

        TreeNode m_tnMem;
        TreeNode m_tnMemLoad;
        TreeNode m_tnMemPhysTotal;
        TreeNode m_tnMemPhysFree;
        TreeNode m_tnMemPhysUsed;
        TreeNode m_tnMemPageTotal;
        TreeNode m_tnMemPageFree;
        TreeNode m_tnMemPageUsed;
        TreeNode m_tnMemVirtualTotal;
        TreeNode m_tnMemVirtualFree;
        TreeNode m_tnMemVirtualUsed;

        TcpClient client;
        NetworkStream networkStream;
        StreamReader reader;

        #endregion

        #region --- Konstruktor ---

        public Form1()
        {
            InitializeComponent();
            Text = Text + " - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CConfig.Load(Application.StartupPath);
            CConfig.LoadWindow(this, sc_Data);
            if (CConfig.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                Visible = false;
                ShowInTaskbar = false;
            }
            StartListen();
        }

        #endregion

        #region --- "Destruktor" ---

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_Update.Stop();
            Thread.Sleep(500);
            DeInitTcpIp();

            CConfig.Save();
            if (WindowState != FormWindowState.Minimized)
                CConfig.SaveWindow(this, sc_Data);
        }

        #endregion

        #region --- StartListen ---

        void StartListen(bool bNoMsg_ = false)
        {
            if (InitTcpIp())
            {
                ControlBox = true;
                InitTreeNodes();
                timer_Update.Start();
            }
            else if(!bNoMsg_)
            {
                MessageBox.Show($"Couldn't connect to {CConfig.IP_Address}:{CConfig.Port}!\r\n\r\nSettings will be opened.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                settingsToolStripMenuItem1_Click(null, null);
            }
        }

        #endregion

        #region --- Einstellungen ---

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer_Update.Stop();
            Thread.Sleep(500);
            DeInitTcpIp();
            tv_Cpu.Nodes.Clear();
            tv_Mem.Nodes.Clear();
            new FormSettings().ShowDialog();
            StartListen();
        }

        #endregion

        #region --- TCP Connection ---

        void DeInitTcpIp()
        {
            try
            {
                reader.Close();
                networkStream.Close();
                client.Close();
            }
            catch (Exception) { }
        }

        bool InitTcpIp()
        {
            try
            {
                client = new TcpClient();
                client.Connect(CConfig.IP_Address, CConfig.Port);

                networkStream = client.GetStream();
                networkStream.ReadTimeout = 2000;

                reader = new StreamReader(networkStream, Encoding.UTF8);
                return true;
            }
            catch (Exception) 
            { 
                return false;
            }
        }

        #endregion

        #region --- Init Tree View ---

        void InitTreeNodes()
        {
            if (reader == null)
                return;

            try
            {
                string strRed = reader.ReadLine();
                m_pJValues.LoadJson(strRed);
            } 
            catch(Exception ex) 
            {
                timer_Update.Stop();
                tv_Cpu.Nodes.Clear();
                tv_Mem.Nodes.Clear();
                m_tnCpuName = tv_Cpu.Nodes.Add("Error: " + ex.Message);
                m_tnMem = tv_Mem.Nodes.Add("Error: " + ex.Message);
                ni_Power.Icon = ni_Temp.Icon = ni_Frequency.Icon = ni_Load.Icon = SystemIcons.Error;
                ni_Power.Text = ni_Temp.Text = ni_Frequency.Text = ni_Load.Text = ("Error: " + ex.Message).Truncate(60);
                DeInitTcpIp();
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                StartListen();
                return;
            }

            m_tnCpuName = tv_Cpu.Nodes.Add(m_pJValues.CpuName);

            m_tnCpuLoad = m_tnCpuName.Nodes.Add($"Load: {m_pJValues.CpuLoadAvg} %");
            for (int i = 0; i < m_pJValues.CpuLoads.Count; i++)
                m_tnCpuLoad.Nodes.Add($"Load [{i}]: {m_pJValues.CpuLoads[i]} %");

            m_tnCpuTemp = m_tnCpuName.Nodes.Add($"Temperature: {m_pJValues.CpuTempMax} °C");
            for (int i = 0; i < m_pJValues.CpuTemps.Count; i++)
                m_tnCpuTemp.Nodes.Add($"Temperature [{i}]: {m_pJValues.CpuTemps[i]} °C");

            m_tnCpuVID = m_tnCpuName.Nodes.Add($"VID: {m_pJValues.CpuVID:0.0000000} V");
            m_tnCpuFrequency = m_tnCpuName.Nodes.Add($"Frequency: {m_pJValues.CpuFrequency:0} MHz");

            m_tnCpuMultiplier = m_tnCpuName.Nodes.Add($"Multiplier: {m_pJValues.CpuMultiplier} x");
            for (int i = 0; i < m_pJValues.CpuMultipliers.Count; i++)
                m_tnCpuMultiplier.Nodes.Add($"Multiplier [{i}]: {m_pJValues.CpuMultipliers[i]} x");

            m_tnCpuPower = m_tnCpuName.Nodes.Add($"Power: {m_pJValues.CpuPowerAvg} W");

            m_tnMem = tv_Mem.Nodes.Add("Memory");
            m_tnMemLoad = m_tnMem.Nodes.Add($"Load: {m_pJValues.MemLoad}");
            m_tnMemPhysTotal = m_tnMem.Nodes.Add($"Physical Total: {m_pJValues.MemPhysTotal}");
            m_tnMemPhysFree = m_tnMem.Nodes.Add($"Physical Free: {m_pJValues.MemPhysFree}");
            m_tnMemPhysUsed = m_tnMem.Nodes.Add($"Physical Used: {m_pJValues.MemPhysUsed}");
            m_tnMemPageTotal = m_tnMem.Nodes.Add($"Page Total: {m_pJValues.MemPageTotal}");
            m_tnMemPageFree = m_tnMem.Nodes.Add($"Page Free: {m_pJValues.MemPageFree}");
            m_tnMemPageUsed = m_tnMem.Nodes.Add($"Page Used: {m_pJValues.MemPageUsed}");
            m_tnMemVirtualTotal = m_tnMem.Nodes.Add($"Virtual Total: {m_pJValues.MemVirtualTotal}");
            m_tnMemVirtualFree = m_tnMem.Nodes.Add($"Virtual Free: {m_pJValues.MemVirtualFree}");
            m_tnMemVirtualUsed = m_tnMem.Nodes.Add($"Virtual Used: {m_pJValues.MemVirtualUsed}");

            tv_Cpu.ExpandAll();
            tv_Mem.ExpandAll();
        }

        #endregion

        #region --- Timer Update ---

        private void timer_Update_Tick(object sender, EventArgs e)
        {
            try
            {
                if (client != null && networkStream != null && reader != null && client.Connected && !reader.EndOfStream)
                {
                    string strRed = reader.ReadLine();
                    m_pJValues.LoadJson(strRed);

                    if (Visible)
                    {
                        m_tnCpuName.Text = m_pJValues.CpuName;

                        m_tnCpuLoad.Text = $"Load: {m_pJValues.CpuLoadAvg} %";
                        for (int i = 0; i < m_pJValues.CpuLoads.Count; i++)
                            m_tnCpuLoad.Nodes[i].Text = $"Load [{i}]: {m_pJValues.CpuLoads[i]} %";

                        m_tnCpuTemp.Text = $"Temp: {m_pJValues.CpuTempMax} °C";
                        for (int i = 0; i < m_pJValues.CpuTemps.Count; i++)
                            m_tnCpuTemp.Nodes[i].Text = $"Temp [{i}]: {m_pJValues.CpuTemps[i]} °C";

                        m_tnCpuVID.Text = $"VID: {m_pJValues.CpuVID:0.0000000} V";
                        m_tnCpuFrequency.Text = $"Frequency: {m_pJValues.CpuFrequency:0} MHz";

                        m_tnCpuMultiplier.Text = $"Multiplier: {m_pJValues.CpuMultiplier} x";
                        for (int i = 0; i < m_pJValues.CpuMultipliers.Count; i++)
                            m_tnCpuMultiplier.Nodes[i].Text = $"Multiplier [{i}]: {m_pJValues.CpuMultipliers[i]} x";

                        m_tnCpuPower.Text = $"Power: {m_pJValues.CpuPowerAvg} W";

                        m_tnMemLoad.Text = $"Load: {m_pJValues.MemLoad}";
                        m_tnMemPhysTotal.Text = $"Physical Total: {m_pJValues.MemPhysTotal}";
                        m_tnMemPhysFree.Text = $"Physical Free: {m_pJValues.MemPhysFree}";
                        m_tnMemPhysUsed.Text = $"Physical Used: {m_pJValues.MemPhysUsed}";
                        m_tnMemPageTotal.Text = $"Page Total: {m_pJValues.MemPageTotal}";
                        m_tnMemPageFree.Text = $"Page Free: {m_pJValues.MemPageFree}";
                        m_tnMemPageUsed.Text = $"Page Used: {m_pJValues.MemPageUsed}";
                        m_tnMemVirtualTotal.Text = $"Virtual Total: {m_pJValues.MemVirtualTotal}";
                        m_tnMemVirtualFree.Text = $"Virtual Free: {m_pJValues.MemVirtualFree}";
                        m_tnMemVirtualUsed.Text = $"Virtual Used: {m_pJValues.MemVirtualUsed}";
                    }

                    ni_Power.Text = $"{m_pJValues.CpuPowerAvg} W";
                    ni_Temp.Text = $"{m_pJValues.CpuTempMax} °C";
                    ni_Frequency.Text = $"{m_pJValues.CpuFrequency:0} MHz";
                    ni_Load.Text = $"{m_pJValues.CpuLoadAvg} %";

                    if (ni_Power.Icon != null)
                    {
                        ni_Power.Icon.Dispose();
                        ni_Temp.Icon.Dispose();
                        ni_Frequency.Icon.Dispose();
                        ni_Load.Icon.Dispose();
                    }

                    ni_Power.Icon = FlimFlan.IconEncoder.Converter.BitmapToIcon(m_pJValues.Bmp_Power);
                    ni_Temp.Icon = FlimFlan.IconEncoder.Converter.BitmapToIcon(m_pJValues.Bmp_Temp);
                    ni_Frequency.Icon = FlimFlan.IconEncoder.Converter.BitmapToIcon(m_pJValues.Bmp_Frequency);
                    ni_Load.Icon = FlimFlan.IconEncoder.Converter.BitmapToIcon(m_pJValues.Bmp_Load);
                }
            }
            catch(Exception ex)
            {
                timer_Update.Stop();
                tv_Cpu.Nodes.Clear();
                tv_Mem.Nodes.Clear();
                m_tnCpuName = tv_Cpu.Nodes.Add("Error: " + ex.Message);
                m_tnMem = tv_Mem.Nodes.Add("Error: " + ex.Message);
                ni_Power.Icon = ni_Temp.Icon = ni_Frequency.Icon = ni_Load.Icon = SystemIcons.Error;
                ni_Power.Text = ni_Temp.Text = ni_Frequency.Text = ni_Load.Text = ("Error: " + ex.Message).Truncate(60);
                DeInitTcpIp();
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                StartListen();
            }
        }

        #endregion

        #region --- After Select TreeView ---

        private void tv_Data_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tv_Cpu.SelectedNode = null;
            tv_Mem.SelectedNode = null;
        }

        #endregion

        #region --- NotifyIcon Menu ---

        private void zeigenVersteckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visible && WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
                Visible = false;
                ShowInTaskbar = false;
            }
            else
            {
                Visible = true;
                ShowInTaskbar = true;
                WindowState = FormWindowState.Normal;
                TopMost = true;
                Thread.Sleep(100);
                TopMost = false;
            }
        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region --- Resize ---

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        #endregion
    }
}
