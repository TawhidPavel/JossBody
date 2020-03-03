<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>
<%@ Register Src="~/header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="~/foter.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, height=device-height, user-scalable=yes" />
    <link href="Css/StyleSheet.css" rel="stylesheet" />
    <title>BdTube-Home</title>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrap">
          <uc1:Header ID="HeaderControl" runat="server" />
           <div class="mainbody">
               
                <asp:Literal ID="ltvideo" runat="server"></asp:Literal>
               <div class="BanglaMovie">
                      <div class="vdtitle">
                         <asp:Label ID="lbltitlename" runat="server" Text="Label"></asp:Label>
                      </div>  
                 </div>
               <br />
                <center><asp:Label ID="lblmsisdn" runat="server" Text="88018950259"></asp:Label></center>
               <br />
               <center><asp:HyperLink ID="HyperLink1" ImageUrl="~/images/Watch_R.png" runat="server"></asp:HyperLink></center>
               <br />
           </div> 
            
         <div class="link">
            <uc2:Footer ID="FooterControl" runat="server" />
         </div>
        <div class="foter">
            
            <p>
                © 2016. All Rights Reserved. 
            </p>
        </div>

        </div>
    </form>
</body>
</html>
