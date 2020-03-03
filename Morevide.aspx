<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Morevide.aspx.cs" Inherits="Morevide" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server"/>
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


        
        function Fullvideo() {
            $('html, body').animate({
                scrollTop: $("#Fullvideo").offset().top
            }, 500);

            // window.location = "GCMPush.aspx";
        }
        function BanglaVideo() {
            $('html, body').animate({
                scrollTop: $("#BanglaVideo").offset().top
            }, 500);
            // window.location = "GCMPush.aspx";
        }

        function Englishmusic() {
            $('html, body').animate({
                scrollTop: $("#Englishmusic").offset().top
            }, 500);
            // window.location = "GCMPush.aspx";
        }

        function BanglaNatok() {
            $('html, body').animate({
                scrollTop: $("#BanglaNatok").offset().top
            }, 500);
            // window.location = "GCMPush.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="Wrap">
            <uc1:Header ID="HeaderControl" runat="server" />

            <div class="mainbody" id="Fullvideo">
                <div class="Catname">
                    ভিডিও
                </div>
                <%--Bangla Video--%>
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                <div id="BM">
                    <div class="section">
                        <div class="BanglaVideo">
                            <div class="vdtitle">
                                বাংলা মুভি
                            </div>
                        </div>
                        <%--  One Row--%>

                        <asp:DataList ID="dataListFullvideobanglamovie" Width="100%" RepeatColumns="2" runat="server">
                            <ItemTemplate>
                                <div class="videocontentmore">
                                    <div class="section1">

                                        <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                            NavigateUrl='<%# Eval("path")%>'
                                            ImageUrl='<%# Bind("imageUrl") %>' />
								 <a href="<%# Eval("path")%>"><img id="bm" runat="server" src="images/play-button.png"  class="imgplay img-responsive imgResizeTest"/></a>

                              

                                        <div class="listtitle"><%# Eval("ContentTile") %></div>
                                    </div>

                                </div>

                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div class="horzontalineimg">
                        <%--<img src="images/ArrowIcone.png" />--%>
                        <%--<asp:ImageButton ID="ImageButton1" ImageUrl="~/images/ArrowIcone.png" OnClick="ImageButton1_Click" runat="server" />--%>
                        <%--<asp:ImageButton ID="ImageButton1" ImageUrl="~/images/ArrowIcone.png" OnClick="ImageButton1_Click" runat="server" />--%>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/aro-video.png" runat="server" Width="25%"  OnClick="ImageButton1_Click"/>
                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                <div id="BG">
                    <div class="section">
                        <div class="BanglaVideo" id="BanglaVideo">
                            <div class="vdtitle">
                                বাংলা গান
                            </div>
                        </div>
                        <%--  One Row--%>
                        <asp:DataList ID="dataListFullvideobanglamusic" Width="100%" RepeatColumns="2" runat="server">
                            <ItemTemplate>
                                <div class="videocontentmore">
                                    <div class="section1">

                                        <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
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
                        <%--<asp:ImageButton ID="btnbanglamusic" ImageUrl="~/images/ArrowIcone.png" OnClick="btnbanglamusic_Click" runat="server" />--%>
                        <asp:ImageButton ID="btnbanglamusic" ImageUrl="~/images/aro-video.png" runat="server" Width="25%"  OnClick="btnbanglamusic_Click"/>

                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <div class="section" style="display: none;">
                    <div class="BanglaVideo">
                        <div class="vdtitle">
                            English Movies
                        </div>
                    </div>
                    <%--  One Row--%>
                    <asp:DataList ID="dataListEnglishmovie" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">

                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")%>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />


                                    <div class="listtitle"><%# Eval("ContentTile") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%--<div class="horzontaline">
                 <img src="images/ArrowIcone.png" />
                <hr />
            </div>--%>


                <div id="EG">
                <div class="section">
                    <div class="BanglaVideo" id="Englishmusic">
                        <div class="vdtitle">
                            ইংলিশ গান
                        </div>
                    </div>
                    <%--  One Row--%>
                    <asp:DataList ID="dataListEnglishmusic" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">

                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
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
                    <%--<asp:ImageButton ID="btnenglishmusic" ImageUrl="~/images/ArrowIcone.png" OnClick="btnenglishmusic_Click" runat="server" />--%>
                        <asp:ImageButton ID="btnenglishmusic" ImageUrl="~/images/aro-video.png" runat="server" Width="25%"  OnClick="btnenglishmusic_Click"/>

                </div>
                <div class="horzontaline">
                    <hr />
                </div>
                </div>
                <%--Bangla Natok--%>

                <div id="BN">
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

                               <a href="<%# Eval("path")%>"><img src="images/play-button.png" class="imgplay img-responsive imgResizeTest"/></a>

                                    <div class="listtitle"><%# Eval("ContentTile") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="horzontalineimg">
                    <%--<asp:ImageButton ID="ImageButton2" ImageUrl="~/images/ArrowIcone.png" OnClick="btnbanglaNatok_Click" runat="server" />--%>
                        <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/aro-video.png" runat="server" Width="25%"  OnClick="btnbanglaNatok_Click"/>

                </div>
                <div class="horzontaline">
                    <hr />
                </div>

                </div>



                <div class="section" style="display: none">
                    <div class="BanglaVideo">
                        <div class="vdtitle">
                            হিন্দি মুভি
                        </div>
                    </div>
                    <%--  One Row--%>
                    <asp:DataList ID="dataListHindimovies" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">

                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")%>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />


                                    <div class="listtitle"><%# Eval("ContentTile") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%-- <div class="horzontaline">
                 <img src="images/ArrowIcone.png" />
                <hr />
            </div>--%>


                <div class="section" style="display: none">
                    <div class="BanglaVideo">
                        <div class="vdtitle">
                            Hindi Music
                        </div>
                    </div>
                    <%--  One Row--%>
                    <asp:DataList ID="dataListHindimusic" Width="100%" RepeatColumns="2" runat="server">
                        <ItemTemplate>
                            <div class="videocontentmore">
                                <div class="section1">

                                    <asp:HyperLink ID="ImgGames" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")%>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />


                                    <div class="listtitle"><%# Eval("ContentTile") %></div>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%--  <div class="horzontaline">
                 <img src="images/ArrowIcone.png" />
                <hr />
            </div>--%>
            </div>
            <div class="link">
                <uc2:Footer ID="FooterControl" runat="server" />
            </div>
           
        </div>
    </form>
    <script>
        $(document)
            .ready(function () {

                $('#bm').addClass('.imgplay.img-responsive').removeClass('.videocontentmore  img');
            });

        var myParam = location.search.split('title=')[1] ? location.search.split('title=')[1] : 'myDefaultValue';
        //alert(myParam);
        gg();
        function gg() {

            if (myParam === 'BM') {
               // alert('test');
                $('#BG').hide();
                $('#EG').hide();
                $('#BN').hide();

            }
            if (myParam === 'BG') {
                $('#BM').hide();
                $('#BN').hide();
                $('#EG').hide();

            }
            if (myParam === 'EG') {
                $('#BM').hide();
                $('#BN').hide();
                $('#BG').hide();

            }


        };
    </script>
</body>
</html>
