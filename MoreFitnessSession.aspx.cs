using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class MoreFitnessSession : System.Web.UI.Page
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
           // Response.Redirect("Restricted.aspx");
        }

        #endregion "MSISDN"

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
        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58C1E6');
           
             
              });";




        cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
        if (!IsPostBack)
        {
            string type = String.Empty;
            try
            {
                
                type = Request.QueryString["type"];
                userInfo();
                UAPROF_URL = Request.UserAgent;
                if (type == null)
                {
                    Response.Redirect("Default.aspx");
                    
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }

            if (type == "zumba")
            {
                dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "Zumba" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
                loadZumbaDetails();
            }
            else if (type == "yoga")
            {
                dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "Yoga" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
                loadYogaDetails();
            }
            else if (type == "easy")
            {
                dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "EasyWorkOut" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
                loadEasyDetails();
            }
            else if (type == "fitnessSecrets")
            {
                dsPage = CA.GetDataSet("Exec [sp_PerPageAccessLog] '" + "fitness.mobi" + "','" + "FitnessSecrets" + "','" + sMsisdn + "','" + UAPROF_URL + "','" + HS_MANUFAC + "','" + HS_MOD + "','" + HS_DIM + "','" + HS_OS + "','" + oUAProfile.GetUserIP() + "'", "WAPDB");
                loadFitnessSecrets();
            }

        }
        

     
    }
    public bool isSubscribe(string MSISDN)
    {
        string subStatus = String.Empty;
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

    private void loadFitnessSecrets()
    {
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5'", "WAPDB");
        dataListFitnessSecrets.DataSource = ds;
        dataListFitnessSecrets.DataBind();
        ImageButtonFs.Visible = true;
        divFitnessSecrets.Visible = true;
       
    }

    private void loadEasyDetails()
    {
        ds = CA.GetDataSet("Exec  FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'E0AEF450-099B-495F-B056-8AED4B95F00A'", "WAPDB");
        dataListEasy.DataSource = ds;
        dataListEasy.DataBind();
        ImageButtonEasy.Visible = true;
        divEasy.Visible = true;
    }

    private void loadYogaDetails()
    {
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '44EAE2BC-F85F-483E-9C8E-B76D84114C00'", "WAPDB");
        dataListYoga.DataSource = ds;
        dataListYoga.DataBind();
        ImageButtonYoga.Visible = true;
        divYoga.Visible = true;
    }


    private void loadZumbaDetails()
    {
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '413623EB-E3BF-4494-8BB8-0302473A91A1'", "WAPDB");
        dataListZumba.DataSource = ds;
        dataListZumba.DataBind();
        imgButtonZumba.Visible = true;
        divZumba.Visible = true;
    }
    


    protected void btnZumba_Click(object sender, ImageClickEventArgs e)
    {
        dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '413623EB-E3BF-4494-8BB8-0302473A91A1', " + 25000 + "", "WAPDB");

        Session["yoga"] = null;
        Session["easy"] = null;
        Session["fs"] = null;
        if (Session["zumba"] == null)
        {
            Session["zumba"] = 8;
        }
        else
        {
            Session["zumba"] = (Convert.ToInt32(Session["zumba"]) + 4);
        }
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '413623EB-E3BF-4494-8BB8-0302473A91A1', " + Session["zumba"] + "", "WAPDB");
       // dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '413623EB-E3BF-4494-8BB8-0302473A91A1'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;
        if (videocount == morecount)
        {
            imgButtonZumba.Visible = false;
        }

        dataListZumba.DataSource = ds;
        dataListZumba.DataBind();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);
    }

    protected void btnYoga_Click(object sender, ImageClickEventArgs e)
    {
        dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '44EAE2BC-F85F-483E-9C8E-B76D84114C00', " + 25000 + "", "WAPDB");
       
        Session["zumba"] = null;
        Session["easy"] = null;
        Session["fs"] = null;
        if (Session["yoga"] == null)
        {
            Session["yoga"] = 8;
        }
        else
        {
            Session["yoga"] = (Convert.ToInt32(Session["yoga"]) + 4);
        }
        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness '44EAE2BC-F85F-483E-9C8E-B76D84114C00', " + Session["yoga"] + "", "WAPDB");
       // dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'CEBF2EA8-1FB3-4E64-AAD2-C5320EB6A23F'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;
        if (videocount == morecount)
        {
            ImageButtonYoga.Visible = false;
        }

        dataListYoga.DataSource = ds;
        dataListYoga.DataBind();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);
    }

    protected void btnEasy_Click(object sender, ImageClickEventArgs e)
    {
        dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'E0AEF450-099B-495F-B056-8AED4B95F00A', " + 25000 + "", "WAPDB");

        Session["zumba"] = null;
        Session["yoga"] = null;
        Session["fs"] = null;
        if (Session["easy"] == null)
        {
            Session["easy"] = 8;
        }
        else
        {
            Session["easy"] = (Convert.ToInt32(Session["easy"]) + 4);
        }

        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'E0AEF450-099B-495F-B056-8AED4B95F00A', " + Session["easy"] + "", "WAPDB");
        //dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'E0AEF450-099B-495F-B056-8AED4B95F00A'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;

        if (videocount == morecount)
        {
            ImageButtonEasy.Visible = false;
        }

        dataListEasy.DataSource = ds;
        dataListEasy.DataBind();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);
    }

    protected void btnFs_Click(object sender, ImageClickEventArgs e)
    {
        dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5', " + 25000 + "", "WAPDB");

        Session["zumba"] = null;
        Session["yoga"] = null;
        Session["easy"] = null;
        if (Session["fs"] == null)
        {
            Session["fs"] = 8;
        }
        else
        {
            Session["fs"] = (Convert.ToInt32(Session["fs"]) + 4);
        }

        ds = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5', " + Session["fs"] + "", "WAPDB");
        //dscount = CA.GetDataSet("Exec FitnessPortal.dbo.Sp_getContentsByCategoryID_fitness 'A2106AB1-A41B-41C4-96FC-42971B8F84C5'", "WAPDB");
        int videocount = ds.Tables[0].Rows.Count;
        int morecount = dscount.Tables[0].Rows.Count;

        if (videocount == morecount)
        {
            ImageButtonFs.Visible = false;
        }

        dataListFitnessSecrets.DataSource = ds;
        dataListFitnessSecrets.DataBind();
        ClientScript.RegisterStartupScript(GetType(), "hwa", "BanglaNatok();", true);
    }
}