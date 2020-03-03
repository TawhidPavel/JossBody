<%@ Page Language="C#" AutoEventWireup="true" CodeFile="serach.aspx.cs" Inherits="serach" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet"  id="cssTemplate" runat="server"/>
    <link href="CSS/NewS/StyleSheet.css" rel="stylesheet" />
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
    <title>FitnessClub</title>
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
                
                <asp:Label ID="lblresult" runat="server" Text="Search"></asp:Label>
                 
            </div>
            <%--Bangla Video--%>
            <div class="section">
                 
              <%--  One Row--%>
                  <asp:DataList ID="dataListnewvideo"  Width="100%"  RepeatColumns="2" runat="server">
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
        <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
        
    </div>
        </div>
    </form>
    <script>
       
        $(document)
            .ready(function () {

                $('#bm').addClass('.imgplay.img-responsive').removeClass('.videocontentmore  img');
            });

    </script>
</body>
</html>
