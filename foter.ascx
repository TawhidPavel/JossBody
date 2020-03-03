<%@ Control Language="C#" AutoEventWireup="true" CodeFile="foter.ascx.cs" Inherits="foter" %>



<table class="table"  Visible="false" id="blink" runat="server">

    <tr style="height: 30px">

     
        <td style="width: 50%; text-align: center; background-color: #58C1E6">
            <a id="HyperLink3" class="" style="padding-left: 5%; padding-right: 5%; margin-top: 10px;" href="Default.aspx"><span>
                <img src="icons/home.png" style="max-height: 25px; max-width: 25px; margin-top: 10px" /></span></a>
            <a id="lnkT" class="" style="margin-bottom: 5px; padding-left: 5%; padding-right: 5%;" href="Services.aspx"><span>
                <img src="icons/about_bl.png" style="max-height: 25px; max-width: 25px; margin-top: 10px" /></span></a>

            <%--<a id="history" runat="server" style="padding-left: 5%; padding-right: 5%" class="" href="Hs.aspx"><span>
                <img src="icons/account_bl.png" style="max-height: 25px; max-width: 25px; margin-top: 10px;" /></span></a>--%>
            <%--<a id="cancelSubscription" style="padding-left: 2%;padding-right: 2%" href="CancelSubscription.aspx"><span><img src="icons/cancel_bl.png" style="max-height: 20px;padding-top: -2px"/></span></a>--%>
        </td>
    </tr>
    <tr style="height: 30px">
        <td id="r" style="width: 50%; text-align: center; background-color: #58C1E6" runat="server">
            <span style="color: white">Joss Body ©
                <asp:Label runat="server" ID="year"></asp:Label>. All Rights Reserved.</span>
        </td>
    </tr>
</table>


