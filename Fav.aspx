<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fav.aspx.cs" Inherits="Fav" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet"  id="cssTemplate" runat="server"/>
    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />
    <link href="CSS/NewS/StyleSheet.css" rel="stylesheet" />
    <title>FitnessClub</title>
    <style>
        
        .imgplay.img-responsive {
            margin-left: 84%;
            margin-top: -18%;
            width: 15%;
            box-shadow: 0px 0px 0px 0px;
            border: 2px solid white !important;
        }
        .imgplay1.img-responsive {
            margin-left: 0%;
            margin-top: -13%;
            width: 15%;
            box-shadow: 0px 0px 0px 0px;
            border: 2px solid white !important;
        }
    </style>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <uc1:Header ID="HeaderControl" runat="server" />

            <div class="mainbody">
                 <div class="text-center">
                    <div id="cancelSubscriptionBlink" runat="server" visible="False">
                        <div style="font-size: 15px; padding-top: -5%">
                            <b><asp:LinkButton Text="UNSUBSCRIBE" ID="LinkButton3" runat="server"  Font-Underline="false" ForeColor="#F16521">UNSUBSCRIBE</asp:LinkButton></b>
                        </div>
                    </div>
                </div>
                <div class="Catname">
						ফেভারিট লিস্ট
                </div>

                <div id="aa">
                <div class="section">
                    <div class="BanglaVideo" id="start">
                        <div class="vdtitle">
								ফেভারিট
                        </div>
                    </div>
                    <asp:DataList ID="dataListFav" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                          
                            <div class="preview">
                                <div class="section1">
                              
                                    <asp:HyperLink ID="ImgGames" runat="server"  CssClass="imgResizeTest" 
                                                   NavigateUrl='<%# Eval("path")%>'  
                                                   ImageUrl='<%# Bind("imageUrl") %>' />
                                    <a href="<%# Eval("path")%>"><img src="images/play-button.png" class="imgplay img-responsive imgResizeTest"/></a>
                                    <span class="slide-title"><%# Eval("ContentTile") %></span>
                                   

                                </div>
                            
                            </div>

                        </ItemTemplate>
                    </asp:DataList>

                </div>
                <div class="horzontalineimg" id="moviereview">
                    <asp:ImageButton ID="btnmoviereview" ImageUrl="~/images/tele.png" Visible="False"  Width="25%" OnClick="btnmoviereview_Click" runat="server" />
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>

            </div>


                </div>

            <div class="link">
                <uc2:Footer ID="FooterControl" runat="server" />
            </div>
            
        </div>
    </form>
</body>
</html>
