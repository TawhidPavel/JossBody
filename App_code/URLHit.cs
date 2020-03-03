using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Asp_Php
/// </summary>
public class URLHit
{
    public string TinyEAIPostRequest(string strURL)
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

}
