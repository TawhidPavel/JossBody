using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Fav : System.Web.UI.Page
{
    CDA CA = new CDA();
    DataSet ds = null;
    DataSet datasetFav = null;
    //UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;
    string sMobNo = string.Empty;
    UAProfile oUAProfile = new UAProfile();
    private int total;
    //String sMsisdn = String.Empty;
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
            btnmoviereview.ImageUrl = "~/images/more.png";

        
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
            loadFavList();
        }

    }

    private void loadFavList()
    {
        ds = CA.GetDataSet("Exec [FitnessPortal].dbo.[Sp_Fav_Fitness] '" + sMsisdn + "'", "WAPDB");
        if (ds != null)
        {
            total = ds.Tables[0].Rows.Count;
            Session["total"] = total;
            btnmoviereview.Visible = total > 10;
            datasetFav = CA.GetDataSet("Exec [FitnessPortal].dbo.[Sp_Fav_Fitness] '" + sMsisdn + "','" + 10 + "'", "WAPDB");
            if (sMsisdn == "")
            {
                dataListFav.DataSource = null;
                btnmoviereview.Visible = false;
                dataListFav.DataBind();
            }
            else
            {
                dataListFav.DataSource = datasetFav;
                dataListFav.DataBind();
            }
        }

    }

    protected void btnmoviereview_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["fav"] == null)
        {
            Session["fav"] = 14;
        }
        else
        {
            Session["fav"] = (Convert.ToInt32(Session["idbanglanatok"]) + 4);
        }
        int number = Convert.ToInt32(Session["fav"]);
        datasetFav = CA.GetDataSet("Exec [FitnessPortal].dbo.[Sp_Fav_Fitness] '" + sMsisdn + "','" + number + "'", "WAPDB");
        int morecount = datasetFav.Tables[0].Rows.Count;
        if (Convert.ToInt32(Session["total"]) == morecount)
        {
            btnmoviereview.Visible = false;
        }
       
        
        
        dataListFav.DataSource = datasetFav;
        dataListFav.DataBind();
    }
}