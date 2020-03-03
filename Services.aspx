<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

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


    <link href="Css/StyleSheet.css" rel="stylesheet" id="cssTemplate" runat="server" />
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

        .close {
            float: none;
            margin-right: -87%;
            margin-top: -15px;
            opacity: 1;
            position: fixed;
            width: 62%;
            z-index: 999999999;
        }

        .modal-body {
            padding: 0px;
            position: relative;
        }

        .modal-content {
            background: none;
            border: none;
            border-radius: 0;
            box-shadow: none;
        }

        .ribonMusic {
            text-align: left;
            height: 30px;
            background-color: rgb(198, 27, 36);
            background-repeat: repeat-x;
            font-weight: bold;
            FONT-SIZE: 11px;
            FONT-FAMILY: Verdana, Tahoma, Arial;
            color: #fff;
            padding-left: 25%;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <div class="Wrap" id="Wrapid" style="display: block">
            <uc1:Header ID="HeaderControl" runat="server" />


            <div class="mainbody">


                <div id="blink" class="table table-responsive" style="margin-left: 0%; margin-right: 1%; display: none" runat="server">
                    <table cellpadding="0" cellspacing="0" class="BlueLine" width="100%">
                        <%-- <tr>
                            <td height="20px" class="ribonMusic">&nbsp;
                                <asp:Label ID="lblPicture" runat="server">Service Info</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <tr>
                                <td height="20px" class="ribonMusic" style="padding-left: 40%">&nbsp;
                                <asp:Label ID="lblPicture" runat="server">Joss Body</asp:Label>
                                </td>
                            </tr>
                            <td colspan="2" style="padding-left: 1%">
                                <br />
                  
				  
				  



                                <span><b>প্রায়শই জিজ্ঞাসিত প্রশ্নাবলী</b><br/><br/>

<b>১। জোস  বডি কি?</b><br/>

উত্তর: জোস বডি হল একটি মোবাইল ফিটনেস পোর্টাল যা থেকে সেলিব্রিটি এবং অন্যান্য ফিটনেস বিশেষজ্ঞদের কাছ থেকে বিভিন্ন স্বাস্থ্য এবং ফিটনেস টিপস পেতে পারেন। এই সেবাটিতে সেলিব্রিটিদের এবং অন্যান্য ফিটনেস বিশেষজ্ঞদের Yoga এবং Workout ভিডিও আছে যা সবাই অনুসরণ করতে পছন্দ করবে এবং তারই সঙ্গে সবাইকে অনুপ্রাণিত করবে। Workout কেবলমাত্র সুস্থ হতে সাহায্য করে না, বরং এটি আপনাকে ভাল বোধ করতে এবং আপনাকে শক্তি দান করতে সাহায্য করে। এতে আরও থাকছে পুষ্টিকর রেসিপি এবং হেলথি টিপস যেটার মাধ্যমে আপনি আরও স্লিম এবং সুস্থ থাকবেন। এই ফিটনেস সেবাটি ছাত্র, কিশোর, যুব এবং প্রায় সব স্বাস্থ্য সচেতন মানুষদের জন্য খুব কার্যকর হবে।<br/><br/>
                                    <b>২। জোস ভিডিওর web পোর্টালের ঠিকানা কী ?</b><br/>

উত্তর: পোর্টালে যেতে চাইলে টাইপ করুনঃhttp:<a href="http://jossbody.com">http://jossbody.com</a> <br/><br/>
                                    <b>৩। কিভাভে Subscribe করবো ওয়েব পোর্টাল দিয়ে?</b><br/>

উত্তর: পোর্টালে যান-<a href="http://jossbody.com">http://jossbody.com</a>  এবং “Subscribe” বাটন চাপুন।<br/><br/>
                                    <b>৪। আমি কিভাবে কনটেন্ট দেখতে পারি?</b><br/>

উত্তর: আপনি আপনার আগ্রহ অনুযায়ী কনটেন্ট নির্বাচন করতে আপনার ফোনে পোর্টাল অ্যাক্সেস করতে পারেন। <br/><br/>

                                    <b>৫। কিভাবে “Subscribe” করবো SMS এর মাধ্যমে?</b> <br/>

উত্তর: টাইপ "START <স্পেস> JB"  to 16561 <br/><br/>

                                    <b>৬। যদি আমি Subscription অপশনটি বেছে নিই, তাহলে আমার Subscription কতক্ষণ থাকবে?</b><br/>

উত্তর: আপনার Subscription ১ দিন  থাকবে। Subscription এর শেষে, আপনার Subscription Auto-renew করা হবে।<br/><br/>

                                    <b>৭। কিভাবে SMS এর মাধ্যমে deactivate অথবা unsubscribe করা হয়?</b><br/>

উত্তর: টাইপ "STOP <স্পেস> JB" to 16561 <br/><br/>

                                    <b>৮। জোস ভিডিও সেবা deactivate করার অন্য কোন উপায় আছে কি?</b><br/>

উত্তর: হ্যাঁ, পোর্টালের হোম পৃষ্ঠার উপরের অংশে " unsubscribe " বাটন রয়েছে। উক্ত বাটনটি ক্লিক করে, ব্যবহারকারী সার্ভিসটি deactivate করতে সক্ষম হবে।<br/><br/>

                                    <b>৯। আমি বিভিন্ন ধরনের কনটেন্টের জন্য কত টাকা দিতে পারি?</b><br/>

উত্তর: TK2 + ভ্যাট + এসডি + এসসি / দিন<br/><br/>

                                    <b>১০। আমাকে কি চার্জ করা হবে যদিও আমি  ঠিকমত কনটেন্ট দেখতে  পারিনি?</b><br/>
উত্তর: যেহেতু এটা একটি Subscription মডেল, সুতরাং যদি সংযোগ বিচ্ছিন্নতা সমস্যাগুলির কারণে আপনি কোনও বাধা সম্মুখীন হন তাহলে এটি একটি কনটেন্ট দেখা হয়েছে হিসাবে বিবেচিত হবে। আপনি আবার চেষ্টা করুন যখন আপনি ভাল সংযোগ আছে তা নিশ্চিত করতে পারবেন।<br/><br/>
                                    <b>১১। যদি আমি Subscription করে কনটেন্ট দেখি, তাহলে কি আমি চিরতরে কন্টেন্ট রাখতে পারবো এবং উপভোগ করতে পারবো?</b><br/>
উত্তর: কনটেন্ট সম্পূর্ণ অনলাইন ভিত্তিক এবং ডাউনলোডযোগ্য নয়, আপনি কনটেন্ট অফলাইন মোডে রাখতে পারবেন না।<br/><br/>
                                    <b>১২। আনলাইন পোর্টাল এবং কনটেন্ট দেখার জন্য কোন ডেটা চার্জ নেই?</b><br/>
উত্তর: হ্যাঁ, পোর্টাল ব্রাউজ করার এবং কনটেন্ট দেখার জন্য আপনার Subscribe করা ডেটা প্ল্যান অনুযায়ী ডাটা চার্জ করা হবে।<br/><br/>
                                    
                                    <b>১৩। পোর্টালের কনটেন্ট কি iOS, ব্ল্যাকবেরি, এবং উইন্ডোজ ফোন সমর্থন করে?</b><br/>
উত্তর: হ্যাঁ, পোর্টালের কন্টেন্ট আইওএস, ব্ল্যাকবেরি, এবং উইন্ডোজ ফোন সমর্থিত, কিন্তু অ্যাপ্লিকেশন Android এর জন্য প্রযোজ্য।<br/><br/>
                                    <b>১৪। যদি কোন অ-সদস্য জোস বডির কনটেন্টের উপর ক্লিক করে তাহলে কি হবে?</b><br/>
উত্তর: তাকে Subscription পৃষ্ঠায় নিয়ে যাওয়া হবে।<br/><br/>
                                    
                                    <b>১৫। যদি কোন ব্যবহারকারী ডাবল ক্লিক বা Subscription করার জন্য ডাবল SMS Send করে তবে ব্যবহারকারীকে দুইবার চার্জ করা হবে কি?</b><br/>
উত্তর: Subscription করার জন্য একবার ব্যবহারকারীকে চার্জ  করা হবে। যদি কোনও বিদ্যমান ব্যবহারকারী একাধিকবার Subscription অনুরোধ পাঠায়, তবে তারা একটি বিনামূল্যের SMS পাবেন যে তিনি ইতিমধ্য সেবাটি Subscribe করেছেন। <br/><br/>
                                    <b>১৬। কোন কনটেন্ট দেখার পরে কি আমি কোন ডাটা সংযোগ ছাড়াই কনটেন্ট দেখতে পারব কি?</b><br/>
উত্তর: না, আপনি কোন ডাটা সংযোগ ছাড়াই কনটেন্ট দেখতে পারবেন না।<br/><br/>
                                    
                                    <b>১৭।  যদি আমি আমার সিম কার্ড পরিবর্তন করি তাহলে কিভাবে এই সেবাটি ব্যবহার করবো?</b><br/>
উত্তর: যদি আপনি আপনার SIM কার্ড পরিবর্তন করেন, তাহলে আপনাকে আবার সেবাটি Subscribe করতে হবে যাতে কনটেন্টগুলি উপভোগ করতে পারেন।<br/><br/>
                                    <b>১৮।  কাস্টমার সাপোর্টের নাম্বার কি?</b><br/>
উত্তর: যোগাযোগ করুন: হেল্পলাইন [08:00 AM - 07:00 PM]: ফোন: +8801736993235<br/><br/>
                                    <b>১৯।  কাস্টমার সাপোর্টের ইমেল কি?</b><br/>
ইমেইল: support@aurkotech.com <br/><br/>
</span>


                                <br/>
                                <br/>
                                
                                
                                
                                 
                              

                            </td>
                        </tr>
                         
                    </table>
                    
                </div>

                <table>
                    <tr id="cancelSubscriptionBlink" runat="server" Visible="False">
                            <td align="right" style="font-size: 10px; padding-top: -5%">
                                <asp:LinkButton Text="Cancel Subscription" ID="LinkButton3" runat="server"  Font-Underline="false" OnClick="lbkbtnCancelSubscription_Click" ForeColor="#F16521">UN-SUBSCRIBE</asp:LinkButton>
                            </td>
                        </tr>
                        </table>



              
               



            </div>
        </div>
        
        <div class="link foter">
             
            <uc2:Footer ID="FooterControl" runat="server" />
        </div>
        <div class="foter">
        </div>

    </form>
</body>
</html>
