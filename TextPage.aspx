<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextPage.aspx.cs" Inherits="Contentdownload" %>


<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="cssTemplate" runat="server" />
    <title>JOSS BODY</title>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
    <link href="Js/toastr.min.css" rel="stylesheet" />


    <script src="StyleSheet/video.js"></script>
    <style>
        .typeFont {
            font-style:;
            font-size: 18px;
            background-color:whitesmoke ;
            color: black;
            border: 4px;
            border-radius: 4px;
            font-weight: normal;
            font-size: 15px;
            margin-top: 6px;
            margin-right: 4px;
            font-family: initial;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrap">
            <uc1:Header ID="HeaderControl" runat="server" />
            <div class="mainbody">
                <div id="main" runat="server" Visible="False">
                    <div id="newVideo" class="robititle" style="background-color: #58C1E6">
                        <div class="robititletext">
                            <span class="glyphicon glyphicon-play"></span>
                        </div>
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 18px; font-family: initial;">
                                 <asp:Label runat="server" ID="lblcat"></asp:Label>
                                <asp:Label runat="server" ID="txtCategory"></asp:Label>
                            </span>
                        </div>
                        <div class="robititletext23">
                            <span style="font-style: italic; font-size: 18px; background-color: whitesmoke; color: black; border: 4px; border-radius: 4px; font-weight: normal; font-size: 15px; margin-top: 6px; margin-right: 4px; font-family: initial">
                            </span>
                            <%--<asp:Button runat="server" CssClass="btn btn-info" BackColor="#158bad" BorderWidth="1px" Width="120%" Text="More >" Font-Bold="True" Font-Italic="True" ></asp:Button>--%>
                        </div>
                       
                    </div>
                    <div>
                       <b style="color: #808080">Last updated:</b> <asp:Label runat="server" CssClass="" ID="lblLastTime" Font-Bold="True" ForeColor="#808080"></asp:Label>
                            
                    </div>
                     <div runat="server" Visible="True">
                                <asp:Label runat="server" CssClass="typeFont" ID="txtType"></asp:Label>
                            
                        </div>


                    <%--img--%>
                    <div style="width: 100%; background: #fff;">
                        <div style="">
                            <div class="video1" id="smartphone1" runat="server" style="width: 100%">
                                <asp:Literal ID="ltvideo" Visible="true" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>



                    <div class="BanglaMovie">
                        <div class="" style="margin-bottom: 4px;">
                            <div style="margin-top: 5px; margin-bottom: 20px;">
                                <blockquote>
                                    <asp:Label runat="server" ID="textFull"></asp:Label>
                                </blockquote>
                            </div>
                        </div>

                        <div class="text-center">
                            <br />
                            <asp:ImageButton ID="btnHome" runat="server" ImageUrl="~/images/Home.png" OnClick="btnHome_OnClick" Width="18%"></asp:ImageButton>
                            <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" Width="18%"></asp:ImageButton>
                        </div>
                    </div>

                </div>

                <div id="preVideo" visible="False" runat="server" class="robititle" style="background-color: #58C1E6">
                    <div class="robititletext">
                        <span class="glyphicon glyphicon-play"></span>
                    </div>
                    &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 18px; font-family: initial;">পূর্ববর্তী পোস্ট</span>
                        </div>
                </div>

                <div class="relatedgroup">
                    <ul>
                        <asp:DataList ID="dataListRelatedvideo" Width="100%" RepeatColumns="0" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# Eval("path") %>"><span class="Title" style="color: blue"><%# Eval("Title") %>
                                        <br />
                                    </span></li>
                            </ItemTemplate>
                        </asp:DataList>
                        <%--<Asp:Literal runat="server" id="ltrlRelatedText"></Asp:Literal>--%>
                    </ul>
                </div>
            </div>
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
    </form>

</body>
</html>
