<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Movie.aspx.cs" Inherits="Movie" %>
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
        //function banglamovie() {
        //    $('html, body').animate({
        //        scrollTop: $("#BanglaMovie").offset().top
        //    }, 500);
        //    // window.location = "GCMPush.aspx";
        //}
        //function hindimovie() {
        //    $('html, body').animate({
        //        scrollTop: $("#hindimovie").offset().top
        //    }, 500);
        //    // window.location = "GCMPush.aspx";
        //}

       

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Wrap">
          <uc1:Header ID="HeaderControl" runat="server" />
        <div class="mainbody" id="Fullvideo">
            <div class="Catname">
                  মুভি
            </div>
            <%--Bangla Video--%>
            <div id="BM">
            <div class="section">
                 <div class="BanglaMovie">
                      <div class="vdtitle">
                        বাংলা মুভি
                      </div>  
                 </div>
              <%--  One Row--%>
                <asp:DataList ID="datalistbanglamovie"  Width="100%"  RepeatColumns="2" runat="server">
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

            </div>
            <div class="horzontalineimg" >
                 <asp:ImageButton ID="btnbanglamovie" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnbanglamovie_Click"  runat="server" />
               
            </div>
            <div class="horzontaline">
                   <hr  />
             </div>

            </div>


            <%--English Movie--%>
            <div class="section" style="display:none">
                 <div class="BanglaVideo">
                      <div class="vdtitle">
                         English Movie
                      </div>  
                 </div>
              <%--  One Row--%>
                <asp:DataList ID="datalistenglishmovie"  Width="100%"  RepeatColumns="2" runat="server">
                        <ItemTemplate>
                                <div class="videocontentmore">
                                    <div class="section1">
                              
                                        <asp:HyperLink ID="ImgGames" runat="server"  CssClass="imgResizeTest" 
                                             NavigateUrl='<%# Eval("path")%>'  
                                                ImageUrl='<%# Bind("imageUrl") %>' />
                              
                              
                                        <div class="listtitle"><%# Eval("ContentTile") %></div>
                                    </div>
                            
                                </div>
                    
                        </ItemTemplate>
                    </asp:DataList>

            </div>
            <div class="horzontaline" style="display:none">
                <asp:ImageButton ID="btnenglish" ImageUrl="~/images/ArrowIcone.png" runat="server" />
                <hr  />
            </div>


             <%--Hindi Movie--%>
            <div id="HM">
            <div class="section">
                 <div class="BanglaVideo" id="hindimovie">
                      <div class="vdtitle">
                        হিন্দি মুভি
                      </div>  
                 </div>
              <%--  One Row--%>
                <asp:DataList ID="datalisthindimovie"  Width="100%"  RepeatColumns="2" runat="server">
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

            </div>
            <div class="horzontalineimg">
                <asp:ImageButton ID="btnhindi" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnhindi_Click" runat="server" />
               <div class="horzontaline">
                   <hr  />
             </div>
            </div>
            
      </div>
            

        </div>
        <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
        
    </div>
    </form>
    
    <script>

        var myParam = location.search.split('title=')[1] ? location.search.split('title=')[1] : 'myDefaultValue';
        //alert(myParam);
        gg();
        function gg() {

            if (myParam === 'BM') {
                // alert('test');
                $('#HM').hide();
               

            }
            if (myParam === 'HM') {
                $('#BM').hide();
                

            }


        };
    </script>
</body>
</html>
