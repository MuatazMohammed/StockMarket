using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{

    public partial class Login_Page : System.Web.UI.Page
    {
        string guid = Guid.NewGuid().ToString();
        public personal_Information pInf;
        public DataAccessLayer dal ;
        bool flag_Login = false, flag_Forgot = false, flag_Reg = false;
        string mail;
        int count = 0;
        private string f;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["sign_doone"] != null)
            //{
            //    int temp = (int)Session["sign_done"];
            //    if (temp == 1)
            //    {
            //        Response.Redirect("#header-section");
            //    }
            //}
            if(Session["log"]!=null)
            {
                int temp = (int)Session["log"];
                if (temp == 1)
                {
                    Response.Redirect("Insert_Order_or_Monitor_Users.aspx");
                }
            }
            

            Block_msg.Visible = false;
            if (!IsPostBack)
            {
                // mail = mailLogin_txt.Value.ToString();

                ViewState.Add("counter", 5);
            }
        }

        #region Login_Button
        public void on_Click_Login_Button(object sender, EventArgs e)
        {
            
            
                if (mailLogin_txt.Value.ToString() == "" || passLogin_txt.Value.ToString() == "")
                {
                    return;
                }
                pInf = new personal_Information();
                count = (int)ViewState["counter"];
                if (pInf.ensure_Email_with_Password(mailLogin_txt.Value.ToString(), passLogin_txt.Value.ToString()) && count != 0)
                {
                    if (pInf.Check_User_Blocking(mailLogin_txt.Value.ToString()))
                    {
                        Block_msg.Visible = true;
                        Block_msg.Text = "Your Account Blocked ,Contact Us Please";
                        return;
                    }
                    else if (count != 5)
                    {
                        count = 5;
                        ViewState["counter"] = count;
                    }
                    Session.Add("mail", mailLogin_txt.Value.ToString());
                    Session.Add("log", 1);
                    Response.Redirect("Insert_Order_or_Monitor_Users.aspx");
                }
                else
                {
                    Block_msg.Visible = true;
                    if (pInf.Check_User_Blocking(mailLogin_txt.Value.ToString()))
                    {

                        Block_msg.Text = "Your Account Blocked ,Contact Us Please";
                        return;
                    }
                    else if (count == 0)
                    {

                        pInf.Set_User_to_Blocked(mailLogin_txt.Value.ToString(), 'Y');
                        Block_msg.Text = " Your Account Was Blocked ";
                        /*Here Write the Code that put the Blocked user on the Monitor Page */
                        flag_Login = true;
                        return;
                    }

                    Block_msg.Text = "Invalid Email or Password ";
                    count--;
                    ViewState["counter"] = count;
                }
                flag_Login = true;
             
            
            
            
        }
        #endregion

        #region forgotPasswordButton
        public void on_Click_Forgot_Btn(object sender, EventArgs e)
        {
            if (mailLogin_txt.Value.ToString() != null)
                Session.Add("mail", mailLogin_txt.Value.ToString());
            Response.Redirect("Change_Password.aspx");
        }
        #endregion



        #region signUpButton
        protected void on_Click_Sign_Up_Btn(object sender, EventArgs e)
        {
            //Session.Add("sign_doone", 1);
            if (int.Parse(saving_txt.Value.ToString()) <= 0)
            {
                savings_lbl.Text = "Not Allowed Negative or Zero . ";
                return;
            }
            message.Text = "";
            pInf = new personal_Information();

            if (pInf.ensure_Exsisting_E_Mail(email_txt.Value.ToString()))
            {


                message.Text = " This Mail Already Exsist ";
                message.Visible = true;
                return;
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    string imagename = FileUpload1.FileName;
                    if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                    {
                     
                        string path = Server.MapPath("assets/img/");
                        FileUpload1.SaveAs(path + imagename);

                        //vParam = new OracleParameter(":img", imagename);
                        //vParam.Direction = System.Data.ParameterDirection.Input;
                        //vParam.OracleType = OracleType.VarChar;
                        //vcmd.Parameters.Add(vParam);
                    }
                   
                    pInf.Add_New_Client(fname_txt.Value.ToString(), lname_txt.Value.ToString(), email_txt.Value.ToString(), DateTime.Parse( bdate_txt.Value.ToString()) , pass_txt.Value.ToString(), double.Parse(saving_txt.Value.ToString()), 'N' ,imagename , DateTime.Now);

                }
                else
                {
                    pInf.Add_New_Client(fname_txt.Value.ToString(), lname_txt.Value.ToString(), email_txt.Value.ToString(), DateTime.Parse(bdate_txt.Value.ToString()), pass_txt.Value.ToString(), double.Parse(saving_txt.Value.ToString()), 'N', "NULL", DateTime.Now);
                }
                signupmessage.Text = "You Are Signed Up Successfully :D ";
                
            }
           
        }
        #endregion

        protected void on_Click_Contact_Us_Button(object sender, EventArgs e)
        {
            Response.Redirect("Contact_Us.aspx");
        }
    }
}