using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Movie : System.Web.UI.Page
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
            btnhindi.ImageUrl = "~/images/tele.png";
           btnbanglamovie.ImageUrl = "~/images/tele.png";
        }

        else if (sMsisdn.StartsWith("88019"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnhindi.ImageUrl = "~/images/blink.png";
            btnbanglamovie.ImageUrl = "~/images/blink.png";

        }
        else if (sMsisdn.StartsWith("88016"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheet.css");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnhindi.ImageUrl = "~/images/aro-video.png";
            btnbanglamovie.ImageUrl = "~/images/aro-video.png";

        }
        else
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnhindi.ImageUrl = "~/images/blink.png";
            btnbanglamovie.ImageUrl = "~/images/blink.png";

        }
       
        if (!IsPostBack)
        {
            BanglaMovies();
           // EnglishMovies();
            HindiMovie();
        }
    }
    public void BanglaMovies()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videoboxmovie 'E564F048-1AD7-450A-BA81-47409FC58BFE'", "WAPDB");
        datalistbanglamovie.DataSource = ds;
        datalistbanglamovie.DataBind();
        btnbanglamovie.Visible = true;
    }


    public void HindiMovie()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videoboxmovie '7E8B1C80-EB99-402C-BE1E-00E7F7C99A3F'", "WAPDB");
        datalisthindimovie.DataSource = ds;
        datalisthindimovie.DataBind();
        btnhindi.Visible = true;
    }
    protected void btnbanglamovie_Click(object sender, ImageClickEventArgs e)
    {
        Session["idhindi"] = null;
        if (Session["idm"] == null)
        {
            Session["idm"] = 8;
        }
        else
        {
            Session["idm"] = (Convert.ToInt32(Session["idm"]) + 4);
        }

        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 'E564F048-1AD7-450A-BA81-47409FC58BFE', " + Session["idm"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'E564F048-1AD7-450A-BA81-47409FC58BFE'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnbanglamovie.Visible = false;
        }


        datalistbanglamovie.DataSource = ds;
        datalistbanglamovie.DataBind();

        HindiMovie();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "banglamovie();", true);
    }
    protected void btnhindi_Click(object sender, ImageClickEventArgs e)
    {
        Session["idm"] = null;
        if (Session["idhindi"] == null)
        {
            Session["idhindi"] = 8;
        }
        else
        {
            Session["idhindi"] = (Convert.ToInt32(Session["idhindi"]) + 4);
        }
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox3 '7E8B1C80-EB99-402C-BE1E-00E7F7C99A3F', " + Session["idhindi"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox '7E8B1C80-EB99-402C-BE1E-00E7F7C99A3F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            btnhindi.Visible = false;
        }
        datalisthindimovie.DataSource = ds;
        datalisthindimovie.DataBind();
        BanglaMovies();
       

        ClientScript.RegisterStartupScript(GetType(), "hwa", "hindimovie();", true);
    }
}