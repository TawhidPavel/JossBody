using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UAprofileFinder;

public partial class OtherLinks : System.Web.UI.UserControl
{
    MSISDNTrack ms = new MSISDNTrack();
    string msisdnm = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //year.Text = DateTime.Now.Year.ToString();
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
            //airtel.Style.Add("display", "block");
            gameclub.ImageUrl = "Ic/agc.png";
            gameclub.PostBackUrl = "http://wap.airtelzone.mobi";
            lg.PostBackUrl = "http://wap.airtelzone.mobi/Pages/OnlineGames.aspx";
            quiz.Visible = false;
        }
        else if (msisdnm.StartsWith("88015"))
        {
           // teletalk.Style.Add("display", "block");
            gameclub.ImageUrl = "Ic/tgc.png";
            gameclub.PostBackUrl = "http://wap.teletalkgamezone.mobi/";
            lg.PostBackUrl = "http://wap.airtelzone.mobi/Pages/OnlineGames.aspx";
            quiz.Visible = false;


        }
        else if (msisdnm.StartsWith("88019"))
        {
            //blink.Style.Add("display", "block");
            gameclub.ImageUrl = "Ic/bgc.png";
            gameclub.PostBackUrl = "http://banglalinkplayzone.com";
            lg.PostBackUrl = "http://banglalinkplayzone.com/Pages/OnlineGames.aspx";

        }
        else if (msisdnm.StartsWith("88017"))
        {
            //blink.Style.Add("display", "block");
            quiz.Visible = false;
            lgMain.Visible = false;
            gameMain.Visible = false;

        }
        else
        {
            //blink.Style.Add("display", "block");
            gameclub.ImageUrl = "Ic/bgc.png";
            gameclub.PostBackUrl = "http://banglalinkplayzone.com";
            lg.PostBackUrl = "http://banglalinkplayzone.com/Pages/OnlineGames.aspx";
        }
    }
}
