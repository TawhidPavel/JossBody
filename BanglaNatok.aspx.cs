using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;
public partial class BanglaNatok : System.Web.UI.Page
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

        if (sMsisdn.StartsWith("88018"))
        {
            Response.Redirect("Restricted.aspx");
        }

        #endregion "MSISDN"


        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58C1E6');
           
             
              });";




        cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
        ImageButton2.ImageUrl = "~/images/more.png";



        if (!IsPostBack)
        {
            BnNatok();

        }
    }


    private void BnNatok()
    {
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox1 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F'", "WAPDB");
        dalaListBanglaNatok.DataSource = ds;
        dalaListBanglaNatok.DataBind();
        ImageButton2.Visible = true;
    }


    protected void btnbanglaNatok_Click(object sender, ImageClickEventArgs e)
    {
        Session["idm"] = null;
        Session["idenglishmusic"] = null;
        if (Session["idbanglanatok"] == null)
        {
            Session["idbanglanatok"] = 8;
        }
        else
        {
            Session["idbanglanatok"] = (Convert.ToInt32(Session["idbanglanatok"]) + 4);
        }
        ds = CA.GetDataSet("Exec Sp_FullvideoContents_videobox1 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F', " + Session["idbanglanatok"] + "", "WAPDB");
        dscount = CA.GetDataSet("Exec sp_videoCount_videobox 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = Convert.ToInt32(dscount.Tables[0].Rows[0]["value"]);
        if (videocount == morecount)
        {
            ImageButton2.Visible = false;
        }

        dalaListBanglaNatok.DataSource = ds;
        dalaListBanglaNatok.DataBind();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);

    }



}