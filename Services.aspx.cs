using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services : System.Web.UI.Page
{
    MSISDNTrack ms = new MSISDNTrack();
    string sMsisdn = String.Empty;
    CDA db = new CDA();
     string  subStatus= String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
         try
            {
                sMsisdn = ms.GetMSISDN();
            }
            catch //(Exception ex)
            {
                sMsisdn = string.Empty;

            }
      
     

      
        string scriptForBl = @" $(document).ready(function() {

           $('.ribonMusic').css('background-color','#58C1E6');
           
             
              });";
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);
            blink.Style.Add("display","block");
            if (isSubscribe(sMsisdn))
            {
                cancelSubscriptionBlink.Visible = true;
            }

     


    }

    protected void lbkbtnCancelSubscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelSubscription.aspx");
    }


    public bool isSubscribe(string MSISDN)
    {
        return true;
        DataSet dsExt = null;
        //dsExt = oCDA.GetDataSet("EXEC WapPortal_CMS.dbo.spGetExtensionByCategoryCodeandSpecification '" + sCategoryCode + "','" + Specification + "'", "WAPDB");
        //string Extenstion = dsExt.Tables[0].Rows[0].ItemArray[0].ToString();

        dsExt = db.GetDataSet("EXEC [Partner_Basket].[dbo].[spChkSubStatus] '" + MSISDN + "'", "WAPDB");


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