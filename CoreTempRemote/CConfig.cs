#region Using...

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace CoreTempRemote
{
    public static class CConfig
    {
        #region --- Variablen ---

        public static string m_strConfigFile = "";

        public static string IP_Address = "192.168.178.22";
        public static int Port = 5200;

        public static bool StartMinimized = false;

        #endregion

        #region --- Laden ---

        public static void Load(string strStartupPath_)
        {
            m_strConfigFile = strStartupPath_ + "\\CoreTempRemote.xml";

            IP_Address = GetStringFromXML(m_strConfigFile, "CONFIG", "TCP", "IP_Address", IP_Address);
            Port = GetIntFromXML(m_strConfigFile, "CONFIG", "TCP", "Port", Port);

            StartMinimized = GetBoolFromXML(m_strConfigFile, "CONFIG", "StartMinimized", StartMinimized);
        }

        public static void LoadWindow(Form f_, SplitContainer scs_)
        {
            LoadWindow(f_, m_strConfigFile, "WINDOW", true, true, new SplitContainer[] { scs_ });
        }

        #endregion

        #region --- Speichern ---

        public static void Save()
        {
            AddStringToXML(m_strConfigFile, "CONFIG", "TCP", "IP_Address", IP_Address);
            AddStringToXML(m_strConfigFile, "CONFIG", "TCP", "Port", Port.ToString());

            AddStringToXML(m_strConfigFile, "CONFIG", "StartMinimized", StartMinimized.ToString());
        }

        public static void SaveWindow(Form f_, SplitContainer scs_)
        {
            SaveWindow(f_, m_strConfigFile, "WINDOW", new SplitContainer[] { scs_ });
        }

        #endregion

        #region --- XML Funktionen ---

        #region -- AddStringToXML --

        public static void AddStringToXML(string strFile_, string strSection_, string strName_, string strContent_)
        {
            //Document
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(strFile_);
            }
            catch (Exception) { };

            //Root Node
            XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
            if (xmlRootNode == null)
            {
                xmlRootNode = xmlDoc.CreateElement("ROOT");
                xmlDoc.AppendChild(xmlRootNode);
            }

            //Section Node
            XmlNode xmlSectionNode = xmlRootNode.SelectSingleNode(strSection_);
            if (xmlSectionNode == null)
            {
                xmlSectionNode = xmlDoc.CreateElement(strSection_);
                xmlRootNode.AppendChild(xmlSectionNode);
            }

            //Data Node
            XmlNode xmlDataNode = xmlSectionNode.SelectSingleNode(strName_);
            if (xmlDataNode == null)
            {
                xmlDataNode = xmlDoc.CreateElement(strName_);
                xmlDataNode.InnerText = strContent_;
                xmlSectionNode.AppendChild(xmlDataNode);
            }
            else
                xmlDataNode.InnerText = strContent_;

            //Document speichern
            xmlDoc.Save(strFile_);
        }

        #endregion

        #region -- AddStringToXML (2 Sections) --

        public static void AddStringToXML(string strFile_, string strSection1_, string strSection2_, string strName_, string strContent_)
        {
            //Document
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(strFile_);
            }
            catch (Exception) { };

            //Root Node
            XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
            if (xmlRootNode == null)
            {
                xmlRootNode = xmlDoc.CreateElement("ROOT");
                xmlDoc.AppendChild(xmlRootNode);
            }

            //Section 1 Node
            XmlNode xmlSection1Node = xmlRootNode.SelectSingleNode(strSection1_);
            if (xmlSection1Node == null)
            {
                xmlSection1Node = xmlDoc.CreateElement(strSection1_);
                xmlRootNode.AppendChild(xmlSection1Node);
            }

            //Section 2 Node
            XmlNode xmlSection2Node = xmlSection1Node.SelectSingleNode(strSection2_);
            if (xmlSection2Node == null)
            {
                xmlSection2Node = xmlDoc.CreateElement(strSection2_);
                xmlSection1Node.AppendChild(xmlSection2Node);
            }

            //Data Node
            XmlNode xmlDataNode = xmlSection2Node.SelectSingleNode(strName_);
            if (xmlDataNode == null)
            {
                xmlDataNode = xmlDoc.CreateElement(strName_);
                xmlDataNode.InnerText = strContent_;
                xmlSection2Node.AppendChild(xmlDataNode);
            }
            else
                xmlDataNode.InnerText = strContent_;

            //Document speichern
            xmlDoc.Save(strFile_);
        }

        #endregion

        #region -- AddStringToXML (3 Sections) --

        public static void AddStringToXML(string strFile_, string strSection1_, string strSection2_, string strSection3_, string strName_, string strContent_)
        {
            //Document
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(strFile_);
            }
            catch (Exception) { };

            //Root Node
            XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
            if (xmlRootNode == null)
            {
                xmlRootNode = xmlDoc.CreateElement("ROOT");
                xmlDoc.AppendChild(xmlRootNode);
            }

            //Section 1 Node
            XmlNode xmlSection1Node = xmlRootNode.SelectSingleNode(strSection1_);
            if (xmlSection1Node == null)
            {
                xmlSection1Node = xmlDoc.CreateElement(strSection1_);
                xmlRootNode.AppendChild(xmlSection1Node);
            }

            //Section 2 Node
            XmlNode xmlSection2Node = xmlSection1Node.SelectSingleNode(strSection2_);
            if (xmlSection2Node == null)
            {
                xmlSection2Node = xmlDoc.CreateElement(strSection2_);
                xmlSection1Node.AppendChild(xmlSection2Node);
            }

            //Section 3 Node
            XmlNode xmlSection3Node = xmlSection2Node.SelectSingleNode(strSection3_);
            if (xmlSection3Node == null)
            {
                xmlSection3Node = xmlDoc.CreateElement(strSection3_);
                xmlSection2Node.AppendChild(xmlSection3Node);
            }

            //Data Node
            XmlNode xmlDataNode = xmlSection3Node.SelectSingleNode(strName_);
            if (xmlDataNode == null)
            {
                xmlDataNode = xmlDoc.CreateElement(strName_);
                xmlDataNode.InnerText = strContent_;
                xmlSection3Node.AppendChild(xmlDataNode);
            }
            else
                xmlDataNode.InnerText = strContent_;

            //Document speichern
            xmlDoc.Save(strFile_);
        }

        #endregion

        #region -- GetStringFromXML --

        public static string GetStringFromXML(string strFile_, string strSection_, string strName_, string strDefault_)
        {
            if (!File.Exists(strFile_))
                return strDefault_;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFile_);
                XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
                XmlNode xmlSectionNode = xmlRootNode.SelectSingleNode(strSection_);
                XmlNode xmlDataNode = xmlSectionNode.SelectSingleNode(strName_);
                return xmlDataNode.InnerText;
            }
            catch (Exception)
            {
                return strDefault_;
            }
        }

        #endregion

        #region -- GetStringFromXML (2 Sections) --

        public static string GetStringFromXML(string strFile_, string strSection1_, string strSection2_, string strName_, string strDefault_)
        {
            if (!File.Exists(strFile_))
                return strDefault_;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFile_);
                XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
                XmlNode xmlSection1Node = xmlRootNode.SelectSingleNode(strSection1_);
                XmlNode xmlSection2Node = xmlSection1Node.SelectSingleNode(strSection2_);
                XmlNode xmlDataNode = xmlSection2Node.SelectSingleNode(strName_);
                return xmlDataNode.InnerText;
            }
            catch (Exception)
            {
                return strDefault_;
            }
        }

        #endregion

        #region -- GetStringFromXML (3 Sections) --

        public static string GetStringFromXML(string strFile_, string strSection1_, string strSection2_, string strSection3_, string strName_, string strDefault_)
        {
            if (!File.Exists(strFile_))
                return strDefault_;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFile_);
                XmlNode xmlRootNode = xmlDoc.SelectSingleNode("ROOT");
                XmlNode xmlSection1Node = xmlRootNode.SelectSingleNode(strSection1_);
                XmlNode xmlSection2Node = xmlSection1Node.SelectSingleNode(strSection2_);
                XmlNode xmlSection3Node = xmlSection2Node.SelectSingleNode(strSection3_);
                XmlNode xmlDataNode = xmlSection3Node.SelectSingleNode(strName_);
                return xmlDataNode.InnerText;
            }
            catch (Exception)
            {
                return strDefault_;
            }
        }

        #endregion

        #region -- GetBoolFromXML --

        public static bool GetBoolFromXML(string strFile_, string strSection_, string strName_, bool bDefault_)
        {
            try
            {
                return Convert.ToBoolean(GetStringFromXML(strFile_, strSection_, strName_, bDefault_.ToString()));
            }
            catch (Exception)
            {
                return bDefault_;
            }
        }

        public static bool GetBoolFromXML(string strFile_, string strSection1_, string strSection2_, string strName_, bool bDefault_)
        {
            try
            {
                return Convert.ToBoolean(GetStringFromXML(strFile_, strSection1_, strSection2_, strName_, bDefault_.ToString()));
            }
            catch (Exception)
            {
                return bDefault_;
            }
        }

        public static bool GetBoolFromXML(string strFile_, string strSection1_, string strSection2_, string strSection3_, string strName_, bool bDefault_)
        {
            try
            {
                return Convert.ToBoolean(GetStringFromXML(strFile_, strSection1_, strSection2_, strSection3_, strName_, bDefault_.ToString()));
            }
            catch (Exception)
            {
                return bDefault_;
            }
        }

        #endregion

        #region -- GetIntFromXML --

        public static int GetIntFromXML(string strFile_, string strSection1_, string strSection2_, string strName_, int iDefault_)
        {
            try
            {
                return Convert.ToInt32(GetStringFromXML(strFile_, strSection1_, strSection2_, strName_, iDefault_.ToString()));
            }
            catch (Exception)
            {
                return iDefault_;
            }
        }

        public static int GetIntFromXML(string strFile_, string strSection1_, string strSection2_, string strSection3_, string strName_, int iDefault_)
        {
            try
            {
                return Convert.ToInt32(GetStringFromXML(strFile_, strSection1_, strSection2_, strSection3_, strName_, iDefault_.ToString()));
            }
            catch (Exception)
            {
                return iDefault_;
            }
        }

        #endregion

        #region -- SaveWindow --

        public static void SaveWindow(Form f_, string strFile_, string strSection_)
        {
            AddStringToXML(strFile_, strSection_, f_.Name, "SizeX", f_.Size.Width.ToString());
            AddStringToXML(strFile_, strSection_, f_.Name, "SizeY", f_.Size.Height.ToString());
            AddStringToXML(strFile_, strSection_, f_.Name, "PosX", f_.Location.X.ToString());
            AddStringToXML(strFile_, strSection_, f_.Name, "PosY", f_.Location.Y.ToString());
            AddStringToXML(strFile_, strSection_, f_.Name, "Maximized", (f_.WindowState == FormWindowState.Maximized).ToString());
        }

        public static void SaveWindow(Form f_, string strFile_, string strSection_, SplitContainer[] scs_)
        {
            SaveWindow(f_, strFile_, strSection_);
            foreach (SplitContainer sc in scs_)
            {
                AddStringToXML(strFile_, strSection_, f_.Name, sc.Name, "Horizontal", (sc.Orientation == Orientation.Horizontal).ToString());
                AddStringToXML(strFile_, strSection_, f_.Name, sc.Name, "SplitterDistance", sc.SplitterDistance.ToString());
            }
        }

        #endregion

        #region -- LoadWindow --

        public static void LoadWindow(Form f_, string strFile_, string strSection_, bool bLoadPos_, bool bLoadSize_)
        {
            if (bLoadSize_)
            {
                int iSizeX = GetIntFromXML(strFile_, strSection_, f_.Name, "SizeX", f_.Size.Width);
                int iSizeY = GetIntFromXML(strFile_, strSection_, f_.Name, "SizeY", f_.Size.Height);
                f_.Size = new System.Drawing.Size(iSizeX, iSizeY);
                if (GetBoolFromXML(strFile_, strSection_, f_.Name, "Maximized", false))
                    f_.WindowState = FormWindowState.Maximized;
                else
                    f_.Size = new System.Drawing.Size(iSizeX, iSizeY);
            }
            if (bLoadPos_)
            {
                int iPosX = GetIntFromXML(strFile_, strSection_, f_.Name, "PosX", 99999);
                int iPosY = GetIntFromXML(strFile_, strSection_, f_.Name, "PosY", 99999);
                if (iPosX != 99999 && iPosY != 99999)
                    SetWindowLocation(f_, iPosX, iPosY);
            }
        }

        public static void LoadWindow(Form f_, string strFile_, string strSection_, bool bLoadPos_, bool bLoadSize_, SplitContainer[] scs_)
        {
            LoadWindow(f_, strFile_, strSection_, bLoadPos_, bLoadSize_);
            foreach (SplitContainer sc in scs_)
            {
                if (GetBoolFromXML(strFile_, strSection_, f_.Name, sc.Name, "Horizontal", (sc.Orientation == Orientation.Horizontal)))
                    sc.Orientation = Orientation.Horizontal;
                else
                    sc.Orientation = Orientation.Vertical;
                sc.SplitterDistance = GetIntFromXML(strFile_, strSection_, f_.Name, sc.Name, "SplitterDistance", sc.SplitterDistance);
            }
        }

        #endregion

        #endregion

        #region --- SetWindowLocation ---

        public static void SetWindowLocation(Form f, int iPosX, int iPosY)
        {
            if (iPosX < Screen.PrimaryScreen.Bounds.Left || iPosX > Screen.PrimaryScreen.Bounds.Right)
                iPosX = 100;
            if (iPosY < Screen.PrimaryScreen.Bounds.Top || iPosY > Screen.PrimaryScreen.Bounds.Bottom)
                iPosY = 100;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(iPosX, iPosY);
        }

        #endregion
    }
}
