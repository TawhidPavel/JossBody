<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FitnessSecrets.aspx.cs" Inherits="FitnessSecrets" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />


    <title>JOSS BODY</title>

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />


    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="cssTemplate" runat="server" />
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
            box-shadow: .3px .3px .3px .3px #c2c2c2;
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

        .viewlikes1 {
            height: 17px;
            width: 100px;
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

        .teest {
            width: 50%;
            height: 50%;
            padding-left: 5%;
            margin-left: 68%;
        }

        .moreBu1 {
            width: 70%;
            margin-left: 6%;
            margin-top: -11%;
        }
    </style>
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



        <div class="Wrap" id="Wrapid" style="display: block">
            <uc1:Header ID="HeaderControl" runat="server" />


            <div class="mainbody">

                <%-- Zumba Session Start--%>
                <div class="Fullvideo">
                    <div class="ftnTitle">
                    </div>
                </div>


                <div class="container">
                    <div class="row">
                        <asp:Repeater ID="repeaterFitnessSecrets" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-6 col-md-6 col-xs-6" style="padding-left: 2px; padding-right: 2px; padding-top: -5px; padding-bottom: -25px;">
                                    <asp:HyperLink ID="vdoPic" runat="server" CssClass="thumbnail img-responsive" NavigateUrl='<%# Eval("path")%>' ImageUrl='<%# Bind("imageUrl") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class="col-xs-offset-9 col-xs-4">
                            <asp:ImageButton runat="server" CssClass="moreBu1" PostBackUrl="~/MoreFitnessSession.aspx?type=fitnessSecrets" ImageUrl="images/more.png" />
                        </div>
                    </div>

                    </div>
                    <%-- Zumba Session End--%>



              




                    <div style="clear: both"></div>
                    <div class="horzontaline">
                        <hr />
                    </div>



                    <div class="fo">
                        <%-- <uc3:Link ID="a" runat="server" />--%>
                        <uc2:Footer ID="FooterControl" runat="server" />
                    </div>

                </div>
            </div>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="js/hammer.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>


    
   


</body>
</html>

