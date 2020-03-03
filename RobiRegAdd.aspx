﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RobiRegAdd.aspx.cs" Inherits="RobiRegAdd" %>

<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheetBL.css" rel="stylesheet" id="cssTemplate" runat="server" />
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
    <form id="form1" runat="server">
        <div class="Wrap">

             <div class="header">
                  <div class="headerlog">
                     <img id="hdimg" src="Images/bdt.jpg" runat="server" />
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

                   
                    <div class="BanglaMovie" style="margin-top:45%">
                        <div class="" style="margin-bottom: 4px;">
                            <div style="margin-top: 20px;">
                                <blockquote>
                                    <asp:Image ID="imgTitle" runat="server" Width="100%" />
                                </blockquote>
                                
                            </div>
                        </div>

                        <div class="text-center">
                           
                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="Images/nib.png" OnClick="btnAdd_OnClick" Width="50%"></asp:ImageButton>
                            
                        </div>

                     
                    </div>
                     <div class="BanglaMovie">
                        <div class="" style="margin-bottom: 4px;">
                            <div style="margin-top: 20px;">
                                <blockquote>
                                    <asp:Image ID="imgBatil" runat="server" Width="100%" />
                                </blockquote>
                                
                            </div>
                        </div>

                        <div class="text-center">
                           
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/batilm.png" PostBackUrl="~/Default.aspx" Width="50%"></asp:ImageButton>
                            
                        </div>

                     
                    </div>
                </div>

           
            </div>
        <%--   <footer>
                <div style="width:100%;background-color:#FF9933">
                    <br />
                    <h4 style="text-align:center">All Rights Reserved by &copy;<%=DateTime.Now.Year %>, VU mobile</h4>
                    <br />

    
                </div>
            </footer>--%>
            <div class="fo">
               
                <uc2:Footer ID="FooterControl" runat="server" />
            </div>
             
        </div>
    </form>

</body>
</html>
