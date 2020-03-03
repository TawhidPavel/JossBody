using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;
public partial class Newvideo : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    DataSet dscount = new DataSet();
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
           // Response.Redirect("Restricted.aspx");
        }

        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";

            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

        if (!isSubscribe(sMsisdn))
        {
            if (sMsisdn.StartsWith("88018"))
            {
                Response.Redirect("Confirmation.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");

            }
        }
        if (!IsPostBack)
            {
                Session["mostLike"] = null;
                  newvideo();
            }
           
    }
     public bool isSubscribe(string MSISDN)
    {
        string subStatus= String.Empty;
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
            return false;
        }

    }
    public void newvideo()
    
    {
        ds = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_getContentsBySubcategoryID_Latest '44EAE2BC-F85F-483E-9C8E-B76D84114C00', 6", "WAPDB");
        dataListnewvideo.DataSource = ds;
        dataListnewvideo.DataBind();
       // btnbanglamovie.Visible = true;
    }

    protected void btnLikeMore_Click(object sender, ImageClickEventArgs e)
    {
        dscount = CA.GetDataSet("Exec FitnessPortal.dbo.[Sp_getContentsBySubcategoryID_Latest] 'A2106AB1-A41B-41C4-96FC-42971B8F84C5', " + 25000 + "", "WAPDB");

        if (Session["mostLike"] == null)
        {
            Session["mostLike"] = 10;
        }
        else
        {
            Session["mostLike"] = (Convert.ToInt32(Session["mostLike"]) + 4);
        }

        ds = CA.GetDataSet("Exec FitnessPortal.dbo.[Sp_getContentsBySubcategoryID_Latest] 'A2106AB1-A41B-41C4-96FC-42971B8F84C5', " + Session["mostLike"] + "", "WAPDB");
        //dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;

        if (videocount == morecount)
        {
            imgButtonMore.Visible = false;
        }

        dataListnewvideo.DataSource = ds;
        dataListnewvideo.DataBind();
    }
}