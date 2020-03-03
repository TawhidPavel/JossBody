using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;


public partial class CancelSubscription : System.Web.UI.Page
{

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
    string subStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

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


        if (sMsisdn.StartsWith("88018") || sMsisdn.StartsWith("88016"))
        {
            DataSet ds = new DataSet();
            ds = oCDA.GetDataSet("Exec [FitnessPortal].dbo.spChkTypeStatus '" + sMsisdn + "'", "WAPDB");
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["Type"].ToString() == "DA")
                {
                    oCDA.ExecuteNonQuery("EXEC Robi_SDP.dbo.spInsertSubscriptionQ_To_SDP_channelID_1 '" + sMsisdn + "','0303900076','0300407908','Deletion'",
                        "ROBI");
                }
                else if (ds.Tables[0].Rows[0]["Type"].ToString() == "WA")
                {
                    oCDA.ExecuteNonQuery("EXEC Robi_SDP.dbo.spInsertSubscriptionQ_To_SDP_channelID_1 '" + sMsisdn + "','0303900076','0300407910','Deletion'",
                        "ROBI");
                }
                else if (ds.Tables[0].Rows[0]["Type"].ToString() == "DNA")
                {
                    oCDA.ExecuteNonQuery("EXEC Robi_SDP.dbo.spInsertSubscriptionQ_To_SDP_channelID_1 '" + sMsisdn + "','0303900077','0300407912','Deletion'",
                        "ROBI");
                }
                else if (ds.Tables[0].Rows[0]["Type"].ToString() == "WNA")
                {
                    oCDA.ExecuteNonQuery("EXEC Robi_SDP.dbo.spInsertSubscriptionQ_To_SDP_channelID_1 '" + sMsisdn + "','0303900077','0300407914','Deletion'",
                        "ROBI");
                }
                else if (ds.Tables[0].Rows[0]["Type"].ToString() == "Not")
                {
                   Response.Redirect("Default.aspx");
                }
            }
           

           
            //oCDA.ExecuteNonQuery("EXEC [Robi_SDP].[dbo].[spDeactivate_CZ_SB] '" + sMsisdn + "','BdTube'", "ROBI");
            ////EXEC Robi_SDP.dbo.spDeactivate_CZ_SB '8801814652546','BdTube'
            //oCDA.ExecuteNonQuery("EXEC [Partner_Basket].[dbo].[sp_setActiveDeactiveBdtube] '" + sMsisdn + "','0'", "BUDDY");
           // oCDA.ExecuteNonQuery("EXEC [FitnessPortal].[dbo].[sp_setActiveDeactiveFitnessPortal] '" + sMsisdn + "','0'", "BUDDY");
        }
        else
        {

            oCDA.ExecuteNonQuery("EXEC [FitnessPortal].[dbo].[sp_setActiveDeactiveFitnessPortal] '" + sMsisdn + "','0'", "BUDDY");
           


            if (sMsisdn.StartsWith("88016"))
            {
                /*try
                {
                    ATASE.Service objATASAE = new ATASE.Service();
                    objATASAE.ASESubscribe(sMsisdn, "vubdtube", "Deletion");
                }
                catch
                {
                }
                */


                string offMSG = "Your Fitness service has been Stopped. To START send START Fitness to 6624 or visit http://wap.shabox.mobi/fitnessclub Help : 01674985965";

                oCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + sMsisdn + "','" + offMSG + "'", "WAPDB");
            }
            else
            {
                string offMSG = "Fitness service is off now. To restart START Fitness and send to 6624.";
                //string  offMSG = "Your BdTube service has been Stopped. To START send START BDTUBE to 6624 or visit http://bdtube.mobi/ Help : 01674985965";

                oCDA.ExecuteNonQuery("EXEC Partner_API.dbo.spSendSMS '" + sMsisdn + "','" + offMSG + "'", "WAPDB");
            }


        }
    }
}