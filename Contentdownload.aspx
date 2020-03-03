<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contentdownload.aspx.cs" Inherits="Contentdownload" %>


<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
    <title>JOSS BODY</title>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
    <%-- <link href="http://vjs.zencdn.net/5.8.8/video-js.css" rel="stylesheet">
      <script src="http://vjs.zencdn.net/5.8.8/video.js"></script>--%>
    <!-- If you'd like to support IE8 -->
    <%-- <script src="http://vjs.zencdn.net/ie8/1.1.2/videojs-ie8.min.js"></script>--%>
    <link href="StyleSheet/video-js.css" rel="stylesheet" />
    <link href="Js/toastr.min.css" rel="stylesheet" />
    <style>
        .viewieyeicone img {
            height: 18px;
            width: 15px;
            margin-bottom: 1px;
            margin-right: 1px;
        }

        .imgplay.img-responsive {
            margin-left: 83%;
            margin-top: -15%;
            width: 15%;
        }
        .Title1 {
            background-color: #ffffff;
            font-size: 11px;
            font-weight: bold;
            margin: 0;
            /* opacity: 0.5; */
            padding: 1px 5px 5px 10px;
            padding-left: 10px;
            margin: 0 0 0 2px;
        }
    </style>
    <script src="Js/toastr.min.js"></script>


    <script src="StyleSheet/video.js"></script>
    <script type="text/javascript">





        $(document).ready(function () {


            $("#clsspan").click(function () {

                //alert('See');
                $('.vjs-big-play-button').click();

                $('.video2').css("display", "block");
                $('.video1').css("display", "none");

            });

            $('#l').click(function () {
                //alert('Liked');

            });
            

        });

        function jsplay() {
            $(document).ready(function () {

            });
        }



        function Like() {
            var x = '<%=GetContentid()%>';
            //var like = $('#f').
            var z = '<%=GetCategoryCode()%>';
            $.ajax({
                url: 'ajaxDbAccess.aspx',
                data: { flag: 'y', contentId: x, op: 'setLike', categorycode: z },
                dataType: 'text',
                method: 'get',
                success: function (data, textStatus, jqXHR) {
                    toastr.success('You Like the Video');
                    $('#lblLikeCount').text(data);
                    // window.location = "Home.aspx?mod=one";
                    // console.log(data);

                    //  $('#lblGenre').text(data.ID);

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    toastr.error('', 'confirmation message');
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);

                }
            });



        }


        function view() {
            var x = '<%=GetContentid()%>';
            var y = '<%=GetMsisdn()%>';
            var z = '<%=GetCategoryCode()%>';
            var contentType = '<%=GetContentType()%>';
            var zedId = '<%=GetZedId()%>';
            var contentTitle = '<%=GetContentTitle()%>';
            var sma = '<%=GetSmaster()%>';
            //var like = $('#f').

            $.ajax({
                url: 'ajaxDbAccess.aspx',
                data: { flag: 'y', contentId: x, msisdn: y, categorycode: z, sMasterCat: sma, ContentTitle: contentTitle, ContentType: contentType, ZedID: zedId, op: 'setView' },
                dataType: 'text',
                method: 'get',
                success: function (data, textStatus, jqXHR) {
                    // alert(data.value);
                    if (data == "-1") {
                        window.location = "Agrohi.aspx";
                    }
                    if (data == "notSubscribe") {
                        window.location = "default.aspx";
                    }
                    //toastr.success('You Like the Video', 'confirmation message');
                    // console.log(data);

                    //  $('#lblGenre').text(data.ID);

                },
                error: function (jqXHR, textStatus, errorThrown) {
                   // window.location = "default.aspx";
                    //toastr.error('Please Use Mobile', 'confirmation message');
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);

                }
            });

        }

        function Fav() {
            var e = '<%=GetContentid()%>';
            var y = '<%=GetMsisdn()%>';
            //var like = $('#f').

            $.ajax({
                url: 'ajaxDbAccess.aspx',
                data: { flag: 'y', contentId: e, msisdn: y, op: 'setFav' },
                dataType: 'text',
                method: 'get',
                success: function (data, textStatus, jqXHR) {
                    toastr.success('Now this video is in your Favourite List');
                    // console.log(data);

                    //  $('#lblGenre').text(data.ID);

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    toastr.error('', 'confirmation message');
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);

                }
            });



        }


    </script>
    <style>
        .preview {
            width: 50%;
            height: auto;
            float: left;
            margin: 0 auto;
            /*   margin-top: 30px; */
            padding: 1px 2px;
            background: #fcfdff;
            /*   border: 6px solid #eaeaea; */
            border: 2px solid #eee;
            border-radius: 2px;
            margin-bottom: 10px;
        }

            .preview img {
                /*  padding: 2%;*/
                width: 100%;
                height: auto;
            }

        .Icone_image {
            left: 35%;
            position: absolute;
            top: 32%;
        }
    </style>
    <style>
        .ten {
            position: center;
        }

        .example3 {
            height: 20px;
            overflow: hidden;
            position: relative;
        }
         .rounda{
	   
	    border: 2px solid #58C1E6;
	    
	    border-radius: 50%;
	    float: left;
	    /*height: 38.5px;*/
	    /*line-height: 38px;*/
	    /*margin: 0 8px 0 0;*/
	    padding: 1px;
	    text-align: center;
	    width: 38px;
        border-style: double;
	  
	   
	   
    }

            .example3 h5 {
                position: absolute;
                width: 100%;
                height: 100%;
                margin: 0 0 0 5px !important;
                line-height: 20px;
                /* Starting position */
                -moz-transform: translateX(100%);
                -webkit-transform: translateX(100%);
                transform: translateX(100%);
                /* Apply animation to this element */
                -moz-animation: example3 10s ease infinite;
                -webkit-animation: example3 10s ease infinite;
                animation: example3 10s ease infinite;
            }
        /* Move it (define the animation) */
        @-moz-keyframes example3 {
            0% {
                -moz-transform: translateX(100%);
            }

            40% {
                -moz-transform: translateX(0%);
            }

            60% {
                -moz-transform: translateX(0%);
            }

            100% {
                -moz-transform: translateX(-100%);
            }
        }

        @-webkit-keyframes example3 {
            0% {
                -webkit-transform: translateX(100%);
            }

            40% {
                -webkit-transform: translateX(0%);
            }

            60% {
                -webkit-transform: translateX(0%);
            }

            100% {
                -webkit-transform: translateX(-100%);
            }
        }

        @keyframes example3 {
            0% {
                -moz-transform: translateX(100%); /* Firefox bug fix */
                -webkit-transform: translateX(100%); /* Firefox bug fix */
                transform: translateX(100%);
            }

            40% {
                -moz-transform: translateX(0%); /* Firefox bug fix */
                -webkit-transform: translateX(0%); /* Firefox bug fix */
                transform: translateX(0%);
            }

            60% {
                -moz-transform: translateX(0%); /* Firefox bug fix */
                -webkit-transform: translateX(0%); /* Firefox bug fix */
                transform: translateX(0%);
            }

            100% {
                -moz-transform: translateX(-100%); /* Firefox bug fix */
                -webkit-transform: translateX(-100%); /* Firefox bug fix */
                transform: translateX(-100%);
            }
        }
        .border {
            border-width: 2px;
            border-color: #5cb5ff;
            border-style: solid;
            border-radius: 27px;
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrap">
            <uc1:Header ID="HeaderControl" runat="server" />
            <div class="mainbody">
                <div style="width: 100%; background: #fff;">
                    <div style="width: 99%; height: auto; padding: 2px; background: #000">
                        <div class="video1" id="smartphone1" runat="server">
                            <asp:Literal ID="ltvideo" Visible="true" runat="server"></asp:Literal>
                        </div>

                        <div class="video2" style="display: none" id="fphone" runat="server">
                            <asp:Literal ID="ltvideo2" Visible="true" runat="server"></asp:Literal>
                        </div>


                    </div>
                </div>



                <div class="BanglaMovie">
                    <div class="" style="margin-bottom: 4px;">

                        <div class="example3">

                            <h5>
                                <asp:Label ID="lbltitlename" CssClass="Title" runat="server" Text="Label">
                                
                                </asp:Label></h5>
                             <span style="margin-left: 20%; color: red;">

                                       <asp:Label runat="server" ID="lblten" Text="" Visible="False"></asp:Label>
                                    </span>
                        </div>
                        <div style="margin-top: 5px; margin-bottom: 20px;">
                            <div class="" style="margin-bottom: 4px;">

                                <div style="padding-left: 5px;">
                                     <span style="font-weight: bold; color: red">Duration:</span>
                                    <span style="font-weight: bold; color: red">
                                        <asp:Label ID="lblDuration" runat="server" Text="Label"></asp:Label>
                                    </span>

                                    <%--<span style="float: right; margin-right: 18px; margin-top: 3px;">
                                        <img id="l" class="like-count" style="width: 25px; height: 25px; margin-top: -65%;" onclick="Like()" src="images/like25.png" />

                                    </span>
                                   
                                    <span style="float: right; margin-right: 5px; margin-top: -4px;">
                                        <asp:Label ID="lblLikeCount" runat="server" Text="40" CssClass="lleee" Font-Bold="False"></asp:Label>
                                    </span>--%>
                                    <span style="float: right; margin-right: 18px; margin-top: 3px;">
                                        <img id="uu" class="like-count" style="width: 25px; height: 18px; margin-top: -65%;margin-left: 8%;"  src="images/vi.png" />

                                    </span>
                                    <span style="float: right; margin-right: 5px; margin-top: -4px;">
                                        <asp:Label ID="lblView" runat="server" CssClass="ddf" Text="40" Font-Bold="False"></asp:Label>
                                    </span>
                                    
                                    <span style="float: right; margin-right: 18px; margin-top: 3px;">
                                        <%--<asp:Label ID="lblLikeCount" runat="server" Text="40"></asp:Label> &nbsp;--%>
                                        <%--<asp:ImageButton ImageUrl="images/fav.png" tyle="width: 25px; height: 25px;" class="favourit-count" ID="nishchitoButton" OnClientClick="fa" runat="server" />--%>
                                        <img id="f" style="width: 25px; height: 25px; margin-top: -65%;margin-left: 57%;margin-left: -6%;display:none" onclick="Fav()" class="favourit-count" src="images/fav.png" />
                                    </span>
                                </div>
                                <div style="padding-left: 5px;">
                                    <span style="font-weight: bold;">Info:</span>
                                    <span style="font-size: .88em;">
                                        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </div>
                                <div style="padding-left: 5px; display:none">
                                    <span style="font-weight: bold;">Genre:</span>
                                    <span style="font-size: .88em;">
                                        <asp:Label ID="lblGenre" runat="server" Text="Label"></asp:Label>
                                    </span> <br/>
                                   
                                   
                                        
                                </div>
                                
                            </div>


                        </div>


                    </div>



                    <%--  <center>

                      
                        <img src="images/Watch_R.png" id="clsspan" />
                        <%--<asp:ImageButton ID="imgwatch" OnClick="imgwatch_Click"  ImageUrl="~/images/Watch_R.png" runat="server"  />--%>

                    <%--</center>--%>
                </div>
                <div class="BanglaMovie">
                    <div class="vdtitle">
                        <asp:Label ID="Label1" runat="server" Text="সংশ্লিষ্ট ভিডিও"></asp:Label>

                    </div>
                </div>
                <div class="relatedgroup">

                    <asp:DataList ID="dataListRelatedvideo" Width="100%" RepeatColumns="1" runat="server">
                        <ItemTemplate>

                            <div style="width: 100%; height: auto;">
                                <div class="preview">
                                    <%--<img src="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Shironame_By_Rafat_00190_400x200.jpg" />--%>


                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="imgResizeTest"
                                        NavigateUrl='<%# Eval("path")+"&sMasterCat=" + Request.QueryString["sMasterCat"].ToString() %>'
                                        ImageUrl='<%# Bind("imageUrl") %>' />

                                    <img src="images/play-button.png" class="imgplay img-responsive imgResizeTest" />

                                </div>
                                <div class="rvideotitle">
                                    <span class="Title1">
                                        <%# Eval("ContentTile") %>
                                        <br />

                                      <span style="float: right" class='viewieyeicone' >
                                            <img src='images/vi.png' /><%# Eval("totalView") %></span><br />
                                        <%--  <span style="float: right" class="viewieyeicone">
                                            <img src='images/lik.png' /><%# Eval("totalLike") %></span>--%>

                                    </span>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:DataList>

                    <center><asp:ImageButton ID="imgMore" ImageUrl="~/images/aro-video.png" runat="server" Width="25%" CssClass="border"  OnClick="ImageButton1_Click"/></center>


                </div>

                <table>
                    <tr id="cancelSubscriptionBlink" runat="server" visible="True">
                        
                        <%--===========================ORIGINAL===========================================--%>

                        <%--<td align="right" style="font-size: 10px; padding-top: -5%">
                            <asp:LinkButton Text="Cancel Subscription" CssClass="btn btn-success" ID="LinkButton3" runat="server" OnClick="lbkbtnCancelSubscription_Click" Font-Underline="false" ForeColor="#FFFFFF">UN-SUBSCRIBE</asp:LinkButton>
                        </td>--%>
                        
                        
                        <%--===========================ORIGINAL===========================================--%>
                    </tr>
                </table>
               
            </div>


            <uc2:Footer ID="FooterControl" runat="server" />

          
        </div>





    </form>
    <script src="Jscript/jwplayer.js"></script>
    <script src="Jscript/video.js"></script>
</body>
</html>
