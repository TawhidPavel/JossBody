<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />


    <title>BDTube</title>

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />


    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="cssTemplate" runat="server"/>
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
            height:18px;
            width:15px;
            margin-bottom:1px;
            margin-right:-7px;
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

                        <%--<div class="item active">
                            <asp:HyperLink ID="HyperLink1" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Shei_Meyeti_By_Bappa_Mazumder_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=1E66E825-9A84-4FEA-B92D-0B02D165E9F6&CategoryCode=A5D68929-8921-4ECD-8151-E36A3871EB95&sPreviewUrl=Shei_Meyeti_By_Bappa_Mazumder.jpg &ContentTitle=Shei_Meyeti_By_Bappa_Mazumder&sContentType=FV&sPhysicalFileName=Shei_Meyeti_By_Bappa_Mazumder&ZedID=D847BB66-8FBF-4357-BD5E-34DDE8148418&sposter=bigPreview_Shei_Meyeti_By_Bappa_Mazumder_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>

                        </div>

                        <div class="item">
                            <asp:HyperLink ID="HyperLink2" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Moneer_Nao_By_Sabrina_N_Kazi_Shuvo_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=DEBE78C7-C823-4373-8338-74E75C33C043&CategoryCode=E8E4F496-9CA9-4B35-BADD-9B6470BE2F74&sPreviewUrl=Moner_Nao_By_Sabrina_N_Kazi_Shuvo.jpg &ContentTitle=Moner_Nao_By_Sabrina_N_Kazi_Shuvo&sContentType=FV&sPhysicalFileName=Moner_Nao_By_Sabrina_N_Kazi_Shuvo&ZedID=1A093413-AD5E-4973-AD2F-46A1C716C178&sposter=bigPreview_Moneer_Nao_By_Sabrina_N_Kazi_Shuvo_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>
                        </div>

                        <div class="item">

                            <asp:HyperLink ID="HyperLink3" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=B045FB56-0EF5-4023-AFEF-CD814DF99B6F&CategoryCode=E8E4F496-9CA9-4B35-BADD-9B6470BE2F74&sPreviewUrl=Valobashar_Pronoy_By_Arfin_Shuvo.jpg &ContentTitle=Valobashar_Pronoy_By_Arfin_Shuvo&sContentType=FV&sPhysicalFileName=Valobashar_Pronoy_By_Arfin_Shuvo&ZedID=2C3BB987-0E08-46F8-BB5B-E3853647474C&sposter=bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>
                        </div>

                        <div class="item">
                            <asp:HyperLink ID="HyperLink4" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Rongilare_By_Mon_Janena_Moner_Thikana_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=E78C818D-F1EB-4ED6-AE33-226CC7C0FE4D&CategoryCode=A5D68929-8921-4ECD-8151-E36A3871EB95&sPreviewUrl=Rongilare_By_Mon_Janena_Moner_Thikana.jpg &ContentTitle=Rongilare_By_Mon_Janena_Moner_Thikana&sContentType=FV&sPhysicalFileName=Rongilare_By_Mon_Janena_Moner_Thikana&ZedID=B90B1FF3-46CD-4B97-B5AD-5CC982F26952&sposter=bigPreview_Rongilare_By_Mon_Janena_Moner_Thikana_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>
                        </div>
                        <div class="item">
                            <asp:HyperLink ID="HyperLink5" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=B045FB56-0EF5-4023-AFEF-CD814DF99B6F&CategoryCode=E8E4F496-9CA9-4B35-BADD-9B6470BE2F74&sPreviewUrl=Valobashar_Pronoy_By_Arfin_Shuvo.jpg &ContentTitle=Valobashar_Pronoy_By_Arfin_Shuvo&sContentType=FV&sPhysicalFileName=Valobashar_Pronoy_By_Arfin_Shuvo&ZedID=2C3BB987-0E08-46F8-BB5B-E3853647474C&sposter=bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>
                        </div>
                        <div class="item">
                            <asp:HyperLink ID="HyperLink6" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=B045FB56-0EF5-4023-AFEF-CD814DF99B6F&CategoryCode=E8E4F496-9CA9-4B35-BADD-9B6470BE2F74&sPreviewUrl=Valobashar_Pronoy_By_Arfin_Shuvo.jpg &ContentTitle=Valobashar_Pronoy_By_Arfin_Shuvo&sContentType=FV&sPhysicalFileName=Valobashar_Pronoy_By_Arfin_Shuvo&ZedID=2C3BB987-0E08-46F8-BB5B-E3853647474C&sposter=bigPreview_Valobashaar_Pronoy_By_Arfin_Shuvo_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>
                        </div>--%>
                      
                        <%--  <div class="item active">
                            <asp:HyperLink ID="HyperLink1" ImageUrl="http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/bigPreview_Shei_Meyeti_By_Bappa_Mazumder_400x200.jpg" NavigateUrl="Contentdownload.aspx?content_code=1E66E825-9A84-4FEA-B92D-0B02D165E9F6&CategoryCode=A5D68929-8921-4ECD-8151-E36A3871EB95&sPreviewUrl=Shei_Meyeti_By_Bappa_Mazumder.jpg &ContentTitle=Shei_Meyeti_By_Bappa_Mazumder&sContentType=FV&sPhysicalFileName=Shei_Meyeti_By_Bappa_Mazumder&ZedID=D847BB66-8FBF-4357-BD5E-34DDE8148418&sposter=bigPreview_Shei_Meyeti_By_Bappa_Mazumder_400x200.jpg&sMasterCat=clips&totalView=0&totalLike=0" runat="server"></asp:HyperLink>

                        </div>--%>

                    </div>

     
                </div>

                <%-- SliderEnd--%>




                <div class="Fullvideo">
                    <div  id="video"  class="robititle">
                        <div class="robititletext">
                            <span>ভিডিও</span>
                        </div>
                        <div class="robititletext2">
                            <span><a runat="server" href="~/Morevide.aspx">আরও...</a></span>
                        </div>
                    </div>

                    <asp:Literal ID="ltFullvideo" runat="server"></asp:Literal>

                </div>

                <div class="Fullvideo">
                    <div id="SC" class="robititle">
                        <div class="robititletext">
                            <span>শর্ট ক্লিপ্স</span>
                        </div>
                        <div class="robititletext2">
                            <span><a runat="server" href="~/ShortVideo.aspx">আরও...</a></span>
                        </div>
                    </div>
                    <%--Number One--%>
                    <asp:Literal ID="ltshortvideo" runat="server"></asp:Literal>

                </div>



                <div class="Fullvideo">
                    <div id="mov" class="robititle">
                        <div class="robititletext">
                            <span>মুভি</span>
                        </div>
                        <div class="robititletext2">
                            <span><a runat="server" href="~/Movie.aspx">আরও...</a></span>
                        </div>
                    </div>
                    <%--Number One--%>
                    <asp:Literal ID="ltmovie" runat="server"></asp:Literal>

                </div>

                <div class="Fullvideo">
                    <div id="natok" class="robititle">
                        <div class="robititletext">
                            <span>নাটক </span>
                        </div>
                        <div class="robititletext2">
                            <span><a runat="server" href="~/BanglaNatok.aspx">আরও...</a></span>
                        </div>
                    </div>
                    <%--Number One--%>
                    <asp:Literal ID="ltNatok" runat="server"></asp:Literal>

                </div>




                <div class="Fullvideo">
                    <div id="newVideo" class="robititle">
                        <div class="robititletext">
                            <span>নতুন ভিডিও</span>
                        </div>
                        <div class="robititletext2">
                            <span><a runat="server" href="~/Newvideo.aspx">আরও...</a></span>
                        </div>
                    </div>
                    <%--Number One--%>
                    <asp:Literal ID="ltnewvideo" runat="server"></asp:Literal>


                </div>



                <div style="clear: both"></div>
                <div class="horzontaline">
                    <hr />
                </div>

            </div>
             <table>
                    <tr id="cancelSubscriptionBlink" runat="server" Visible="False">
                            <td align="right" style="font-size: 10px; padding-top: -5%">
                                <asp:LinkButton Text="Cancel Subscription" ID="LinkButton3" runat="server" OnClick="lbkbtnCancelSubscription_Click"  Font-Underline="false"  ForeColor="#F16521">Cancel Subscription</asp:LinkButton>
                            </td>
                        </tr>
                        </table>
            <div class="link">
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
            $('#myCarousel').hammer().on('swipeleft', function () {
                $('#myCarousel').carousel('next');
            })
            $('#myCarousel').hammer().on('swiperight', function () {
                $('#myCarousel').carousel('prev');
            })
        });
    </script>
    <script src="Js/swiper.js"></script>
    <script>
        var mySwiper = new Swiper('.swiper-container', {
            slidesPerView: 'auto',
            initialSlide: 0,
            loop: false,
            loopedSlides: 20,
        });


        //(function () {
        //    var myVar;

           
        //    myVar = setTimeout(showPage, 1);
        //    function showPage() {
        //        //document.getElementById("load").style.display = "none";
        //        document.getElementById("Wrapid").style.display = "block";


        //    }
        //})();






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
        $(document).ready(function() {

            $(this).on('contextmenu', function(e) {

                e.preventDefault();
            });

        });
    </script>
</body>
</html>
