using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HC.UI.Model;
using UAprofileFinder;

public partial class Nibondhon : System.Web.UI.Page
{
    string type = String.Empty;
    string type1 = String.Empty;
    string auto = String.Empty;
    CDA CA = new CDA();
    MSISDNTrack ms = new MSISDNTrack();
    UAProfile oUAProfile = new UAProfile();
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string HS_MANUFAC = string.Empty;
    string SOURCE_URL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string msisdn = ms.GetMSISDN();
		if (!msisdn.StartsWith("8801"))
        {
            Response.Redirect("CheckOperator.aspx");
        }
        Image3.ImageUrl = "~/Images/baaad.jpg";
        try
        {
            type1 = Request.QueryString["Type"].ToString();
            type = type1.Substring(0, 1);
            auto = type1.Substring(1,1);
        }
        catch { }
        if (!isSubscribe(msisdn))
        {
            subscribeuser(type, auto);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        
    }

    private void subscribeuser(string types, string autos)
    {
        string msisdnN = ms.GetMSISDN();
        DataSet DNDMno = CA.GetDataSet("EXEC [WapPortal_CMS].dbo.spCheckDNDMno '" + msisdnN + "','Fitnss','6624'",
            "WAPDB");
        string DNDMobileNo = string.Empty;
        try
        {
            DNDMobileNo = DNDMno.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        catch
        {

        }
        try
        {
            string UAPROF_URL = oUAProfile.GetUserAgent();
            SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            HSProfiling.Service Profile = new HSProfiling.Service();
            var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

            HS_MANUFAC = HSProfiling.Manufacturer;
            HS_MOD = HSProfiling.Model;
            HS_DIM = HSProfiling.Dimension;
            HS_OS = HSProfiling.OS;
            UAPROF_URL = HSProfiling.UAXML;

            if (HS_OS == "Desktop")
            {
                Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=OS");
            }
            else if (HS_MANUFAC == "Generic" || HS_MOD == "Generic")
            {
                Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=Mobile");

            }


        }
        catch
        {
            Response.Redirect("http://wap.shabox.mobi/Error/Default.aspx?id=OS");
        }

        if (DNDMobileNo == "Y")
        {
            Response.Redirect("~/ErrorMessage.aspx?type=dnd");
        }
        if (types == "d" && autos == "t")
        {
           
            string msisdn = ms.GetMSISDN();
            //string Package = "FC";
            //CA.ExecuteNonQuery("EXEC [Partner_API].[dbo].[spProcessRequestOnlineAdvertisement] '" + msisdn + "','" + Package + "'", "WAPDB");
            RobiDoubleConfirm rs = new RobiDoubleConfirm();
            Response.Redirect(rs.GetLink(msisdn, "http://amarfitness.com/", "0300407908"),true);
        }
        else if (types == "w" && autos == "t")
        {
            string msisdn = ms.GetMSISDN();
            //string Package = "FCW";
            //CA.ExecuteNonQuery("EXEC [Partner_API].[dbo].[spProcessRequestOnlineAdvertisement] '" + msisdn + "','" + Package + "'", "WAPDB");
            RobiDoubleConfirm rs = new RobiDoubleConfirm();
            Response.Redirect(rs.GetLink(msisdn, "http://amarfitness.com/", "0300407910"), true);
        }
        else if (types == "d" && autos == "f")
        {
            string msisdn = ms.GetMSISDN();
            //string Package = "FCDN";
            //CA.ExecuteNonQuery("EXEC [Partner_API].[dbo].[spProcessRequestOnlineAdvertisement] '" + msisdn + "','" + Package + "'", "WAPDB");
            RobiDoubleConfirm rs = new RobiDoubleConfirm();
            Response.Redirect(rs.GetLink(msisdn, "http://amarfitness.com/", "0300407912"), true);
        }
        else if (types == "w" && autos == "f")
        {
            string msisdn = ms.GetMSISDN();
            //string Package = "FCWN";
            //CA.ExecuteNonQuery("EXEC [Partner_API].[dbo].[spProcessRequestOnlineAdvertisement] '" + msisdn + "','" + Package + "'", "WAPDB");
            RobiDoubleConfirm rs = new RobiDoubleConfirm();
            Response.Redirect(rs.GetLink(msisdn, "http://amarfitness.com/", "0300407914"), true);
        }
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
}