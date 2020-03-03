using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class serach : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    UAProfile oUAProfile = new UAProfile();
    string contentname = String.Empty;
    String sMsisdn = String.Empty;
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

       
       
        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";

     
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

        if (!IsPostBack)
        {
            display();
        }
           
    }
    public void display()
    {
        try
        {
            contentname = Request.QueryString["name"].ToString();
        }
        catch
        {

        }
        //ds = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_Search_fitness_All N'" + contentname + "'", "WAPDB");
		ds = CA.GetDataSet("Exec [FitnessPortal].dbo.Sp_Search_fitness N'" + contentname + "'", "WAPDB");
        if(ds!=null)
        {
            dataListnewvideo.DataSource = ds;
            dataListnewvideo.DataBind();
        }
        else
        {
            lblresult.Text = "No info Found";
        }
        
        // btnbanglamovie.Visible = true;
    }
}