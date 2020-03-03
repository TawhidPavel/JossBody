<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="Service" %>
<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BDTube</title>
     <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />
    
    
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
    <link href="Css/swiper.css" rel="stylesheet" />


    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 100%;
            margin: auto;
        }


        .swiper-container {
            width: 100%;
            height: 100%;
        }

        .swiper-slide {
            /*text-align: center;
        font-size: 18px;
        background: #fff;*/
            /* Center slide text vertically */
            display: -webkit-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
        }




        #bdtubebody {
            background: #000;
        }

        .loadvideo {
            position: absolute;
            bottom: 40%;
            width: 100%;
        }



        .video-js {
            padding-top: 56.25%;
        }

        .vjs-fullscreen {
            padding-top: 0px;
        }

        #bdtubebody {
            background: #fff;
        }

        .loadvideo {
            position: absolute;
            bottom: 40%;
            width: 100%;
        }

        .button-close {
            background-image: url(/Animation/addBtn.png);
            background-color: transparent; /* make the button transparent */
            background-repeat: no-repeat; /* make the background image appear only once */
            margin-right: 60%;
        }

        button.close {
            margin-left: 69%;
            margin-top: -2%;
        }

        .close {
            float: none;
            margin-right: -87%;
            margin-top: -15px;
            opacity: 1;
            position: fixed;
            width: 62%;
            z-index: 999999999;
        }

        .modal-body {
            padding: 0px;
            position: relative;
        }

        .modal-content {
            background: none;
            border: none;
            border-radius: 0;
            box-shadow: none;
        }

        .ribonMusic {
            text-align: center;
            height: 30px;
            background-color: rgb(198, 27, 36);
            background-repeat: repeat-x;
            font-weight: bold;
            FONT-SIZE: 11px;
            FONT-FAMILY: Verdana, Tahoma, Arial;
            color: #fff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap" id="Wrapid" style="display:block">
            
            <uc1:Header ID="HeaderControl" runat="server" />
            
            <div class="mainbody">
               <div class="table table-responsive"  style="margin-left:0%;margin-right:0%">
                    <table cellpadding="0" cellspacing="0" class="BlueLine" width="100%">
                        <tr>
                            <td height="20px" class="ribonMusic">&nbsp;
                                <asp:Label ID="lblHelp" runat="server">Service</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                       <tr id="textForBL" runat="server" visible="False">
                            <td width="50%" height="20px" align="Left" style="padding-left: 10px;">
                                <b>Charging info:</b><br>
                                &gt;	Taka 2 (+VAT, SD and SC) for subscription.<br>
                                &gt;	Five free videos view/day.<br>
                                &gt;	Taka 2 (+VAT, SD and SC) views after assume free daily limits.<br>
                                &gt;	Taka 20 (+VAT, SD and SC)/Full Movie.<br>
                                &gt;	Full Movie will not consider under daily free limits & five bundle views against of Taka 2 (+VAT, SD and SC).<br>
                                <br>
                                <b>Service modality:</b><br>
                                &gt;	User has to subscribe by Taka 2 (+VAT, SD and SC) to streaming exclusive videos.<br>
                                &gt;	Since its subscription model, daily Taka 2 (+VAT, SD and SC) will deduct from user’s account, even user do not view their free contents.<br>
                                &gt;	This cycle will continue until user deactivates the service because this is an auto-renewal process.<br>
                                <br>
                                <b>Deactivation:</b><br>
                                &gt;	To deactivate type STOP bdtube and send SMS to 6624<br>
                                <br>
                                <b>Support:</b><br>
                                &gt;   Helpline: 8801992303765<br>
                                &gt;   Support e-mail : support@vumobile.biz
                            </td>
                        </tr>
                        <tr id="textForTT" runat="server" visible="false">
                            <td width="50%" height="20px" align="Left" style="padding-left: 10px;">
                                <b>Charging info:</b><br>
                                &gt;	Taka 2 (+VAT, SD and SC) for subscription.<br>
                                &gt;	Five free videos view/day.<br>
                                &gt;	Tk2+3% Surcharge+VAT/5 views after assume free daily limits.<br>
                                &gt;	Taka 20 (+VAT, SD and SC)/Full Movie.<br>
                                &gt;	Full Movie will not consider under daily free limits & five bundle views against of Taka 2 (+VAT, SD and SC).<br>
                                <br>
                                <b>Service modality:</b><br>
                                &gt;	User has to subscribe by Tk2+3%SD+VAT to streaming exclusive videos.<br>
                                &gt;	Since its subscription model, daily Taka 2 (+VAT, SD and SC) will deduct from user’s account, even user do not view their free contents.<br>
                                &gt;	This cycle will continue until user deactivates the service because this is an auto-renewal process.<br>
                                <br>
                                <b>Deactivation:</b><br>
                                &gt;	To deactivate type STOP bdtube and send SMS to 6624<br>
                                <br>
                                <b>Support:</b><br>
                                &gt;   Helpline: 8801534524714<br>
                                &gt;   Support e-mail : support@vumobile.biz
                            </td>
                        </tr>
                        <tr id="textForRobi" runat="server" visible="false">
                            <td width="50%" height="20px" align="Left" style="padding-left: 10px;">
                                <b>What is BdTube?</b><br />• BDtube VOD is a subscription based video streaming service whereby members can enjoy different video contents such as movie trailers, music videos, funny videos, and full length movies. There will be different video categories to enjoy videos from Bdtube portal so user can choose what suite them best. BDTube VOD service will fulfill user’s needs in terms of pricing and variety number of video content that they can enjoy.<br />Once user subscribed to BDTube, they will need an active data connection to be able to validate your subscription status and view your desirable contents. Data charges will be applicable as per the package selected.<br /><br /><b>What is BdTube address?</b><br />• The contest portal address will be <a href='http://bdtube.mobi/'>http://bdtube.mobi/</a> <br /><br /><b>How can users join the service?</b><br />• User can join service from portal (<a href='http://bdtube.mobi/'>http://bdtube.mobi/</a> ) or by sending SMS keyword.<br />• Activation Procedure:<br />• Type START BDTube to 6624<br /><br /><b>How to deactivate the service?</b><br />• Service can be deactivated anytime by using unsubscribe button or sending deactivation SMS.<br />• Deactivation procedure:<br />• Type STOP BDTube to 6624<br /><br /><b>What is service modality?</b><br />•	User has to subscribe by Taka 2 (+VAT, SD and SC) to streaming exclusive videos.<br />•	Since its subscription model, daily Taka 2 (+VAT, SD and SC) will deduct from user’s account, even user do not view their free contents. This cycle will continue until user deactivates the service because this is an auto-renewal process.<br /><br /><b>What is Charging info?</b><br />• Taka 2 (+VAT, SD and SC) for subscription.<br />• Five free videos view/day.<br />• Taka 2 (+VAT, SD and SC)/5 views after assume free daily limits.<br />• Taka 20 (+VAT, SD and SC)/Full Movie.<br />• Full Movie will not consider under daily free limits & five bundle views against of Taka 2 (+VAT, SD and SC).
                                
                                <br /><br /><b>Where can I find the contents which I have already viewed?</b><br />• You can go to “My Account” section to see the list of contents that has already been viewed by you.

                                <br /><br /><b>Is there any other way to deactivate BDTube service?</b><br />• Yes, there is a ‘Unsubscribe” button at the bottom of each page of the portal. By clicking the unsubscribe button, the user will able to deactivate the service.

                                <br /><br /><b>How much do I pay for bask the various contents?</b><br />• If you have opted to BDTube, then you can view daily five contents as freebies and can enjoy various sorts of contents from a big category list when subscription is active. Subscriptions are available either at TK2+VAT+SD+SC/day.
                                <br /><br /><b>What are the prices for on-demand contents?</b><br />• On-demand model user can purchase 5 free videos view at TK2+VAT+SD+SC and 10Tk+VAT+SD+SC for full movies view.
                                <br /><br /><b>Do I need to pay any other fee for on-demand contents?</b><br />• No, you don’t have to pay any other fees after you pay the one time view fee for the desired content.
                                <br /><br /><b>If I view the content on-demand, can I keep the content forever and enjoy?</b><br />• Since its streaming service, so user will not able to store their preferred contents.
                                <br /><br /><b>Is there any data charge for browsing the contents portal and content views?</b><br />• Yes, there will be data charges as per your subscribed data plan for browsing the portal and viewing contents.
                                <br /><br /><b>For re-viewing the content from My Account/History, do I have to pay again for the content?</b><br />• No. there is no charges for re-viewing the content from My Account/History.  However, data charges may apply depending on your data package.
                                <br /><br /><b>Does the content support iOS, Blackberry, and Windows phones?</b><br />• Yes, portal contents are supported to iOS, Blackberry, and Windows phone, but application in only valid for android.




                                
                                <br /><br /><b>What is the helpline/hotline number?</b><br />• 8801814426426<br /><br /><b>What is the support email address?</b><br />• Support mail : support@vumobile.biz<br />
                            </td>
                        </tr>
                        <tr id="textForAirtel" runat="server" visible="false">
                            <td width="50%" height="20px" align="Left" style="padding-left: 10px;">
                                <b>What is BdTube?</b><br />• BDtube VOD is a subscription based video streaming service whereby members can enjoy different video contents such as movie trailers, music videos, funny videos, and full length movies. There will be different video categories to enjoy videos from Bdtube portal so user can choose what suite them best. BDTube VOD service will fulfill user’s needs in terms of pricing and variety number of video content that they can enjoy.<br />Once user subscribed to BDTube, they will need an active data connection to be able to validate your subscription status and view your desirable contents. Data charges will be applicable as per the package selected.<br /><br /><b>What is BdTube address?</b><br />• The contest portal address will be <a href='http://bdtube.mobi/'>http://bdtube.mobi/</a> <br /><br /><b>How can users join the service?</b><br />• User can join service from portal (<a href='http://bdtube.mobi/'>http://bdtube.mobi/</a> ) or by sending SMS keyword.<br />• Activation Procedure:<br />• Type START BDTube to 6624<br /><br /><b>How to deactivate the service?</b><br />• Service can be deactivated anytime by using unsubscribe button or sending deactivation SMS.<br />• Deactivation procedure:<br />• Type STOP BDTube to 6624<br /><br /><b>What is service modality?</b><br />•	User has to subscribe by Taka 2 (+VAT, SD and SC) to streaming exclusive videos.<br />•	Since its subscription model, daily Taka 2 (+VAT, SD and SC) will deduct from user’s account, even user do not view their free contents. This cycle will continue until user deactivates the service because this is an auto-renewal process.<br /><br /><b>What is Charging info?</b><br />• Taka 2 (+VAT, SD and SC) for subscription.<br />• Five free videos view/day.<br />• Taka 2 (+VAT, SD and SC)/5 views after assume free daily limits.<br />• Taka 20 (+VAT, SD and SC)/Full Movie.<br />• Full Movie will not consider under daily free limits & five bundle views against of Taka 2 (+VAT, SD and SC).
                                
                                <br /><br /><b>Where can I find the contents which I have already viewed?</b><br />• You can go to “My Account” section to see the list of contents that has already been viewed by you.

                                <br /><br /><b>Is there any other way to deactivate BDTube service?</b><br />• Yes, there is a ‘Unsubscribe” button at the bottom of each page of the portal. By clicking the unsubscribe button, the user will able to deactivate the service.

                                <br /><br /><b>How much do I pay for bask the various contents?</b><br />• If you have opted to BDTube, then you can view daily five contents as freebies and can enjoy various sorts of contents from a big category list when subscription is active. Subscriptions are available either at TK2+VAT+SD+SC/day.
                                <br /><br /><b>What are the prices for on-demand contents?</b><br />• On-demand model user can purchase 5 free videos view at TK2+VAT+SD+SC and 10Tk+VAT+SD+SC for full movies view.
                                <br /><br /><b>Do I need to pay any other fee for on-demand contents?</b><br />• No, you don’t have to pay any other fees after you pay the one time view fee for the desired content.
                                <br /><br /><b>If I view the content on-demand, can I keep the content forever and enjoy?</b><br />• Since its streaming service, so user will not able to store their preferred contents.
                                <br /><br /><b>Is there any data charge for browsing the contents portal and content views?</b><br />• Yes, there will be data charges as per your subscribed data plan for browsing the portal and viewing contents.
                                <br /><br /><b>For re-viewing the content from My Account/History, do I have to pay again for the content?</b><br />• No. there is no charges for re-viewing the content from My Account/History.  However, data charges may apply depending on your data package.
                                <br /><br /><b>Does the content support iOS, Blackberry, and Windows phones?</b><br />• Yes, portal contents are supported to iOS, Blackberry, and Windows phone, but application in only valid for android.




                                
                                <br /><br /><b>What is the helpline/hotline number?</b><br />• 8801674985965<br /><br /><b>What is the support email address?</b><br />• Support mail : support@vumobile.biz<br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                       
                    </table>
                </div>

            </div>
        </div>
    <div>
    
    </div>
        <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
        
    </form>
</body>
</html>
