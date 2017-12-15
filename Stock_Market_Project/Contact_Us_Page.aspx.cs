using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        

       



        
        
        protected void AS(object sender, EventArgs e)
        {
            Response.Redirect("Insert_Order_Page.aspx");
        }

        protected void on_Click_SendRequest_Button(object sender, EventArgs e)
        {
            Response.Redirect("Insert_Order_Page.aspx");

        }
    }
}