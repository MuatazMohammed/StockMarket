using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Text;
using System.Net.Mail;

namespace Stock_Market_Project
{
    public partial class Change_Password : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ( Session["mail"] != null )
            //email1_txt.Value = (string)Session["mail"];
        }

        #region sendButton
        protected void on_Click_Send_Btn(object sender, EventArgs e)
        {
          
            personal_Information p = new personal_Information();
            try
            {
                #region temp
                //string _connectionString = "Data source = orcl; User Id = hr; Password = hr;";
                ////personal_Information p = new personal_Information();
                //DataTable dt = new DataTable();
                //OracleConnection conn = new OracleConnection(_connectionString);
                // OracleCommand cmd = new OracleCommand("select * from stock_market where e_mail = :email", conn);
                 
                // cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = (string)Session["mail"];
                // conn.Open();
                // OracleDataAdapter adp = new OracleDataAdapter(cmd);
                

                //adp.Fill(dt);

                //if (dt.Rows.Count > 0)
                //{



            //    SendEmail((string)Session["mail"]);

            //    lbresult.Text = "successfully sent reset link on  your mail ,please check once! Thank you.";
            //    conn.Close();

            //    cmd.Dispose();

            //    email_txt.Value = "";
            //}
            //    else
            //    {

            //        lbresult.Text = "Please enter valid email ,please check once! Thank you.";
            //        conn.Close();

            //        cmd.Dispose();
            //    }

            //}

            //catch (Exception ex)
            //{

            //}

                #endregion

                if (p.ensure_Exsisting_E_Mail(email1_txt.Value.ToString()))
                   {

                       DataAccessLayer.SendEmail(email1_txt.Value.ToString());
                       p.Update_Exp_Date(email1_txt.Value.ToString(), DateTime.Now);
                       lbresult.Text = "successfully sent reset link on  your mail ,please check once! Thank you.";
                       lbresult.BackColor.Equals("Green");
                       email1_txt.Value = "";

                   }
                   else
                    lbresult.Text = "Please enter valid email ,please check once! Thank you." + email1_txt.Value.ToString();
        
                

            }

            catch (Exception ex)
            {
                lbresult.Text = ex.Message;
            }

        }
        #endregion



        

    }
}