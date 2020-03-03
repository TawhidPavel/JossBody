using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class foter : System.Web.UI.UserControl
{
    MSISDNTrack ms = new MSISDNTrack();
    string msisdnm = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        year.Text = DateTime.Now.Year.ToString();
        if (Session["MSISDN"] == null)
        {
            msisdnm = ms.GetMSISDN();
        }
        else
        {
            msisdnm = Session["MSISDN"].ToString();
        }

        if (msisdnm.StartsWith("88016"))
        {
            blink.Visible = true;

        }
        else if (msisdnm.StartsWith("88015"))
        {
            blink.Visible = true;


        }
        else if (msisdnm.StartsWith("88019"))
        {
            blink.Visible = true;

        }
        else if (msisdnm.StartsWith("88017"))
        {
            blink.Visible = true;
           // history.Visible = true;
        }
        else
        {
            blink.Visible = true;

           
        }
    }
}