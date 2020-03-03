using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;
using HSProfiling;



public partial class Home : System.Web.UI.Page
{
    CDA CA = new CDA();
    MSISDNTrack ms = new MSISDNTrack();
    UAProfile oUAProfile = new UAProfile();
    string sMobNo = string.Empty;
    string sPath = string.Empty;
    string sMsisdn = string.Empty;
    string HS_MANUFAC = string.Empty;
    string APN = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string subStatus = string.Empty;
    string subSmsisdn = string.Empty;
    string chk = string.Empty;
    string addC = String.Empty;
    string nisC = String.Empty;
    string SOURCE_URL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
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
                    subSmsisdn = sMsisdn.Substring(0, 5);
                    ViewState["msisdn"] = sMsisdn;
                }
            }
            catch //(Exception ex)
            {
                sMsisdn = string.Empty;
                subSmsisdn = string.Empty;
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
                Session["HSOS"] = HS_OS;

            }
            catch
            {


            }
            string scriptForBl = @" $(document).ready(function() {

           $('.robititle').css('background-color','#F16521');
           
             
              });";

            string scriptForTT = @" $(document).ready(function() {

            $('.robititle').css('background-color','#71BD44');         
           
              
});";



            if (sMsisdn.StartsWith("88015"))
            {
                cssTemplate.Attributes.Add("href", "~/Css/StyleSheetTT.css");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForTT, true);
            }

            else if (sMsisdn.StartsWith("88019"))
            {
                cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
                if (isSubscribe(sMsisdn))
                {
                    cancelSubscriptionBlink.Visible = true;
                }

            }
            else if (sMsisdn.StartsWith("88016"))
            {
                cssTemplate.Attributes.Add("href", "~/Css/StyleSheet.css");
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

            }

            else if (sMsisdn.StartsWith("88018"))
            {
                Response.Redirect("Restricted.aspx");
            }
            else
            {
                cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            }






            string key = String.Empty;
            if (Request.Params["key"] != null)
            {
                key = Request.Params["key"].ToString();

                Session["KEY"] = key;
            }

            string flagAccess = "0";
            if (Session["flagAccess"] != null)
            {
                flagAccess = Session["flagAccess"].ToString();
            }

            CA.ExecuteNonQuery("EXEC [Partner_Basket].[dbo].[sp_SetPortalAccess]'" + SOURCE_URL + "','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','','" + oUAProfile.GetUserIP() + "','" + HS_OS + "'", "WAPDB");

            if (!String.IsNullOrEmpty(key) && flagAccess == "0")
            {
                string accessKey = CA.getSingleValue("Exec spGET_OA_ACCESS'" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + oUAProfile.GetUserIP() + "','" + HS_OS + "'", "WAPDB").ToString();

                Session["Accesskey"] = accessKey;
                Session["flagAccess"] = "1";
            }
            Slider();
            Fullvideo();
            Shortvideo();
            Fullmovie();
            Newvideo();
            BanglaNatok();
            if (string.IsNullOrEmpty((sMsisdn)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " function  callFunction() { $('#myModal').modal('hide');$('#myModal2').modal('hide'); $('#myModal3').modal('show'); }", true);
            }
            if (!string.IsNullOrEmpty((sMsisdn)))
            {
                lblNumber.Text = sMsisdn;
                lblNumber.Visible = true;
                lblNumber2.Visible = true;
                lblNumber2.Text = sMsisdn;
            }
        }
        //Session.Clear();
        // Session.RemoveAll();
        //Session.Abandon();
    }
    public string returnMsisdn()
    {
        return sMsisdn;
    }

    public string returnMan()
    {
        return HS_MANUFAC;
    }
    public string returnMod()
    {
        return HS_MOD;
    }
    public string returnOs()
    {
        return HS_OS;
    }
    public string returnDim()
    {
        return HS_DIM;
    }

    public void Slider()
    {
        DataSet datasetslider = null;
        string slider =String.Empty;
        datasetslider = CA.GetDataSet("Sp_slider_videobox", "WAPDB");
        if (slider != null)
        {
            int i = 0;
            foreach (DataRow dr in datasetslider.Tables[0].Rows)
            {
                if (i == 0)
                {
                    slider = "<div class='item active'>" +
                       "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                         "</div>";
                    i++;
                }
                else
                {
                    slider += "<div class='item'>" +
                        "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                         "</div>";
                    i++;
                }

                



            }
            ltslider.Text = slider.ToString();
        }



    }

    public void Fullvideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:80%;'>";
        dsFullvideo = CA.GetDataSet("Sp_Fullvideo_videobox", "WAPDB");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {
                fulvideocontents += "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                         "<a href='" + dr["path"]  + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                        "<div class='Icone_image'>" +
                            "<a href='" + dr["path"] +  "'><img src='images/play-button.png' style='width:80%;box-shadow:0px 0px 0px 0px'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                         "<div class='Title'>" +
                            "<span>" + dr["ContentTile"] + "</span>" +
                         "</div>" +
                          "<div class='viewlike'>" +
                              "<div class='vieweyes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/vi.png' /></div>" +
                                "<div class='vtitle'> <span>" + dr["totalView"] + "</span>" +
                                 "</div> </div>" +
                                 "<div class='viewlikes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/lik.png' /></div>" +
                                  "<div class='vtitle'><span>" + dr["totalLike"] + "</span></div></div>" +
                          "</div></div></div></div>";




            }
            ltFullvideo.Text = fulvideocontents.ToString() + "</div></div>";
        }



    }
    public void Shortvideo()
    {
        DataSet dsShortvideo = null;
        string Shortvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:80%;'>";
        dsShortvideo = CA.GetDataSet("Sp_Shortclips_videobox", "WAPDB");
        if (dsShortvideo != null)
        {
            foreach (DataRow dr in dsShortvideo.Tables[0].Rows)
            {
                Shortvideocontents += "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                         "<a href='" + dr["path"] + "&sMasterCat=clips" + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                        "<div class='Icone_image'>" +
                            "<a href='" + dr["path"] + "&sMasterCat=clips" + "'><img src='images/play-button.png' style='width:80%;box-shadow:0px 0px 0px 0px'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                         "<div class='Title'>" +
                            "<span>" + dr["ContentTile"] + "</span>" +
                         "</div>" +
                          "<div class='viewlike'>" +
                              "<div class='vieweyes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/vi.png' /></div>" +
                                "<div class='vtitle'> <span>" + dr["totalView"] + "</span>" +
                                 "</div> </div>" +
                                 "<div class='viewlikes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/lik.png' /></div>" +
                                  "<div class='vtitle'><span>" + dr["totalLike"] + "</span></div></div>" +
                          "</div></div></div></div>";





            }
            ltshortvideo.Text = Shortvideocontents.ToString() + "</div></div>";
        }
    }
    public void Fullmovie()
    {
        DataSet dsmovie = null;
        string movievideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:80%;'>";
        dsmovie = CA.GetDataSet("Sp_Fullmovie_videobox", "WAPDB");
        if (dsmovie != null)
        {
            foreach (DataRow dr in dsmovie.Tables[0].Rows)
            {
                movievideocontents += "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                         "<a href='" + dr["path"]  + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                        "<div class='Icone_image'>" +
                            "<a href='" + dr["path"]+ "'><img src='images/play-button.png' style='width:80%;box-shadow:0px 0px 0px 0px'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                         "<div class='Title'>" +
                            "<span>" + dr["ContentTile"] + "</span>" +
                         "</div>" +
                          "<div class='viewlike'>" +
                              "<div class='vieweyes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/vi.png' /></div>" +
                                "<div class='vtitle'> <span>" + dr["totalView"] + "</span>" +
                                 "</div> </div>" +
                                 "<div class='viewlikes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/lik.png' /></div>" +
                                  "<div class='vtitle'><span>" + dr["totalLike"] + "</span></div></div>" +
                          "</div></div></div></div>";



            }
            ltmovie.Text = movievideocontents.ToString() + "</div></div>";

        }
    }


    public void BanglaNatok()
    {
        DataSet dsnatok = null;
        string movienatokcontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:80%;'>";
        //dsnatok = CA.GetDataSet("Sp_Fullmovie_videobox", "WAPDB");
        dsnatok = CA.GetDataSet("Exec Sp_FullvideoContents_videobox4 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F', " + 8 + "", "WAPDB");

        if (dsnatok != null)
        {
            foreach (DataRow dr in dsnatok.Tables[0].Rows)
            {
                movienatokcontents += "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                         "<a href='" + dr["path"] +  "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                        "<div class='Icone_image'>" +
                            "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:80%;box-shadow:0px 0px 0px 0px'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                         "<div class='Title'>" +
                            "<span>" + dr["ContentTile"] + "</span>" +
                         "</div>" +
                          "<div class='viewlike'>" +
                              "<div class='vieweyes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/vi.png' /></div>" +
                                "<div class='vtitle'> <span>" + dr["totalView"] + "</span>" +
                                 "</div> </div>" +
                                 "<div class='viewlikes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/lik.png' /></div>" +
                                  "<div class='vtitle'><span>" + dr["totalLike"] + "</span></div></div>" +
                          "</div></div></div></div>";


            }
            ltNatok.Text = movienatokcontents.ToString() + "</div></div>";

        }
    }
    public void Newvideo()
    {
        DataSet dsnewvideo = null;
        string newvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:80%;'>";
        dsnewvideo = CA.GetDataSet("Sp_Newvideo_videobox", "WAPDB");
        if (dsnewvideo != null)
        {


            foreach (DataRow dr in dsnewvideo.Tables[0].Rows)
            {
                newvideocontents += "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                         "<a href='" + dr["path"] +  "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                        "<div class='Icone_image'>" +
                            "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:80%;box-shadow:0px 0px 0px 0px'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                         "<div class='Title'>" +
                            "<span>" + dr["ContentTile"] + "</span>" +
                         "</div>" +
                          "<div class='viewlike'>" +
                              "<div class='vieweyes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/vi.png' /></div>" +
                                "<div class='vtitle'> <span>" + dr["totalView"] + "</span>" +
                                 "</div> </div>" +
                                 "<div class='viewlikes'>" +
                                  "<div class='viewieyeicone'>" +
                                      "<img src='images/lik.png' /></div>" +
                                  "<div class='vtitle'><span>" + dr["totalLike"] + "</span></div></div>" +
                          "</div></div></div></div>";



            }
            ltnewvideo.Text = newvideocontents.ToString() + "</div></div>";



        }
    }


    protected string GetMsisdnValue()
    {
        string number = ViewState["msisdn"] == null ? "" : ViewState["msisdn"].ToString();

        if (isSubscribe(number))
        {
            return (ViewState["msisdn"].ToString());

        }
        else if (nisC == "3")
        {
            return "10";
        }
        else if (!string.IsNullOrEmpty(number) && !isSubscribe(number) && addC == "2nd")
        {
            //here will be the logic where to navigate 
            //if user already subscribed then it will take user to the QuizPlay.aspx 
            //other wise to the page subscribe the user according to the operator

            // return "1";
            return "2";// APN but user not suscribed

        }
        else if (string.IsNullOrEmpty(number) && !isSubscribe(number) && addC == "2nd")
        {
            //here will be the logic where to navigate 
            //if user already subscribed then it will take user to the QuizPlay.aspx 
            //other wise to the page subscribe the user according to the operator

            // return "1";
            return "2";// APN but user not suscribed

        }

        else if (!string.IsNullOrEmpty(number) && !isSubscribe(number))
        {
            //here will be the logic where to navigate 
            //if user already subscribed then it will take user to the QuizPlay.aspx 
            //other wise to the page subscribe the user according to the operator

            // return "1";
            return "-1";// APN but user not suscribed

        }

        else
        {
            return "0";// Wifi user
        }


    }


    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = CA.GetDataSet("EXEC [Partner_Basket].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


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
            return false;
        }

    }

    protected void addButton_Click(object sender, ImageClickEventArgs e)
    {
        addC = "2nd";

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
            }
        }
        catch //(Exception ex)
        {
            sMsisdn = string.Empty;
        }
        #endregion "MSISDN"


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

        string AccessId = string.Empty;
        string key = string.Empty;

        if (Session["Accesskey"] != null)
        {
            AccessId = Session["Accesskey"].ToString();
        }

        if (Session["KEY"] != null)
        {
            key = Session["KEY"].ToString();

            //oCDA.ExecuteNonQuery("Exec spGET_OA_SUCCESS '" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + HS_OS + "','" + AccessId + "','" + UAPROF_URL + "',''", "WAPDB");
            CA.ExecuteNonQuery("EXEC [spGET_OA_ACCESS_SECOND_PAGE] '" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + HS_OS + "','" + AccessId + "','" + UAPROF_URL + "',''", "WAPDB");
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " function  callFunction() { $('#myModal').modal('hide');$('#myModal2').modal('show'); $('#myModal3').modal('hide'); }", true);

    }




    protected void NishchitoButton_Click(object sender, ImageClickEventArgs e)
    {
        nisC = "3";
        string number = ViewState["msisdn"] == null ? "" : ViewState["msisdn"].ToString();

        string AccessId = string.Empty;
        string key = string.Empty;
        string UAPROF_URL = oUAProfile.GetUserAgent();

        if (Session["Accesskey"] != null)
        {
            AccessId = Session["Accesskey"].ToString();
        }

        if (Session["KEY"] != null)
        {
            key = Session["KEY"].ToString();

            CA.ExecuteNonQuery("Exec spGET_OA_SUCCESS '" + SOURCE_URL + "','BDTube','" + number + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + HS_OS + "','" + AccessId + "','" + UAPROF_URL + "',''", "WAPDB");

        }

        if (!string.IsNullOrEmpty(number))
        {
            DataSet DNDMno = CA.GetDataSet("EXEC [WapPortal_CMS].dbo.spCheckDNDMno '" + number + "','BDTube','6624'",
                "WAPDB");
            string DNDMobileNo = string.Empty;
            try
            {
                DNDMobileNo = DNDMno.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch
            {

            }


            if (DNDMobileNo == "Y")
            {
                //Response.Redirect("~/ErrorMessage.aspx?type=dnd");
            }

            if (!isSubscribe(number))
            {
                string ChargingReply = string.Empty;
                ChargingReply = CGW(number);

                if (ChargingReply == "success")
                {
                    CA.ExecuteNonQuery(
                        "EXEC [Partner_Basket].[dbo].[sp_AddSubscriptionBDTUBE] '" + number + "','000','0','1','" +
                        HS_MOD + "','" + HS_MANUFAC + "'", "WAPDB");
                    //oCDA.ExecuteNonQuery("EXEC [Partner_Basket].[dbo].[sp_AddSubscriptionBDTUBE_history] '" + sMsisdn + "','000','0','1','" + HS_MOD + "','" + HS_MANUFAC + "'", "WAPDB");
                    
                    if (number.StartsWith("88016"))
                    {
                        //string MSG = "You have successfully subscribed to BD Tube service @Tk2+VAT+SD+SC/day(auto-renewal).To unsubscribe,sms STOP BDTUBE to 6624.Help:01674985965(Call charge apply)";

                        //oCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + sMsisdn + "','" + MSG + "'", "WAPDB");
                    }
                    else
                    {
                        //string MSG = "Welcome to BDTube service. Visit http://bdtube.mobi to watch latest and exclusive videos. Cost:TK.2 daily. SMS STOP BDTUBE to 6624 to cancel.";
                        string MSG = null;
                        if (number.StartsWith("88019"))
                        {
                            MSG =
                                "Your subscription of BDTube service has been confirmed @Taka 2 (+VAT,SD+SC)/day auto-renewal.To unsubscribe send STOP BDTUBE to 6624. Help: 01992303765";
                        }
                        else if (number.StartsWith("88015"))
                        {
                            MSG =
                                "Your subscription of BDTube service has been confirmed @Taka 2 (+VAT,SD+SC)/day auto-renewal.To unsubscribe send STOP BDTUBE to 6624. Help: 01534524714";
                        }
                       
                        CA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + number + "','" + MSG + "'", "WAPDB");
                    }
                }
            }

            string cType = "";

            try
            {
                cType = Request.QueryString["cType"].ToString();

            }
            catch
            {

            }

            switch (cType)
            {
                case "PremiumVideo":
                    // Response.Redirect("~/PremiumVideo.aspx");
                    break;
                case "VideoClips":
                    //Response.Redirect("~/VideoClips.aspx");
                    break;
                case "FreeVideo":
                    // Response.Redirect("~/FreeVideo.aspx");
                    break;
                case "":
                    //Response.Redirect("~/Default.aspx?mod=done");
                    //Response.Redirect("~/Download.aspx?content_code=" + Request.QueryString["content_code"] + "&CategoryCode=" + Request.QueryString["CategoryCode"] + "&sPreviewUrl=" + Request.QueryString["sPreviewUrl"] + "&ContentTitle=" + Request.QueryString["ContentTitle"] + "&sContentType=" + Request.QueryString["sContentType"] + "&sPhysicalFileName=" + Request.QueryString["sPhysicalFileName"] + "&ZedID=" + Request.QueryString["ZedID"] + "&m=" + sMsisdn + "&sMasterCat=" + Request.QueryString["sMasterCat"]);
                    break;
                default:
                    //Response.Redirect("~/");
                    Response.Redirect("~/Download.aspx?content_code=" + Request.QueryString["content_code"] +
                                      "&CategoryCode=" + Request.QueryString["CategoryCode"] + "&sPreviewUrl=" +
                                      Request.QueryString["sPreviewUrl"] + "&ContentTitle=" +
                                      Request.QueryString["ContentTitle"] + "&sContentType=" +
                                      Request.QueryString["sContentType"] + "&sPhysicalFileName=" +
                                      Request.QueryString["sPhysicalFileName"] + "&ZedID=" +
                                      Request.QueryString["ZedID"] + "&m=" + sMsisdn + "&sMasterCat=" +
                                      Request.QueryString["sMasterCat"]);
                    break;
            }



            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction",
                " function  callFunction() { $('#myModal').modal('show');$('#myModal2').modal('hide'); $('#myModal3').modal('hide'); }",
                true);
        }
    }



    public string CGW(string MSISDN)
    {
        string replyAPI = string.Empty;
        string sDownloadRequest = string.Empty;
        string Charging = string.Empty;


        if (MSISDN.StartsWith("88019"))
        {
            string key = "TUBE2";
            string PortalCode_Port_VU = "EE9D65C0-A155-464C-A41F-D6FAF01D4B88";
            string ContentCode = "subscription";
            string PortalCategoryCode = "";

            //TubeCGW.ServiceSoapClient tbCGW = new TubeCGW.ServiceSoapClient();
            BLSDP.BLSDP_CGW tbCGW = new BLSDP.BLSDP_CGW();

            try
            {
                //comment
                sDownloadRequest = tbCGW.ChargingProcess(MSISDN, key, PortalCode_Port_VU, ContentCode, PortalCategoryCode);
                //sDownloadRequest = "success";
            }
            catch { }

            if (sDownloadRequest.ToLower().Contains("success"))
            {
                sDownloadRequest = "success";
            }
            sDownloadRequest = "success";
        }
        //if (MSISDN.StartsWith("88018"))
        //{
        //    sDownloadRequest = "success";
        //}
        if (MSISDN.StartsWith("88016"))
        {
            try
            {
                //comment
                ATASE.Service objATASAE = new ATASE.Service();
                objATASAE.ASESubscribe(MSISDN, "vubdtube", "Addition");
            }
            catch
            {
            }

            //ATCGW.Service ATAPI = new ATCGW.Service();
            ////string ChargingReply = ATAPI.AirtelCGW_Process(MSISDN, "CZM");
            //string ChargingReply = ATAPI.AirtelCGW_Process(MSISDN, "BDTSUB");

            //if (ChargingReply.StartsWith("SUCC"))
            //{
            sDownloadRequest = "success";
            //}

        }
        if (MSISDN.StartsWith("88015"))
        {
            string key = "TUBE2";

            TTCGW.Service tlAPI = new TTCGW.Service();
            try
            {
                sDownloadRequest = tlAPI.TTCGW_Process(MSISDN, key, "", "", "");
                //comment
                //sDownloadRequest = "Successful";

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

            sDownloadRequest = "success";
        }


        return replyAPI = sDownloadRequest.ToLower();
    }

    protected void lbkbtnCancelSubscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelSubscription.aspx");
    }
}