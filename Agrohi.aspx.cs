using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SDPROBI;
using UAprofileFinder;


public partial class Agrohi : System.Web.UI.Page
{
    CDA db = new CDA();
    private bool ag = false;
    MSISDNTrack ms = new MSISDNTrack();
    UAProfile oUAProfile = new UAProfile();
    string SOURCE_URL = String.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string subStatus = string.Empty;
    string HS_MANUFAC = String.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        Image3.ImageUrl = "~/Images/baaad.jpg";

        string UAPROF_URL = oUAProfile.GetUserAgent();
        try
        {
            SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            HSProfiling.Service Profile = new HSProfiling.Service();
            var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

            HS_MANUFAC = HSProfiling.Manufacturer;
            HS_MOD = HSProfiling.Model;
            HS_DIM = HSProfiling.Dimension;
            HS_OS = HSProfiling.OS;
            UAPROF_URL = HSProfiling.UAXML;
        }
        catch { }
    }

    protected void btnAdd_OnClick(object sender, ImageClickEventArgs e)
    {
      
        string number = ms.GetMSISDN();
        string flag = "y";
        if (flag == "y")
        {
            DataSet dsWord = db.GetDataSet("EXEC [FitnessPortal].[dbo].[sp_getHistory_AgrohiCheck] '" + number + "'",
                "WAPDB");
            string check = dsWord.Tables[0].Rows[0]["Content_Title"].ToString();
            if (check == "Renew")
            {
                ag = true;
            }
            else
            {
                ag = false;
            }
            if (!ag)
            {
                string ChargingReply = CGW(number);

                if (ChargingReply == "success")
                {
                    string MSG = String.Empty;
                    if (number.StartsWith("88019"))
                    {
                        MSG =
                            "You have successfully charged Tk.2.44 for next 5 videos. To cancel SMS STOP FC to 6624. Help: 01992303765";
                    }
                    else if (number.StartsWith("88015"))
                    {
                        MSG =
                            "You have successfully charged Tk.2.44 for next 5 videos. To cancel SMS STOP FC to 6624. Help: 01534524714";
                    }
                    else if (number.StartsWith("88016"))
                    {
                        MSG =
                            "You have successfully charged Tk.2.44 for next 5 videos. To cancel SMS STOP FC to 6624. Help: 01674985965";
                    }
                    else if (number.StartsWith("88018"))
                    {
                        MSG =
                            "You have successfully charged Tk.2(+VAT+SD+SC) for next 5 videos . Help: 8801814426426";
                    }
                    //ag = true;
                    db.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + number + "','" + MSG + "'", "WAPDB");
                    db.ExecuteNonQuery(
                        "Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + number +
                        "','Renew','Renew','Renew','Renew','Renew','Renew','" + HS_MANUFAC + "','" + HS_MOD + "','" +
                        HS_DIM + "','" + HS_OS + "','','Renew','','1','194','2.44','1'", "WAPDB");
                    //string MSG = "Welcome to BDTube service. Visit http://bdtube.mobi to watch latest and exclusive videos. Cost:TK.2 daily. SMS STOP BDTUBE to 6624 to cancel.";

                    DataSet ds =
                        db.GetDataSet("Exec FitnessPortal.dbo.[sp_ViewCountByMsisdn] '" + number + "','" + 1 + "'",
                            "WAPDB");
                    Response.Redirect("Default.aspx");

                }
                else
                {
                    Response.Write("error");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");

            }
        }
    }
    public string CGW(string MSISDN)
    {
        string replyAPI = string.Empty;
        string sDownloadRequest = string.Empty;
        string Charging = string.Empty;


        if (MSISDN.StartsWith("88019"))
        {
            /* string key = "TUBE2";
             string PortalCode_Port_VU = "EE9D65C0-A155-464C-A41F-D6FAF01D4B88";
             string ContentCode = "subscription";
             string PortalCategoryCode = "";


             BLSDP.BLSDP_CGW tbCGW = new BLSDP.BLSDP_CGW();

             try
             {
                 sDownloadRequest = tbCGW.ChargingProcess(MSISDN, key, PortalCode_Port_VU, ContentCode, PortalCategoryCode);
             }
             catch { }

             if (sDownloadRequest.ToLower().Contains("success"))
             {
                 sDownloadRequest = "success";
             }*/

            sDownloadRequest = "success";


        }

        else if (MSISDN.StartsWith("88016"))
        {

            /* ATCGW.Service ATAPI = new ATCGW.Service();

             string ChargingReply = ATAPI.AirtelCGW_Process(MSISDN, "CZM");

             if (ChargingReply.StartsWith("SUCC"))
             {
                 sDownloadRequest = "success";
             }
             */

            sDownloadRequest = "success";

        }
        else if (MSISDN.StartsWith("88015"))
        {

            /*string key = "TUBE2";
            

            TTCGW.Service tlAPI = new TTCGW.Service();
            try
            {
                sDownloadRequest = tlAPI.TTCGW_Process(MSISDN, key, "", "", "");
            }
            catch { }

            if (sDownloadRequest.ToUpper() == "SUCCESSFUL")
            {
                sDownloadRequest = "success";
            }
            else
            {
                sDownloadRequest = "Unsuccessful Due to insufficient balance.";
            }
             */
            sDownloadRequest = "success";
        }
        else if (MSISDN.StartsWith("88018"))
        {
            //sDownloadRequest = SDP.ChargeMSISDN(sMobNo, Amount, "RobPlay", Request.QueryString["sGameCode"].ToString(), CategoryFullName);
            ////sDownloadRequest = "<?xml version";
            //if (sDownloadRequest.Contains("<?xml version"))
            //{
            //    sDownloadRequest = "Successful";
            //    iFree = "0";
            //}
            //else
            //{
            //    sDownloadRequest = "Download failed due to insufficient balance";
            //}
            //http://192.168.10.5/SDP_CGW/SDPCGW.asmx
            SDPROBI.SDPCGWSoapClient ks = new SDPCGWSoapClient();
            sDownloadRequest = ks.ChargeMSISDN(MSISDN, "FCSUB", "514B49B6-38D8-4304-B2AB-3799FAB3B40", "Agrohi", "Fitness Renew");
            if (sDownloadRequest.Contains("<?xml version"))
            {
                sDownloadRequest = "success";
            }
            else
            {
                sDownloadRequest = "failed";
            }



        }
        else if (MSISDN.StartsWith("88017"))
        {

            sDownloadRequest = "success";

        }

        return replyAPI = sDownloadRequest.ToLower();
    }
}