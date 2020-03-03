using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class Help : System.Web.UI.Page
{
    UAProfile oUAProfile = new UAProfile();
    string sMsisdn = String.Empty;

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

        if (sMsisdn.StartsWith("88018"))
        {
            Response.Redirect("Restricted.aspx");
        }
        string scriptForBl = @" $(document).ready(function() {

           $('.ribonMusic').css('background-color','#F16521');
           
             
              });";

        string scriptForTT = @" $(document).ready(function() {

            $('.ribonMusic').css('background-color','#71BD44');       
           });";



        if (sMsisdn.StartsWith("88015"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetTT.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForTT, true);
        }

        if (sMsisdn.StartsWith("88019"))
        {
            cssTemplate.Attributes.Add("href", "~/Css/StyleSheetBL.css");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScriptName", scriptForBl, true);

        }
    }
}