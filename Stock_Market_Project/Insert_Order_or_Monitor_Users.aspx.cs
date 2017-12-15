using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{
    public partial class Insert_Order_or_Monitor_Users : System.Web.UI.Page
    {
        DataAccessLayer dal;
        protected void Page_Load(object sender, EventArgs e)
        {
            int temp = (int)Session["log"];
            if (temp!= 1)
            {
                Response.Redirect("Login_Page.aspx");
            }
            dal = new DataAccessLayer();
            dal.Retrieve_UserName((string)Session["mail"]);
            Usr_Name_lbl.Text = dal.user_name;
            dal.Retrieve_Image((string)Session["mail"]);
            Image1.ImageUrl = dal.Image;
        }

        protected void On_Click_Insert_Order(object sender, EventArgs e)
        {
            Response.Redirect("Insert_Order_Page.aspx");
        }
        //on_Click_Logout_Button

        protected void on_Click_Logout_Button(object sender, EventArgs e)
        {
            Session.Add("log", 0);
            Response.Redirect("Insert_Order_or_Monitor_Users.aspx");
             
        }
        protected void On_Click_Monitor_Page_Btn(object sender, EventArgs e)
        {
            Response.Redirect("Monitor_Page.aspx");
        }
    }
}