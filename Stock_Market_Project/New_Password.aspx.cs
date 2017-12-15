using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Stock_Market_Project
{
    public partial class New_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region confirmButton
        protected void on_Click_Confirm_Button(object sender, EventArgs e)
        {
            
            string temp = Request.QueryString["username"];
            personal_Information p = new personal_Information();
            if ( p.Retrieve_Exp_Date(temp).AddDays(1) > DateTime.Now)
            {
                p.confirm_Change_Password(temp, npass_txt.Value.ToString());
                Response.Write("<script> alert ('your password has been successfully updated') </script>");
                Response.Redirect("Login_Page.aspx");
            }
            lbresult.Text = " This Link Was Expired ";
        }
        #endregion
    }
}