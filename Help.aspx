<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>
<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BDTube</title>
     <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="StyleSheet/bootstarp.css" rel="stylesheet" id="cssTemplate" runat="server" />
    
    
    <link href="Css/StyleSheet.css" rel="stylesheet" />
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
                                <asp:Label ID="lblHelp" runat="server">Help</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                           <td width="50%" height="20px" align="Left" style="padding-left: 10px;">
                                <b>Service Name:</b> JOSS BODY<br />
                                <b>Service Type:</b> Video Streaming Portal<br />
                                <b>Daily Charging:</b> Taka 2+ (VAT, SD & SC) / which will be renewed every day.<br /><br />

                                
                                <b>To Activate:</b> Type START TJB and send SMS to 16561<br />
                               <b>To DeActivate:</b> Type STOP TJB and send SMS to 16561<br />
                                  

                                <b>Helpline:</b>+8801736993235 [8:30AM – 07:30 PM]<br />
                                
                                <b>Support email:</b> support@aurkotech.com  

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
