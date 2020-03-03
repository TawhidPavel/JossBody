using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class boschorShera : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    DataSet datasetShera = null;
    //UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    string sMobNo = string.Empty;
    UAProfile oUAProfile = new UAProfile();
    private int total;
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
            btnmoviereview.ImageUrl = "~/images/tele.png";
        }


        else if (sMsisdn.StartsWith("88019"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnmoviereview.ImageUrl = "~/images/blink.png";

        }
        else if (sMsisdn.StartsWith("88016"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheet.css");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnmoviereview.ImageUrl = "~/images/aro-video.png";

        }
        else
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            btnmoviereview.ImageUrl = "~/images/blink.png";
        }
        #region MSISDN
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
        #endregion MSISDN

        if (!IsPostBack)
        {
            loadSheraList();
            Session["shera"] = null;
        }
    }

    private void loadSheraList()
    {
        string title = "newyear_video";

        ds = CA.GetDataSet("Exec [sp_MustWatch_bdtube1] '" + title + "'", "WAPDB");
        if (ds != null)
        {
            total = ds.Tables[0].Rows.Count;
            Session["total"] = total;
            btnmoviereview.Visible = total > 4;
            datasetShera = CA.GetDataSet("Exec[sp_MustWatch_bdtube1] '" + title + "','" + 4 + "'", "WAPDB");
           
                dataListShera.DataSource = datasetShera;
                dataListShera.DataBind();
            
        }
    }

    protected void btnsheraview_Click(object sender, ImageClickEventArgs e)
    {
        string title = "newyear_video";
        ds = CA.GetDataSet("Exec [sp_MustWatch_bdtube1] '" + title + "','" + 1000 + "'", "WAPDB");
        Session["TotalForMore"] = ds.Tables[0].Rows.Count;
        if (Session["shera"] == null)
        {
            Session["shera"] = 8;
        }
        else
        {
            Session["shera"] = (Convert.ToInt32(Session["shera"]) + 4);
        }
        int number = Convert.ToInt32(Session["shera"]);
        datasetShera = CA.GetDataSet("Exec[sp_MustWatch_bdtube1] '" + title + "','" + number + "'", "WAPDB");
        int morecount = datasetShera.Tables[0].Rows.Count;
        if (Convert.ToInt32(Session["TotalForMore"]) == morecount)
        {
            btnmoviereview.Visible = false;
        }


        dataListShera.DataSource = datasetShera;
        dataListShera.DataBind();
    }
}