using System;
using System.Data;
using BLSDP;
using SDPROBI;
using UAprofileFinder;



public partial class ajaxDbAccess : System.Web.UI.Page
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
    private bool ag = false;
    string type = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        userInfo();
        try
        {
            number = ms.GetMSISDN();
        }
        catch { }

        option = Request.QueryString["op"];

        if (option == "setLike")
        {
            string flag = Request.QueryString["flag"];
            string catid = Request.QueryString["categorycode"];
            
            if (flag == "y")
            {
                DataSet ds = null;
                string likecount = String.Empty;
                if ((catid == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (catid == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
                {
                     ds = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal '" + Request.QueryString["contentId"] + "','" + 2 + "'", "WAPDB2");
                }
                else
                {
                     ds = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal '" + Request.QueryString["contentId"] + "','" + 2 + "'", "WAPDB");
                }
               // DataSet ds = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal '" + Request.QueryString["contentId"] + "','" + 2 + "'", "WAPDB");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    likecount = ds.Tables[0].Rows[0][0].ToString();
                }
                Response.Write(likecount);
            }
        }


        else if (option == "setView")
        {
            string flag = Request.QueryString["flag"];
            string msisdn = Request.QueryString["msisdn"];
            string categorycode = Request.QueryString["categorycode"];
            string contentcode = Request.QueryString["contentId"];
            string sMaster = Request.QueryString["sMasterCat"];//from here

            string contetntTitle = Request.QueryString["ContentTitle"];
            string contentType = Request.QueryString["ContentType"];
            string zid = Request.QueryString["ZedID"];
            DataSet ds1 = db.GetDataSet("Exec [Sp_insert_View] '" + contentcode + "','Buddy'", "WapPortal");
            //if (categorycode.Equals("413623EB-E3BF-4494-8BB8-0302473A91A1"))
            //{
            //    type = "Zumba";
            //}
            //else if (categorycode.Equals("44EAE2BC-F85F-483E-9C8E-B76D84114C00"))
            //{
            //    type = "Yoga";
            //}
            //else if (categorycode.Equals("E0AEF450-099B-495F-B056-8AED4B95F00A"))
            //{
            //    type = "Easy Workout";
            //}
            //else if (categorycode.Equals("A2106AB1-A41B-41C4-96FC-42971B8F84C5"))
            //{
            //    type = "Fitness Secrets";
            //}
            //else
            //{
            //    type = "New";
            //}

            //if (categorycode.Equals("E564F048-1AD7-450A-BA81-47409FC58BFE") || categorycode.Equals("7E8B1C80-EB99-402C-BE1E-00E7F7C99A3F") && isSubscribe(msisdn))
            //{
            //    string PortalCode_Port_VU = "EE9D65C0-A155-464C-A41F-D6FAF01D4B88";
            //    string ContentCode = contentcode;
            //    //string PortalCategoryCode = sMasterCat;
            //    if (isSubscribe(msisdn))
            //    {
            //        string response = CGW(number, "", PortalCode_Port_VU, contentcode, "");
            //        if (response.StartsWith("su"))
            //        {
            //            Response.Write("success");
            //            if (msisdn.StartsWith("88017"))
            //            {
            //                db.ExecuteNonQuery("Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + sMsisdn + "','" + contentcode + "',N'" + contetntTitle + "','" + sMaster + "','" + contentType + "','" + zid + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + OPERATOR + "','" + categorycode + "','','1','194','12.18','0'", "WAPDB");

            //            }
            //            else
            //            {
            //                db.ExecuteNonQuery("Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + sMsisdn + "','" + contentcode + "',N'" + contetntTitle + "','" + sMaster + "','" + contentType + "','" + zid + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + OPERATOR + "','" + categorycode + "','','1','194','24.35','0'", "WAPDB");

            //            }
            //        }
            //        else
            //        {

            //            Response.Write("notSubscribe");

            //        }
            //    }
            //    else
            //    {

            //        Response.Write("notSubscribe");

            //    }



            //}
            //else
            //{
            //    string obj = String.Empty;
            //    string catid = Request.QueryString["categorycode"];
            //    if (flag == "y" && isSubscribe(msisdn))
            //    {
            //        string chargepervideo = "";
            //        DataSet ds = null;
            //        DataSet ds1 = null;
            //        if ((catid == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (catid == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
            //        {//pavel
            //             //ds =
            //             //   db.GetDataSet(
            //             //       "Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal '" + Request.QueryString["contentId"] + "','" + 1 +
            //             //       "'", "WAPDB2");
            //             //ds1 = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_ViewCountByMsisdn '" + msisdn + "'", "WAPDB2");
            //        }
            //        else
            //        {
            //            //pavel
            //             //ds =
            //             //   db.GetDataSet(
            //             //       "Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal '" + Request.QueryString["contentId"] + "','" + 1 +
            //             //       "'", "WAPDB");
            //             //ds1 = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_ViewCountByMsisdn '" + msisdn + "'", "WAPDB");

            //        }
                  
            //       // obj = ds1.Tables[0].Rows[0][0].ToString();

            //        obj= "1";
            //        if (obj == "1" || obj == "5")
            //        {
            //          //pavel  db.ExecuteNonQuery("Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + msisdn + "','" + contentcode + "',N'" + contetntTitle + "','" + type + "','" + contentType + "','" + zid + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + OPERATOR + "','" + categorycode + "','','','194','" + chargepervideo + "','1'", "WAPDB");

            //        }

            //        //#region 5 video seen msg

            //        //if (obj == "5")
            //        //{
            //        //    string MSG = null;
            //        //    if (number.StartsWith("88019"))
            //        //    {
            //        //        MSG =
            //        //            "Dear subscriber you assumed your daily free limits. You will be charge Taka 2(+VAT,SD and SC) for next five views except full movie. Help:01992303765";
            //        //    }
            //        //    else if (number.StartsWith("88015"))
            //        //    {
            //        //        MSG =
            //        //            "Dear subscriber you assumed your daily free limits. You will be charge Taka 2(+VAT,SD and SC) for next five views except full movie. Help:01534524714";
            //        //    }
            //        //    else if (number.StartsWith("88016"))
            //        //    {
            //        //        MSG =
            //        //            "Dear subscriber you assumed your daily free limits. You will be charge Taka 2(+VAT,SD and SC) for next five views except full movie. Help:01674985965";
            //        //    }
            //        //    else if (number.StartsWith("88018"))
            //        //    {
            //        //        MSG =
            //        //            "Dear subscriber you assumed your daily free limits. You will be charge Taka 2(+VAT,SD and SC) for next five views . Help:8801814426426";
            //        //    }
            //        //    db.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + number + "','" + MSG + "'", "WAPDB");
            //        //}

            //        //#endregion  5 video seen msg


            //        Response.Write("1");

            //    }
            //    else
            //    {
            //         Response.Write("1");
            //    }
            //}

        }

        else if (option == "setFav")
        {
            string flag = Request.QueryString["flag"];
            string msisdn = Request.QueryString["msisdn"];

            if (flag == "y")
            {

                DataSet ds = db.GetDataSet("Exec [FitnessPortal].[dbo].sp_UpdateLikeCountByContentFitnessPortal  '" + Request.QueryString["contentId"] + "','" + 3 + "','" + msisdn + "'", "WAPDB");
                Response.Write("s");

            }
        }
        else if (option == "agrohi")
        {

            string flag = Request.QueryString["flag"];
            string number = Request.QueryString["msisdn"];
            string HS_MANUFAC = Request.QueryString["manu"];
            string HS_MOD = Request.QueryString["mod"];
            string HS_DIM = Request.QueryString["dim"];
            string HS_OS = Request.QueryString["os"];

            if (flag == "y")
            {
                DataSet dsWord = db.GetDataSet("EXEC [FitnessPortal].[dbo].[sp_getHistory_AgrohiCheck] '" + number + "'", "WAPDB");
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
                        db.ExecuteNonQuery("Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + number + "','Renew','Renew','Renew','Renew','Renew','Renew','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','','Renew','','1','194','2.44','1'", "WAPDB");
                        //string MSG = "Welcome to BDTube service. Visit http://bdtube.mobi to watch latest and exclusive videos. Cost:TK.2 daily. SMS STOP BDTUBE to 6624 to cancel.";

                        DataSet ds = db.GetDataSet("Exec FitnessPortal.dbo.[sp_ViewCountByMsisdn] '" + number + "','" + 1 + "'", "WAPDB");
                        Response.Write(ds);

                    }
                    else
                    {
                        Response.Write("error");
                    }
                }
                else
                {
                    Response.Write("error");

                }



            }

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
            HS_OS = "Android";
            //HSProfiling.Service test = new HSProfiling.Service();
            //UAProfile ua = new UAProfile();
            //var HSProfiling = test.HansetDetection(UAPROF_URL, ua.GetUAProfileXWap());
            //HS_MANUFAC = HSProfiling.Manufacturer;
            //HS_MOD = HSProfiling.Model;
            //HS_DIM = HSProfiling.Dimension;
            //HS_OS = HSProfiling.OS;
            //UAPROF_URL = HSProfiling.UAXML;

        }
        catch
        {


        }
    }


    public string CGW12(string MSISDN)
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
        if (MSISDN.StartsWith("88018"))
        {
            // sDownloadRequest = "success";
        }
        if (MSISDN.StartsWith("88016"))
        {

            /*
            try
            {
                ATASE.Service objATASAE = new ATASE.Service();
                //comment
                objATASAE.ASESubscribe(MSISDN, "vubdtube", "Addition");
            }
            catch
            {
            }
            */

            sDownloadRequest = "success";


        }
        if (MSISDN.StartsWith("88015"))
        {
            /*
            string key = "TUBE2";

            TTCGW.Service tlAPI = new TTCGW.Service();
            try
            {
               
                sDownloadRequest = tlAPI.TTCGW_Process(MSISDN, key,"","","");
               
            }
            catch { }

            if (sDownloadRequest.ToUpper() == "SUCCESSFUL")
            {
                sDownloadRequest = "success";
            }
            else
            {
                sDownloadRequest = "Unsuccessful Due to insufficient balance.";
            }*/

            sDownloadRequest = "success";
        }


        return replyAPI = sDownloadRequest.ToLower();
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




    public bool isSubscribe(string MSISDN)
    {
        return true;
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = db.GetDataSet("EXEC [FitnessPortal].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


        if (dsExt != null)
        {
            subStatus = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        if (subStatus == "Active")
        {
            return true;
        }
        else
        {
            return true;
        }

    }

    public string CGW(string MSISDN, string ContentType, string PortalCode_Port_VU, string ContentCode, string PortalCategoryCode)
    {
        //(string MSISDN, string key, string PortalCode_Port_VU, string ContentCode, string PortalCategoryCode)
        string replyAPI = string.Empty;
        string sDownloadRequest = string.Empty;
        string key = string.Empty;

        if (MSISDN.StartsWith("88019"))
        {

            /* key = "DC5";


             BLSDP.BLSDP_CGW tbCGW = new BLSDP_CGW();

             try
             {

                 sDownloadRequest = tbCGW.ChargingProcess(MSISDN, key, PortalCode_Port_VU, ContentCode, PortalCategoryCode);
             }
             catch { }


             if (sDownloadRequest.ToLower().Contains("success"))
             {
                  string MSG = "You have successfully charged Taka 20 (+VAT, SD and SC) for viewed this video. Visit http://bdtube.mobi for more videos. To cancel SMS STOP BDTUBE to 6624.";
                  db.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + MSISDN + "','" + MSG + "'", "WAPDB");
             }




             if (sDownloadRequest.ToLower().Contains("success"))
             {
                 sDownloadRequest = "success";
             }*/
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
            sDownloadRequest = "success";



        }
        else if (MSISDN.StartsWith("88016"))
        {


            /*  ATCGW.Service ATAPI = new ATCGW.Service();

              string ChargingReply = ATAPI.AirtelCGW_Process(MSISDN, "BDTUBE20");

              if (ChargingReply.StartsWith("SUCC"))
              {
                  sDownloadRequest = "success";
              }
              */
            sDownloadRequest = "success";
        }

        else if (MSISDN.StartsWith("88015"))
        {



            /* key = "TUBEVD";

             TTCGW.Service tlAPI = new TTCGW.Service();
             try
             {

                 sDownloadRequest = tlAPI.TTCGW_Process(MSISDN, key, "", "", "");

             }
             catch { }
             */

            sDownloadRequest = "success";


            if (sDownloadRequest.ToUpper() == "SUCCESSFUL")
            {
                string MSG = "You have successfully charged Tk.10 for viewed this video. Visit http://bdtube.mobi for more videos. To cancel SMS STOP BDTUBE to 6624.";
                //by me
                // db.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + MSISDN + "','" + MSG + "'", "WAPDB");
            }


            if (sDownloadRequest.ToUpper() == "SUCCESSFUL")
            {
                sDownloadRequest = "success";
            }
            else
            {
                sDownloadRequest = "Unsuccessful Due to insufficient balance.";
            }

        }
        else if (MSISDN.StartsWith("88017"))
        {

            sDownloadRequest = "success";


        }



        return replyAPI = sDownloadRequest.ToLower();
    }


}