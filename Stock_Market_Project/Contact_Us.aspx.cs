using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        DataAccessLayer dal;
        personal_Information Pinfo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void on_Click_SendRequest_Button(object sender, EventArgs e)
        {
            dal = new DataAccessLayer();
            if ( dal.ensure_exsisting_mail(emailContact.Value.ToString() ))
            {

                DataAccessLayer.SendEmail1(emailContact.Value.ToString() , msg.Value.ToString());

            }
        }
    }
}