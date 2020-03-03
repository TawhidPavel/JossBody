using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HSProfiling;
using UAprofileFinder;

public partial class Hs : System.Web.UI.Page
{
    CDA oCDA = new CDA();
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    string HS_MANUFAC = string.Empty;
    string APN = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string subStatus = string.Empty;
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
		if (isSubscribe(sMsisdn))
            {
                cancelSubscriptionBlink.Visible = true;
            }
        if (sMsisdn.StartsWith("88018"))
        {
           // Response.Redirect("Restricted.aspx");
        }

        #endregion "MSISDN"


        string scriptForBl = @" $(document).ready(function() {

           $('.ribonMusic').css('background-color','#58c1e6');
           
             
              });";

        string scriptForTT = @" $(document).ready(function() {

            $('.ribonMusic').css('background-color','#58c1e6');       
           });";
      
      
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

    
        if (!IsPostBack)
        {
            #region UAProfile_AND_Banner
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

            if (sMsisdn.StartsWith("88018"))
            {
              //  Response.Redirect("Restricted.aspx");
            }
            string UAPROF_URL = oUAProfile.GetUserAgent();
            try
            {
                HSProfiling.Service Profile = new HSProfiling.Service();
                var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

                HS_MANUFAC = HSProfiling.Manufacturer;
                HS_MOD = HSProfiling.Model;
                HS_DIM = HSProfiling.Dimension;
                HS_OS = HSProfiling.OS;
                UAPROF_URL = HSProfiling.UAXML;
            }
            catch { }
            //lblHandset.Text = "&nbsp;" + HS_MANUFAC + " " + HS_MOD;



            #endregion UAProfile_AND_Banner

            lblM.Text = sMsisdn;
            lblM1.Text = sMsisdn;
            DataSet dsWord = oCDA.GetDataSet("EXEC [FitnessPortal].[dbo].[sp_getHistory] '" + sMsisdn + "'", "BDTUBE");
            DataSet subStatusData = oCDA.GetDataSet("EXEC [FitnessPortal].[dbo].[spSubStatus1] '" + sMsisdn + "'", "BDTUBE");

            if (subStatusData != null)
            {
                grdMyAccount.DataSource = subStatusData;
                grdMyAccount.DataBind();
                
            }
            if (dsWord != null)
            {
                if (sMsisdn == "")
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = dsWord;
                    GridView1.DataBind();
                }
                
            }



        }
    }

    protected void lbkbtnCancelSubscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelSubscription.aspx");
    }

    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = oCDA.GetDataSet("EXEC [FitnessPortal].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


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
}