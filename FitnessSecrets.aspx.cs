using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class FitnessSecrets : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    DataSet dscount = null;
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    DataSet dsPage = new DataSet();
    string HS_MANUFAC = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = String.Empty;
    string OPERATOR = String.Empty;
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
       
        if (!IsPostBack)
        {
            userInfo();
            dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "FitnessSecrets" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
            loadFitnessSecrets();
        }
    }

    private void loadFitnessSecrets()
    {
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5',4", "WAPDB");
        repeaterFitnessSecrets.DataSource = ds;
        repeaterFitnessSecrets.DataBind();
       
    }
    private void userInfo()
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
                if (sMsisdn.StartsWith("88018"))
                {
                    OPERATOR = "Robi";
                }

                if (sMsisdn.StartsWith("88016"))
                {
                    OPERATOR = "Airtel";
                }

                if (sMsisdn.StartsWith("88019"))
                {
                    OPERATOR = "Banglalink";
                }

                if (sMsisdn.StartsWith("88015"))
                {
                    OPERATOR = "Teletalk";
                }

            }
        }
        catch //(Exception ex)
        {
            sMsisdn = string.Empty;

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

        }
        catch
        {


        }
    }
}