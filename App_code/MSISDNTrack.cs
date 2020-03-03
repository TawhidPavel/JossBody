using System.Web;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Data;
using System.Text;

    public partial class MSISDNTrack
    {

        CDA oCDA = new CDA();

        HttpRequest Request = HttpContext.Current.Request;


        public string GetUserAgent()
        {
            HttpRequest Request = HttpContext.Current.Request;
            string agent = Request.UserAgent;
            if (!string.IsNullOrEmpty(Request.Headers["X-OperaMini-Phone-UA"]))
            {
                agent = Request.Headers["X-OperaMini-Phone-UA"];
            }
            return agent;
        }


        //----------------------- New code for MSISDN-----------------------
        #region"MSISDN"
        public string GetMSISDN() // Find out the MSISDN Number of GrameenPhone Mobile
        {
            HttpRequest Request = HttpContext.Current.Request;

            string sMsisdnNo = string.Empty;

            try
            {
                string sMsisdn = string.Empty;

                sMsisdn = Request.ServerVariables.Get("HTTP_X_UP_CALLING_LINE_ID");

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["HTTP_MSISDN"]; } // for GP

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["MSISDN"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers.Get("MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("X-MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("User-Identity-Forward-msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_X_FH_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("HTTP_X_MSISDN"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["http_msisdn"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables.Get("http_msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["msisdn"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers.Get("msisdn"); }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.ServerVariables["HTTP_X_HTS_CLID"]; }

                if (string.IsNullOrEmpty(sMsisdn))
                { sMsisdn = Request.Headers["X-WAP-Network-Client-MSISDN"]; } // for Airtel

                if (sMsisdn.Length > 13)
                {
                    for (int iCount = 1; iCount < sMsisdn.Length; iCount += 2)
                    {
                        sMsisdnNo += sMsisdn[iCount].ToString();
                    }
                }
                else
                {
                    sMsisdnNo = sMsisdn;
                }
                if (string.IsNullOrEmpty(sMsisdn))
                {
                    sMsisdnNo = Request.Headers["msisdn"].ToString();
                }
            }
            catch (Exception ex)
            {
                sMsisdnNo = "Error - " + ex.Message;
            }

            //sMsisdnNo = "8801857888750";

            return sMsisdnNo;
        }
        #endregion"MSISDN"
        //----------------------- New Code for MSISDN-------------------------

        #region"OS Detect"
        public string GetOS() // Find out the OS of Mobile
        {
            HttpRequest Request = HttpContext.Current.Request;
            string MHW = GetUAProfileUrl();
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            string OS = string.Empty;
            try
            {
                string Node = @"\<device_os\>(.*?)\</device_os\>";

                foreach (Match match in Regex.Matches(MHW, Node))
                {
                    OS = match.Groups[1].Value;
                    OS = OS.Replace(" OS", "");
                }
            }
            catch { }
            if (String.IsNullOrEmpty(OS))
            {
                OS = "Java OS";
            }
            if (strUserAgent != null)
            {
                if (strUserAgent.Contains("Series40"))
                {
                    OS = "Nokia OS";
                }
                if (strUserAgent.Contains("Series60"))
                {
                    OS = "Symbian";
                }
                if (strUserAgent.Contains("bada"))
                {
                    OS = "Bada OS";
                }
                if (strUserAgent.Contains("opera mini"))
                {
                    OS = "Opera Mini";
                }
                if (strUserAgent.Contains("iphone"))
                {
                    OS = "Iphone";
                }
                if (strUserAgent.Contains("blackberry"))
                {
                    OS = "Blackberry";
                }
                if (strUserAgent.Contains("windows"))
                {
                    OS = "Windows";
                }
                if (strUserAgent.Contains("windows ce"))
                {
                    OS = "Windows Mobile";
                }
                if (strUserAgent.Contains("windows phone"))
                {
                    OS = "Windows Phone";
                }
                if (strUserAgent.Contains("adr"))
                {
                    OS = "Android";
                }
                if (strUserAgent.Contains("android"))
                {
                    OS = "Android";
                }
                if (strUserAgent.Contains("symbian"))
                {
                    OS = "Symbian";
                }
                if (strUserAgent.Contains("symbos"))
                {
                    OS = "Symbian";
                }
            }


            string userAgent = string.Empty;
            if (!string.IsNullOrEmpty(Request.ServerVariables["HTTP_USER_AGENT"]))
            {
                userAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["X-OperaMini-Phone-UA"]))
            {
                userAgent = Request.Headers["X-OperaMini-Phone-UA"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["Device-Stock-UA"]))
            {
                userAgent = Request.Headers["Device-Stock-UA"];
            }

            if (OS == "Java OS")
            {
                if (userAgent.ToLower().Contains("nokia"))
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlTextReader reader = new XmlTextReader(MHW);
                        reader.Read();
                        doc.Load(reader);
                        XmlNodeList nodes = doc.GetElementsByTagName("prf:OSVendor");
                        foreach (XmlNode node in nodes)
                        {
                            OS = node.ChildNodes[0].Value;
                        }
                        if (OS == "Nokia")
                        {
                            OS = "Nokia OS";
                        }
                        if (OS == "Symbian LTD")
                        {
                            OS = "Symbian";
                        }
                    }
                    catch { }
                }
            }
            if (OS == "Opera Mini")
            {
                if (userAgent.ToLower().Contains("nokia"))
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlTextReader reader = new XmlTextReader(MHW);
                        reader.Read();
                        doc.Load(reader);
                        XmlNodeList nodes = doc.GetElementsByTagName("prf:OSVendor");
                        foreach (XmlNode node in nodes)
                        {
                            OS = node.ChildNodes[0].Value;
                        }
                        if (OS == "Nokia")
                        {
                            OS = "Nokia OS";
                        }
                        if (OS == "Symbian LTD")
                        {
                            OS = "Symbian";
                        }
                    }
                    catch { }
                }
            }
            return OS;
        }
        #endregion"OS Detect"


        public string GetUserIP()
        {
            string ipList = string.Empty;
            try
            {
                ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            catch (Exception e)
            {

            }


            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }

        public string GetUAProfileXWap()
        {
            HttpRequest Request = HttpContext.Current.Request;
            string sUAProfile = string.Empty;

            string xWapProfile = Request.Headers["X-Wap-Profile"];

            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["x-wap-profile"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["X-WAP-PROFILE"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.ServerVariables["HTTP_X_WAP_PROFILE"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["19-profile"];
            }
            if (string.IsNullOrEmpty(xWapProfile))
            {
                xWapProfile = Request.Headers["wap-profile"];
            }
            //sUAProfile = "http://wap.samsungmobile.com/uaprof/GT-I9100.xml";

            return xWapProfile;
        }
        //--------------- End New Addition Kabir : 27/06/2011-------------------------


        protected internal static string GetUAProfileOpera()
        {
            string phpURL = "http://www.vumobile.biz/wurfl/check_wurfl.php?force_ua=";
            string userAgent = string.Empty;

            HttpRequest Request = HttpContext.Current.Request;
            //string xWapProfile = Request.Headers["X-OperaMini-Phone-UA"];
            ////xWapProfile = "Nokia# E71";
            ////xWapProfile = "Android";

            //if (string.IsNullOrEmpty(xWapProfile))
            //{
            //    xWapProfile = Request.Headers["x-operamini-phone"];
            //}
            //if (string.IsNullOrEmpty(xWapProfile))
            //{
            //    xWapProfile = Request.Headers["X-OperaMini-Phone"];
            //}

            if (!string.IsNullOrEmpty(Request.ServerVariables["HTTP_USER_AGENT"]))
            {
                userAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["X-OperaMini-Phone-UA"]))
            {
                userAgent = Request.Headers["X-OperaMini-Phone-UA"];
            }
            if (!string.IsNullOrEmpty(Request.Headers["Device-Stock-UA"]))
            {
                userAgent = Request.Headers["Device-Stock-UA"];
            }
            string getValue = TinyEAIPostRequest(phpURL + userAgent);

            //string sUAProfile = PageBase.oBllFacade.GetDeviceUAProfileUrl(xWapProfile);
            string sUAProfile = getUaProf(getValue);

            return sUAProfile;
            //return xWapProfile;
        }

        protected internal static string getUaProf(string Val)
        {
            string xmlValue = string.Empty;

            string Node = @"\<uaprof\>(.*?)\</uaprof\>";

            foreach (Match match in Regex.Matches(Val, Node))
            {
                xmlValue = match.Groups[1].Value;
            }
            return xmlValue;
        }

        public string GetUAProfileUrl()  // Find out the Dimention of Mobile Device
        {
            string sUAProfile = string.Empty;

            sUAProfile = GetUAProfileXWap();

            if (string.IsNullOrEmpty(sUAProfile))
            {
                sUAProfile = GetUAProfileOpera();
            }

            //sUAProfile = "http://nds1.nds.nokia.com/uaprof/NN73-1r100-SB3G.xml";
            return sUAProfile;
        }

        public string AdPlayRequest(string URL)
        {
            HttpWebResponse objHttpWebResponse = null;
            UTF8Encoding encoding;
            string strResponse = "";
            try
            {
                HttpWebRequest objHttpWebRequest;
                objHttpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                objHttpWebRequest.KeepAlive = false;
                objHttpWebRequest.ProtocolVersion = HttpVersion.Version10;
                objHttpWebRequest.Method = "GET";
                objHttpWebRequest.Timeout = 30000;
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();
                encoding = new UTF8Encoding();
                StreamReader objStreamReader =
                    new StreamReader(objHttpWebResponse.GetResponseStream(), encoding);
                strResponse = objStreamReader.ReadToEnd();
            }
            catch { }
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return strResponse;
        }

        protected internal static string TinyEAIPostRequest(string strURL)
        {
            HttpWebResponse objHttpWebResponse = null;
            UTF8Encoding encoding;
            string strResponse = "";

            HttpWebRequest objHttpWebRequest;
            objHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
            objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            objHttpWebRequest.PreAuthenticate = true;

            objHttpWebRequest.Method = "POST";

            //Prepare the request stream
            if (strURL != null && strURL != string.Empty)
            {
                encoding = new UTF8Encoding();
                Stream objStream = objHttpWebRequest.GetRequestStream();
                Byte[] Buffer = encoding.GetBytes(strURL);
                // Post the request
                objStream.Write(Buffer, 0, Buffer.Length);
                objStream.Close();
            }
            objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();
            encoding = new UTF8Encoding();
            StreamReader objStreamReader =
                new StreamReader(objHttpWebResponse.GetResponseStream(), encoding);
            strResponse = objStreamReader.ReadToEnd();
            string removeBreak = Regex.Replace(strResponse, "\n", "");
            string MobileXml = Regex.Replace(removeBreak, "\"", "'");
            objHttpWebResponse.Close();
            objHttpWebRequest = null;
            return MobileXml;
        }

        public string GetDimension()  // Find out the Dimention of Mobile Device
        {
            string handsetDimension = string.Empty;
            string MHW = "";
            string xWapProfile = GetUAProfileUrl();

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");
                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }

                //MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:ScreenSize");
            XmlNode product = doc.GetElementsByTagName("prf:ScreenSize")[0];
            foreach (XmlNode price in prices)
            {
                handsetDimension = price.ChildNodes[0].Value;
            }
            return handsetDimension;
        }

        public string GetHandsetModel() // Find out the Mobile Device Model
        {
            string handsetModel = string.Empty;
            string xWapProfile = GetUAProfileUrl();

            string MHW = "";

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");
                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }

                //MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:Model");
            XmlNode product = doc.GetElementsByTagName("prf:Model")[0];
            foreach (XmlNode price in prices)
            {
                handsetModel = price.ChildNodes[0].Value;
            }
            return handsetModel;
        }

        public string GetHandsetManufacturer()  // Find out the Mobile Device Manufacturer or Vendor
        {
            string handsetManufacturer = string.Empty;
            string xWapProfile = GetUAProfileUrl();

            string MHW = "";

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");

                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }

                // MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("prf:Vendor");
            XmlNode product = doc.GetElementsByTagName("prf:Vendor")[0];
            foreach (XmlNode price in prices)
            {
                handsetManufacturer = price.ChildNodes[0].Value;
            }
            return handsetManufacturer;
        }

        public string GetHandsetPolyToneFormat()  // Find out which polytone format is supported by a particular Mobile Device
        {
            bool Flg_MIDI = false;
            bool Flg_SPMIDI = false;
            bool Flg_MMF = false;

            string AudioFormat = string.Empty;
            string xWapProfile = Request.Headers["X-Wap-Profile"];

            string MHW = "";

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");
                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }
                //MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                AudioFormat += "," + price.ChildNodes[0].Value;
            }

            if (AudioFormat.Contains("audio/sp-midi"))
            {
                Flg_SPMIDI = true;
            }
            if (AudioFormat.Contains("audio/midi"))
            {
                Flg_MIDI = true;
            }
            if (AudioFormat.Contains("audio/mmf"))
            {
                Flg_MMF = true;
            }
            if (Flg_SPMIDI == true && Flg_MIDI == true && Flg_MMF == true)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == false && Flg_MIDI == true && Flg_MMF == true)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == true && Flg_MMF == false)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == false && Flg_MIDI == true && Flg_MMF == false)
            {
                AudioFormat = "MIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == false && Flg_MMF == true)
            {
                AudioFormat = "SPMIDI";
            }
            if (Flg_SPMIDI == true && Flg_MIDI == false && Flg_MMF == false)
            {
                AudioFormat = "SPMIDI";
            }

            if (Flg_SPMIDI == false && Flg_MIDI == false && Flg_MMF == true)
            {
                AudioFormat = "MMF";
            }

            return AudioFormat;
        }

        public string GetHandsetTrueToneFormat()  // Find out which Truetone format is supported by a particular Mobile Device
        {
            bool Flg_AMR = false;
            bool Flg_MP3 = false;
            string AudioFormat = string.Empty;
            string xWapProfile = Request.Headers["X-Wap-Profile"];

            string MHW = "";

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }

                int iFIndex = xWapProfile.IndexOf("http");

                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }

                //MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                AudioFormat += "," + price.ChildNodes[0].Value;
            }

            if (AudioFormat.Contains("audio/amr"))
            {
                Flg_AMR = true;
            }

            if (AudioFormat.Contains("audio/mp3"))
            {
                Flg_MP3 = true;
            }

            if (Flg_MP3 == true && Flg_AMR == true)
            {
                AudioFormat = "MP3";
            }

            if (Flg_MP3 == true && Flg_AMR == false)
            {
                AudioFormat = "MP3";
            }

            if (Flg_MP3 == false && Flg_AMR == true)
            {
                AudioFormat = "AMR";
            }
            return AudioFormat;
        }

        public string ClosestMinimumFinder(string Dimension, string ContentType)
        {
            CDA cmd = new CDA();
            DataSet ds = cmd.GetDataSet("Select Specification from tbl_ContentFormat Where title='" + ContentType + "'", "WAPDB");
            int Input_W = 0;
            int Input_H = 0;

            string strDimentionFromDB = string.Empty;
            int Database_W = 0;
            int Database_H = 0;

            string[] arrSplitedString = Dimension.Split('x');
            Input_W = Convert.ToInt32(arrSplitedString[0]);
            Input_H = Convert.ToInt32(arrSplitedString[1]);

            int TempDifference = -1;
            int MinimumDifference = -1;
            int MinimumClosestWidth = 0;
            string MinimumDimention = "Default";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strDimentionFromDB = dr.ItemArray[0].ToString();
                arrSplitedString = strDimentionFromDB.Split('x');

                Database_W = Convert.ToInt32(arrSplitedString[0].Split('D')[1]);

                TempDifference = Input_W - Database_W;

                if (TempDifference == 0)
                {
                    MinimumDifference = TempDifference;
                    MinimumClosestWidth = Database_W;
                    break;
                }
                else if (TempDifference > 0)
                {
                    if (MinimumDifference != -1)
                    {
                        if (TempDifference < MinimumDifference)
                        {
                            MinimumDifference = TempDifference;
                            MinimumClosestWidth = Database_W;
                        }
                    }
                    else
                    {
                        MinimumDifference = TempDifference;
                        MinimumClosestWidth = Database_W;
                    }
                }
            }

            if (MinimumDifference >= 0)
            {
                DataSet objDataSet = cmd.GetDataSet("SELECT Specification FROM tbl_ContentFormat WHERE title='" + ContentType + "' AND Specification LIKE 'D" + MinimumClosestWidth + "x%'", "WAPDB");
                TempDifference = -1;
                MinimumDifference = -1;

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRaw in objDataSet.Tables[0].Rows)
                    {
                        strDimentionFromDB = dataRaw.ItemArray[0].ToString();
                        arrSplitedString = strDimentionFromDB.Split('x');

                        Database_H = Convert.ToInt32(arrSplitedString[1]);

                        TempDifference = Input_H - Database_H;

                        if (TempDifference == 0)
                        {
                            MinimumDifference = TempDifference;
                            MinimumDimention = strDimentionFromDB;
                            break;
                        }
                        else if (TempDifference > 0)
                        {
                            if (MinimumDifference != -1)
                            {
                                if (TempDifference < MinimumDifference)
                                {
                                    MinimumDifference = TempDifference;
                                    MinimumDimention = strDimentionFromDB;
                                }
                            }
                            else
                            {
                                MinimumDifference = TempDifference;
                                MinimumDimention = strDimentionFromDB;
                            }
                        }
                    }
                }
            }
            return MinimumDimention;
        }
        public bool IsNumeric(string strTextEntry)
        {
            bool bIsNumeric = true;
            try
            {
                System.Text.RegularExpressions.Regex objNotWholePattern = new Regex("[^0-9]");
                bIsNumeric = !objNotWholePattern.IsMatch(strTextEntry);
            }
            catch
            {
                bIsNumeric = false;
            }

            return bIsNumeric;
        }

        public string GetHandsetVideoFormat()  // Find out which polytone format is supported by a particular Mobile Device
        {
            bool Flg_3GP = false;
            //bool Flg_MP4 = false;
            //bool Flg_MPEG = false;

            string VideoFormat = string.Empty;
            string xWapProfile = Request.Headers["X-Wap-Profile"];

            string MHW = "";

            if (string.IsNullOrEmpty(xWapProfile))
            {
                MHW = GetUAProfileOpera();
            }
            else
            {
                int iIndex = xWapProfile.IndexOf(".xml");

                if (iIndex == -1)
                { iIndex = xWapProfile.IndexOf(".rdf"); }
                int iFIndex = xWapProfile.IndexOf("http");

                if (iFIndex == 0)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 4);
                }
                if (iFIndex == 1)
                {
                    MHW = xWapProfile.Substring(iFIndex, iIndex + 3);
                }

                //MHW = xWapProfile.Substring(1, iIndex + 3);
            }
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(MHW);
            reader.Read();
            doc.Load(reader);
            XmlNodeList prices = doc.GetElementsByTagName("rdf:li");
            XmlNode product = doc.GetElementsByTagName("rdf:li")[0];
            foreach (XmlNode price in prices)
            {
                VideoFormat += "," + price.ChildNodes[0].Value;
            }

            if (VideoFormat.Contains("video/3gpp"))
            {
                Flg_3GP = true;
            }
            //if (VideoFormat.Contains("video/mp4"))
            //{
            //    Flg_MP4 = true;
            //}
            //if (VideoFormat.Contains("video/mpeg4"))
            //{
            //    Flg_MPEG = true;
            //}
            //if (Flg_MP4 == true && Flg_3GP == true && Flg_MPEG == true)
            //{
            //    VideoFormat = "3GP";
            //}
            //if (Flg_MP4 == false && Flg_3GP == true && Flg_MPEG == true)
            //{
            //    VideoFormat = "3GP";
            //}
            //if (Flg_MP4 == true && Flg_3GP == true && Flg_MPEG == false)
            //{
            //    VideoFormat = "MIDI";
            //}
            //if (Flg_MP4 == false && Flg_3GP == true && Flg_MPEG == false)
            //{
            //    VideoFormat = "MIDI";
            //}
            //if (Flg_MP4 == true && Flg_3GP == false && Flg_MPEG == true)
            //{
            //    VideoFormat = "SPMIDI";
            //}
            //if (Flg_MP4 == true && Flg_3GP == false && Flg_MPEG == false)
            //{
            //    VideoFormat = "SPMIDI";
            //}

            //if (Flg_MP4 == false && Flg_3GP == false && Flg_MPEG == true)
            //{
            //    VideoFormat = "MMF";
            //}
            if (Flg_3GP == true)
            {
                VideoFormat = "3GP";
            }
            return VideoFormat;
        }

        public string GetAPN() // Find out the MSISDN Number of GrameenPhone Mobile
        {
            string sAPN = string.Empty;

            try
            {

                string sLAPN = string.Empty;

                sLAPN = Request.Headers["APN"];

                if (string.IsNullOrEmpty(sLAPN))
                {
                    sLAPN = Request.Headers.Get("APN");
                }

                if (string.IsNullOrEmpty(sLAPN))
                {
                    sLAPN = Request.Headers["x-up-operator"];
                }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.Headers["HTTP_X_UP_OPERATOR"]; }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.ServerVariables.Get("x-up-operator"); }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = Request.ServerVariables.Get("HTTP_X_UP_OPERATOR"); }

                //if (string.IsNullOrEmpty(sLAPN))
                //{ sLAPN = curr.GatewayVersion; }

                if (string.IsNullOrEmpty(sLAPN))
                { sLAPN = string.Empty; }
                else
                {
                    sAPN = sLAPN;
                }

            }
            catch (Exception ex)
            {
                sAPN = "Error - " + ex.Message;
            }

            return sAPN;
        }

        public string Encode(string Encode)
        {
            string encodedText = string.Empty;
            try
            {
                byte[] bytesToEncode = Encoding.UTF8.GetBytes(Encode);
                encodedText = Convert.ToBase64String(bytesToEncode);
            }
            catch { }
            return encodedText;
        }

        public string Decode(string Decode)
        {
            string decodedText = string.Empty;
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(Decode);
                decodedText = Encoding.UTF8.GetString(decodedBytes);
            }
            catch { }
            return decodedText;
        }

        //public string MakeAbsolute(string partialPath)
        //{
        //    // Remove any leading directory markers.
        //    if (partialPath.StartsWith(Path.AltDirectorySeparatorChar.ToString()) ||
        //        partialPath.StartsWith(Path.DirectorySeparatorChar.ToString()))
        //        partialPath = partialPath.Substring(1, partialPath.Length - 1);
        //    // Combing with the application root.
        //    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, partialPath).Replace("/", "\\");
        //}

    }
