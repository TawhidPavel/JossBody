<%@ Page Language="C#" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="Support" ContentType="text/html" %>

<%@ Register Src="~/header.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register TagPrefix="uc2" TagName="Footer" Src="~/foter.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head id="Head1" runat="server">
    <title>BDTube</title>
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" id="cssTemplate" runat="server" />
    <style type="text/css">
        p.MsoNormal {
            margin-bottom: .0001pt;
            font-size: 12.0pt;
            font-family: "Calibri","sans-serif";
            margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }

        .style1 {
            font-size: 0.8em;
        }

        p.MsoListParagraphCxSpFirst {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 0in;
            margin-left: .5in;
            margin-bottom: .0001pt;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }

        p.MsoListParagraphCxSpMiddle {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 0in;
            margin-left: .5in;
            margin-bottom: .0001pt;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }

        p.MsoListParagraphCxSpLast {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 10.0pt;
            margin-left: .5in;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }

        p.MsoListParagraph {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 10.0pt;
            margin-left: .5in;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }

   
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" class="cbp-spmenu-push">
    <table cellpadding="0" cellspacing="0" class="TABLE" id="thefuckingmenu">
        <tr>
            <td align="center">
                <div id="showLeftPush">
                    <asp:Image ID="lnkHeader" runat="server"></asp:Image>
                </div>
            </td>
        </tr>
    </table>
    
    <form id="frmHot" runat="server">
        <%--<uc1:Menu runat="server" ID="Menu" />--%>
        <table cellpadding="0" cellspacing="0" class="TABLE" style="margin-top: 15.6%;">
            <tr>
                <td align="left" valign="top">
                    <table cellpadding="0" cellspacing="0" class="TABLE">
<%--                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="lnkHeader" runat="server"></asp:HyperLink>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblHandset" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="TABLE">
            <tr>
                <td height="20px" class="ribonMusic">&nbsp;<asp:Label ID="lblPicture" runat="server">My Account</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="0" class="TABLE">
                        <tr>
                            <td height="20px" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="labelCategory"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <table cellpadding="2" cellspacing="0" class="scoreTable" align="center">
                                <tr class="header">
                          <%--          <td>SL.</td>--%>
                                    <td>Mobile no.</td>
                                    <td>Action</td>
                                    <td>Date Time</td>
                                    <td>Charge(Tk.)</td>
                                </tr>
                                <asp:Repeater ID="subStatus" runat="server" OnItemDataBound="subStatus_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
<%--                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblSL2" runat="server"></asp:Label></td>--%>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblMSISDN" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblRegDate" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblReAcDate" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblDeAcDate" runat="server"></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td>
                    <table cellpadding="2" cellspacing="0" class="TABLE">
                        <tr>
                            <td height="20px" class="ribonMusic">&nbsp;<span id="">View History</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="20px" align="center">
                                <asp:Label ID="lblMsg" runat="server" CssClass="labelCategory"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <table cellpadding="2" cellspacing="0" class="scoreTable" align="center">
                                <tr class="header">
                                    <td>SL.</td>
                                    <td>Mobile no.</td>
                                    <td>Video Name</td>
                                    <td>Charged(Tk.)</td>
                                    <td>Time</td>
                                </tr>
                                <asp:Repeater ID="RptTopScore" runat="server" OnItemDataBound="RptTopScore_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblSL" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblMSISDN" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblGame" runat="server"></asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblCharge" runat="server">0.00</asp:Label></td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblDownloadTime" runat="server"></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td style="text-align: center">&nbsp;
                </td>
            </tr>

           
        </table>

        <table cellpadding="0" cellspacing="0" class="TABLE">
               <%------------------------------------------------%>

            <tr>
                <td style="text-align: center;">&nbsp;</td>
            </tr>
        </table>
        <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
        <div class="foter">
            <p>
                © 2016. All Rights Reserved. 
            </p>
        </div>
    </form>
</body>
