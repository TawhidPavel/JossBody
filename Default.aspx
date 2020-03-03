<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="OtherLinks.ascx" TagName="Link" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />


    <title>JOSS BODY</title>

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />

    <link href="CSS/NewS/StyleSheet.css" rel="stylesheet" />

    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="cssTemplate" runat="server" />
    <link href="CSS/NewS/mystyle.css" rel="stylesheet" />
    <link href="Css/swiper.css" rel="stylesheet" />


    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 100%;
            margin: auto;
        }


        .swiper-container {
            width: 100%;
            height: 100%;
        }

        .swiper-slide {
            /*text-align: center;
        font-size: 18px;
        background: #fff;*/
            /* Center slide text vertically */
            display: -webkit-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
        }




        #bdtubebody {
            background: #000;
        }

        .loadvideo {
            position: absolute;
            bottom: 40%;
            width: 100%;
        }



        .video-js {
            padding-top: 56.25%;
        }

        .vjs-fullscreen {
            padding-top: 0px;
        }

        #bdtubebody {
            background: #fff;
        }

        .loadvideo {
            position: absolute;
            bottom: 40%;
            width: 100%;
        }

        .button-close {
            background-image: url(/Animation/addBtn.png);
            background-color: transparent; /* make the button transparent */
            background-repeat: no-repeat; /* make the background image appear only once */
            margin-right: 60%;
        }

        button.close {
            margin-left: 69%;
            margin-top: -2%;
        }
    </style>
    <style>
        .close {
            float: none;
            right: -28%;
            margin-top: -50px;
            opacity: 1;
            position: fixed;
            width: 62%;
            z-index: 999999999;
        }

        .modal-body {
            padding: 0px;
            position: relative;
        }

        .modal-content1 {
            background: none;
            border: none;
            border-radius: 0;
            box-shadow: none;
        }

        .videocontent img {
            border-radius: 5px;
            /*box-shadow: .3px .3px .3px .3px #c2c2c2;*/
            padding: 3px;
            width: 98%;
        }

        .vtitle {
            float: left;
            height: auto;
            margin: 0 0 0 -16px;
            color: #080808;
        }

        .viewieyeicone img {
            height: 18px;
            width: 15px;
            margin-bottom: 1px;
            margin-right: -7px;
        }

        .fo {
            text-align: center;
            width: 100%;
        }

        .buttonColor {
            background-color: #275a69;
        }

        .imgPlay {
            /*left: 8%;*/
            position: absolute;
            top: 65%;
            /*width: 83%;*/
        }

        .viewlike {
            padding-left: 10px;
            padding-top: 0;
            width: 100%;
        }

        .vieweyes, .viewlikes {
            height: 17px;
            width: 69px;
            float: left;
        }

            .vieweyes img {
                width: 6%;
            }

        .viewieyeicone {
            width: 34px;
            height: auto;
            float: left;
        }

            .viewieyeicone img {
                height: 10px;
                width: 10px;
            }
        .robititleMain {
            background: #58C1E6;
            color: #fff;
            font-family: Verdana,Tahoma,Arial;
            height: 36px;
            text-align: center;
            margin-bottom: 2px;
            margin-top: 2px;
        }
        .vtitle {
            float: left;
            height: auto;
            margin: 0 0 0 -22px;
            color: #a7a7a7;
        }

        .vtitle1 {
            float: left;
            height: auto;
            /*margin: 0 0 0 -22px;*/
            color: #a7a7a7;
        }

        .Icone_image {
            left: 41%;
            position: absolute;
            top: 32%;
        }


        .thumbnail1 {
            display: block;
            padding: 4px;
            /*margin-bottom: 20px;*/
            line-height: 1.42857143;
            background-color: #fff;
            border: 1px solid #ddd;
            /*border-radius: 4px;*/
            -webkit-transition: border .2s ease-in-out;
            -o-transition: border .2s ease-in-out;
            transition: border .2s ease-in-out;
        }

            .thumbnail1 a > img, .thumbnail1 > img {
                margin-right: auto;
                margin-left: auto;
            }

        a.thumbnail1.active, a.thumbnail1:focus, a.thumbnail1:hover {
            border-color: #337ab7;
        }

        .thumbnail1 .caption {
            padding: 9px;
            color: #333;
        }

        .moreBu {
            width: 66%;
            margin-right: -43px;
            /*margin-left: 45%;*/
           /* border-radius: 22%*/
        }
        .Title1 {
            background-color: #ffffff;
            font-size: 11px;
            /* font-weight: bold; */
            margin: 0;
            /* opacity: 0.5; */
            padding: 1px 5px 5px 10px;
            padding-left: 10px;
            margin: 0 0 0 2px;
        }
        .no-link{
            pointer-events: none;
            cursor: text;
            text-decoration: none;
            color: black;
        } 
    </style>

    <script>
        function pad2(n) { return n < 10 ? '0' + n : n }

        var date = new Date();

        function GetRef() {
            return date.getFullYear().toString() + pad2(date.getMonth() + 1) + pad2(date.getDate()) + pad2(date.getHours()) + pad2(date.getMinutes()) + pad2(date.getSeconds());

        }


        function GetDate() {
            return date.getFullYear().toString() + '-' + pad2(date.getMonth() + 1) + '-' +  pad2(date.getDate());
        }


        console.log(GetDate());


        $(document).ready(function ($) {
            var urlVars = getUrlVars();
            console.log(urlVars.length);
            console.log(urlVars.length);
            console.log(urlVars["endUserId"]);
            if (
                (urlVars["endUserId"] === "" || urlVars["endUserId"] === undefined) && (urlVars["errorDescription"] === undefined || urlVars["errorDescription"] === "")) {
                window.location
                    .href =
                    "http://vmsisdndp.grameenphone.com/digital5/proxy/vmsisdnprocess?servicekey=afef69c7cbbe4b55bb10d47dd5969677&serviceIdentifier=SUB00035204569&transactionDate=" + GetDate()+"&referenceCode=" + GetRef();

            } else if (urlVars["errorDescription"] === "") {
                window.location
                    .href =
                    "http://vmsisdndp.grameenphone.com/digital5/proxy/vmsisdnprocess?servicekey=afef69c7cbbe4b55bb10d47dd5969677&serviceIdentifier=SUB00035204569&transactionDate=" + GetDate() +"&referenceCode=" + GetRef();

            }

        });
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

    </script>
    <script>
        $(window).resize(function () {

            window.setInterval(function () {
                /// call your function here
                $('.swiper-slide').css('width', '100%');

            }, 1);


        });
    </script>

</head>
<body>
    <form id="form1" runat="server">



        <div class="container">

            <div class="modal fade" id="myModal" role="dialog" style="margin: 18px; position: fixed; z-index: 9999999;">

                <div class="modal-dialog modal-sm">
                    <button type="button" class="close" data-dismiss="modal">
                        <img width="10%" src="Animation/close-button.png" /></button>

                    <div class="modal-content1">

                        <div class="modal-body">
                            <img src="Animation/bd1.jpg" class="img-responsive" />


                            <div style="margin-left: auto; margin-right: auto; text-align: center; background-color: white">
                                <asp:Label runat="server" ID="lblNumber" Text="MSISDN" Style="text-align: center" Font-Bold="True" Font-Size="Large" CssClass="StrongText" Visible="False"></asp:Label>

                            </div>



                            <asp:ImageButton ImageUrl="~/Animation/addBtn.jpg" CssClass="img-responsive" ID="addButton" runat="server" OnClick="addButton_Click" />

                            <%--<img src="Animation/jog-din.jpg"  class="img-responsive"  onclick="secondclick()" style="cursor:pointer"/>--%>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModal2" role="dialog" style="margin: 18px; position: fixed; z-index: 9999999;">

                <div class="modal-dialog modal-sm">
                    <button type="button" class="close" data-dismiss="modal">
                        <img width="10%" src="Animation/close-button.png" /></button>

                    <div class="modal-content1">
                        <div class="modal-body">
                            <img src="Animation/bd2.jpg" class="img-responsive" />


                            <div style="margin-left: auto; margin-right: auto; text-align: center; background-color: white">
                                <asp:Label runat="server" ID="lblNumber2" Text="MSISDN" Style="text-align: center" Font-Bold="True" Font-Size="Large" CssClass="StrongText" Visible="False"></asp:Label>

                            </div>


                            <asp:ImageButton ImageUrl="~/Animation/confirmBtn.jpg" CssClass="img-responsive" ID="nishchitoButton" runat="server" OnClick="NishchitoButton_Click" />
                            <%-- <a href="Confirms.aspx"> <img src="Animation/nishchito.jpg" class="img-responsive" onclick="$('#myModal').modal('hide');$('#myModal2').modal('hide');" style=" cursor: pointer;"/>
                     </a>--%>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModal3" role="dialog" style="margin: 18px; position: fixed; z-index: 9999999;">

                <div class="modal-dialog modal-sm">
                    <button type="button" class="close" data-dismiss="modal">
                        <img width="10%" src="Animation/close-button.png" /></button>

                    <div class="modal-content1">
                        <div class="modal-body">
                            <img src="Animation/fire.jpg" class="img-responsive" />

                            <%-- <a href="Default.aspx">
                              <img src="Animation/quizplay-fire-jan.jpg" class="img-responsive"  style="cursor:pointer"/>
                        </a>  --%>

                            <img src="Animation/home.jpg" class="img-responsive" onclick="thirdclick()" style="cursor: pointer;" />

                        </div>
                    </div>
                </div>
            </div>

            <%--Modal after wtching five more videos --%>


            <div class="modal fade" id="myModal4" role="dialog" style="margin: 18px; position: fixed; z-index: 9999999;">

                <div class="modal-dialog modal-sm">
                    <button type="button" class="close" data-dismiss="modal">
                        <img width="10%" src="Animation/close-button.png" /></button>

                    <div class="modal-content1">
                        <div class="modal-body">
                            <img src="Animation/agrohim.png" class="img-responsive" />

                            <%-- <a href="Default.aspx">
                              <img src="Animation/quizplay-fire-jan.jpg" class="img-responsive"  style="cursor:pointer"/>
                        </a>  --%>

                            <img src="Animation/ag.jpg" class="img-responsive" onclick="reConfirm()" style="cursor: pointer;" />

                        </div>
                    </div>
                </div>
            </div>


        </div>












        <div class="Wrap" id="Wrapid" style="display: block">
            <uc1:Header ID="HeaderControl" runat="server" />


            <div class="mainbody">




                <%--slider--%>

                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                        <li data-target="#myCarousel" data-slide-to="4"></li>
                        <li data-target="#myCarousel" data-slide-to="5"></li>
                        <li data-target="#myCarousel" data-slide-to="6"></li>
                        <li data-target="#myCarousel" data-slide-to="7"></li>
                        <li data-target="#myCarousel" data-slide-to="8"></li>
                        <li data-target="#myCarousel" data-slide-to="9"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">

                        <asp:Literal ID="ltslider" runat="server"></asp:Literal>
                    </div>


                </div>



                <div class="BanglaMovie" style="margin-top: 2%" id="non" runat="server">


                    <div class="text-center">


                        
                       <%-- <asp:Button runat="server" CssClass=" btn btn-success" Text="নিবন্ধন" Font-Size="20px" OnClick="OnClick" Style="font-weight: bold;" />--%>
                         

                    </div>


                </div>
                <div runat="server" id="divSubscription" class="text-center">
                    <div id="subDiv" runat="server">
                        <p>ফিটনেস স্পেশালিস্টদের ফিটনেস ভিডিও দেখতে এবং ফিটনেস টিপস ফ্রি পড়তে নিচের বাটনটি অথবা যে কোনো কন্টেন্ট এ ক্লিক করুন ।</p>
                        <asp:Button runat="server" ID="btnSubscription" Text="Subscription" CssClass="btn btn-success" OnClick="btnSubscription_OnClick" />
                    </div>
                                   
                                    <asp:Button runat="server" ID="btnUnSubscription1" Text="Un-Subscription" CssClass="btn btn-danger" Visible="False" OnClick="btnUnSubscription_OnClick" />
                                </div>



                <%-- SliderEnd--%>
            <div class="Fullvideo">
                <div id="newVideo" class="robititle">
                        
                    &nbsp;
                    <div class="robititletext">
                        <span style="font-style: normal; font-size: 14px; padding-top: 3%">&nbsp;ওয়ার্ক আউট মিউজিক ভিডিও</span>
                    </div>
                    <div class="robititletext2">
                        <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">More > </a></span>--%>
                        <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/Videos.aspx?cid=60579B0C-259E-435A-A227-BF2E546DDCFE" ImageUrl="images/ar.png" />
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <asp:Literal ID="ltrlmusicVideos" runat="server"></asp:Literal>
                    </div>
                </div>

            </div>
                
                <div class="Fullvideo" style="display:none">
                    <div id="newVideo" class="robititle">
                        
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 14px; padding-top: 3%">&nbsp;গ্ল্যামারাস ফিটনেস ভিডিও</span>
                        </div>
                        <div class="robititletext2">
                            <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">More > </a></span>--%>
                            <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/Videos.aspx?cid=B6392C5F-5F5B-41BC-AC82-49CDA4169B11" ImageUrl="images/ar.png" />
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlHotVideos" runat="server"></asp:Literal>
                        </div>
                    </div>

                </div>


                 <div class="Fullvideo">
                    <div id="exclusive" class="robititle" style="display:none">
                       
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 14px; padding-top: 3%">&nbsp;এক্সক্লোসিভ ভিডিও   </span>
                        </div>
                        <div class="robititletext2">
                            <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">More > </a></span>--%>
                            <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/Videos.aspx?cid=A49ACD7E-010D-4937-9A74-AB9E8A9B36B7" ImageUrl="images/ar.png" ID="exbtn"  />
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlExclusiveVideo" runat="server"></asp:Literal>
                        </div>
                    </div>
                <div class="Fullvideo">
                    <div class="robititleMain">
                        
                        &nbsp;
                        
                        <span class="text-center" style="font-style: normal; font-size: 25px;font-weight: bold">ডেইলি এক্সারসাইজ ভিডিও</span>
                     

                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlExercise" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>

                
                
                
                

                <div class="Fullvideo">
                    <div class="robititleMain">
                        
                        &nbsp;
                        
                            <span class="text-center" style="font-style: normal; font-size: 25px;font-weight: bold">এনফোটেইনমেন্ট</span>
                     

                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlFitnessGuide" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
    
                
                

                <div class="Fullvideo" runat="server" Visible="False">
                    <div id="newVideo" class="robititle">
                        <div class="robititletext" style="padding-top: .8%">
                            <span class="glyphicon glyphicon-play"></span>
                        </div>
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 14px; padding-top: 5%">মোস্ট লাইক</span>
                        </div>
                        <div class="robititletext2">
                            <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">
                                 > </a></span>--%>
                            <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/MostLike.aspx" ImageUrl="images/more.png" />
                        </div>
                    </div>
                    <%--Number One--%>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="literalMostLiked" runat="server"></asp:Literal>

                        </div>
                    </div>




                </div>


                <div class="Fullvideo">
                    <div id="newVideo" class="robititle">
                        
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 14px; padding-top: 3%">&nbsp;সেলিব্রিটি ওয়ার্ক আউট ভিডিও  </span>
                        </div>
                        <div class="robititletext2">
                            <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">More > </a></span>--%>
                            <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/Videos.aspx?cid=CDCB34D0-363C-4281-AFE4-AE289138179D" ImageUrl="images/ar.png" />
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlLatestVideos" runat="server"></asp:Literal>
                        </div>
                    </div>

                </div>


                <div class="Fullvideo">
                    <div id="celebrityfitness" class="robititle">
                       
                        &nbsp;
                        <div class="robititletext">
                            <span style="font-style: normal; font-size: 14px; padding-top: 3%">&nbsp;হেলদি রেসিপি ভিডিও  </span>
                        </div>
                        <div class="robititletext2">
                            <%--<span><a runat="server" href="~/Newvideo.aspx" style="font-style: italic; font-size: 18px; background-color: #0f8bc5; border: 4px; border-radius: 4px;margin-right: 5px">More > </a></span>--%>
                            <asp:ImageButton runat="server" CssClass="moreBu" PostBackUrl="~/Videos.aspx?cid=DB3FED39-4577-4268-9FA0-CD6C967ED512" ImageUrl="images/ar.png" />
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <asp:Literal ID="ltrlFitnessSecrets" runat="server"></asp:Literal>
                        </div>
                    </div>

                </div>

                <div style="clear: both"></div>
                <div class="horzontaline">
                    <hr />
                </div>

            </div>
            <table class="container text-center">
                <tr id="cancelSubscriptionBlink" runat="server" visible="True">
                    <td class="text-center" style="font-size: 10px; padding-top: -5%">

                        <%--==================================ORIGINAL==================================================--%>
                        <%--<asp:LinkButton Text="Cancel Subscription" CssClass="btn btn-success" ID="LinkButton3" runat="server" OnClick="lbkbtnCancelSubscription_Click" Font-Underline="false" ForeColor="#FFFFFF">UN-SUBSCRIBE</asp:LinkButton>--%>
                        <%--==================================ORIGINAL==================================================--%>

                    </td>
                </tr>
            </table>
            
            <div runat="server" id="divS" style="text-align:right">
                <%--<div id="Div2" runat="server">
                    <p>ফিটনেস স্পেশালিস্টদের ফিটনেস ভিডিও দেখতে এবং ফিটনেস টিপস ফ্রি পড়তে নিচের বাটনটি অথবা যে কোনো কন্টেন্ট এ ক্লিক করুন ।</p>
                    <asp:Button runat="server" ID="Button1" Text="Subscription" CssClass="btn btn-success" OnClick="btnSubscription_OnClick" />
                </div>--%>
                
                
                                   
                <asp:Button runat="server" ID="btnUnSubscription" Text="CancelSubscription" CssClass="" Visible="False" style="height:10px; width: 50px;font-size : 4.5px; "  OnClick="btnUnSubscription_OnClick" />
            </div>
            <div style="clear: both"></div>
            <div class="horzontaline">
                <hr />
            </div>
            <div class="fo">
                <%-- <uc3:Link ID="a" runat="server" />--%>
                <uc2:Footer ID="FooterControl" runat="server" />
            </div>

        </div>

        <%--  <div style="width: 100%; height: auto; background: #000" id="load">
            <div class="loadvideo">
                <center><img src="Animation/BDTUBE-update.gif" width="50%" /></center>

            </div>
        </div>--%>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="js/hammer.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#myCarousel')
                .hammer()
                .on('swipeleft',
                function () {
                    $('#myCarousel').carousel('next');
                });
            $('#myCarousel')
                .hammer()
                .on('swiperight',
                function () {
                    $('#myCarousel').carousel('prev');
                });
        });
    </script>
    <script src="Js/swiper.js"></script>
    <script>
        var mySwiper = new Swiper('.swiper-container',
            {
                slidesPerView: 'auto',
                initialSlide: 0,
                loop: false,
                loopedSlides: 20
            });


    </script>

    <script type="text/javascript">
        var x = '<%=GetMsisdnValue()%>';
        // called server side method
        // alert(x);
        callFunction();
        function callFunction() {
            // alert(x);
            if (x === "-1") {
                $('#myModal').modal('show');
                $('#myModal2').modal('hide');
                $('#myModal3').modal('hide');
            }
            else if (x === "0") {
                $('#myModal').modal('hide');
                $('#myModal2').modal('hide');
                $('#myModal3').modal('show');
            }
            else if (x === "2") {
                $('#myModal').modal('hide');
                $('#myModal2').modal('show');
                $('#myModal3').modal('hide');
            }

        }


        function thirdclick() {

            $('#myModal').modal('show');// please register
            $('#myModal2').modal('hide');// Confirmation 
            $('#myModal3').modal('hide');// Wifi user
        }

        CallMyFunction();

    </script>

    <script>
        var myParam = location.search.split('mod=')[1] ? location.search.split('mod=')[1] : 'myDefaultValue';
        //alert(myParam);
        gg();
        function gg() {

            if (myParam === 'one') {

                $('#myModal').modal('hide'); // please register
                $('#myModal4').modal('show'); // Confirmation 
                $('#myModal3').modal('hide'); // Wifi user
            }


        };

        function reConfirm() {

            var msisdn = '<%=returnMsisdn()%>';
            var hsManu = '<%=returnMan()%>';
            var hsMod = '<%=returnMod()%>';
            var hsOs = '<%=returnOs()%>';
            var hsdim = '<%=returnDim()%>';
            //var like = $('#f').
            //alert(x);
            $.ajax({
                url: 'ajaxDbAccess.aspx',
                data: { flag: 'y', msisdn: msisdn, manu: hsManu, mod: hsMod, os: hsOs, dim: hsdim, op: 'agrohi' },
                dataType: 'text',
                method: 'get',
                success: function (data, textStatus, jqXHR) {
                    //toastr.success('You Like the Video', 'confirmation message');
                    // console.log(data);
                    if (data == 'error') {
                        window.location = "default.aspx?mod=one";
                    }
                    else {
                        window.location = "default.aspx";
                    }
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
    <script>
        $(document).ready(function () {

            $(this).on('contextmenu', function (e) {

                //e.preventDefault();
            });

        });
    </script>
</body>
</html>
