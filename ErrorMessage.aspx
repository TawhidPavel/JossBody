<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorMessage.aspx.cs" Inherits="ErrorMessage" ContentType="text/html" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        #form1
        {
            text-align: center;
        }
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" 
        Text="Please Use gp Internet To use this service"></asp:Label><br/>
        <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
    </form>
   
</body>
</html>
