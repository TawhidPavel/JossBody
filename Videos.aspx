<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>


<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
    <link href="CSS/NewS/StyleSheet.css" rel="stylesheet" />
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
    <title>JOSS BODY</title>
    <style>
        
        .imgplay.img-responsive {
            margin-left: 71%;
            margin-top: -18%;
            width: 15%;
             box-shadow: 0px 0px 0px 0px;
			  border: 2px solid white !important;
        }
        .btnde {
            border-radius: 25%
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Wrap">
          <uc1:Header ID="HeaderControl" runat="server" />
        <div class="mainbody">
            <div class="Catname">
             <asp:Label runat="server" ID="HeaderText"></asp:Label>
            </div>
            <%--Bangla Video--%>
            <div class="section">
                 
              <%--  One Row--%>
                  <asp:DataList ID="dataListMostLiked"  Width="100%"  RepeatColumns="2" runat="server">
                      <ItemTemplate>
                          <div class="preview">
                              <div class="section1">
                              
                                  <asp:HyperLink ID="ImgGames" runat="server"  CssClass="imgResizeTest" 
                                                 NavigateUrl='<%# Eval("path")%>'  
                                                 ImageUrl='<%# Bind("imageUrl") %>' />
                                  <a href="<%# Eval("path")%>"><img src="images/play-button.png" class="imgplay img-responsive imgResizeTest"/></a>
                                  <span class="slide-title"><%# Eval("ContentTile") %></span>
                                  <span class="slide-title">
                                      <%--<div class="col-xs-7 col-sm-4 lk-padding">
                                          <img src="images/lik.png" style="width: 16px;height: 17px;"><%# Eval("totalLike") %>
                                      </div>--%>
                                      <div class="col-xs-5 col-sm-4">
                                          <img src="images/vi.png" style="width: 46%; margin-left: 98px"><%# Eval("totalView") %></div>
                                  </span>

                              </div>
                            
                          </div>
                    
                      </ItemTemplate>
                    </asp:DataList>
                <div class="horzontalineimg">
                        <asp:ImageButton ID="imgButtonMore" ImageUrl="~/images/more.png" Width="25%" CssClass="btnde" OnClick="btnLikeMore_Click" runat="server" />

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