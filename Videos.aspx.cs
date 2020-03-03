using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Videos : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    DataSet dscount = new DataSet();
    string Catid = String.Empty;


    string GPURL = string.Empty;
	string SOURCE_URL = String.Empty;
    string HS_MANUFAC = String.Empty;
    string HS_MOD = String.Empty;
    string HS_DIM = String.Empty;
    string HS_OS = String.Empty;
    string subscriberLive = string.Empty;



    protected void Page_Load(object sender, EventArgs e)
    
    {
        #region "MSISDN"
        if (Session["MSISDN"] == null)
        {
            try
            {
                if (string.IsNullOrEmpty(oUAProfile.GetMSISDN()) || oUAProfile.GetMSISDN().StartsWith("Error"))
                {
                    throw new Exception();
                }
                else
                {
                    sMsisdn = oUAProfile.GetMSISDN();

                }
            }
            catch //(Exception ex)
            {
                sMsisdn = string.Empty;

            }
        }
        else
        {
            sMsisdn = Session["MSISDN"].ToString();
        }



        #endregion "MSISDN"
        //if (sMsisdn.StartsWith("88018"))
        //{
        //    Response.Redirect("Restricted.aspx");
        //}

        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";

        cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
        if (!isSubscribe(sMsisdn))
        {
            if (sMsisdn.StartsWith("88018"))
            {
              //pavel  Response.Redirect("Confirmation.aspx");
            }
            else
            {
              //pavel  Response.Redirect("Default.aspx");

            }
        }

        if (!IsPostBack)
        {
            if (Session["endUserId"] != null)
            {
                sMsisdn = Session["endUserId"].ToString();
            }

            GpSubUnsubConfig();
            //HS_MANUFAC = Session["HS_MANUFAC"].ToString();
            //HS_MOD = Session["HS_MOD"].ToString();
            //HS_DIM = Session["HS_DIM"].ToString();
            //HS_OS = Session["HS_OS"].ToString();
            SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            
            string PORTAL_N_SHORT = "JossBody/JD";
         //pavel   CA.ExecuteNonQuery("EXEC [AurkoCRM].[dbo].[spInsertPortalVisitLog]'" + SOURCE_URL + "','" + "JossBody:Home" + "','" + oUAProfile.Decode(sMsisdn) + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','','" + PORTAL_N_SHORT + "','" + HS_OS + "','" + Request.UserAgent + "','" + oUAProfile.GetUserIP() + "','13'", "Aurko");

            try
            {
                Catid = Request.QueryString["cid"].ToString();
                HeaderText.Text = "";
                if (Catid == "DB3FED39-4577-4268-9FA0-CD6C967ED512")//"447DC46C-3D03-48E5-9D9D-58744C89DBA3")
                {
                    HeaderText.Text = "হেলদি রেসিপি ভিডিও";
                }
                else if (Catid == "CDCB34D0-363C-4281-AFE4-AE289138179D")//"991CE47D-458A-41BC-91AF-B59A6BB711EF")
                {
                    HeaderText.Text = "সেলিব্রিটি ওয়ার্ক আউট ভিডিও";
                }
                else if (Catid == "B4955166-7C8B-4E0E-81DF-75A2FCCA6187")//"0BDA01AD-F846-4800-B34C-ADFE473D42FB")
                {
                    HeaderText.Text = "ডেইলি ইয়োগা প্রাকটিস  ভিডিও";
                }
                else if (Catid == "7BA286C1-81B8-4267-BF0D-D6057CDC3CFE")
                {
                    HeaderText.Text = "ওয়েট লস এক্সারসাইজ ভিডিও ";
                }
                else if (Catid == "D8958FA5-DFA9-40F0-B831-92771E5CA3F8")
                {
                    HeaderText.Text = "হোম রেমেডি চ্যানেল  ভিডিও";
                }
                else if (Catid =="60579B0C-259E-435A-A227-BF2E546DDCFE") //"01A332B2-A207-44B9-9D3C-F85A1563571A")
                {
                    HeaderText.Text = "ওয়ার্ক আউট মিউজিক ভিডিও";
                }
                else if (Catid == "B6392C5F-5F5B-41BC-AC82-49CDA4169B11")//"873E3EA9-3A28-484B-B74B-68C107DDD800")
                {
                    HeaderText.Text = "গ্ল্যামারাস ফিটনেস ভিডিও";
                }
                else if (Catid == "A49ACD7E-010D-4937-9A74-AB9E8A9B36B7")
                {
                    HeaderText.Text = "এক্সক্লোসিভ ভিডিও ";
                }
            }
            catch
            {

            }
            newvideo(Catid);
        }

    }


    //========================ADDED=======================================================

    //==============================ADDED=====================================


    private void GpSubUnsubConfig()
    {


        //original===========================================
        string ip = oUAProfile.GetUserIP();
        //string ip = "119.30.39.251";
        //original===========================================

        
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
                Response.Redirect("~/ErrorMessage.aspx");
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


    public bool isSubscribe(string MSISDN)
    {
        return true;
        string subStatus = String.Empty;
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
    public void newvideo(string catid)
    {

        if ((catid == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (catid == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            ds = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + catid + "', 6", "WapPortal");
            dataListMostLiked.DataSource = ds;
            dataListMostLiked.DataBind();
            dscount = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + 25000 + "", "WapPortal");
        }
        else
        {
            ds = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + catid + "', 6", "WapPortal");
            dataListMostLiked.DataSource = ds;
            dataListMostLiked.DataBind();
            dscount = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + 25000 + "", "WapPortal");
        }
        
        if (dscount != null || ds != null)
        {
            if (ds.Tables[0].Rows.Count == dscount.Tables[0].Rows.Count)
            {
                imgButtonMore.Visible = false;
            }
        }
        else
        {
            imgButtonMore.Visible = false;
        }
      
        // btnbanglamovie.Visible = true;
    }

    protected void btnLikeMore_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Catid = Request.QueryString["cid"].ToString();
        }
        catch
        {

        }

        if ((Catid == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Catid == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            dscount = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + 25000 + "", "WapPortal");
        }
        else
        {
            dscount = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + 25000 + "", "WapPortal");
        }
        

        if (Session["mostLike"] == null)
        {
            Session["mostLike"] = 8;
        }
        else
        {
            Session["mostLike"] = (Convert.ToInt32(Session["mostLike"]) + 4);
        }

        if ((Catid == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Catid == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            ds = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + Session["mostLike"] + "", "WapPortal");
        }
        else
        {
            ds = CA.GetDataSet("Exec [WapPortal].dbo.[Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + Catid + "', " + Session["mostLike"] + "", "WapPortal");
        }
        
        //dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;

        if (videocount == morecount)
        {
            imgButtonMore.Visible = false;
        }

        dataListMostLiked.DataSource = ds;
        dataListMostLiked.DataBind();

    }
}