using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class ShortVideo : System.Web.UI.Page
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
            btnbanglamusic.ImageUrl = "~/images/tele.png";
            btnbangladrama.ImageUrl = "~/images/tele.png";
            btnenglishmusic.ImageUrl = "~/images/tele.png";
            btnbanglamovie.ImageUrl = "~/images/tele.png";
            btnhindimovie.ImageUrl = "~/images/tele.png";
            btncelebritynews.ImageUrl = "~/images/tele.png";
            btnmoviereview.ImageUrl = "~/images/tele.png";
            btnholymoviereview.ImageUrl = "~/images/tele.png";
            btngossip.ImageUrl = "~/images/tele.png";
        }

        else if (sMsisdn.StartsWith("88019"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnbanglamusic.ImageUrl = "~/images/blink.png";
            btnbangladrama.ImageUrl = "~/images/blink.png";
            btnenglishmusic.ImageUrl = "~/images/blink.png";
            btnbanglamovie.ImageUrl = "~/images/blink.png";
            btnhindimovie.ImageUrl = "~/images/blink.png";
            btncelebritynews.ImageUrl = "~/images/blink.png";
            btnmoviereview.ImageUrl = "~/images/blink.png";
            btnholymoviereview.ImageUrl = "~/images/blink.png";
            btngossip.ImageUrl = "~/images/blink.png";

        }
        else if (sMsisdn.StartsWith("88016"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheet.css");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnbanglamusic.ImageUrl = "~/images/aro-video.png";
            btnbangladrama.ImageUrl = "~/images/aro-video.png";
            btnenglishmusic.ImageUrl = "~/images/aro-video.png";
            btnbanglamovie.ImageUrl = "~/images/aro-video.png";
            btnhindimovie.ImageUrl = "~/images/aro-video.png";
            btncelebritynews.ImageUrl = "~/images/aro-video.png";
            btnmoviereview.ImageUrl = "~/images/aro-video.png";
            btnholymoviereview.ImageUrl = "~/images/aro-video.png";
            btngossip.ImageUrl = "~/images/aro-video.png";

        }
        else
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnbanglamusic.ImageUrl = "~/images/blink.png";
            btnbangladrama.ImageUrl = "~/images/blink.png";
            btnenglishmusic.ImageUrl = "~/images/blink.png";
            btnbanglamovie.ImageUrl = "~/images/blink.png";
            btnhindimovie.ImageUrl = "~/images/blink.png";
            btncelebritynews.ImageUrl = "~/images/blink.png";
            btnmoviereview.ImageUrl = "~/images/blink.png";
            btnholymoviereview.ImageUrl = "~/images/blink.png";
            btngossip.ImageUrl = "~/images/blink.png";
        }
        if (!IsPostBack)
        {
            Banglamusic();
            Bangladramaclips();
            Englishmusic();
            Hindimovie();
            Banglamovie();
            BollywoodCelebrityNews();
            BollywoodMovieReview();
            HollywoodMovieReview();
            HollywoodGossip();

        }
    }
    public void Banglamusic()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5DCA7C64-F342-434A-A934-750F37D74AEC'", "WAPDB");
        datalistBanglaMusic.DataSource = ds;
        datalistBanglaMusic.DataBind();
        btnbanglamusic.Visible = true;
    }

    public void Bangladramaclips()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'EAB3B615-9942-462C-B531-97F255C6041D'", "WAPDB");
        datalistbangladrama.DataSource = ds;
        datalistbangladrama.DataBind();
        btnbangladrama.Visible = true;
    }


    public void Englishmusic()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '502902E6-36D9-49AA-AF31-6C722E95C000'", "WAPDB");
        datalistenglishmusic.DataSource = ds;
        datalistenglishmusic.DataBind();
        btnenglishmusic.Visible = true;
    }

    public void Hindimovie()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5EAF33AB-0A57-4D80-9392-F212E5D209FF'", "WAPDB");
        datalisthindimovie.DataSource = ds;
        datalisthindimovie.DataBind();
        btnhindimovie.Visible = true;
    }


    public void Banglamovie()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'C4C85FA7-7021-4BB4-B7EB-E793D26963B3'", "WAPDB");
        datalistbanglamovie.DataSource = ds;
        datalistbanglamovie.DataBind();
        btnbanglamovie.Visible = true;
    }


    public void BollywoodCelebrityNews()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5C5778B0-BDD2-4751-8835-A84988E9D09D'", "WAPDB");
        datalistcelebritynews.DataSource = ds;
        datalistcelebritynews.DataBind();
        btncelebritynews.Visible = true;
    }

    public void BollywoodMovieReview()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '104CDD74-51AA-416E-93B0-7F3931AE60BD'", "WAPDB");
        datalistmoviereview.DataSource = ds;
        datalistmoviereview.DataBind();
        btnmoviereview.Visible = true;
    }


    public void HollywoodMovieReview()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '021AB351-3182-49DF-894C-888FA66EA59F'", "WAPDB");
        datalistholymoviereviw.DataSource = ds;
        datalistholymoviereviw.DataBind();
        btnholymoviereview.Visible = true;
    }

    public void HollywoodGossip()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'C1104876-012B-4B85-8E51-F84FA6CD6DBA'", "WAPDB");
        datalistholygossip.DataSource = ds;
        datalistholygossip.DataBind();
        btngossip.Visible = true;
    }
    protected void btnbanglamusic_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        // Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;



        if (Session["idbanglamusic"] == null)
        {
            Session["idbanglamusic"] = 8;
        }
        else
        {
            Session["idbanglamusic"] = (Convert.ToInt32(Session["idbanglamusic"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5DCA7C64-F342-434A-A934-750F37D74AEC', " + Session["idbanglamusic"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '5DCA7C64-F342-434A-A934-750F37D74AEC'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnbanglamusic.Visible = false;
        }


        datalistBanglaMusic.DataSource = ds;
        datalistBanglaMusic.DataBind();

        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('start');", true);
    }
    protected void btnbangladrama_Click(object sender, ImageClickEventArgs e)
    {
        //Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;
        if (Session["idbangladrama"] == null)
        {
            Session["idbangladrama"] = 8;
        }
        else
        {
            Session["idbangladrama"] = (Convert.ToInt32(Session["idbangladrama"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'EAB3B615-9942-462C-B531-97F255C6041D', " + Session["idbangladrama"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'EAB3B615-9942-462C-B531-97F255C6041D'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnbangladrama.Visible = false;
        }


        datalistbangladrama.DataSource = ds;
        datalistbangladrama.DataBind();


        Banglamusic();
        //Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('banglamusic');", true);
    }
    protected void btnenglishmusic_Click(object sender, ImageClickEventArgs e)
    {
        //Session["idbanglamusic"] = null;

        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        // Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;



        if (Session["idenglish"] == null)
        {
            Session["idenglish"] = 8;
        }
        else
        {
            Session["idenglish"] = (Convert.ToInt32(Session["idenglish"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '502902E6-36D9-49AA-AF31-6C722E95C000', " + Session["idenglish"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '502902E6-36D9-49AA-AF31-6C722E95C000'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnenglishmusic.Visible = false;
        }


        datalistenglishmusic.DataSource = ds;
        datalistenglishmusic.DataBind();


        Banglamusic();
        Bangladramaclips();
        //Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('bangladrama');", true);
    }
    protected void btnhindimovie_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        //Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;

        if (Session["idhindimovie"] == null)
        {
            Session["idhindimovie"] = 8;
        }
        else
        {
            Session["idhindimovie"] = (Convert.ToInt32(Session["idhindimovie"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5EAF33AB-0A57-4D80-9392-F212E5D209FF', " + Session["idhindimovie"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '5EAF33AB-0A57-4D80-9392-F212E5D209FF'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnhindimovie.Visible = false;
        }


        datalisthindimovie.DataSource = ds;
        datalisthindimovie.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        //Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('HindiMovieC');", true);
    }
    protected void btnbanglamovie_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        //Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;

        if (Session["idbanglamovie"] == null)
        {
            Session["idbanglamovie"] = 8;
        }
        else
        {
            Session["idbanglamovie"] = (Convert.ToInt32(Session["idbanglamovie"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'C4C85FA7-7021-4BB4-B7EB-E793D26963B3', " + Session["idbanglamovie"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'C4C85FA7-7021-4BB4-B7EB-E793D26963B3'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnbanglamovie.Visible = false;
        }


        datalistbanglamovie.DataSource = ds;
        datalistbanglamovie.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        // Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('hindimovie');", true);
    }
    protected void btncelebritynews_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        // Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;

        if (Session["idcelebritynews"] == null)
        {
            Session["idcelebritynews"] = 8;
        }
        else
        {
            Session["idcelebritynews"] = (Convert.ToInt32(Session["idcelebritynews"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '5C5778B0-BDD2-4751-8835-A84988E9D09D', " + Session["idcelebritynews"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '5C5778B0-BDD2-4751-8835-A84988E9D09D'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btncelebritynews.Visible = false;
        }


        datalistcelebritynews.DataSource = ds;
        datalistcelebritynews.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        //BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('bollywoodCelebrityNews');", true);
    }
    protected void btnmoviereview_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        // Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        Session["idgossip"] = null;
        if (Session["idmoviereview"] == null)
        {
            Session["idmoviereview"] = 8;
        }
        else
        {
            Session["idmoviereview"] = (Convert.ToInt32(Session["idmoviereview"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '104CDD74-51AA-416E-93B0-7F3931AE60BD', " + Session["idmoviereview"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '104CDD74-51AA-416E-93B0-7F3931AE60BD'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnmoviereview.Visible = false;
        }


        datalistmoviereview.DataSource = ds;
        datalistmoviereview.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        //BollywoodMovieReview();
        HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('bollywoodMovieReview');", true);
    }
    protected void btnholymoviereview_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idgossip"] = null;
        // Session["idholymoviereview"] = null;

        if (Session["idholymoviereview"] == null)
        {
            Session["idholymoviereview"] = 8;
        }
        else
        {
            Session["idholymoviereview"] = (Convert.ToInt32(Session["idholymoviereview"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 '021AB351-3182-49DF-894C-888FA66EA59F', " + Session["idholymoviereview"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '021AB351-3182-49DF-894C-888FA66EA59F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnholymoviereview.Visible = false;
        }


        datalistholymoviereviw.DataSource = ds;
        datalistholymoviereviw.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        //HollywoodMovieReview();
        HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('hollywoodMovieReview');", true);
    }
    protected void btngossip_Click(object sender, ImageClickEventArgs e)
    {
        Session["idbangladrama"] = null;
        Session["idbanglamusic"] = null;
        Session["idbangladrama"] = null;
        Session["idenglish"] = null;
        Session["idhindimovie"] = null;
        Session["idbanglamovie"] = null;
        Session["idcelebritynews"] = null;
        Session["idmoviereview"] = null;
        Session["idholymoviereview"] = null;
        // Session["idgossip"] = null;
        if (Session["idgossip"] == null)
        {
            Session["idgossip"] = 8;
        }
        else
        {
            Session["idgossip"] = (Convert.ToInt32(Session["idgossip"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox6 'C1104876-012B-4B85-8E51-F84FA6CD6DBA', " + Session["idgossip"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'C1104876-012B-4B85-8E51-F84FA6CD6DBA'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btngossip.Visible = false;
        }


        datalistholygossip.DataSource = ds;
        datalistholygossip.DataBind();


        Banglamusic();
        Bangladramaclips();
        Englishmusic();
        Hindimovie();
        Banglamovie();
        BollywoodCelebrityNews();
        BollywoodMovieReview();
        HollywoodMovieReview();
        //HollywoodGossip();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie('gossip');", true);
    }
}