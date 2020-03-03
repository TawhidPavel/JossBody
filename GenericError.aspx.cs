using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class GenericError : System.Web.UI.Page
{
    CDA objCDA=new CDA();
    UAProfile oUAProfile = new UAProfile();
    string MSISDN = String.Empty;
    string sMsisdn = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void report_OnClick(object sender, EventArgs e)
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
            sMsisdn = "Wifi";

        }
        MSISDN = "8801622595292";
      //  objCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + MSISDN + "', '404 Error BDTube from User " + sMsisdn + " , Need To check BDTube portal urgently!!!'", "WAPDB");
        MSISDN = "8801913828774";
        objCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + MSISDN + "', '404 Error BDTube" + sMsisdn + " , Need To check BDTube portal urgently!!!'", "WAPDB");
        MSISDN = "8801814652539";
        objCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + MSISDN + "', '404 Error BDTube'"+ sMsisdn+" , Need To check BDTube portal urgently!!!'", "WAPDB");
        thnks.Visible = true;
    }
}