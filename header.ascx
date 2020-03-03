<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="header" %>

<style>
    #showRightPush > span {
        border: 1px solid;
        margin-left: 10px;
        padding: 0 10px;
        font-weight: bold;
    }
</style>
<%--<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>--%>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<style>
    
    .aa
    {background-color:#58C1E6;border-color:#58C1E6}
    .btn-warning .badge{color:#58C1E6;background-color:#fff}
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<link href="StyleSheet/bootstarp.css" rel="stylesheet" />

<%--<script src="Jscript/modernizr.custom.js"></script>--%>
<script type="text/javascript">

  

    (function ($) {
        $(document).ready(function () {
            $(document).ready(function () {

                $('#cssmenu > ul > li ul').each(function (index, e) {
                    var count = $(e).find('li').length;
                    var content = '<span class=\"cnt\">' + count + '</span>';
                    $(e).closest('li').children('a').append(content);
                });
                $('#cssmenu ul ul li:odd').addClass('odd');
                $('#cssmenu ul ul li:even').addClass('even');
                $('#cssmenu > ul > li > a').click(function () {
                    $('#cssmenu li').removeClass('active');
                    $(this).closest('li').addClass('active');
                    var checkElement = $(this).next();
                    if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
                        $(this).closest('li').removeClass('active');
                        checkElement.slideUp('normal');
                    }
                    if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
                        $('#cssmenu ul ul:visible').slideUp('normal');
                        checkElement.slideDown('normal');
                    }
                    if ($(this).closest('li').find('ul').children().length == 0) {
                        return true;
                    } else {
                        return false;
                    }
                });

            });

        });
    })(jQuery);



    var navU = navigator.userAgent;

    // Android Mobile
    var isAndroidMobile = navU.indexOf('Android') > -1 && navU.indexOf('Mozilla/5.0') > -1 && navU.indexOf('AppleWebKit') > -1;

    // Apple webkit
    var regExAppleWebKit = new RegExp(/AppleWebKit\/([\d.]+)/);
    var resultAppleWebKitRegEx = regExAppleWebKit.exec(navU);
    var appleWebKitVersion = (resultAppleWebKitRegEx === null ? null : parseFloat(regExAppleWebKit.exec(navU)[1]));

    // Chrome
    var regExChrome = new RegExp(/Chrome\/([\d.]+)/);
    var resultChromeRegEx = regExChrome.exec(navU);
    var chromeVersion = (resultChromeRegEx === null ? null : parseFloat(regExChrome.exec(navU)[1]));

    // Native Android Browser
    var isAndroidBrowser = isAndroidMobile && (appleWebKitVersion !== null && appleWebKitVersion < 537) || (chromeVersion !== null && chromeVersion < 37);


    if (isAndroidBrowser) {
        //alert("abc");
        $(document).ready(function () {
            $("#cssmenu").css("margin-top", "0px");
        });
    }


</script>

<style>
    #cbp-spmenu-s1 {
        font-weight: bolder !important;
    }

    .accordion {
        overflow: visible !important;
    }

    .input-group {
        margin-bottom: 5%;
    }
</style>

<div class="header">
    <div class="headerlog">
        <img src="~/images/headerj.png" class="headerimg"  id="ha" runat="server" />
        <img src="images/search.png" class="searchicone" style="width: 10%; position: absolute; right: 5px; top: 10px" />
    </div>
    <div class="manu">
      
        <div id='cssmenu' style="display: none">
            <ul style="border-top: #e9967a solid 1px;">
             <li class='active'><a runat="server" href="~/Default.aspx"><span><img src="Icon/home.png" style="max-height: 25px;max-width: 25px"/> হোম </span></a></li>
                <%--  <li class='has-sub'><a href="#accordion-1" class="accordion-section-title"><span><img src="Icon/music-video.png" style="max-height: 25px;max-width: 25px"/> ফিটনেস গাইড </span></a>
                    <ul>
                        <li id="v01" runat="server"><a runat="server" href="~/TextPage.aspx?type=5"><span> ফিটনেস সেশন  </span></a></li>
                        <li id="v02" runat="server"><a runat="server" href="~/TextPage.aspx?type=1"><span> হেলথি ডায়েট</span></a></li>
                        <li class='last' id="Li2" runat="server"><a runat="server" href="~/TextPage.aspx?type=6"><span> সেলিব্রিটি ফিটনেস </span></a></li>
                        <li class='last' id="v03" runat="server"><a runat="server" href="~/TextPage.aspx?type=10"><span> হোম রেমেডি </span></a></li>
                    </ul>
                </li>

                <li class='active'><a runat="server" href="~/MoreFitnessSession.aspx?type=fitnessSecrets"><span><img src="Icon/fitness.png" style="max-height: 25px;max-width: 25px"/>সেলিব্রিটি ফিটনেস সিক্রেট</span></a></li>
                <li class='has-sub'><a href="#accordion-1" class="accordion-section-title"><span><img src="Icon/comedy.png" style="max-height: 25px;max-width: 25px"/> ফিটনেস সেশন</span></a>
                    <ul>
                        <li id="Li1" runat="server"><a runat="server" href="~/MoreFitnessSession.aspx?type=zumba"><span>জুম্বা </span></a></li>
                        <li id="Li3" runat="server"><a runat="server" href="~/MoreFitnessSession.aspx?type=yoga"><span>যোগ ব্যয়াম</span></a></li>
                        <li class='last' id="Li4" runat="server"><a runat="server" href="~/MoreFitnessSession.aspx?type=easy"><span>ইজি ওয়ার্ক আউট  </span></a></li>
                       
                    </ul>
                </li>
              

                <li class='last'><a runat="server" href="~/Fav.aspx"><span><img src="Icon/favourite.png" style="max-height: 25px;max-width: 25px"/>ফেভারিট</span></a></li>--%>
                <li class='last'><a runat="server" href="~/Videos.aspx?cid=7BA286C1-81B8-4267-BF0D-D6057CDC3CFE"><span><img src="fitmenuicon/wl.png" style="max-height: 25px;max-width: 25px"/> ওয়েট লস এক্সারসাইজ ভিডিও</span></a></li>
                <li class='last'><a runat="server" href="~/Videos.aspx?cid=B4955166-7C8B-4E0E-81DF-75A2FCCA6187"><span><img src="fitmenuicon/dyp.png" style="max-height: 25px;max-width: 25px"/> ডেইলি ইয়োগা প্রাকটিস ভিডিও</span></a></li>
                <li class='last'><a runat="server" href="~/Videos.aspx?cid=D8958FA5-DFA9-40F0-B831-92771E5CA3F8"><span><img src="fitmenuicon/hrc.png" style="max-height: 25px;max-width: 25px"/> হোম রেমেডি চ্যানেল ভিডিও</span></a></li>
                <li class='last'><a runat="server" href="TextPage.aspx?type=3A827B46-C8EA-4D1A-B1BE-3BFF59014168"><span><img src="fitmenuicon/ft.png" style="max-height: 25px;max-width: 25px"/>ফুড টিপস </span></a></li>
                <li class='last'><a runat="server" href="TextPage.aspx?type=12EE8772-F439-4354-AA4F-427BFA8D41A0"><span><img src="fitmenuicon/ht.png" style="max-height: 25px;max-width: 25px"/>হেলথ টিপস</span></a></li>
                <li class='last'><a runat="server" href="~/Videos.aspx?cid=CDCB34D0-363C-4281-AFE4-AE289138179D"><span><img src="fitmenuicon/cwv.png" style="max-height: 25px;max-width: 25px"/> সেলিব্রিটি ওয়ার্ক আউট ভিডিও</span></a></li>

                <li class='last'><a runat="server" href="~/Videos.aspx?cid=DB3FED39-4577-4268-9FA0-CD6C967ED512"><span><img src="fitmenuicon/hrv.png" style="max-height: 25px;max-width: 25px"/> হেলদি রেসিপি ভিডিও</span></a></li>
                        <%-- <li>
                    <a href="https://play.google.com/store/apps/details?id=bdtube.vumobile.com.bdtube" runat="server">
                        <span><img src="Images/gplay.png" style="max-height: 35px;max-width: 120px"/></span>
                    </a>
                </li>   --%>
            </ul>
        </div>
    </div>

    <div class="input-group" style="display: none">

        <asp:TextBox ID="txtserach" placeholder="Search " class="form-control" runat="server"></asp:TextBox>

        <span class="input-group-btn">
            <asp:Button ID="btnsearch" runat="server" CssClass="btn aa" OnClick="btnsearch_Click" Text="Search" />

        </span>
    </div>


</div>
<script>

    $(document).ready(function () {

        var value = 0;
        $("#cssmenu").hide();

        $(".searchicone").click(function () {


            //value = 1;

            //if (value == "1") {
            $("#cssmenu").hide();
            $(".input-group").toggle();
            //}
            //else {

            //    $("#cssmenu").animate({
            //        width: "toggle"
            //    });
            //}

        });
        // if (value == "0") {
        $(".headerimg").click(function () {
            $(".input-group").hide();
            $("#cssmenu").animate({
                width: "toggle"
            });
        });
        //}
    });
</script>
 <script>
     $(document).ready(function () {

         $(this).on('contextmenu', function (e) {

             e.preventDefault();
         });

     });
    </script>
