<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenericError.aspx.cs" Inherits="GenericError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <style>
        .pa {
            padding:40px 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="text-center">
        <br/>
        <br/>
            <Asp:Image runat="server" ImageUrl="Images/404.gif" Width="70%" CssClass=""/> <br/>
       <div class="text-center" id="thnks" runat="server" Visible="False">
            <asp:Label runat="server" Text="Thanks for your Report" Font-Size="40" Font-Bold="True"></asp:Label>
        </div>
        <asp:Button runat="server" ID="report" Text="Report" Font-Size="30" Font-Bold="True" OnClick="report_OnClick"  CssClass="btn btn-danger pa"/>
         <asp:Button runat="server" PostBackUrl="Default.aspx" Text="Home" Font-Size="30" Font-Bold="True" OnClick="report_OnClick" CssClass="btn btn-danger pa"/>
    </div>
        
    </form>
</body>
</html>
