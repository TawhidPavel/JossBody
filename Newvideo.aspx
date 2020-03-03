<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newvideo.aspx.cs" Inherits="Newvideo" %>
<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
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
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Wrap">
          <uc1:Header ID="HeaderControl" runat="server" />
        <div class="mainbody">
            <div class="Catname">
               নতুন ভিডিও 
            </div>
            <%--Bangla Video--%>
            <div class="section">
                 
              <%--  One Row--%>
                  <asp:DataList ID="dataListnewvideo"  Width="100%"  RepeatColumns="2" runat="server">
                        <ItemTemplate>
                                <div class="videocontentmore">
                                    <div class="section1">
                              
                                        <asp:HyperLink ID="ImgGames" runat="server"  CssClass="imgResizeTest" 
                                             NavigateUrl='<%# Eval("path")%>'  
                                                ImageUrl='<%# Bind("imageUrl") %>' />
                              <a href="<%# Eval("path")%>"><img src="images/play-button.png" class="imgplay img-responsive imgResizeTest"/></a>
                              
                              
                                        <div class="listtitle"><%# Eval("ContentTile") %></div>
                                    </div>
                            
                                </div>
                    
                        </ItemTemplate>
                    </asp:DataList>

                <div class="horzontalineimg">
                        <asp:ImageButton ID="imgButtonMore" ImageUrl="~/images/more.png" Width="25%" OnClick="btnLikeMore_Click" runat="server" />

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