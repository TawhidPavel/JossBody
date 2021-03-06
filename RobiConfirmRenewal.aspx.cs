﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class RobiConfirmRenewal : System.Web.UI.Page
{
    CDA CA = new CDA();
    MSISDNTrack ms = new MSISDNTrack();
    UAProfile oUAProfile = new UAProfile();
    protected void Page_Load(object sender, EventArgs e)
    {
        string scriptForBl = @" $(document).ready(function() {

           $('.vdtitle').css('background-color','#58c1e6');
           
             
              });";
        Image3.ImageUrl = "~/Images/baaad.jpg";

    }

    protected void btnAdd_OnClick(object sender, ImageClickEventArgs e)
    {
        string number = oUAProfile.GetMSISDN();
        Response.Redirect(!isSubscribe(number) ? "~/Nibondhon.aspx?Type=dt" : "Default.aspx");
    }

    public bool isSubscribe(string MSISDN)
    {
        DataSet dsExt = null;
        dsExt = CA.GetDataSet("EXEC [FitnessPortal].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");
        var subStatus = String.Empty;


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
        Response.Redirect(!isSubscribe(number) ? "~/Nibondhon.aspx?Type=wt" : "Default.aspx");
    }
}