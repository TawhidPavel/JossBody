using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;
using HSProfiling;
using System.Web.Script.Serialization;
using System.Net;
using System.Threading;

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
    string UrlReferrer = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        string UAPROF_URL = oUAProfile.GetUserAgent();
        try
        {

            if (Detection.fBrowserIsMobile())
            {
               // Console.WriteLine("Mob");
            }
            else
            {
               // Response.Redirect("http://jossbody.com/feature");
            }

          
        }
        catch { }

        //===================================== added ========================
       GpSubUnsubConfig();
        //=====================================added========================
        SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
        try
        {
            //pavel var UrlReferrer1 = Request.UrlReferrer;
            //pavel UrlReferrer = UrlReferrer1.ToString();

        }
        catch { }

        string scriptForTT1 = @" $(document).ready(function() {

            $('.robititle').css('background-color','#58C1E6');    
   
            });";

        if (Session["MSISDN"] != null)
        {
            string msisdn = Session["MSISDN"].ToString();
            if (msisdn.StartsWith("88015"))
            {
                cssTemplate.Attributes.Add("href", "~/Css/StyleSheetTT.css");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForTT1, true);
            }
        }

        


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
                    Session["MSISDN"] = sMsisdn;
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

           
            try
            {
                //HS_OS = "Android";
                //pavel//
                //SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                //HSProfiling.Service Profile = new HSProfiling.Service();
                //var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

                //HS_MANUFAC = HSProfiling.Manufacturer;
                //Session["HS_MANUFAC"] = HS_MANUFAC;
                //HS_MOD = HSProfiling.Model;
                //Session["HS_MOD"] = HS_MOD;
                //HS_DIM = HSProfiling.Dimension;
                //Session["HS_DIM"] = HS_DIM;
                //HS_OS = HSProfiling.OS;
                //Session["HS_OS"] = HS_OS;
                //UAPROF_URL = HSProfiling.UAXML;
                //Session["UAPROF_URL"] = UAPROF_URL;
                //pavel//
            }
            catch { }
            string scriptForBl = @" $(document).ready(function() {

           $('.robititle').css('background-color','#58C1E6');
           
             
              });";


            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);







            string key = String.Empty;
            if (Request.Params["key"] != null)
            {
                key = Request.Params["key"].ToString();
                Session["key"] = key;
            }
            if (Session["key"] != null)
            {
                key = Session["key"].ToString();
            }

            string flagAccess = "0";
            if (Session["flagAccess"] != null)
            {
                flagAccess = Session["flagAccess"].ToString();
            }
            string PORTAL_N_SHORT = "JossBody/JD";
           //pavel CA.ExecuteNonQuery("EXEC [AurkoCRM].[dbo].[spInsertPortalVisitLog]'" + SOURCE_URL + "','" + "JossBody:Home" + "','" + oUAProfile.Decode(sMsisdn) + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','" + PORTAL_N_SHORT + "','" + HS_OS + "','" + Request.UserAgent + "','" + oUAProfile.GetUserIP() + "','13'", "Aurko");



            //===============================ORGINIAL==================================
            //CA.ExecuteNonQuery("EXEC [FitnessPortal].[dbo].[sp_SetPortalAccess]'" + SOURCE_URL + "','" + sMsisdn + "','" + oUAProfile.GetUserAgent() + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + "APN" + " ','" + "AMARFITNESS" + "','" + oUAProfile.GetUserIP() + "','" + HS_OS + "'", "WAPDB");
            //===============================ORGINIAL==================================



            //  CA.ExecuteNonQuery("EXEC [Partner_Basket].[dbo].[sp_SetPortalAccess]'" + SOURCE_URL + "','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + "''" + " ','" + "VDOPortal" + "','','" + oUAProfile.GetUserIP() + "','" + HS_OS + "'", "WAPDB");
            if (sMsisdn.StartsWith("88019") || sMsisdn.StartsWith("88015") || sMsisdn.StartsWith("88015") ||
                sMsisdn.StartsWith("88017"))
            {
               // Response.Redirect("Restriction.aspx");

            }

            if (!string.IsNullOrEmpty(key))
            {
                if (Session["AccessID"] == null)
                {
                    //DataSet dsAccess = CA.GetDataSet("EXEC spGET_OA_ACCESS'" + SOURCE_URL + "','" + SrvID + "','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','" + PORTAL_N_SHORT + "','" + CAM_KEY + "','" + oUAProfile.GetUserIP() + "','" + HS_OS + "','" + oUAProfile.GetUserAgent() + "','" + UrlReferrer + "','" + RequestFull + "'", "WAPDB");
                  //pavel  DataSet accessKey = CA.GetDataSet("Exec spGET_OA_ACCESS'" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + oUAProfile.GetUserIP() + "','" + HS_OS + "'", "WAPDB");

                   //pavel if (accessKey != null)
                    //pavel {
                        //AccessID = "&aid=" + dsAccess.Tables[0].Rows[0]["ID"].ToString();
                     //pavel    Session["AccessID"] = accessKey.Tables[0].Rows[0]["ID"].ToString();
                    //pavel}
                }

            }






            Slider();
            FitnessGuide();
             ExclusiveHotVideo();
            MusicVideo();
            DailyExcerciseVideo();
            CelebrityWorkOutVideo();
            HealthyRecepieVideo();
            //ExclusiveVideo();
            // BindVideoMostLiked();
            Most();
            bool subs = isSubscribe(sMsisdn);
            cancelSubscriptionBlink.Visible = subs;
            non.Visible = !subs;

            //if (string.IsNullOrEmpty((sMsisdn)))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " function  callFunction() { $('#myModal').modal('hide');$('#myModal2').modal('hide'); $('#myModal3').modal('show'); }", true);
            //}
            if (!string.IsNullOrEmpty((sMsisdn)))
            {
                //lblNumber.Text = sMsisdn;
                //lblNumber.Visible = true;
                //lblNumber2.Visible = true;
                //lblNumber2.Text = sMsisdn;
            }
        }

    }


    public void MusicVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
            dsFullvideo = CA.GetDataSet("Exec [WapPortal].dbo.Sp_getContentsBySubcategoryID_BdtubeRobi_Newup '60579B0C-259E-435A-A227-BF2E546DDCFE', " + 6 + "", "WapPortal");
        //dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '873E3EA9-3A28-484B-B74B-68C107DDD800', " + 8 + "", "WAPDB2");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontents +=
                    "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                    "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                    "<div class='Icone_image'>" +
                    "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
                    "<div class='videoTitle'>" +
                    "<div class='Title1'>" +
                    "<span class='fonte'>" + dr["ContentTile"] + "</span>" + "</br>" +
                    "<img  class='like-count' style='width: 15%;margin-left: 75%;' src='images/vi.png'>" +
                    "<label style='font-weight: 100;'>" + dr["totalView"] + "</label>" +
                    //"<img  class='' style='    width: 18px;height:18px;margin-left: 45%; ' src='images/lik.png'>" +
                    //"<label style='font-weight: 100;'>" + dr["totalLike"] + "</label>" +
                    "</div>" +
                    "</div></div></div>";



            }
            ltrlmusicVideos.Text = fulvideocontents.ToString() + "</div></div>"; ;
        }



    }
    public void ExclusiveHotVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
       //pavel dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '01A332B2-A207-44B9-9D3C-F85A1563571A', " + 8 + "", "WAPDB2");
        dsFullvideo = CA.GetDataSet(" Exec [Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + "B6392C5F-5F5B-41BC-AC82-49CDA4169B11" + "','" + 6 + "'", "WapPortal");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontents +=
                    "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                    "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                    "<div class='Icone_image'>" +
                    "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
                    "<div class='videoTitle'>" +
                    "<div class='Title1'>" +
                    "<span class='fonte'>" + dr["ContentTile"] + "</span>" + "</br>" +
                    "<img  class='like-count' style='width: 15%;margin-left: 75%;' src='images/vi.png'>" +
                    "<label style='font-weight: 100;'>" + dr["totalView"] + "</label>" +
                    //"<img  class='' style='    width: 18px;height:18px;margin-left: 45%; ' src='images/lik.png'>" +
                    //"<label style='font-weight: 100;'>" + dr["totalLike"] + "</label>" +
                    "</div>" +
                    "</div></div></div>";



            }
            ltrlHotVideos.Text = fulvideocontents.ToString() + "</div></div>"; ;
        }



    }


    public void ExclusiveVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
        dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness 'A49ACD7E-010D-4937-9A74-AB9E8A9B36B7', " + 8 + "", "WAPDB");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontents +=
                    "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                    "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                    "<div class='Icone_image'>" +
                    "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
                    "<div class='videoTitle'>" +
                    "<div class='Title1'>" +
                    "<span class='fonte'>" + dr["ContentTile"] + "</span>" + "</br>" +
                    "<img  class='like-count' style='width: 15%;margin-left: 75%;' src='images/vi.png'>" +
                    "<label style='font-weight: 100;'>" + dr["totalView"] + "</label>" +
                    //"<img  class='' style='    width: 18px;height:18px;margin-left: 45%; ' src='images/lik.png'>" +
                    //"<label style='font-weight: 100;'>" + dr["totalLike"] + "</label>" +
                    "</div>" +
                    "</div></div></div>";



            }
            ltrlExclusiveVideo.Text = fulvideocontents.ToString() + "</div></div>"; ;
        }
    }

    private void DailyExcerciseVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
        // dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_Latest1 'A2106AB1-A41B-41C4-96FC-42971B8F84C5',4", "WAPDB");
        List<DEV> dd = new List<DEV>()
        {
            new DEV()
            {
                ImageUrl = "images/1.png",
                Path = "Videos.aspx?cid=7BA286C1-81B8-4267-BF0D-D6057CDC3CFE",
                Title = "ওয়েট লস এক্সারসাইজ"
            },
            new DEV()
            {
                ImageUrl = "images/3.png",
                Path = "Videos.aspx?cid=B4955166-7C8B-4E0E-81DF-75A2FCCA6187",
                Title = "ডেইলি ইয়োগা প্রাকটিস"
            },
            new DEV()
            {
                ImageUrl = "images/2T.png",
              
                Path = "Videos.aspx?cid=D8958FA5-DFA9-40F0-B831-92771E5CA3F8",
                Title = "হোম রেমেডি চ্যানেল"
            }

        };

        foreach (var dr in dd)
        {


            fulvideocontents +=
                "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                "<a href='" + dr.Path + "'><img src='" + dr.ImageUrl + "' style='Height:200px' /></a>" +
                "<div style='text-align: center;'>"+ dr.Title + "</div>"+
                "<div class='Icone_image'>" +
                "<a href='" + dr.Path + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
               "</div></div>";


        }
        ltrlExercise.Text = fulvideocontents.ToString() + "</div></div>";

    }
    public class DEV
    {
        public string Path { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

    }
    private void HealthyRecepieVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
        //pavel  dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '447DC46C-3D03-48E5-9D9D-58744C89DBA3',8", "WAPDB");
        dsFullvideo = CA.GetDataSet("Exec [WapPortal].dbo.Sp_getContentsBySubcategoryID_BdtubeRobi_Newup 'DB3FED39-4577-4268-9FA0-CD6C967ED512',6", "WapPortal");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontents +=
                    "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                    "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                    "<div class='Icone_image'>" +
                    "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
                    "<div class='videoTitle'>" +
                    "<div class='Title1'>" +
                    "<span class='fonte'>" + dr["ContentTile"] + "</span>" + "</br>" +
                    "<img  class='like-count' style='width: 15%;margin-left: 75%;'  src='images/vi.png'>" +
                    "<label style='font-weight: 100;'>" + dr["totalView"] + "</label>" +
                    //"<img  class='' style='    width: 18px;height:18px;margin-left: 45%; ' src='images/lik.png'>" +
                    //"<label style='font-weight: 100;'>" + dr["totalLike"] + "</label>" +
                    "</div>" +
                    "</div></div></div>";


            }
            ltrlFitnessSecrets.Text = fulvideocontents.ToString() + "</div></div>";
        }
    }

    public void Most()
    {
        DataSet dsFullvideo = null;
        string fulvideocontentsMost = string.Empty;
       //pavel dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.[Sp_getContentsMostLiked_fitness] 'E0AEF450-099B-495F-B056-8AED4B95F00A', 4", "WAPDB");
        dsFullvideo = CA.GetDataSet("Exec [WapPortal].dbo.Sp_getContentsBySubcategoryID_BdtubeRobi_Newup '60579B0C-259E-435A-A227-BF2E546DDCFE', " + 6 + "", "WapPortal");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontentsMost +=
                    "<div class='col-lg-6 col-md-6 col-xs-6' style='padding-left: 2px; padding-right: 2px; padding-top: -5px; padding-bottom: -25px;'>" +

                    //<asp:HyperLink ID="vdoPic" runat="server" CssClass="thumbnail img-responsive" NavigateUrl='<%# Eval("path")%>' ImageUrl='<%# Bind("imageUrl") %>' />
                    "<a href='" + dr["path"] + "'  Class='thumbnail img-responsive'><img src='" + dr["imageUrl"] + "'  /></a>" +
                      "<div class='Icone_image'>" +
                            "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:50%;box-shadow:0px 0px 0px 0px'/></a></div>" +
                    "<div class='listtitle1'>" + dr["ContentTile"] + "</div>" +
                    "</div>";



            }
            literalMostLiked.Text = fulvideocontentsMost.ToString();
        }

    }


    private void FitnessGuide()
    {
        DataSet dsFullvideo = null;
        string newYear = String.Empty;
        dsFullvideo = CA.GetDataSet(" Exec [Sp_getContentsBySubcategoryID_BdtubeRobi_Newup] '" + "B6392C5F-5F5B-41BC-AC82-49CDA4169B11" + "','" + 2 + "'", "WapPortal");
       //pavel dsFullvideo = CA.GetDataSet("Exec Sp_FullvideoContents_videoboxHomePage 'C1104876-012B-4B85-8E51-F84FA6CD6DBA',2", "WAPDB");
        if (dsFullvideo != null)
        {
            string type = String.Empty;
            string typeCover = String.Empty;
            string Title = String.Empty;
            int i = 0;
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {
                if (i == 0)
                {
                    type = "3A827B46-C8EA-4D1A-B1BE-3BFF59014168";
                    typeCover = "images/i1.png";
                    Title = "ফুড টিপস";
                }
                else if (i == 1)
                {
                    type = "12EE8772-F439-4354-AA4F-427BFA8D41A0";
                    typeCover = "images/2.png";
                    Title = "হেলথ টিপস ";
                }
                //else if (i == 2)
                //{
                //    type = "6";
                //    typeCover = "imgNewYear/cff.jpg";

                //}
                //else if (i == 3)
                //{
                //    type = "10";
                //    typeCover = "imgNewYear/hrf.jpg";

                //}

                newYear += "<div class='col-lg- col-md-6 col-xs-6' style='padding-left:2px;padding-right:2px;padding-top:-5px;padding-bottom:-25px;'>" +
                           "<a Class='thumbnail img-responsive' href='" + "TextPage.aspx?type=" + type + "'><img src='" + typeCover + "'/>"+
                           "<div class='no-link' style='text-align: center;'>" + Title + "</div>"+
                           "</a>" +
                           //        "<div class='imgPlay'>" +
                           //"<a Class='thumbnail img-responsive' href='" +"TextPage.aspx?type=" + type + "'><img src='" + typeCover + "'  /></a>" +
                           //   "</div>" +


                "</div>";

                i++;

            }
            ltrlFitnessGuide.Text = newYear.ToString();
        }
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
        string slider = String.Empty;
        
        
        //datasetslider = CA.GetDataSet("Exec FitnessPortal.dbo.[Sp_slider_fitness]", "WAPDB2");
        datasetslider = CA.GetDataSet("Exec WapPortal.dbo.[Sp_sliderfitness]", "WapPortal");
        if (datasetslider != null)
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

    public void CelebrityWorkOutVideo()
    {
        DataSet dsFullvideo = null;
        string fulvideocontents = "<div class='swiper-container'><div class='swiper-wrapper' style='width:47%;height:50%'>";
        //pavel  dsFullvideo = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_fitness '991CE47D-458A-41BC-91AF-B59A6BB711EF', " + 8 + "", "WAPDB");
        dsFullvideo = CA.GetDataSet("Exec [WapPortal].dbo.Sp_getContentsBySubcategoryID_BdtubeRobi_Newup 'CDCB34D0-363C-4281-AFE4-AE289138179D', " + 4 + "", "WapPortal");
        if (dsFullvideo != null)
        {
            foreach (DataRow dr in dsFullvideo.Tables[0].Rows)
            {


                fulvideocontents +=
                    "<div class='swiper-slide' style='width:100%'><div class='videowrap' style='width:100%'><div class='videocontent' style='position:relative;'>" +
                    "<a href='" + dr["path"] + "'><img src='" + dr["imageUrl"] + "'  /></a>" +
                    "<div class='Icone_image'>" +
                    "<a href='" + dr["path"] + "'><img src='images/play-button.png' style='width:24px;height:27px'/></a></div></div>" +
                    "<div class='videoTitle'>" +
                    "<div class='Title1'>" +
                    "<span class='fonte'>" + dr["ContentTile"] + "</span>" + "</br>" +
                    "<img  class='like-count' style='width: 15%;margin-left: 75%;' src='images/vi.png'>" +
                    "<label style='font-weight: 100;'>" + dr["totalView"] + "</label>" +
                    //"<img  class='' style='    width: 18px;height:18px;margin-left: 45%; ' src='images/lik.png'>" +
                    //"<label style='font-weight: 100;'>" + dr["totalLike"] + "</label>" +
                    "</div>" +
                    "</div></div></div>";



            }
            ltrlLatestVideos.Text = fulvideocontents.ToString() + "</div></div>"; ;
        }



    }





    public void BindVideoMostLiked()
    {
        DataSet dsVdo = null;
        dsVdo = CA.GetDataSet("Exec [FitnessPortal].dbo.[Sp_getContentsMostLiked_fitness] 'E0AEF450-099B-495F-B056-8AED4B95F00A', 4", "WAPDB");

        // DataListVdo.DataSource = dsVdo;
        // DataListVdo.DataBind();

    }

    protected string GetMsisdnValue()
    {
        //string number = ViewState["msisdn"] == null ? "" : ViewState["msisdn"].ToString();
        //if ((!number.StartsWith("88018")|| !number.StartsWith("88016")) && number != "")
        //{
        //    if (isSubscribe(number))
        //    {
        //        return (ViewState["msisdn"].ToString()); 

        //    }
        //    else if (nisC == "3")
        //    {
        //        return "10";
        //    }
        //    else if (!string.IsNullOrEmpty(number) && !isSubscribe(number) && addC == "2nd")
        //    {
        //        //here will be the logic where to navigate 
        //        //if user already subscribed then it will take user to the QuizPlay.aspx 
        //        //other wise to the page subscribe the user according to the operator

        //        // return "1";
        //        return "2";// APN but user not suscribed

        //    }
        //    else if (string.IsNullOrEmpty(number) && !isSubscribe(number) && addC == "2nd")
        //    {
        //        //here will be the logic where to navigate 
        //        //if user already subscribed then it will take user to the Qui zPlay.aspx 
        //        //other wise to the page subscribe the user according to the operator

        //        // return "1";
        //        return "2";// APN but user not suscribed

        //    }

        //    else if (!string.IsNullOrEmpty(number) && !isSubscribe(number))
        //    {
        //        //here will be the logic where to navigate 
        //        //if user already subscribed then it will take user to the QuizPlay.aspx 
        //        //other wise to the page subscribe the user according to the operator

        //        // return "1";
        //        return "-1";// APN but user not suscribed

        //    }

        //    else
        //    {
        //        return "0";// Wifi user
        //    }

        //}

        //else
        //{
        //    return "55";
        //}
        return "55";

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
            //SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            //HSProfiling.Service Profile = new HSProfiling.Service();
            //var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

            //HS_MANUFAC = HSProfiling.Manufacturer;
            //HS_MOD = HSProfiling.Model;
            //HS_DIM = HSProfiling.Dimension;
            //HS_OS = HSProfiling.OS;
            //UAPROF_URL = HSProfiling.UAXML;
        }
        catch { }

        string AccessId = string.Empty;
        string key = string.Empty;

        if (Session["AccessID"] != null)
        {
            AccessId = Session["AccessID"].ToString();
        }

        if (Session["key"] != null)
        {
            key = Session["key"].ToString();

            //oCDA.ExecuteNonQuery("Exec spGET_OA_SUCCESS '" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + HS_OS + "','" + AccessId + "','" + UAPROF_URL + "',''", "WAPDB");
            CA.ExecuteNonQuery("EXEC [spGET_OA_ACCESS_SECOND_PAGE] '" + SOURCE_URL + "','BDTube','" + sMsisdn + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + APN + "','VDOPortal','" + key + "','" + HS_OS + "','" + AccessId + "','" + UAPROF_URL + "',''", "WAPDB");
        }

        if (!sMsisdn.StartsWith("88018"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " function  callFunction() { $('#myModal').modal('hide');$('#myModal2').modal('show'); $('#myModal3').modal('hide'); }", true);

        }

    }




    protected void NishchitoButton_Click(object sender, ImageClickEventArgs e)
    {
        nisC = "3";
        string number = ViewState["msisdn"] == null ? "" : ViewState["msisdn"].ToString();

        string AccessId = string.Empty;
        string key = string.Empty;
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
        // string UAPROF_URL = oUAProfile.GetUserAgent();

        if (Session["AccessID"] != null)
        {
            AccessId = Session["AccessID"].ToString();
        }

        if (Session["key"] != null)
        {
            key = Session["key"].ToString();

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
                    //CA.ExecuteNonQuery(
                    //    "EXEC [Partner_Basket].[dbo].[sp_AddSubscriptionBDTUBE] '" + number + "','000','0','1','" +
                    //    HS_MOD + "','" + HS_MANUFAC + "'", "WAPDB");

                    CA.ExecuteNonQuery(
                      "EXEC [FitnessPortal].[dbo].[sp_AddSubscriptionFitnessPortal] '" + number + "','000','0','1','" +
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
                                "Your subscription of Fitness service has been confirmed @Taka 2 (+VAT,SD+SC)/day auto-renewal.To unsubscribe send STOP Fitness to 6624. Help: 01992303765";
                        }
                        else if (number.StartsWith("88015"))
                        {
                            MSG =
                                "Your subscription of Fitness service has been confirmed @Taka 2 (+VAT,SD+SC)/day auto-renewal.To unsubscribe send STOP Fitness to 6624. Help: 01534524714";
                        }
                        else if (number.StartsWith("88018"))
                        {
                            MSG =
                                "Your subscription of Fitness service has been confirmed @Taka 2 (+VAT,SD+SC)/day auto-renewal.To unsubscribe send STOP Fitness to 6624. Help: 8801814426426";
                        }

                        CA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + number + "','" + MSG + "'", "WAPDB");
                    }
                }
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
        //if (MSISDN.StartsWith("88018"))
        //{
        //    sDownloadRequest = "success";
        //}
        if (MSISDN.StartsWith("88016"))
        {


            /*try
            {
                //comment
                ATASE.Service objATASAE = new ATASE.Service();
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

            /* string key = "TUBE2";

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
             }*/

            sDownloadRequest = "success";
        }
        if (MSISDN.StartsWith("88017"))
        {

            sDownloadRequest = "success";
        }

        if (MSISDN.StartsWith("88018"))
        {

            sDownloadRequest = "success";
        }


        return replyAPI = sDownloadRequest.ToLower();
    }

    protected void lbkbtnCancelSubscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelSubscription.aspx");
    }

    protected void OnClick(object sender, EventArgs e)
    {
        try
        {
            string UAPROF_URL = oUAProfile.GetUserAgent();
            SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            HSProfiling.Service Profile = new HSProfiling.Service();
            var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

            HS_MANUFAC = HSProfiling.Manufacturer;
            HS_MOD = HSProfiling.Model;
            HS_DIM = HSProfiling.Dimension;
            HS_OS = HSProfiling.OS;
            UAPROF_URL = HSProfiling.UAXML;

            if (HS_OS == "Desktop")
            {
                Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=OS");
            }
            else if (HS_MANUFAC == "Generic" || HS_MOD == "Generic")
            {
                Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=Mobile");

            }


        }
        catch
        {
            Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=OS");
        }
        Response.Redirect("RobiFirstPAge.aspx");
    }

    //===================================ADDED=====================================
    protected void btnSubscription_OnClick(object sender, EventArgs e)
    {

        //============ORIGINAL
        string ip = oUAProfile.GetUserIP();
        //string ip = "119.30.39.251";
        //ORIGINAL==============================



        //string ip = "119.30.39.251";
        WebClient client = new WebClient();
        string downloadString = client.DownloadString("http://192.168.14.16/dpdpclient/api/RecognizeGPSubscribes?Ip=" + ip);

        if (!downloadString.Contains("True"))
        {

            //Response.Redirect("~/Nomsisdn1.aspx?sid=57");
            Response.Redirect("~/ErrorMessage.aspx");
        }

        //else
        //{
        //    Response.Redirect("~/Nomsisdn1.aspx?sid=57");
        //}


        string referenceCode = string.Empty;
        try
        {
            referenceCode = referenceCode = DateTime.Now.ToString("yyyyMMddHHmmssffffff"); //Request.QueryString["referenceCode"].ToString();
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
            successUrl = "http://182.160.119.238/jbtest",
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

    protected void btnUnSubscription_OnClick(object sender, EventArgs e)
    {
        SendService sendService = new SendService();
        string endUserId = string.Empty;




        try
        {
            endUserId = Request.QueryString["endUserId"].ToString();
        }
        catch (Exception exception)
        {
            endUserId = "";
        }
        string query = @"SELECT subscriptionId
  FROM[DPDP].[dbo].[tblBase]
  where ServiceId = '13' and MSISDN = '" + endUserId + "' and RegStatus = 1";

        object subscriptionId = new CDA().getSingleValue(query, "DPDP");

        string json = new JavaScriptSerializer().Serialize(new
        {
            Id = "",
            servicekey = "afef69c7cbbe4b55bb10d47dd5969677",
            endUserId = endUserId,
            subscriptionId = subscriptionId.ToString(),
            accesschannel = "WAP"
        });

        sendService.Send("http://192.168.14.16/DPDPClient/api/Unsubscribe", json);
        Thread.Sleep(5000);
        Response.Redirect("~/Default.aspx");
    }



    private void GpSubUnsubConfig()
    {

        //original===========================================
        string ip = oUAProfile.GetUserIP();
        //string ip = "119.30.39.251";
        //original===========================================

        
        WebClient client = new WebClient();
        string downloadString = client.DownloadString("http://192.168.14.16/dpdpclient/api/RecognizeGPSubscribes?Ip=" + ip);

        if (downloadString.Contains("True"))
        {
            BaseCheck();
        }
  
    }

    private void SetSMsisdn()
    {
        try
        {
            sMsisdn = Request.QueryString["endUserId"].ToString();
            Session["endUserId"] = sMsisdn;
            //============================================ORIGINAL

            //Session["endUserId"] = oUAProfile.Encode(sMsisdn);

            //============================================ORIGINAL
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

        SetSMsisdn();

        string query = @"SELECT top 1 1
  FROM[DPDP].[dbo].[tblBase]

  where ServiceId = '13' and MSISDN = '" + sMsisdn + "' and RegStatus = 1";

        DataSet dataSet = new CDA().GetDataSet(query, "DPDP");

        if (dataSet != null)
        {
            subDiv.Visible = false;
            btnUnSubscription.Visible = true;
        }
        else
        {
            subDiv.Visible = true;
            btnUnSubscription.Visible = false;
        }
    }

    //++++++++++++++++++ADDED++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}