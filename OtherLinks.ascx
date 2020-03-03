<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OtherLinks.ascx.cs" Inherits="OtherLinks" %>
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.0.min.js" type="text/javascript"></script>
<script src="Js/toastr.min.js"></script>
<style type="text/css">
 .rounda{
	   
	    border: 2px solid #B5B5B5;
	    
	    border-radius: 50%;
	    float: left;
	    /*height: 38.5px;*/
	    /*line-height: 38px;*/
	    margin: 0 8px 0 0;
	    padding: 1px;
	    text-align: center;
	    width: 38px;
        border-style: double;
	   -webkit-box-shadow: 0 8px 6px -5px black;
	   -moz-box-shadow: 0 8px 6px -5px black;
	   
	   
    }
</style>

<script type="text/javascript">
    
    function logBuddy()
    {
       
        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'buddy' },
            dataType: 'text',
            method: 'get',
            async:false,
            success: function (data, textStatus, jqXHR) {
            },
            error: function (jqXHR, textStatus, errorThrown) {
                toastr.error('', 'confirmation message');
            }
        });

        

    }
    function logClubz() {
       // alert("hi clubz");
        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'clubz' },
            dataType: 'text',
            method: 'get',
            async: false,
            success: function (data, textStatus, jqXHR) {
               

            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });

        

    }

    function logQuiz() {

        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'quiz' },
            dataType: 'text',
            method: 'get',
            async: false,
            success: function (data, textStatus, jqXHR) {
               
            },
            error: function (jqXHR, textStatus, errorThrown) {
              
            }
        });

       

    }

    function logSticker() {

        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'sticker' },
            dataType: 'text',
            method: 'get',
            async: false,
            success: function (data, textStatus, jqXHR) {
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }
        });
       
    }

    function logGameClub() {

        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'gameClub' },
            dataType: 'text',
            method: 'get',
            async: false,
            success: function (data, textStatus, jqXHR) {


            },
            error: function (jqXHR, textStatus, errorThrown) {


            }
        });
       
    }
    function logLiveGame() {

        $.ajax({
            url: 'footerInfo.aspx',
            data: { flag: 'y', op: 'liveGame' },
            dataType: 'text',
            method: 'get',
            async: false,
            success: function (data, textStatus, jqXHR) {
            },
            error: function (jqXHR, textStatus, errorThrown) {
            }
        });
      
    }

</script>
 

<div class="footer1" id="footer">
    
        <h5    style="text-align: left; padding-left: 2%;" ><span style="font-size: 13px">OTHER LINKS</span></h5>
 
       
            
                <div class="col-md-12" style="text-align: center">
                       
                        <ul class="social">
                                 
                           
                               <li id="buddy" runat="server"> <asp:ImageButton ID="bdfb" runat="server" CssClass="rounda" PostBackUrl="http://wap.shabox.mobi/buddy/" ImageUrl="Ic/buddy.png" OnClientClick="logBuddy()"  AlternateText="Buddy" Style="margin: -7px 0 0 -6.5px;max-width: 40px;max-height: 40px"></asp:ImageButton> </li>
                                                                         
                            <%--<li> <asp:ImageButton ID="bdyou" runat="server" ImageUrl="~/Images/youtube.png" AlternateText="You Tube" Style="margin: -7px 0 0 -6.5px;"></asp:ImageButton> </li>--%>
                                                         
                            <li id="clubz" runat="server"><asp:ImageButton ID="bdclub" runat="server" CssClass="rounda" PostBackUrl="http://wap.shabox.mobi/clubz/" ImageUrl="Ic/clubz.png" AlternateText="Clubz App" OnClientClick="logClubz()" Style="margin: -7px 0 0 -6.5px;padding-left:2px;max-width: 40px;max-height: 40px;"></asp:ImageButton> </li>
                             
                            <li id="quiz" runat="server"><asp:ImageButton ID="bdquiz" runat="server" CssClass="rounda" PostBackUrl="http://quizplay.mobi" ImageUrl="Ic/qp.png" OnClientClick="logQuiz()" AlternateText="Quiz Play" Style="margin: -7px 0 0 -6.5px;padding-left:2px;max-width: 40px;max-height: 40px"></asp:ImageButton> </li>
                            
                            <li id="sticker" runat="server"><asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="logSticker()" CssClass="rounda" PostBackUrl="http://play.google.com/store/apps/details?id=com.vumobile.amarsticker&hl=en/" ImageUrl="Ic/as.png" AlternateText="Amar Sticker" Style="margin: -7px 0 0 -6.5px;padding-left:2px;max-width: 40px;max-height: 40px"></asp:ImageButton> </li>
                            
                            <li id="gameMain" runat="server"><asp:ImageButton ID="gameclub" runat="server" CssClass="rounda" OnClientClick="logGameClub()"  ImageUrl="Ic/clubz.png" AlternateText="Clubz App" Style="margin: -7px 0 0 -6.5px;padding-left:2px;max-width: 40px;max-height: 40px"></asp:ImageButton> </li>
                           
                             <li id="lgMain" runat="server"><asp:ImageButton ID="lg" runat="server" CssClass="rounda" OnClientClick="logLiveGame()" ImageUrl="Ic/lg.png" AlternateText="Clubz App" Style="margin: -7px 0 0 -6.5px;padding-left:2px;max-width: 40px;max-height: 40px"></asp:ImageButton> </li>
                           
                        </ul>
                </div>
           
        </div>


