using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class header : System.Web.UI.UserControl
{
    UAProfile oUAProfile = new UAProfile();
    string sMobNo = string.Empty;
    string sPath = string.Empty;
    string sMsisdn = string.Empty;
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
       
        //sMsisdn = "8801955279938";

        #endregion "MSISDN"

        if (sMsisdn.StartsWith("88015")) { ha.Src = "~/images/header.jpg"; }
        else if (sMsisdn.StartsWith("88019")) { ha.Src = "~/images/header.jpg"; }
        else if (sMsisdn.StartsWith("88016")) { ha.Src = "~/images/header.jpg"; }
        else { ha.Src = "~/images/header.jpg"; }
        //if (sMsisdn.StartsWith("88019")) { cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css"); }
        ha.Src = "~/images/header.jpg";
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("serach.aspx?name="+txtserach.Text+"");
    }
}