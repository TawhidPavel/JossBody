<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RobiFirstPAge.aspx.cs" Inherits="RobiFirstPAge" %>

<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="Link1" runat="server" />
    <title>JOSS BODY</title>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
    <link href="Js/toastr.min.css" rel="stylesheet" />
    <link href="StyleSheet/bootstarp.css" rel="stylesheet" />

    <script src="StyleSheet/video.js"></script>
    <style>
        .typeFont {
            font-style: italic;
            font-size: 18px;
            background-color: whitesmoke;
            color: black;
            border: 4px;
            border-radius: 4px;
            font-weight: normal;
            font-size: 15px;
            margin-top: 6px;
            margin-right: 4px;
            font-family: initial;
        }
        .fo {
            text-align: center;
            width: 100%;
        }
    </style>


</head>
<body>
<form id="form2" runat="server">
    <div class="Wrap">

        <div class="header">
            <div class="headerlog">
                <img id="hdimg" src="Images/bdt.png" runat="server" />
                <%--<asp:Image id="HeaderImage" runat="server" />--%>
            </div>
          
        </div>
        <%--<uc1:Header ID="HeaderControl" runat="server" />--%>
        <div class="mainbody">
            <div id="main" runat="server" Visible="true">
                  
                <%--    <div>
                                <asp:Label runat="server" CssClass="typeFont" ID="txtType"></asp:Label>
                            
                        </div>--%>


                <%--img--%>
                <div style="width: 100%; background: #fff;">
                    <div style="">
                        <div class="video1" id="smartphone1" runat="server" style="width: 100%">
                            <%--<asp:Literal ID="ltvideo" Visible="true" runat="server"></asp:Literal>--%>
                        </div>
                    </div>
                </div>
              
               
                <div class="BanglaMovie" style="margin-top:50%">
                  

                    <div class="text-center">
                           
                        <p style="padding-left: 1%;padding-right: 1%">আপনি ফিটনেস ক্লাব সার্ভিস এ রেজিস্ট্রেশন করার জন্য অনুরোধ করেছেন | আপনি আনলিমিটেড  ফ্রি ভিডিও দেখতে এবং  সকল ফিটনেস টিপস ফ্রি  পড়তে পারবেন | স্ট্যান্ডার্ড ডাটা চার্জ প্রযোজ্য |</p>
                      
                            
                    </div>

                     
                </div>
                <br/>
               
                <div class="BanglaMovie" style="margin-top:0%">
                   

                    <div class="text-center">
                           
                            
                        <p style="padding-left: 5%;padding-right: 5%"><b>ডেইলি সাবস্ক্রিপশন (অটো রিনিউয়াল) : </b>আপনাকে প্রতিদিন ২ টাকা (+ভ্যাট +এসডি+এসসি) হারে চার্জ করা হবে |</p>
                        <asp:Button runat="server" CssClass=" btn btn-success" Text="নিবন্ধন"  Font-Size="20px" PostBackUrl="Nibondhon.aspx?type=dt"/>
                            
                    </div>

                     
                </div>
                <br/>
                <div class="BanglaMovie" style="margin-top:0%">
                   

                    <div class="text-center">
                           
                            
                        <p style="padding-left: 5%;padding-right: 5%"><b>ডেইলি সাবস্ক্রিপশন (নন রিনিউয়াল) : </b>আপনাকে ১দিনের জন্য ২ টাকা (+ভ্যাট +এসডি+এসসি) চার্জ করা হবে |</p>
                        <asp:Button runat="server" CssClass=" btn btn-success" Text="নিবন্ধন" Font-Size="20px" PostBackUrl="Nibondhon.aspx?type=df"/>
                            
                    </div>

                     
                </div>
                
                <br/>
                <div class="BanglaMovie" style="margin-top:0%">
                   

                    <div class="text-center">
                           
                            
                        <p style="padding-left: 5%;padding-right: 5%"><b>সাপ্তাহিক সাবস্ক্রিপশন (অটো রিনিউয়াল) :</b> আপনাকে প্রতি সপ্তাহে ৭  টাকা (+ভ্যাট +এসডি+এসসি) হারে চার্জ করা হবে |</p>
                        <asp:Button runat="server" CssClass=" btn btn-success" Text="নিবন্ধন" Font-Size="20px" PostBackUrl="Nibondhon.aspx?type=wt"/>
                            
                    </div>

                     
                </div>
                <br/>
                <div class="BanglaMovie" style="margin-top:0%">
                   

                    <div class="text-center">
                           
                            
                        <p style="padding-left: 5%;padding-right: 5%"><b>সাপ্তাহিক সাবস্ক্রিপশন (নন রিনিউয়াল) : </b>আপনাকে ৭ দিনের জন্য ৭  টাকা (+ভ্যাট +এসডি+এসসি) চার্জ করা হবে | </p>
                        <asp:Button runat="server" CssClass=" btn btn-success" Text="নিবন্ধন" Font-Size="20px" PostBackUrl="Nibondhon.aspx?type=wf"/>
                            
                    </div>

                     
                </div>
           
                <br/>
                
            </div>
            
            
          
           
        </div>
        <%--   <footer>
                <div style="width:100%;background-color:#FF9933">
                    <br />
                    <h4 style="text-align:center">All Rights Reserved by &copy;<%=DateTime.Now.Year %>, VU mobile</h4>
                    <br />

    
                </div>
            </footer>--%>
        <br/>
        <div class="fo">
               
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
             
    </div>
</form>

</body>
</html>
