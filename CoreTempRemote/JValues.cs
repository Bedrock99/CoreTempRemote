#region Using...

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace CoreTempRemote
{
    public class JValues
    {
        #region --- Dll Import ---

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        #endregion

        #region --- Variablen ---

        #region -- CPU --

        public string CpuName { get; private set; }

        public int CpuLoadAvg = 0;
        public List<int> CpuLoads = new List<int>();

        public float CpuTempMax = 0;
        public List<float> CpuTemps = new List<float>();

        public float CpuVID = 0;
        public float CpuFrequency = 0;
        public float CpuMultiplier = 0;
        public List<float> CpuMultipliers = new List<float>();

        public float CpuPowerAvg = 0;

        #endregion

        #region -- MEM --

        public int MemLoad = 0;
        public string MemPhysTotal = "";
        public string MemPhysFree = "";
        public string MemPhysUsed = "";

        public string MemPageTotal = "";
        public string MemPageFree = "";
        public string MemPageUsed = "";

        public string MemVirtualTotal = "";
        public string MemVirtualFree = "";
        public string MemVirtualUsed = "";

        #endregion

        #region -- Icons --

        public Icon Icon_Temp { get; private set; }
        public Icon Icon_Load { get; private set; }
        public Icon Icon_Frequency { get; private set; }
        public Icon Icon_Power { get; private set; }

        public IntPtr Icon_TempHandle = IntPtr.Zero;
        public IntPtr Icon_LoadHandle = IntPtr.Zero;
        public IntPtr Icon_FrequencyHandle = IntPtr.Zero;
        public IntPtr Icon_PowerHandle = IntPtr.Zero;

        #endregion

        #endregion

        #region --- LoadJson ---

        public void LoadJson(string strJson_)
        {
            JObject jObj = JObject.Parse(strJson_);

            #region -- CPU --

            JToken jCpu = jObj["CpuInfo"];
            if (jCpu != null)
            {
                JToken jLoad = jCpu["uiLoad"];
                int iAvg = 0;
                int iCount = 0;
                List<int> loads = new List<int>();
                foreach (JToken jTok in jLoad)
                {
                    int iVal = Convert.ToInt32(jTok.ToString());
                    iAvg += iVal;
                    iCount++;
                    loads.Add(iVal);
                }
                CpuLoadAvg = iAvg / iCount;
                CpuLoads = loads;


                JToken jTemp = jCpu["fTemp"];
                float fTempMax = 0;
                List<float> temps = new List<float>();
                foreach (JToken jTok in jTemp)
                {
                    float fVal = Convert.ToSingle(jTok.ToString());
                    if (fVal > fTempMax)
                        fTempMax = fVal;
                    temps.Add(fVal);
                }
                CpuTempMax = fTempMax;
                CpuTemps = temps;

                CpuName = jCpu["CPUName"].ToString();
                CpuVID = Convert.ToSingle(jCpu["fVID"].ToString());
                CpuFrequency = Convert.ToSingle(jCpu["fCPUSpeed"].ToString());
                CpuMultiplier = Convert.ToSingle(jCpu["fMultiplier"].ToString());

                List<float> multipliers = new List<float>();
                foreach (JToken jTok in jTemp)
                    multipliers.Add(Convert.ToSingle(jTok.ToString()));
                CpuMultipliers = multipliers;

                JToken jPower = jCpu["fPower"];
                float fAvg = 0;
                iCount = 0;
                foreach (JToken jTok in jPower)
                {
                    float fVal = Convert.ToSingle(jTok.ToString());
                    fAvg += fVal;
                    iCount++;
                }
                CpuPowerAvg = fAvg / iCount;
            }

            #endregion

            #region -- MEM --

            JToken jMem = jObj["MemoryInfo"];
            if (jMem != null)
            {
                long lTotal = Convert.ToInt64(jMem["TotalPhys"].ToString()) * 1024 * 1024;
                long lFree = Convert.ToInt64(jMem["FreePhys"].ToString()) * 1024 * 1024;
                MemPhysTotal = GetSizeHumanReadAble(lTotal);
                MemPhysFree = GetSizeHumanReadAble(lFree);
                MemPhysUsed = GetSizeHumanReadAble(lTotal - lFree);

                lTotal = Convert.ToInt64(jMem["TotalPage"].ToString()) * 1024 * 1024;
                lFree = Convert.ToInt64(jMem["FreePage"].ToString()) * 1024 * 1024;
                MemPageTotal = GetSizeHumanReadAble(lTotal);
                MemPageFree = GetSizeHumanReadAble(lFree);
                MemPageUsed = GetSizeHumanReadAble(lTotal - lFree);

                lTotal = Convert.ToInt64(jMem["TotalVirtual"].ToString()) * 1024 * 1024;
                lFree = Convert.ToInt64(jMem["FreeVirtual"].ToString()) * 1024 * 1024;
                MemVirtualTotal = GetSizeHumanReadAble(lTotal);
                MemVirtualFree = GetSizeHumanReadAble(lFree);
                MemVirtualUsed = GetSizeHumanReadAble(lTotal - lFree);

                MemLoad = Convert.ToInt32(jMem["MemoryLoad"].ToString());
            }

            #endregion

            #region -- Create Icons --

            Icon_Frequency = CreateIcon("Freq", (CpuFrequency / 1000.0).ToString("0.0").Replace(",", ""), Color.Cyan, ref Icon_TempHandle, true);
            Icon_Load = CreateIcon("Load", CpuLoadAvg.ToString(), Color.Yellow, ref Icon_LoadHandle);
            Icon_Temp = CreateIcon("Temp", CpuTempMax.ToString("0"), Color.FromArgb(255, 32, 32), ref Icon_FrequencyHandle);
            Icon_Power = CreateIcon("Pwr", CpuPowerAvg.ToString("0"), Color.Magenta, ref Icon_PowerHandle);

            #endregion
        }

        #endregion

        #region --- CreateIcon ---

        public Icon CreateIcon(string name_, string text_, Color col_, ref IntPtr handle_, bool bAddPoint_ = false)
        {
            try
            {
                if (handle_ != IntPtr.Zero)
                    DestroyIcon(handle_);

                int iTextSize = 9;
                int iTextPos = 5;
                if (text_.Length > 2 && !bAddPoint_)
                {
                    iTextSize = 6;
                    iTextPos = 8;
                }
                Bitmap bmp = new Bitmap(16, 16);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.SmoothingMode = SmoothingMode.None;
                    g.PixelOffsetMode = PixelOffsetMode.None;
                    g.Clear(Color.Black);
                    g.DrawString(name_, new Font("Consolas", 5), new SolidBrush(col_), 0, 0);
                    g.DrawString(text_, new Font("Consolas", iTextSize), new SolidBrush(col_), 0, iTextPos);
                    if (bAddPoint_)
                        g.DrawLine(new Pen(col_, 1), 8, 14, 8, 16);
                }
                handle_ = bmp.GetHicon();
                return Icon.FromHandle(handle_);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region --- GetSizeHumanReadAble ---

        public string GetSizeHumanReadAble(long lSize_)
        {
            string strType = " B";
            double dblReturn = Convert.ToDouble(lSize_);

            if (dblReturn / 1024.0 > 1)
            {
                dblReturn = dblReturn / 1024.0;
                strType = " KB";
                if (dblReturn / 1024.0 > 1)
                {
                    dblReturn = dblReturn / 1024.0;
                    strType = " MB";
                    if (dblReturn / 1024.0 > 1)
                    {
                        dblReturn = dblReturn / 1024.0;
                        strType = " GB";
                        if (dblReturn / 1024.0 > 1)
                        {
                            dblReturn = dblReturn / 1024.0;
                            strType = " TB";
                        }
                    }
                }
            }
            return dblReturn.ToString("0.##") + strType;
        }

        #endregion
    }
}
