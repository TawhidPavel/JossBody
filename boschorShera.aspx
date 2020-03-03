<%@ Page Language="C#" AutoEventWireup="true" CodeFile="boschorShera.aspx.cs" Inherits="boschorShera" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet"  id="cssTemplate" runat="server"/>
    <title>BDTube</title>
    <style>
        
        .imgplay.img-responsive {
            margin-left: 71%;
            margin-top: -18%;
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
                <div class="Catname">
                   বছর সেরা
                </div>

                <div id="aa">
                <div class="section">
                    <div class="BanglaVideo" id="start">
                        <div class="vdtitle">
                            বছর সেরা
                        </div>
                    </div>
                    <asp:DataList ID="dataListShera" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">

                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")%>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />

                                     <a href="<%# Eval("path")%>"><img src="images/play-button.png" class="imgplay img-responsive imgResizeTest"/></a>
                                    <div class="listtitle"><%# Eval("ContentTitle") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>

                </div>
                <div class="horzontalineimg" id="moviereview">
                    <asp:ImageButton ID="btnmoviereview" ImageUrl="~/images/tele.png" Visible="False"  Width="25%" OnClick="btnsheraview_Click" runat="server" />
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
