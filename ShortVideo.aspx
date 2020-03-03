<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShortVideo.aspx.cs" Inherits="ShortVideo" %>

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
        function banglamovie(name) {

            $('html, body').animate({
                scrollTop: $("#" + name).offset().top
            }, 500);
            // window.location = "GCMPush.aspx";
        }
        function hindimovie() {
            $('html, body').animate({
                scrollTop: $("#hindimovie").offset().top
            }, 500);
            // window.location = "GCMPush.aspx";
        }



    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrap">
            <uc1:Header ID="HeaderControl" runat="server" />
            <div class="mainbody">
                <div class="Catname">
                    শর্ট ক্লিপ্স
                </div>
                <%--Bangla Music--%>
                <div id="BG">
                    <div class="section">
                        <div class="BanglaVideo" id="start">
                            <div class="vdtitle">
                                বাংলা গান
                            </div>
                        </div>
                        <asp:DataList ID="datalistBanglaMusic" Width="100%" RepeatColumns="2" runat="server">
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
                    <div class="horzontalineimg" id="banglamusic">
                        <asp:ImageButton ID="btnbanglamusic" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnbanglamusic_Click" runat="server" />

                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <%--Bangla End--%>



                <%--Bangla Music--%>
                <div id="BNC">
                    <div class="section">
                        <div class="BanglaVideo">
                            <div class="vdtitle">
                                <span id="Label17">বাংলা নাটক ক্লিপ্স </span>
                            </div>
                        </div>
                        <asp:DataList ID="datalistbangladrama" Width="100%" RepeatColumns="2" runat="server">
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
                    <div class="horzontalineimg" id="bangladrama">
                        <asp:ImageButton ID="btnbangladrama" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnbangladrama_Click" runat="server" />

                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <div id="EG">
                    <div class="section">
                        <div class="BanglaVideo">
                            <div class="vdtitle">
                                <span id="lblBollywoodFunnyScene">ইংলিশ গান</span>
                            </div>
                        </div>
                        <asp:DataList ID="datalistenglishmusic" Width="100%" RepeatColumns="2" runat="server">
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
                    <div class="horzontalineimg" id="Englishmusic">
                        <asp:ImageButton ID="btnenglishmusic" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnenglishmusic_Click" runat="server" />

                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <%--Bangla End--%>





                <%--Bangla Music--%>
                <div id="BMC">
                    <div class="section">
                        <div class="BanglaVideo" id="BanglaMovieClips">
                            <div class="vdtitle">
                               বাংলা সিনে ক্লিপ্স 
                            </div>
                        </div>
                        <asp:DataList ID="datalistbanglamovie" Width="100%" RepeatColumns="2" runat="server">
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
                    <div class="horzontalineimg" id="banglamovie">
                        <asp:ImageButton ID="btnbanglamovie" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnbanglamovie_Click" runat="server" />

                    </div>
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                <%--Bangla End--%>



                <%--Hindi Movie Clips--%>
                <div id="HMC">
                    <div class="section">
                        <div class="BanglaVideo" id="HindiMovieC">
                            <div class="vdtitle">
                                <span id="lblBollywoodHotScene">হিন্দি মুভি  ক্লিপ্স </span>
                            </div>
                        </div>
                        <asp:DataList ID="datalisthindimovie" Width="100%" RepeatColumns="2" runat="server">
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
                    <div class="horzontalineimg" id="hindimovie">
                        <asp:ImageButton ID="btnhindimovie" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnhindimovie_Click" runat="server" />
                        <div class="horzontaline">
                            <hr />
                        </div>
                    </div>
                </div>
                <%--Hindi Movie Clips--%>




                <%--Bangla Music--%>
                <div id="BCN">
                <div class="section">
                    <div class="BanglaVideo" id="bollywoodCelebrityNews">
                        <div class="vdtitle">
                            <span id="Label2">বলিউড সেলিব্রিটি  </span>
                        </div>
                    </div>
                    <asp:DataList ID="datalistcelebritynews" Width="100%" RepeatColumns="2" runat="server">
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
                <div class="horzontalineimg" id="celebritynews">
                    <asp:ImageButton ID="btncelebritynews" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btncelebritynews_Click" runat="server" />
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                </div>
                <%--Bangla End--%>


                <%--Bangla Music--%>
                <div id="BMR">
                <div class="section">
                    <div class="BanglaVideo" id="bollywoodMovieReview">
                        <div class="vdtitle">
                            বলিউড  মুভি  রিভিউ 
                        </div>
                    </div>
                    <asp:DataList ID="datalistmoviereview" Width="100%" RepeatColumns="2" runat="server">
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
                <div class="horzontalineimg" id="moviereview">
                    <asp:ImageButton ID="btnmoviereview" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnmoviereview_Click" runat="server" />
                    <div class="horzontaline">
                        <hr />
                    </div>
                </div>
                </div>
                <%--Bangla End--%>


                <%--Bangla Music--%>
                <div id="HMR">
                <div class="section">
                    <div class="BanglaVideo" id="hollywoodMovieReview">
                        <div class="vdtitle">
                            <span id="Label9">হলিউড মুভি রিভিউ</span>
                        </div>
                    </div>
                    <asp:DataList ID="datalistholymoviereviw" Width="100%" RepeatColumns="2" runat="server">
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
                <div class="horzontalineimg" id="gossip">
                    <asp:ImageButton ID="btnholymoviereview" ImageUrl="~/images/ArrowIcone.png"  Width="25%" OnClick="btnholymoviereview_Click" runat="server" />

                </div>
                <div class="horzontaline">
                    <hr />
                </div>
                    </div>
                <%--Bangla End--%>

                <%--Bangla Music--%>
                <div id="HG">
                <div class="section">
                    <div class="BanglaVideo">
                        <div class="vdtitle">
                            <span id="Label9">হলিউড গসিপ</span>
                        </div>
                    </div>
                    <asp:DataList ID="datalistholygossip" Width="100%" RepeatColumns="2" runat="server">
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
                    <asp:ImageButton ID="btngossip" ImageUrl="~/images/ArrowIcone.png" Width="25%" OnClick="btngossip_Click" runat="server" />

                </div>
                <div class="horzontaline">
                    <hr />
                </div>
                    </div>
                <%--Bangla End--%>
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

            if (myParam === 'BG') {  
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();
                                      
            }                         
            if (myParam === 'BNC') {
                $('#BG').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'EG') {
                $('#BG').hide();
                $('#BNC').hide();
                //$('#EG').hide(); 
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'BMC') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
               // $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'HMC') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                //$('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'BCN') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                //$('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'BMR') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                //$('#BMR').hide();
                $('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'HMR') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                //$('#HMR').hide();
                $('#HG').hide();

            }
            if (myParam === 'HG') {
                $('#BG').hide();
                $('#BNC').hide();
                $('#EG').hide();
                $('#BMC').hide();
                $('#HMC').hide();
                $('#BCN').hide();
                $('#BMR').hide();
                $('#HMR').hide();
                //$('#HG').hide();

            }



        };
    </script>
</body>
</html>
