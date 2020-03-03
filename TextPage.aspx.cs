using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UAprofileFinder;

public partial class Contentdownload : System.Web.UI.Page
{
    DataSet ds = null;
    CDA CA = new CDA();
    string contentType = string.Empty;
    string contentCode = string.Empty;
    dynamic CategoryCode = string.Empty;
    string physicalfilename = string.Empty;
    string path = string.Empty;
    string imageurl = string.Empty;
    string previewImage = string.Empty;
    string videoUrl = string.Empty;
    MSISDNTrack ms = new MSISDNTrack();
    string HS_OS = String.Empty;
    string sMobNo = string.Empty;
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    bool smartphone = false;
    string subStatus = String.Empty;
    string type = String.Empty;
    string ContentID = String.Empty;
    string HS_MANUFAC = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
	DataSet dsPage = new DataSet();



    string GPURL = string.Empty;
	string SOURCE_URL = String.Empty;
    string subscriberLive = string.Empty;



    string OPERATOR = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        sMsisdn = oUAProfile.GetMSISDN();
        string msisdn = ms.GetMSISDN();
        if (!msisdn.StartsWith("8801"))
        {
           // Response.Redirect("CheckOperator.aspx");
        }
        if (!isSubscribe(sMsisdn))
        {
           //pavel Response.Redirect("Confirmation.aspx");
        }
        userInfo();

        try
        {
            type = Request.QueryString["type"].ToString();
            if (type == "5")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "ফিটনেস সেশন ";
              //pavel  dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "FitnessSession" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }
            else if (type == "1")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "হেলথি ডায়েট";
                //pavel  dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "HealthyDiet" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }
            else if (type == "6")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "সেলিব্রিটি ফিটনেস";
                //pavel dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "CelebirtyFitness" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }
            else if (type == "10")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "হোম রেমেডি";
                //pavel dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "HomeRedemy" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }
            else if (type == "12EE8772-F439-4354-AA4F-427BFA8D41A0")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "হেলথ টিপস";
                //dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "HealthTips" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }
            else if (type == "3A827B46-C8EA-4D1A-B1BE-3BFF59014168")
            {
                string UAPROF_URL = Request.UserAgent;
                txtCategory.Text = "ফুড টিপস";
                //  dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "FoodTips" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            }

            if (!isSubscribe(sMsisdn))
            {
               // Response.Redirect("Default.aspx");

            }
        }

        catch
        {
            //Response.Redirect("Default.aspx");

        }

        if (!IsPostBack)
        {
            if (Session["endUserId"] != null)
            {
                sMsisdn = Session["endUserId"].ToString();
            }

          GpSubUnsubConfig();


            if (Request.UrlReferrer != null)
            {
                btnExit.PostBackUrl = "Default.aspx";
            }

            Loadcontent();
            LoadRelatedvideo();
            sMobNo = ms.GetMSISDN();
			
            //       HS_MANUFAC = Session["HS_MANUFAC"].ToString();
            //HS_MOD = Session["HS_MOD"].ToString();
            //HS_DIM = Session["HS_DIM"].ToString();
            //HS_OS = Session["HS_OS"].ToString();
            SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;

            string PORTAL_N_SHORT = "JossBody/JD";
            //pavel CA.ExecuteNonQuery("EXEC [AurkoCRM].[dbo].[spInsertPortalVisitLog]'" + SOURCE_URL + "','" + "JossBody:Home" + "','" + oUAProfile.Decode(sMsisdn) + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','','" + PORTAL_N_SHORT + "','" + HS_OS + "','" + Request.UserAgent + "','" + oUAProfile.GetUserIP() + "','13'", "Aurko");
        }

    }


    //==============================ADDED=====================================


    private void GpSubUnsubConfig()
    {


        //original===========================================
        string ip = oUAProfile.GetUserIP();
        //string ip = "119.30.39.251";
        //original===========================================

        //string ip = "119.30.39.251";
        WebClient client = new WebClient();
        string downloadString = client.DownloadString("http://192.168.14.16/dpdpclient/api/RecognizeGPSubscribes?Ip=" + ip);

        if (!downloadString.Contains("True"))
        {
            Response.Redirect("ErrorMessage.aspx");
        }
        else
        {
            BaseCheck();
            
        }
    }

    private void SetSMsisdn()
    {
        try
        {
            sMsisdn = Request.QueryString["endUserId"].ToString();
            Session["endUserId"] = oUAProfile.Encode(sMsisdn);
        }
        catch (Exception exception)
        {
            sMsisdn = "";
        }

        string referenceCode = string.Empty;

        try
        {
            referenceCode = Request.QueryString["referenceCode"].ToString();
            Session["referenceCode"] = referenceCode;
        }
        catch (Exception exception)
        {
            referenceCode = "";
            Session["referenceCode"] = referenceCode;
        }
    }

    private void BaseCheck()
    {

        //SetSMsisdn();

        string query = @"SELECT top 1 1
  FROM[DPDP].[dbo].[tblBase]

  where ServiceId = '13' and MSISDN = '" + sMsisdn + "' and RegStatus = 1";

        DataSet dataSet = new CDA().GetDataSet(query, "DPDP");

        if (dataSet != null)
        {
            //   Response.Redirect("ErrorMessage.aspx");
        }
        else
        {
            CheckGPUser();
        }
    }


    private void CheckGPUser()
    {
        string serviceName = string.Empty;
        string SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
        string PORTAL_N_SHORT = "JossVideo/JV";
        string ContentCate = string.Empty;
        try
        {
            string contcat = Request.QueryString["cat"].ToString();
            if (contcat == "more")
            {
                ContentCate = "&cat=more";
            }
        }
        catch { }

        try
        {
            string GPBC = Request.QueryString["source"].ToString();
            if (GPBC == "GP")
            {
                SOURCE_URL = "GP";
            }
        }
        catch { }

        //STEP1:Check Subscriber Status: Y or N. Y= LIVE & N=NOT LIVE 
        subscriberLive = SubscriberStatus(sMsisdn);
        if (subscriberLive == "N" || subscriberLive == "")
        {

            //string ip = "119.30.39.250";
            string ip = oUAProfile.GetUserIP();
            //ip = "37.111.233.51";
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("http://192.168.14.16/dpdpclient/api/RecognizeGPSubscribes?Ip=" + ip);

            if (!downloadString.Contains("True"))
            {
                Response.Redirect("~/ComingSoon.aspx?sid=57");
            }



            //Response.Redirect("~/Default.aspx");

            string referenceCode = string.Empty;
            try
            {
                referenceCode = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                //      Session["referenceCode"].ToString();
            }
            catch (Exception exception)
            {
                referenceCode = "";
            }

            SendService sendService = new SendService();

            string json = new JavaScriptSerializer().Serialize(new
            {
                code = "SUB00035204569183201251"
            ,
            amount = "2"
            ,
            taxAmount = "0.55"
            ,
            description = "Joss Body"
            ,
            servicekey = "afef69c7cbbe4b55bb10d47dd5969677"
            ,
            productId = "6610"
            ,
            type = "WAP"
            ,
            title = "Subscription"
                ,
                thumbnailUrl = "http://www.jossbody.com"
                ,
                successUrl = "http://www.jossbody.com",
                failureUrl = "http://www.jossbody.com",
                cancelUrl = "http://www.jossbody.com"
                ,
                notifyUrl = "http://funkhobor.com/NotifyUrl.aspx"
                ,
                downloadUrl = "http://www.jossbody.com"
                ,
                referenceCode = referenceCode

            });


            ApiResult apiResult = sendService.Send("http://192.168.14.16/DPDPClient/api/GetChargingURL", json);

            string res = apiResult.Result.Replace("\"", "");

            if (!string.IsNullOrWhiteSpace(res))
            {
                Response.Redirect(res);
            }


        }
    }
    private string SubscriberStatus(string MSISDN)
    {
        MSISDN = oUAProfile.Decode(MSISDN);
        string Status = string.Empty;
        //STEP2: Subscriber Exist or not
        object IsUser = CA.getSingleValue("Select RegDate from [DPDP].[dbo].[tblBase] where MSISDN= '" + MSISDN + "' AND RegStatus!=0 AND serviceID=13", "DPDP");
        if (IsUser != null) //If Subscriber Exist
        {
            DateTime LastChg_dt = Convert.ToDateTime(IsUser);
            DateTime CurrentDate = System.DateTime.Now.Date;
            DateTime NextDate = CurrentDate.AddHours(-24);
            if (LastChg_dt.Date < NextDate) //Chk 48 Hr Charging Status
            {
                //IF:NO CHARGING STAUS FOUND:Charging Here Then Display the Content
                //string ReplyCGW = CGW(MSISDN); //STEP3: CHARGING; MACHANISM
                string ReplyCGW = "SUCCESSFUL"; //STEP3: CHARGING; MACHANISM
                if (ReplyCGW == "SUCCESSFUL")
                {
                    Status = "Y";
                    if (sMsisdn.StartsWith("88017"))
                    {
                        CA.ExecuteNonQuery("EXEC [Partner_API].[dbo].[spProcessRequestOnlineAdvertisement] '" + sMsisdn + "','SB'", "WAPDB");
                    }
                    else
                    {
                        CA.ExecuteNonQuery("EXEC Sp_UPDATE_SUBSCRIBER_STATUS_BY_ONLINE_CHARGING '" + MSISDN + "'", "SBDB");
                    }
                }
                else
                {
                    Status = "Y";
                    //lblMsg.ForeColor = Color.Red;
                    //lblMsg.Text = "Your registration is temporayly block.Please top up your account & visit again.";
                }

            }
            else //SUBSCRIPTION CHARGING OCCURED & SUBSCRIBER LIVE FOR GET CONTENT
            {

                Status = "Y";
            }
        }
        else //FOR NEW SUBSCRIBER
        {
            if (MSISDN.StartsWith("88017"))
            {
                Status = "Y";
            }


            try
            {
                string GPBC = Request.QueryString["source"].ToString();
                if (GPBC == "GP")
                {
                    GPURL = "&source=GP";
                }
            }
            catch { }



            //string ReplyCGW = CGW(MSISDN);
            //if (ReplyCGW == "SUCCESSFUL")
            //{
            //    Status = "Y";

            //    oCDA.ExecuteNonQuery("EXEC ShaboxBuddy.dbo.spInsertSubscriberBuddy 1"+",'"+sMsisdn+"','"+HS_MANUFAC+"','"+HS_MOD+"','"+ "WAP"+"','1','"+"1"+"','"+System.DateTime.Now+"'", "SBDB");
            //}
            //else // ENTRY SUBSCRIBER WHITHOUT CHARGING BUT WILL TRY TO CHARGE NEXT DAY / NEXT VISIT
            //{
            //    Status = "N";
            //    oCDA.ExecuteNonQuery("EXEC ShaboxBuddy.dbo.spInsertSubscriberBuddy 1" + ",'" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + "WAP" + "','-1','" + "0" + "','" + System.DateTime.Now + "'", "SBDB");
            //}
            // Charging & Insert Into Subscriber Table.
        }

        return Status;
    }

    //===================================ADDED==============================================

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
            //pavel
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



    public void Loadcontent()
    {
        string CategoryName = String.Empty;
        string contentid = String.Empty;
        string texttype = String.Empty;
        try
        {
            contentid = Request.QueryString["contentid"];

        }
        catch
        {
            contentid = "";
        }
        if (contentid == null)
        {
            contentid = "";

        }

        DataSet ds = CA.GetDataSet("Exec [Sp_getTextContent] '" + type + "','" + contentid + "'", "WapPortal");
        if (ds != null)
        {
            string imgLoad = String.Empty;
            main.Visible = true;
            string img = ds.Tables[0].Rows[0]["ContentImage"].ToString();
            if (img == "")
            {
                imgLoad = "none";
            }
            else
            {
                imageurl =
               "http://182.160.119.238/CMS/Assets/images/200/" + img;
                imgLoad = "block";

            }

            try
            {
                ContentID = Request.QueryString["cid"].ToString();
            }
            catch
            {
                ContentID = ds.Tables[0].Rows[0]["cid"].ToString();

            }
            textFull.Text = ds.Tables[0].Rows[0]["Content"].ToString();
            txtType.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            lblLastTime.Text = ds.Tables[0].Rows[0]["ContentDate"].ToString();
            texttype = ds.Tables[0].Rows[0]["Title"].ToString();
            ltvideo.Text = "<div class='videocontent' style='position:relative;width:100%'>" +
                           "<img src='" + imageurl + "'style='display:" + imgLoad + "'  />" +
                           "<div class='Icone_image'>" +
                           "<img src='images/Watch_R.png'  style='width:0%' align='left'/></div></div>";

        }
        else
        {
            DataSet ds1 = CA.GetDataSet("Exec [Sp_getTextContentNextpage] '" + contentid + "'", "WapPortal");
            try
            {
                CategoryName = Request.QueryString["CategoryName"].ToString();
            }
            catch
            {
                CategoryName = ds1.Tables[0].Rows[0]["CategoryName"].ToString();

            }
            lblcat.Text = CategoryName;

            string imgLoad = String.Empty;
            main.Visible = true;
            if (ds1 != null)
            {
                string img = ds1.Tables[0].Rows[0]["ContentImage"].ToString();
                if (img == "")
                {
                    imgLoad = "none";
                }
                else
                {
                    imageurl =
                        "http://182.160.119.238/CMS/Assets/images/200/" + img;
                    imgLoad = "block";

                }

                ContentID = ds1.Tables[0].Rows[0]["ContentId"].ToString();


                textFull.Text = ds1.Tables[0].Rows[0]["Content"].ToString();
                lblLastTime.Text = ds1.Tables[0].Rows[0]["ContentDate"].ToString();
                txtType.Text = ds1.Tables[0].Rows[0]["Title"].ToString();
                texttype = ds1.Tables[0].Rows[0]["Title"].ToString();

                ltvideo.Text = "<div class='videocontent' style='position:relative;width:100%'>" +
                               "<img src='" + imageurl + "'style='display:" + imgLoad + "'  />" +
                               "<div class='Icone_image'>" +
                               "<img src='images/Watch_R.png' style='width:0%' align='left'/></div></div>";
            }

        }



        //CA.ExecuteNonQuery("Exec [FitnessPortal].[dbo].[sp_SetPortalSuccess] '" + sMsisdn + "','" + "Text" + "',N'" + texttype + "','" + "" + "','" + "Text" + "','" + "" + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + OPERATOR + "','" + "" + "','','','194','" + "" + "','1'", "WAPDB");







    }

    public void LoadRelatedvideo()
    {
        ds = Session["id"] == null ?
            CA.GetDataSet("Exec [Sp_getTextContentRelated] '" + type + "','" + ContentID + "'", "WapPortal")
            :
            CA.GetDataSet("Exec [Sp_getTextContentRelated] '" + type + "','" + ContentID + "','" +
            Session["id"] + "'", "WapPortal");

        if (ds != null)
        {
            preVideo.Visible = true;
        }
        dataListRelatedvideo.DataSource = ds;
        dataListRelatedvideo.DataBind();
    }


    public bool isSubscribe(string MSISDN)
    {
        return true;
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        // dsExt = CA.GetDataSet("EXEC [Partner_Basket].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");
        dsExt = CA.GetDataSet("EXEC [FitnessPortal].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");



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


    protected void btnHome_OnClick(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


}