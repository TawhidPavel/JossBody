<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hs.aspx.cs" Inherits="Hs" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />


    <title>JOSS BODY</title>

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
            text-align: left;
            height: 30px;
            background-color: rgb(198, 27, 36);
            background-repeat: repeat-x;
            font-weight: bold;
            FONT-SIZE: 11px;
            FONT-FAMILY: Verdana, Tahoma, Arial;
            color: #fff;
            padding-left: 25%
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">


        <div class="Wrap" id="Wrapid" style="display: block">
            <uc1:Header ID="HeaderControl" runat="server" />


            <div class="mainbody">


                <div class="table table-responsive"  style="margin-left:1%;margin-right:1%">
                    <table cellpadding="0" cellspacing="0" class="BlueLine" width="100%">
                        <tr>
                            <td height="20px" class="ribonMusic">&nbsp;
                                <asp:Label ID="lblPicture" runat="server">My Account-<asp:Label ID="lblM1" runat="server"></asp:Label></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grdMyAccount"  runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="3">
                                    <Columns>
                                       
                                        <asp:BoundField HeaderText="Content" DataField="Action">
                                            <FooterStyle Width="110px" />
                                            <HeaderStyle Width="110px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Charge" DataField="Charge">
                                            <FooterStyle Width="110px" />

                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Time" DataField="Date">
                                            <FooterStyle Width="110px" />
                                            <HeaderStyle Width="200px" />
                                        </asp:BoundField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                       
                    </table>
                </div>
                <div class="table table-responsive" style="margin-left:1%;margin-right:1%">
                    <table cellpadding="0" cellspacing="0" class="BlueLine" width="100%">
                         <tr>
                            <td height="20px" class="ribonMusic">&nbsp;
                                <asp:Label ID="Label1" runat="server">My View- <asp:Label ID="lblM" runat="server"></asp:Label> </asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        </table>
                    <table cellpadding="2" cellspacing="2" class="BlueLine" width="100%">
                        <tr>
                            <td>


                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="3">
                                    <Columns>
                                        
                                        <asp:BoundField HeaderText="Action" DataField="CONTENT_TITLE">
                                            <FooterStyle Width="120px" />
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="Charge" DataField="ChargingReply">
                                            <FooterStyle Width="120px" />
                                            <FooterStyle Width="110px" />

                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Time" DataField="Date">
                                             <FooterStyle Width="120px" />
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                      
                                    </Columns>
                                </asp:GridView>
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
        <table>
                    <tr id="cancelSubscriptionBlink" runat="server" Visible="False">
                            <td align="right" style="font-size: 10px; padding-top: -5%">
                                <asp:LinkButton Text="Cancel Subscription" ID="LinkButton3" runat="server" OnClick="lbkbtnCancelSubscription_Click" CssClass="btn btn-success"  Font-Underline="false"  ForeColor="#FFFFFF">UN-SUBSCRIBE</asp:LinkButton>
                            </td>
                        </tr>
                        </table>
        <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
       
        </div>



    </form>


</body>
</html>
