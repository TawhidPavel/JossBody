using System;
using System.Data;
using UAprofileFinder;

public partial class footerInfo : System.Web.UI.Page
{
    string option = string.Empty;
    string subStatus = String.Empty;
    CDA db = new CDA();
    MSISDNTrack ms = new MSISDNTrack();
    string number = String.Empty;
    UAProfile oUAProfile = new UAProfile();
    string HS_MANUFAC = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string OPERATOR = String.Empty;
    string sMsisdn = String.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        userInfo();
        try
        {
            number = ms.GetMSISDN();
        }
        catch
        {
            number = "wifi";
        }
        if (number.Contains("Error"))
        {
            number = "wifi";
            
        }
        option = Request.QueryString["op"].ToString();
        if (option == "buddy")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option +  "'", "WAPDB");
        }
        if (option == "clubz")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option + "'", "WAPDB");
        }
        if (option == "quiz")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option + "'", "WAPDB");
        }
        if (option == "sticker")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option + "'", "WAPDB");
        }
        if (option == "gameClub")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option + "'", "WAPDB");
        }
        if (option == "liveGame")
        {
            DataSet dsUserinfo = db.GetDataSet("Exec sp_otherLinkInfo '" + number + "','" + OPERATOR + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + option + "'", "WAPDB");
            DataSet hit = db.GetDataSet("Exec sp_otherLinkTotalHitCount '" + option + "'", "WAPDB");
        }
    }

    private void userInfo()
    {
        #region "MSISDN"
        try
        {
            if (string.IsNullOrEmpty(oUAProfile.GetMSISDN()) || oUAProfile.GetMSISDN().StartsWith("Error"))
            {
                throw new Exception();
            }
            else
            {
                sMsisdn = oUAProfile.GetMSISDN();
                if (sMsisdn.StartsWith("88018"))
                {
                    OPERATOR = "Robi";
                }

                if (sMsisdn.StartsWith("88016"))
                {
                    OPERATOR = "Airtel";
                }

                if (sMsisdn.StartsWith("88019"))
                {
                    OPERATOR = "Banglalink";
                }

                if (sMsisdn.StartsWith("88015"))
                {
                    OPERATOR = "Teletalk";
                }

            }
        }
        catch //(Exception ex)
        {
            sMsisdn = string.Empty;

        }

        //sMsisdn = "8801955279938";

        #endregion "MSISDN"

        string UAPROF_URL = Request.UserAgent;
        try
        {
            HSProfiling.Service test = new HSProfiling.Service();
            UAProfile ua = new UAProfile();
            var HSProfiling = test.HansetDetection(UAPROF_URL, ua.GetUAProfileXWap());
            HS_MANUFAC = HSProfiling.Manufacturer;
            HS_MOD = HSProfiling.Model;
            HS_DIM = HSProfiling.Dimension;
            HS_OS = HSProfiling.OS;
            UAPROF_URL = HSProfiling.UAXML;

        }
        catch
        {


        }
    }

}