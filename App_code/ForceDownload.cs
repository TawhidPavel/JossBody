/***********
Author: Abu Haider (http://www.haiders.net)
Nov 2008
Adds Extension Method "ForceDownload" to HttpResponse class
Requires: ASP.NET 3.5
Drop this in App_Code
/************/


using System.IO;
using System.Web;
public static class HttpExtensions
{

    //Forces Download/Save rather than opening in Browser//
    public static void ForceDownload(this HttpResponse Response, string virtualPath, string fileName)
    {

        Response.Clear();
        //Response.ClearHeaders(); //solve the  bug  IE 6 - IE 8.0 + SSL 
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        Response.WriteFile(virtualPath);
        Response.ContentType = "";
        Response.End();

    }

}