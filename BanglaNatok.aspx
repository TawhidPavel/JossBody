<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanglaNatok.aspx.cs" Inherits="BanglaNatok" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
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

    <script>
        function BanglaNatok() {
          
            $('html, body').animate({
    scrollTop: $("#BanglaNatok").offset().top
}, 500);
          // window.location = "GCMPush.aspx";
          }
          function BanglaTeleflim() {
              $('html, body').animate({
                  scrollTop: $("#BanglaTeleflims").offset().top
              }, 500);
              // window.location = "GCMPush.aspx";
          }



          </script>
      </head>
      <body>
          <form id="form1" runat="server">
        <div class="wrap">
            <uc1:Header ID="HeaderControl" runat="server" />
            <div class="mainbody">
                <div class="Catname">
                    নাটক 
                </div>
                <%--Bangla Natok--%>


                <div class="section">
                    <div class="BanglaVideo" id="BanglaNatok">
                        <div class="vdtitle">
                            বাংলা নাটক 
                        </div>
                    </div>
                    <%--  One Row--%>
                    <asp:DataList ID="dalaListBanglaNatok" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">
                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")%>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />

                                    <a href="<%# Eval("path")%>">
                                        <img src="images/play-button.png" class="imgplay img-responsive imgResizeTest" /></a>

                                    <div class="listtitle"><%# Eval("ContentTile") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="horzontalineimg">
                    <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/ArrowIcone.png" Width="25%" OnClick="btnbanglaNatok_Click" runat="server" />

                </div>
                <div class="horzontaline">
                    <hr />
                </div>




            </div>
            <div class="link">
                <uc2:Footer ID="FooterControl" runat="server" />
            </div>

        </div>
    </form>
</body>
</html>
