using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Morevide : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    DataSet dscount = null;
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
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

        if (sMsisdn.StartsWith("88018"))
        {
            Response.Redirect("Restricted.aspx");
        }
        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#F16521');
           
             
              });";

        string scriptForTT = @" $(document).ready(function() {

            $('.vdtitle').css('background-color','#71BD44');    
            
           });";



        if (sMsisdn.StartsWith("88015"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetTT.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForTT, true);
            ImageButton1.ImageUrl = "~/images/tele.png";
            btnbanglamusic.ImageUrl = "~/images/tele.png";
            btnenglishmusic.ImageUrl = "~/images/tele.png";
            ImageButton2.ImageUrl = "~/images/tele.png";
        }

        else if (sMsisdn.StartsWith("88019"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            ImageButton1.ImageUrl = "~/images/blink.png";
            btnbanglamusic.ImageUrl = "~/images/blink.png";
            btnenglishmusic.ImageUrl = "~/images/blink.png";
            ImageButton2.ImageUrl = "~/images/blink.png";

        }
        else if (sMsisdn.StartsWith("88016"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheet.css");
            ImageButton1.ImageUrl = "~/images/aro-video.png";
            btnbanglamusic.ImageUrl = "~/images/aro-video.png";
            btnenglishmusic.ImageUrl = "~/images/aro-video.png";
            ImageButton2.ImageUrl = "~/images/aro-video.png";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

        }
        else
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            ImageButton1.ImageUrl = "~/images/blink.png";
            btnbanglamusic.ImageUrl = "~/images/blink.png";
            btnenglishmusic.ImageUrl = "~/images/blink.png";
            ImageButton2.ImageUrl = "~/images/blink.png";
        }
        if (!IsPostBack)
        {
            BanglaMovies();
            BanglaMusic();
            EnglishMovies();
            EnglishMusic();
            HindiMovies();
            HindiMusic();
            BanglaNatok();
        }
    }

    private void BanglaNatok()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F'", "WAPDB");
        dalaListBanglaNatok.DataSource = ds;
        dalaListBanglaNatok.DataBind();
        ImageButton2.Visible = true;
    }


    public void BanglaMovies()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'A5D68929-8921-4ECD-8151-E36A3871EB95'", "WAPDB");
        dataListFullvideobanglamovie.DataSource = ds;
        dataListFullvideobanglamovie.DataBind();
        ImageButton1.Visible = true;
    }
    public void BanglaMusic()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'E8E4F496-9CA9-4B35-BADD-9B6470BE2F74'", "WAPDB");
        dataListFullvideobanglamusic.DataSource = ds;
        dataListFullvideobanglamusic.DataBind();
        btnbanglamusic.Visible = true;
    }
    public void EnglishMovies()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 '84449296-53E1-4DC1-87DB-B37546A8B112'", "WAPDB");
        dataListEnglishmovie.DataSource = ds;
        dataListEnglishmovie.DataBind();
    }
    public void EnglishMusic()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 '74D847C2-4E98-44DA-B7A3-61C1EAE8938F'", "WAPDB");
        dataListEnglishmusic.DataSource = ds;
        dataListEnglishmusic.DataBind();
        btnenglishmusic.Visible = true;
    }
    public void HindiMovies()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'C857EB0C-CF68-42D1-A532-7BC309F986E7'", "WAPDB");
        dataListHindimovies.DataSource = ds;
        dataListHindimovies.DataBind();
    }
    public void HindiMusic()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 '60186F4D-CD4D-4559-9BAE-89830C75A0BE'", "WAPDB");
        dataListHindimusic.DataSource = ds;
        dataListHindimusic.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {


        if (Session["idm"] == null)
        {
            Session["idm"] = 10;
        }
        else
        {
            Session["idm"] = (Convert.ToInt32(Session["idm"]) + 4);
        }


        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'A5D68929-8921-4ECD-8151-E36A3871EB95', " + Session["idm"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'A5D68929-8921-4ECD-8151-E36A3871EB95'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            ImageButton1.Visible = false;
        }


        dataListFullvideobanglamovie.DataSource = ds;
        dataListFullvideobanglamovie.DataBind();
        BanglaMusic();
        EnglishMusic();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "Fullvideo();", true);
    }
    protected void btnbanglamusic_Click(object sender, ImageClickEventArgs e)
    {
        Session["idm"] = null;
        if (Session["idbanglamusic"] == null)
        {
            Session["idbanglamusic"] = 10;
        }
        else
        {
            Session["idbanglamusic"] = (Convert.ToInt32(Session["idbanglamusic"]) + 4);
        }
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'E8E4F496-9CA9-4B35-BADD-9B6470BE2F74', " + Session["idbanglamusic"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'E8E4F496-9CA9-4B35-BADD-9B6470BE2F74'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnbanglamusic.Visible = false;
        }
        dataListFullvideobanglamusic.DataSource = ds;
        dataListFullvideobanglamusic.DataBind();
        BanglaMovies();
        EnglishMusic();

        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaVideo();", true);

    }
    protected void btnenglishmusic_Click(object sender, ImageClickEventArgs e)
    {
        Session["idm"] = null;
        Session["idbanglamusic"] = null;
        if (Session["idenglishmusic"] == null)
        {
            Session["idenglishmusic"] = 10;
        }
        else
        {
            Session["idenglishmusic"] = (Convert.ToInt32(Session["idenglishmusic"]) + 4);
        }
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 '74D847C2-4E98-44DA-B7A3-61C1EAE8938F', " + Session["idenglishmusic"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '74D847C2-4E98-44DA-B7A3-61C1EAE8938F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnenglishmusic.Visible = false;
        }

        dataListEnglishmusic.DataSource = ds;
        dataListEnglishmusic.DataBind();
        BanglaMovies();
        BanglaMusic();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "Englishmusic();", true);

    }



    protected void btnbanglaNatok_Click(object sender, ImageClickEventArgs e)
    {
        Session["idm"] = null;
        Session["idenglishmusic"] = null;
        if (Session["idbanglanatok"] == null)
        {
            Session["idbanglanatok"] = 10;
        }
        else
        {
            Session["idbanglanatok"] = (Convert.ToInt32(Session["idbanglanatok"]) + 4);
        }
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F', " + Session["idbanglanatok"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            ImageButton2.Visible = false;
        }

        dalaListBanglaNatok.DataSource = ds;
        dalaListBanglaNatok.DataBind();
        BanglaMovies();
        BanglaMusic();
        EnglishMusic();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);

    }
}