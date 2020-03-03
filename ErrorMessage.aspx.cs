using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                //string type = Request.QueryString["type"].ToString();
                //if (type == "dnd")
                //{
                //    Label1.Text = "Error! Mobile number not allowed it is in DND list.";
                //}
              
            }
            catch { }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
