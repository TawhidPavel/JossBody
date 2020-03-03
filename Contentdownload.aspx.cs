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
    DataSet dsMore = new DataSet();


    string GPURL = string.Empty;
	    string HS_MANUFAC = string.Empty;
    string APN = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    private string SOURCE_URL = string.Empty;
    string subscriberLive = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    
    
    {
		 string msisdn = ms.GetMSISDN();
        if (!msisdn.StartsWith("8801"))
        {
          //  Response.Redirect("CheckOperator.aspx");
        }
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


        #region Profiling

        if (Session["HSOS"] == null)
        {
            HS_OS ="Android";
            //pavel
            //string UAPROF_URL = oUAProfile.GetUserAgent();


            //HSProfiling.Service profile = new HSProfiling.Service();
            //var HSProfiling = profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());


            //HS_OS = HSProfiling.OS;
            //UAPROF_URL = HSProfiling.UAXML;
            //pavel

        }

        else
        {
            HS_OS = Session["HSOS"].ToString();
        }
        #endregion Profiling


        if (!isSubscribe(sMsisdn) && !sMsisdn.StartsWith("88018"))
        {
           //pavel Response.Redirect("Default.aspx");

        }
        else if (!isSubscribe(sMsisdn) && sMsisdn.StartsWith("88018"))
        {
            //pavel Response.Redirect("~/Confirmation.aspx");
        }

        if (HS_OS == "iOS")
        {
            smartphone = true;
        }
        else if (HS_OS == "Firefox")
        {
            smartphone = true;
        }
        else if (HS_OS == "Android")
        {
            smartphone = true;
        }
        else if (HS_OS == "Windows Phone")
        {
            smartphone = true;
        }
        else if (HS_OS == "Desktop")
        {
            smartphone = true;
        }
        if (smartphone)
        {

        }
        else
        {
            smartphone1.Style.Add("display", "none");
            fphone.Style.Add("display", "block");
        }

        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";




        cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
        imgMore.ImageUrl = "~/images/more.png";


        CategoryCode = Request.QueryString["CategoryCode"].ToString().Trim();
        if (CategoryCode.Equals("E564F048-1AD7-450A-BA81-47409FC58BFE") ||
            CategoryCode.Equals("7E8B1C80-EB99-402C-BE1E-00E7F7C99A3F"))
        {
            lblten.Visible = true;
            if (sMsisdn.StartsWith("88019") || sMsisdn.StartsWith("88016"))
            {
                lblten.Text = "<b>Price:</b> Tk 20(+VAT, SD and SC)";

            }
            else
            {
                lblten.Text = "<b>Price:</b> Tk 10(+VAT, SD and SC)";

            }
            lblten.ForeColor = Color.Red;

        }

        if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            imgMore.Visible = false;

        }


        if (!IsPostBack)
        {
            if (Session["endUserId"] != null)
            {
                sMsisdn = Session["endUserId"].ToString();
            }

            GpSubUnsubConfig();


            Loadcontent();
           //pavel loadAudioInfo();
            LoadRelatedvideo();
            sMobNo = ms.GetMSISDN();
            bool subs = isSubscribe(sMobNo);
            cancelSubscriptionBlink.Visible = subs;
            //   HS_MANUFAC = Session["HS_MANUFAC"].ToString();
            //HS_MOD = Session["HS_MOD"].ToString();
            //HS_DIM = Session["HS_DIM"].ToString();
            //HS_OS = Session["HS_OS"].ToString();
            //SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            //UAPROF_URL = Session["UAPROF_URL"].ToString();
            string PORTAL_N_SHORT = "JossBody/JB";
          CA.ExecuteNonQuery("EXEC [AurkoCRM].[dbo].[spInsertPortalVisitLog]'" + SOURCE_URL + "','" + "JossBody:Home" + "','" + oUAProfile.Decode(sMsisdn) + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','" + PORTAL_N_SHORT + "','" + HS_OS + "','" + Request.UserAgent + "','" + oUAProfile.GetUserIP() + "','13'", "Aurko");

        }

    }


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

       // SetSMsisdn();

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
            Response.Redirect("Default.aspx");
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


    private void loadAudioInfo()
    {
        DataSet audioInfo = null;
        if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            audioInfo = CA.GetDataSet("Exec sp_getAudionInfoBdtube '" + contentCode + "'", "WAPDB2");
        }
        else
        {
            audioInfo = CA.GetDataSet("Exec sp_getAudionInfoBdtube '" + contentCode + "'", "WAPDB");

        }

       
        if (audioInfo.Tables[0].Rows.Count > 0)
        {
            lblInfo.Text = audioInfo.Tables[0].Rows[0][0].ToString();

        }

    }

    public void Loadcontent()
    {
        string vext = string.Empty;
        try
        {
            contentType = Request.QueryString["sContentType"].ToString().Trim();
            contentCode = Request.QueryString["content_code"].ToString().Trim();
            CategoryCode = Request.QueryString["CategoryCode"].ToString().Trim();
            try
            {
                physicalfilename = Request.QueryString["ContentTitle"].ToString().Trim();
            }
            catch
            {
                physicalfilename = Request.QueryString["ContentTitle"].ToString().Trim();
               //pavel physicalfilename = Request.QueryString["sPhysicalFileName"].ToString().Trim();
            }

            previewImage = Request.QueryString["sposter"].ToString().Trim();
            lbltitlename.Text = physicalfilename.Replace("_", " ");
            lblDuration.Text = Request.QueryString["audioDuration"].ToString();
           //p lblLikeCount.Text = "10";// Request.QueryString["totalLike"].ToString();
            lblInfo.Text = Request.QueryString["ContentTitle"].ToString();//Request.QueryString["audioInfo"].ToString();
          //  lblGenre.Text = Request.QueryString["genre"].ToString();
            physicalfilename = Request.QueryString["sPhysicalFileName"].ToString().Trim();

        }
        catch
        {

        }
        try{
          lblView.Text = Request.QueryString["totalView"].ToString();
        }
        catch
        {
            lblView.Text = "13";
        }
        if (contentType == "FV")
        {
            if (smartphone)
            {

                if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
                {
                    vext = ".mp4";
                    //imageurl = "http://192.168.14.16/testCMS/GraphicsPreview/FullVideo/" + previewImage;
                    //videoUrl = "http://192.168.14.16/testCMS/Content/Graphics/FullVideo/D480x320/" + physicalfilename + vext;
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                }
                else
                {
                    vext = ".mp4";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://game.darungame.com/CMS/GraphicsPreview/FullVideo/" + previewImage;
                    //videoUrl = "http://game.darungame.com/CMS/Content/Graphics/FullVideo/D480x320/" + physicalfilename + vext;
                }






                
            }
            else
            {
                if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
                {
                    vext = ".flv";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://192.168.14.16/testCMS/GraphicsPreview/FullVideo/" + previewImage;
                    //videoUrl = "http://192.168.14.16/testCMS/Content/Graphics/FullVideo/D320x320/" + physicalfilename + vext;
                }
                else
                {
                    vext = ".flv";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://game.darungame.com/CMS/GraphicsPreview/FullVideo/" + previewImage;
                    //videoUrl = "http://game.darungame.com/CMS/Content/Graphics/FullVideo/D320x320/" + physicalfilename + vext;
                }


                
            }

        }
        else
        {
            if (smartphone)
            {
                if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
                {
                    vext = ".mp4";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://192.168.14.16/testCMS/GraphicsPreview/Video clips/" + previewImage;
                    //videoUrl = "http://192.168.14.16/testCMS/Content/Graphics/Video clips/D480x320/" + physicalfilename + vext;
                }
                else
                {
                    vext = ".mp4";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://202.164.213.242/CMS/GraphicsPreview/Video clips/" + previewImage;
                    //videoUrl = "http://202.164.213.242/CMS/Content/Graphics/Video clips/D480x320/" + physicalfilename + vext;
                }
             
            }
            else
            {
                if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
                {
                    vext = ".flv";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://game.darungame.com/CMS/GraphicsPreview/Video clips/" + previewImage;
                    //videoUrl = "http://game.darungame.com/CMS/Content/Graphics/Video clips/D320x320/" + physicalfilename + vext;
                }
                else
                {
                    vext = ".flv";
                    imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
                    videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
                    //imageurl = "http://202.164.213.242/CMS/GraphicsPreview/Video clips/" + previewImage;
                    //videoUrl = "http://202.164.213.242/CMS/Content/Graphics/Video clips/D320x320/" + physicalfilename + vext;
                }


               
            }

        }
        // path = "Contentdownload.aspx?content_code=" + contentCode + "&CategoryCode=" + CategoryCode + "&sPreviewUrl=" + Request.QueryString["sPreviewUrl"].ToString().Trim() + "&ContentTitle=" + Request.QueryString["ContentTitle"].ToString().Trim() + "&sContentType=" + contentType + "&sPhysicalFileName=" + physicalfilename + "&ZedID=" + Request.QueryString["ZedID"].ToString().Trim() + "&sposter=" + previewImage + "";

        //  HyperLink1.NavigateUrl = path;

        ltvideo.Text = "<div class='videocontent' style='position:relative'>" +
                             "<img src='" + imageurl + "'  />" +
                             "<div class='Icone_image'>" +
                                 "<img src='images/Watch_R.png' id='clsspan' onclick='view()' style='width:40%' align='left'/></div></div>";



        if (smartphone)
        {
            ltvideo2.Text =
                "<video id='example_video_1' width='100%' height='auto' class='video-js vjs-default-skin vjs-big-play-centered' controls preload='none' poster='" +
                imageurl + "'  data-setup='{}'> <source src='" + videoUrl + "' type='video/mp4' /></video>";

        }
        else
        {
            ltvideo2.Text =
               "<object width='100%' height='200'>" +
                                                "<param value='Jscript/flayr.swf?movie=" + videoUrl + "&color_background=efefef&name=&controls=false&autoplay=false&buffer=false&preview=" + imageurl + "&click_counter=' name='movie'>" +
                                                "<param value='true' name='allowfullscreen'>" +
                                                "<param value='opaque' name='wmode'>" +
                                                "<param value='always' name='allowscriptaccess'>" +
                                                "<embed id='showreel' width='100%' allowscriptaccess='always' wmode='opaque' allowfullscreen='true' type='application/x-shockwave-flash' src='Jscript/flayr.swf?movie=" + videoUrl + "&color_background=efefef&name=&controls=true&autoplay=false&buffer=false&preview=" + imageurl + "&click_counter='>" +
                                                "</object>";
        }

        //ltvideo.Text = "<video id='example_video_1' width='100%' height='auto' class='video-js vjs-default-skin vjs-big-play-centered' controls preload='none' poster='" + imageurl + "'  data-setup='{}'> <source src='" + videoUrl + "' type='video/mp4' /></video>";
    }

    public string GetContentid()
    {
        return Request.QueryString["content_code"].ToString().Trim();
    }
    public string GetSmaster()
    {
        return Request.QueryString["sMasterCat"].ToString().Trim();
    }
    public string GetContentType()
    {
        return Request.QueryString["sContentType"].ToString().Trim();
    }

    public string GetZedId()
    {
        return Request.QueryString["ZedID"].ToString().Trim();
    }
    public string GetContentTitle()
    {
        return Request.QueryString["ContentTitle"].ToString().Trim();
    }

    public string GetCategoryCode()
    {
        return Request.QueryString["CategoryCode"].ToString().Trim();
    }

    public string GetMsisdn()
    {
        return sMobNo;
    }
    public void LoadRelatedvideo()
    {

        if ((Request.QueryString["CategoryCode"].ToString() == "01A332B2-A207-44B9-9D3C-F85A1563571A") || (Request.QueryString["CategoryCode"].ToString() == "873E3EA9-3A28-484B-B74B-68C107DDD800"))
        {
            if (Session["id"] == null)
            {
                ds = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + CategoryCode + "','" + physicalfilename + "'",
                   "WapPortal");
               // ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_Related_Fitness '" + CategoryCode + "','" + physicalfilename + "'", "WAPDB2");
            }

            else
            {
                ds = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + CategoryCode + "','" + physicalfilename + "','" + Session["id"] + "'",
                   "WapPortal");
               // ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_Related_Fitness '" + CategoryCode + "','" + physicalfilename + "','" + Session["id"] + "'", "WAPDB2");
            }
        }
        else
        {
            if (Session["id"] == null)
            {
                ds = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + CategoryCode + "','" + physicalfilename + "'",
                   "WapPortal");
              //  ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_Related_Fitness '" + CategoryCode + "','" + physicalfilename + "'", "WAPDB");
            }

            else
            {
                ds = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + CategoryCode + "','" + physicalfilename + "','" + Session["id"] + "'",
                   "WapPortal");
               // ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_Related_Fitness '" + CategoryCode + "','" + physicalfilename + "','" + Session["id"] + "'", "WAPDB");
            }
        }

        







        //lblDuration.Text = Request.QueryString["audioDuration"].ToString();
        //lblInfo.Text = Request.QueryString["audioInfo"].ToString();
        dataListRelatedvideo.DataSource = ds;
        dataListRelatedvideo.DataBind();
    }


    public bool isSubscribe(string MSISDN)
    {
        return true;
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = CA.GetDataSet("EXEC FitnessPortal.dbo.[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


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


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ds = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + CategoryCode + "','" + physicalfilename + "','" + 10000 + "'",
                  "WapPortal");

       //pavel ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_Related_Fitness '" + CategoryCode + "','" + physicalfilename + "','" + 10000 + "'", "WAPDB");
        Session["TotalForMore"] = ds.Tables[0].Rows.Count;
        if (Session["id"] == null)
        {
            Session["id"] = 8;
        }
        else
        {
            Session["id"] = (Convert.ToInt32(Session["id"]) + 4);
        }
        int number = Convert.ToInt32(Session["id"]);

        dsMore = CA.GetDataSet("Exec [Sp_Related_videoboxUp] '" + Request.QueryString["CategoryCode"].ToString().Trim() + "','" + Request.QueryString["sPhysicalFileName"].ToString().Trim() + "','" + Session["id"] + "'", "WapPortal");

        int morecount = dsMore.Tables[0].Rows.Count;
        if (Convert.ToInt32(Session["TotalForMore"]) == (morecount+1))
        {
            imgMore.Visible = false;
        }

        dataListRelatedvideo.DataSource = ds;
        dataListRelatedvideo.DataBind();
    }
    protected void lbkbtnCancelSubscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelSubscription.aspx");
    }
    protected void imgwatch_Click(object sender, ImageClickEventArgs e)
    {
        string vext = string.Empty;
        try
        {
            contentType = Request.QueryString["sContentType"].ToString().Trim();
            contentCode = Request.QueryString["content_code"].ToString().Trim();
            CategoryCode = Request.QueryString["CategoryCode"].ToString().Trim();
            physicalfilename = Request.QueryString["sPhysicalFileName"].ToString().Trim();
            previewImage = Request.QueryString["sposter"].ToString().Trim();
            lbltitlename.Text = physicalfilename.Replace("_", " ");
        }
        catch
        {

        }
        if (contentType == "FV")
        {
            vext = ".mp4";
            imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
            videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
            //imageurl = "http://game.darungame.com/CMS/GraphicsPreview/FullVideo/" + previewImage;
            //videoUrl = "http://game.darungame.com/CMS/Content/Graphics/FullVideo/D480x320/" + physicalfilename + vext;
        }
        else
        {
            vext = ".mp4";
            imageurl = "http://182.160.119.238/CMS/Assets/Images/" + previewImage;
            videoUrl = "http://182.160.119.238/CMS/Assets/video/" + physicalfilename;
            //imageurl = "http://game.darungame.com/CMS/GraphicsPreview/Video clips/" + previewImage;
            //videoUrl = "http://game.darungame.com/CMS/Content/Graphics/Video clips/D480x320/" + physicalfilename + vext;
        }

        ltvideo.Text = "<video id='example_video_1' width='100%' height='auto' class='video-js vjs-default-skin vjs-big-play-centered' controls preload='none' poster='" + imageurl + "'  data-setup='{}'> <source src='" + videoUrl + "' type='video/mp4' /></video>";





        ClientScript.RegisterStartupScript(GetType(), "hwa", "jsplay();", true);
    }

}