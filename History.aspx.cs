using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;
using HSProfiling;

public partial class Support : System.Web.UI.Page
{
    int Serial = 0;
    int Serial2 = 0;
    CDA oCDA = new CDA();
    UAProfile oUAProfile = new UAProfile();
    string FOLDER = string.Empty;
    string sPath = string.Empty;
    string sMsisdn = string.Empty;
    string HS_MANUFAC = string.Empty;
    string APN = string.Empty;
    string UAPROF_URL = string.Empty;
    string HS_DIM = string.Empty;
    string HS_MOD = string.Empty;
    string HS_OS = string.Empty;
    string subStatus2 = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
       // Year.Text = DateTime.Now.Year.ToString();
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
            
            string UAPROF_URL = oUAProfile.GetUserAgent();
            try
            {
                HSProfiling.Service Profile = new HSProfiling.Service();
                //HSProfiling. Profile = new HS_Profiling.ServiceSoapClient();
                var HSProfiling = Profile.HansetDetection(UAPROF_URL, oUAProfile.GetUAProfileXWap());

                HS_MANUFAC = HSProfiling.Manufacturer;
                HS_MOD = HSProfiling.Model;
                HS_DIM = HSProfiling.Dimension;
                HS_OS = HSProfiling.OS;
                UAPROF_URL = HSProfiling.UAXML;
            }
            catch { }
            lblHandset.Text = "&nbsp;" + HS_MANUFAC + " " + HS_MOD;

            //hlHome.NavigateUrl = "~/Default.aspx";
            //hlSupport.NavigateUrl = "~/Support.aspx";

            string scriptForBl = @" $(document).ready(function() {

           $('.robititle').css('background-color','#58C1E6');
           
             
              });";


            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            #region "TopHeader"
            try
            {
                if (string.IsNullOrEmpty(HS_DIM))
                {
                    throw new Exception();
                }
                else
                {
                    FOLDER = "D" + HS_DIM;
                }
            }
            catch //(Exception ex)
            {
                FOLDER = "D320x240";
            }
            #endregion "TopHeader"

            object dim = oCDA.getSingleValue("EXEC spGetDimensionByCategoryCode'" + "3F0996CC-94DB-4C87-8EEE-790D79C42593" + "','" + FOLDER + "'", "WAPDB");
            if (dim != null)
            {
                if (dim.ToString() == "Y")
                {
                    sPath = "http://wap.shabox.mobi/CMS/UIHeader/" + FOLDER + "/";
                }
                else if (dim.ToString() == "N")
                {
                    string bestfitCat = oUAProfile.ClosestMinimumFinder(HS_DIM, "Wallpaper");
                    sPath = "http://wap.shabox.mobi/CMS/UIHeader/" + bestfitCat + "/";
                }
            }
            else
            {
                sPath = "~http://wap.shabox.mobi/CMS/UIHeader/D320x240/";
            }

            if (sMsisdn.StartsWith("88015"))
            {
                lnkHeader.ImageUrl = sPath + "BD_Tub_Header_TT.jpg";
                cssTemplate.Attributes.Add("href", "~/StyleSheet/StyleSheetTT.css");
            }
            else if (sMsisdn.StartsWith("88018"))
            {
                lnkHeader.ImageUrl = sPath + "Robi_bdtube_header.jpg";
                cssTemplate.Attributes.Add("href", "~/StyleSheet/StyleSheetRobi.css");
            }
            else if (sMsisdn.StartsWith("88016"))
            {
                lnkHeader.ImageUrl = sPath + "Robi_bdtube_header.jpg";
                cssTemplate.Attributes.Add("href", "~/StyleSheet/StyleSheetRobi.css");
            }
            else if (sMsisdn.StartsWith("88017"))
            {
                lnkHeader.ImageUrl = sPath + "BD_Tub_Header_GP.jpg";
                //scrollBanner.ImageUrl = sPath + "BD_Tub_Header_Header.jpg";
                cssTemplate.Attributes.Add("href", "~/StyleSheet/StyleSheetGP.css");

            }
            else if (sMsisdn.StartsWith("88019"))
            {
                lnkHeader.ImageUrl = sPath + "BDtube.jpg";
            }
            else
            {
                lnkHeader.ImageUrl = sPath + "BDtube.jpg";

            }


            //lnkHeader.ImageUrl = sPath + "BDtube.jpg";
            //lnkHeader.NavigateUrl = "~/Default.aspx";

            //lnkFooter.ImageUrl = sPath + "Shabox_Buddy_Footer.jpg";
            //lnkFooter.NavigateUrl = "~/Default.aspx";            

            #endregion UAProfile_AND_Banner  

            DataSet dsWord = oCDA.GetDataSet("SELECT TOP (20) MSISDN, CONTENT_TITLE, CONTENT_TYPE_SHORT, CAST (TIME_STAMP AS  datetime) AS Date, ChargingReply FROM tbl_Success_BDTUBE WHERE (MSISDN = '" + sMsisdn + "') ORDER BY TIME_STAMP DESC", "BDTUBE");

            if (dsWord != null)
            {
                RptTopScore.DataSource = dsWord.Tables[0].Rows;
                RptTopScore.DataBind();
            }

            //DataSet subStatusData = oCDA.GetDataSet("SELECT MSISDN, RegDate, ReActivationDate, DeactivationDate FROM tbl_Subscriber_BDTUBE WHERE (MSISDN = '" + sMsisdn + "') ORDER BY TimeStamp DESC", "BDTUBE");

            DataSet subStatusData = oCDA.GetDataSet("EXEC[Partner_Basket].[dbo].[spSubStatus] '" + sMsisdn + "'", "BDTUBE");

            if (subStatusData != null)
            {
                subStatus.DataSource = subStatusData.Tables[0].Rows;
                subStatus.DataBind();
            }


        }

        if ((sMsisdn.StartsWith("88019") || sMsisdn.StartsWith("88018")) && isSubscribe(sMsisdn))
        {
            //cancelSubscription.Visible = true;
        }


    }

    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = oCDA.GetDataSet("EXEC [Partner_Basket].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


        if (dsExt != null)
        {
            subStatus2 = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        if (subStatus2 == "Active")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected void RptTopScore_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Serial++;
            Label SL = e.Item.FindControl("lblSL") as Label;
            Label MSISDN = e.Item.FindControl("lblMSISDN") as Label;
            Label Game = e.Item.FindControl("lblGame") as Label;
            Label Charge = e.Item.FindControl("lblCharge") as Label;
            Label Time = e.Item.FindControl("lblDownloadTime") as Label;

            DataRow drWord = e.Item.DataItem as DataRow;

            SL.Text = Serial.ToString();
            MSISDN.Text = drWord.ItemArray[0].ToString();
            Game.Text = drWord.ItemArray[1].ToString().Replace("_", " ");
            //Charge.Text = drWord.ItemArray[3].ToString();
            if (drWord.ItemArray[4].ToString() == "24.35")
            {
                Charge.Text = drWord.ItemArray[4].ToString();
            }
            else if (drWord.ItemArray[4].ToString() == "2.44")
            {
                Charge.Text = "2.44";
            }
            else
            {
                Charge.Text = "0.00";
            }

            Time.Text = drWord.ItemArray[3].ToString();
        }
    }

    protected void subStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Serial2++;
            Label SL2 = e.Item.FindControl("lblSL2") as Label;
            Label MSISDN = e.Item.FindControl("lblMSISDN") as Label;
            Label RegDate = e.Item.FindControl("lblRegDate") as Label;
            Label ReAcDate = e.Item.FindControl("lblReAcDate") as Label;
            Label DeAcDate = e.Item.FindControl("lblDeAcDate") as Label;

            DataRow subStatusData = e.Item.DataItem as DataRow;

           // SL2.Text = Serial2.ToString();
            MSISDN.Text = subStatusData.ItemArray[0].ToString();
            RegDate.Text = subStatusData.ItemArray[1].ToString();
            ReAcDate.Text = subStatusData.ItemArray[2].ToString();
            DeAcDate.Text = subStatusData.ItemArray[3].ToString();

        }
    }
}
