using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Confirmation : System.Web.UI.Page
{
    CDA CA = new CDA();
    MSISDNTrack ms = new MSISDNTrack();
    UAProfile oUAProfile = new UAProfile();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";

        // Image3.ImageUrl = "~/Images/baaad.jpg";
        string number = oUAProfile.GetMSISDN();
        if(isSubscribe(number))
        {
            Response.Redirect("Default.aspx");
        }

    }

    protected void btnAdd_OnClick(object sender, ImageClickEventArgs e)
    {
        string number = oUAProfile.GetMSISDN();
        Response.Redirect(!isSubscribe(number) ? "~/RobiConfirmRenewal.aspx" : "Default.aspx");
    }

    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        // dsExt = CA.GetDataSet("EXEC [Partner_Basket].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");
        dsExt = CA.GetDataSet("EXEC [FitnessPortal].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");
        string subStatus = String.Empty;


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

    protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
    {
        string number = oUAProfile.GetMSISDN();
        Response.Redirect(!isSubscribe(number) ? "~/RobiConfirmNonRenewal.aspx" : "Default.aspx");
    }
}