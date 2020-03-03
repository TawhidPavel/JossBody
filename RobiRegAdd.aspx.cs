using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class RobiRegAdd : System.Web.UI.Page
{
    UAProfile oUAProfile = new UAProfile();
    CDA CA = new CDA();
    string subStatus = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string number = oUAProfile.GetMSISDN();
        if (isSubscribe(number))
        {
            Response.Redirect("Default.aspx");

        }
        imgTitle.ImageUrl = "~/Images/bdtubeAdd.png";
        imgBatil.ImageUrl = "~/Images/batil.jpg";
    }

    protected void btnAdd_OnClick(object sender, ImageClickEventArgs e)
    {
        string number = oUAProfile.GetMSISDN();
        if (!isSubscribe(number))
        {
            Response.Redirect("RobiConfirm.aspx");

        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

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
}