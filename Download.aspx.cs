using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    string contentType = string.Empty;
    string contentCode = string.Empty;
    string CategoryCode = string.Empty;
    string physicalfilename = string.Empty;
    string path = string.Empty;
    string imageurl = string.Empty;
    string previewImage = string.Empty;

    MSISDNTrack ms = new MSISDNTrack();

    string sMobNo = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Loadcontent();

            sMobNo = ms.GetMSISDN();
            lblmsisdn.Text = sMobNo;
        }
    }

    public void Loadcontent()
    {
        try
        {
            contentType = Request.QueryString["sContentType"].ToString().Trim();
            contentCode = Request.QueryString["content_code"].ToString().Trim();
            CategoryCode = Request.QueryString["CategoryCode"].ToString().Trim();
            physicalfilename = Request.QueryString["sPhysicalFileName"].ToString().Trim();
            previewImage = Request.QueryString["sposter"].ToString().Trim();
            lbltitlename.Text = physicalfilename.Replace("_", " ");
        }
        catch
        {
            
        }
        if(contentType=="FV")
        {
            imageurl = "http://wap.shabox.mobi/CMS/GraphicsPreview/FullVideo/" + previewImage;
        }
        else
        {
            imageurl = "http://wap.shabox.mobi/CMS/GraphicsPreview/Video clips/" + previewImage;
        }
        path = "Contentdownload.aspx?content_code=" + contentCode + "&CategoryCode=" + CategoryCode + "&sPreviewUrl=" + Request.QueryString["sPreviewUrl"].ToString().Trim() + "&ContentTitle=" + Request.QueryString["ContentTitle"].ToString().Trim() + "&sContentType=" + contentType + "&sPhysicalFileName=" + physicalfilename + "&ZedID=" + Request.QueryString["ZedID"].ToString().Trim() + "&sposter="+previewImage+"";

        HyperLink1.NavigateUrl = path;

        ltvideo.Text = "<div class='videocontent' style='position:relative'>" +
                            "<img src='" + imageurl + "'  />" +
                            "<div class='Icone_image'>" +
                                "<a href='" + path + "'><img src='images/play-button.png'/></a></div></div>" +
                            "<div class='videoTitle'>" +
                             "<div class='Title'>" +
                                "<span></span>" +
                             "</div>";
    }
}