using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{
    public partial class Monitor_Users_Page : System.Web.UI.Page
    {
        DataAccessLayer dal;
        DataTable vTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            dal = new DataAccessLayer();
            vTable = new DataTable();

            dal.Retrieve_theBlocked_Users_Data();
            if (dal.numofBlockedUsers != -1)
            {
                vTable.Columns.Add("User Name");
                vTable.Columns.Add("Email");
                vTable.Columns.Add("Blocked");

                for (int i = 0; i < dal.numofBlockedUsers; i++)
                {
                    if (dal.userName[i] == null)
                        return;
                    vTable.Rows.Add(dal.userName[i], dal.Email[i], dal.Blocked[i]);

                }


                grd_view_users.DataSource = vTable;
                grd_view_users.DataBind();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int indx = e.Row.DataItemIndex;


                e.Row.ToolTip = "User Name : " + (e.Row.DataItem as DataRowView)["User Name"].ToString() + "\n" + "E_mail : " + (e.Row.DataItem as DataRowView)["Email"].ToString() + "\n" + "Blocked (Y/N) : " +(e.Row.DataItem as DataRowView)["Blocked"];

            }

        }
        protected void Activate_Button(object sender, EventArgs e)
        {
            string email = Request.QueryString["username"];
            dal.Activate_User(email);
            Response.Redirect("Monitor_Users_Page.aspx");
           
        }
    }
}