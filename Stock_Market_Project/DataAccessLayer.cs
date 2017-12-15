using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Text;
using System.Net.Mail;
namespace Stock_Market_Project
{
    public class DataAccessLayer
    {
        public static string _connectionString = "Data source = orcl; User Id = hr; Password = hr;";
        public OracleCommand cmd;
        public OracleConnection con;
        public OracleDataReader dr;
        public string []stock_Names;
        public string []transationDate;
        public string[] userName;
        public string[] Email;
        public char[] Blocked;
        public string[] Quantity;
        public string[] totalPrice;
        public string user_name;
        public string Image;
        public string msg;
        public int numofOrders;
        public int numofBlockedUsers;

        #region Insert_New_Client
        public void register_New_Client(string pFirst_Name, string pLast_Name, string pEmail, DateTime pBirth_Date, string pPassword , double pSavings , char pBlocked ,  string pImg , DateTime pExp_Date )
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert_New_Client";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("First_Name", OracleDbType.Varchar2, ParameterDirection.Input).Value = pFirst_Name;
            cmd.Parameters.Add("Last_Name", OracleDbType.Varchar2, ParameterDirection.Input).Value = pLast_Name;

            cmd.Parameters.Add("E_Mail", OracleDbType.Varchar2, ParameterDirection.Input).Value = pEmail;
            cmd.Parameters.Add("Birth_Date", OracleDbType.Date, ParameterDirection.Input).Value = pBirth_Date;//Convert.ToDateTime(pBirth_Date);
            

            //int encryptPass = int.Parse(pPassword);

            //encryptPass += 4;

            //pPassword = encryptPass.ToString();


            cmd.Parameters.Add("Password", OracleDbType.Varchar2, ParameterDirection.Input).Value = pPassword;
            cmd.Parameters.Add("Birth_Date", OracleDbType.BinaryDouble, ParameterDirection.Input).Value = pSavings;
            cmd.Parameters.Add("Blocked", OracleDbType.Varchar2, ParameterDirection.Input).Value = pBlocked;
            cmd.Parameters.Add("Img", OracleDbType.Varchar2, ParameterDirection.Input).Value = pImg;
            cmd.Parameters.Add("Birth_Date", OracleDbType.Date, ParameterDirection.Input).Value = pExp_Date;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    //vfirst_Name = pFirst_Name;
                    //vlast_Name = pLast_Name;
                    //ve_Mail = pEmail;
                    //vbirth_Date = pBirth_Date;
                    //vpassword = pPassword;
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }





        }
        #endregion

        #region Enure_Exsisting_E_Mail
        public bool ensure_exsisting_mail(string pMail)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  e_mail from Clients where e_mail = :vmail";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("vmail", OracleDbType.Varchar2).Value = pMail;
            //cmd.Parameters.Add("s", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.ReturnValue);
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    return true;
                }
                dr.Close();
                return false;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
            return false;



        }
        #endregion


         #region Set User to Be Blocked
        public void Set_User_to_Be_Blocked(string pMail, char pBlocked)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Set_User_to_Be_Blocked";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion



        #region Check If Blocked Or No
        public bool Check_User_Blocking(string pMail)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  * from Clients where e_mail = :vmail and Blocked = 'Y'";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("vmail", OracleDbType.Varchar2).Value = pMail;
            //cmd.Parameters.Add("s", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.ReturnValue);
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    return true;
                }
                dr.Close();
                return false;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
              
            }
            return false;



        }
        #endregion

        #region Ensure_Email_with_Password
        public bool ensure_email_password_login(string pMail, string pPassword)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  e_mail from Clients where e_mail = :bmail and pssword = :bpass";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("bmail", OracleDbType.Varchar2).Value = pMail;
            cmd.Parameters.Add("bpass", OracleDbType.Varchar2).Value = pPassword;
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    dr.Close();
                    return true;
                }
                dr.Close();
                return false;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
            return false;



        }
        #endregion

        #region confirming_Change_Password
        public void confirming_Change_Password(string pEmail, string pPassword)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "confirming_Change_Password";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pEmail;
            cmd.Parameters.Add("Password", OracleDbType.Varchar2, ParameterDirection.Input).Value = pPassword;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {

                    //ve_Mail = pEmail;

                    //vpassword = pPassword;
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }





        }
        #endregion

        #region load Stocks Names to dropDownList

        public void load_Names_of_Stocks()
        {
            stock_Names = new string[1000];
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "retrieve_Stocks_Names";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("sNamesCursor", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
            
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();
                int count = 0 ;
                while (dr.Read())
                {
                    stock_Names[count++] = dr.GetString(0); 
                }
                dr.Close();
         

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }



        }
        #endregion

        #region Retrieve UserName
        public void Retrieve_UserName(string pMail)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  First_Name , Last_Name from Clients where e_mail = :vmail";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("vmail", OracleDbType.Varchar2).Value = pMail;
            //cmd.Parameters.Add("s", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.ReturnValue);
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    user_name = dr.GetString(0) + " " + dr.GetString(1);
                }
                dr.Close();
            

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
       



        }
        #endregion

        #region Retrieve Price of Stock
        public double Retrieve_Corresponding_PriceOfStock(string pStockName)
        {
            double temp = 0.0 ;
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  PriceOfStock from Stocks where stock_name = :vstock_name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("vstock_name", OracleDbType.Varchar2).Value = pStockName;
            //cmd.Parameters.Add("s", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.ReturnValue);
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                   temp = dr.GetDouble(0);
                    
                }
                dr.Close();
                return temp;


            }
            catch (Exception e)
            { }
            finally
            {
                  
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
            return temp;



        }
        #endregion

        #region Ensuring Exsisting Enough Savings
        public bool Ensuring_Exsisting_Enough_Savings(string pMail, double pSavings)
        {
           con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  e_mail from Clients where e_mail = :email and savings >= :psavings";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = pMail;
            cmd.Parameters.Add("psavings", OracleDbType.BinaryDouble).Value = pSavings;
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    dr.Close();
                    return true;
                }
                dr.Close();
                return false;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
            return false;



        }
        
        #endregion

        #region Ensuring Exsisting Specific Data in Table NumofStocksforspecificStock1
        public bool Ensuring_Exsisting_Specific_Data_in_Table_NumofStocksforspecificStock1(string pMail, string pStockName)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();

            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  email from numofstocksforspecificstock1 where email = :email and stock_name = :pstockName";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = pMail;
            cmd.Parameters.Add("pstockName", OracleDbType.Varchar2).Value = pStockName;
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    dr.Close();
                    return true;
                }
                dr.Close();
                return false;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
               
            }
            return false;



        }

        #endregion


        #region Updating Data in Table NumofStocksforSpecificStock1
        public void Updating_Data_in_Table_NumofStocksforSpecificStock1(string pMail,  string pStockName , int pNumofStocks)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Updating_NumOfStocks";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            cmd.Parameters.Add("stockname", OracleDbType.Varchar2, ParameterDirection.Input).Value = pStockName;
            cmd.Parameters.Add("Price", OracleDbType.Varchar2, ParameterDirection.Input).Value = pNumofStocks;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion


        #region Insert_Data_to_Table_NumofStocksforSpecificStock1
        public void Insert_Data_to_Table_NumofStocksforSpecificStock1(string pEMail, string pStockName, int pNumofStocks)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert_Data_Table_NumOfStocks";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("eMail", OracleDbType.Varchar2, ParameterDirection.Input).Value = pEMail;
            cmd.Parameters.Add("stocknName", OracleDbType.Varchar2, ParameterDirection.Input).Value = pStockName;
            cmd.Parameters.Add("numOfStocks", OracleDbType.Int64, ParameterDirection.Input).Value = pNumofStocks;

            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {

                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion


        #region Updating Savings for Buying
        public void Updating_Savings_For_Buying(string pMail, double pTotalPrice)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Updating_Savings_For_Buying";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            cmd.Parameters.Add("Price", OracleDbType.Varchar2, ParameterDirection.Input).Value = pTotalPrice;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region Insert_New_Order
        public void Insert_New_Order ( string pUserName , string pEMail , string pStockName , DateTime pTransactionDate, double pTotalPrice, int pNumofStocks, string pTypeofOrder )
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert_New_Order";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userName", OracleDbType.Varchar2, ParameterDirection.Input).Value = pUserName;
            cmd.Parameters.Add("eMail", OracleDbType.Varchar2, ParameterDirection.Input).Value = pEMail;

            cmd.Parameters.Add("stocknName", OracleDbType.Varchar2, ParameterDirection.Input).Value = pStockName;
            cmd.Parameters.Add("Transaction_Date", OracleDbType.Date, ParameterDirection.Input).Value = pTransactionDate;

            cmd.Parameters.Add("totalPrice", OracleDbType.BinaryDouble, ParameterDirection.Input).Value = pTotalPrice;
            cmd.Parameters.Add("numOfStocks", OracleDbType.Int64, ParameterDirection.Input).Value = pNumofStocks;
            cmd.Parameters.Add("typeOfOrder", OracleDbType.Varchar2, ParameterDirection.Input).Value = pTypeofOrder;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                  
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }





        }
        #endregion

        #region Ensuring_that_Client__Have_EnoughNumofStocks_for_Specific_Stock
        public int Ensuring_that_Client__Have_EnoughNumofStocks_for_Specific_Stock( string pMail , string pStock_Name )
        {
            int temp = -1;
          con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  s.totalNumofStocks from numOfStocksForSpecificStock1 s where s.email = :email   and s.stock_name = :stockName";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = pMail;
            cmd.Parameters.Add("stockName", OracleDbType.Varchar2).Value = pStock_Name;

            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    temp = int.Parse(dr[0].ToString());
                    dr.Close();
                    return temp;
                   
                }
                dr.Close();
                return temp;

            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }
            return temp;



        }
        
        #endregion

        #region Updating Savings for Selling
        public void Updating_Savings_For_Selling(string pMail, double pTotalPrice)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Updating_Savings_For_Selling";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            cmd.Parameters.Add("Price", OracleDbType.Varchar2, ParameterDirection.Input).Value = pTotalPrice;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region Updating theDiffofNumofStocksBuyandSell
        public void Updating_theDiffofNumofStocksBuyandSell_for_Specific_Stock(string pStock_Name , string  pMail , int pDiffBuyingandSelling )
        {

            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();

            cmd.Connection = con;
            //string s;
            cmd.CommandText = "Updating_NumofStocks_forStock";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("stockName", OracleDbType.Varchar2,ParameterDirection.Input).Value = pStock_Name;
            cmd.Parameters.Add("email", OracleDbType.Varchar2 , ParameterDirection.Input).Value = pMail;
            cmd.Parameters.Add("diffnumofstocks", OracleDbType.Int32,ParameterDirection.Input).Value =  pDiffBuyingandSelling;
            try
            {
                con.Open();

                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    
                }

            }
            catch (Exception e)
            { msg = e.Message; }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
               
            }


        }
        #endregion


        #region Num_of_Orders
        public int Num_of_Orders()
        {
         
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            int count = -1;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select count(*) from orders";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("numoforders", OracleDbType.Int32,DBNull.Value, ParameterDirection.Output);

            try
            {
                con.Open();

                count = Convert.ToInt32( cmd.ExecuteScalar() );
                
                
                 
                    numofOrders = count;
                  
                    return count;
                

              
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return count;
        }

        #endregion

        #region Insert Exp Date
        public void Insert_Exp_Date(string pMail, DateTime pExp_Date)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert_Date_Expiration";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            cmd.Parameters.Add("Price", OracleDbType.Date, ParameterDirection.Input).Value = pExp_Date;
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion


        #region Retrieve Expiration Date
        public DateTime Retrieve_Expiration_Date(string pEmail)
        {

            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select DATE_EXPIRATION from Clients where E_MAIL= :email";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("email", OracleDbType.Date, DBNull.Value, ParameterDirection.Output);

            try
            {
                con.Open();

                return Convert.ToDateTime(cmd.ExecuteScalar());



            

               



            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return DateTime.Now;
        }

        #endregion


        #region Num_of_Blocked_Users
        public int Num_of_Blocked_Users()
        {

            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            int count = -1;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select count(*) from Clients where Blocked = 'Y'";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("numoforders", OracleDbType.Int32, DBNull.Value, ParameterDirection.Output);

            try
            {
                con.Open();

                count = Convert.ToInt32(cmd.ExecuteScalar());



                numofBlockedUsers = count;

                return count;



            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return count;
        }

        #endregion


        #region Monitor_Summary_order
        public void Monitor_Summary_Order ()
        {
            numofOrders = Num_of_Orders();
            if (numofOrders == -1)
                return;
            stock_Names = new string[numofOrders];
            transationDate = new string[numofOrders];
            userName = new string[numofOrders];
            Quantity = new string[numofOrders];
            totalPrice = new string[numofOrders];
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();

            cmd.Connection = con;
            //string s;
            cmd.CommandText = "Monitor_Summary_Order";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("rowscursor", OracleDbType.RefCursor, ParameterDirection.Output);

            try
            {
                con.Open();

                dr = cmd.ExecuteReader();
                int count = 0 ;
                while ( dr.Read() )
                {
                   transationDate[count] = dr.GetDateTime(0).ToString();
                    stock_Names[count] = dr.GetString(1);
                    userName[count] = dr.GetString(2);
                    Quantity[count] = dr["NUMOF_STOCKS"].ToString();
                    totalPrice[count++] = dr.GetDouble(4).ToString();
                }
                dr.Close();
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
               
            }
        }

        #endregion

        #region Retrieve Data of Clients that are Blocked
        public void Retrieve_theBlocked_Users_Data()
        {
            numofBlockedUsers = Num_of_Blocked_Users();
            if (numofBlockedUsers == -1)
                return ;
            
            userName = new string[numofBlockedUsers];
            Email = new string[numofBlockedUsers];
            Blocked = new char[numofBlockedUsers];
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
          
            cmd.Connection = con;
            
            cmd.CommandText = "Retrieve_theBlocked_Users_Data";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cursor", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
           
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    userName[count] = dr["userName"].ToString();
                    Email[count] = dr.GetString(1).ToString();
                    Blocked[count++] = dr.GetChar(2);
                }
                dr.Close();
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
        }
        #endregion

        #region sendEmailMethod
        public static void SendEmail(string mail)
        {

            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
                sb.Append("<a href=http://localhost:1930/New_Password.aspx?username=" + mail +">");
                sb.Append("Click here to change your password</a><br/>");
                sb.Append("<b>Thanks</b>,<br> Stock_Market <br/>");
                sb.Append("<br/><b> for more post </b> <br/>");
                sb.Append("<br/><a href=http://neerajcodesolution.blogspot.in");
                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("moataztreka@gmail.com", mail, "Reset Your Password", sb.ToString());

                SmtpClient smtp = new SmtpClient();
                //string mailServerName = ("smtp.gmail.com,587");
                //smtp.Host = mailServerName;
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.EnableSsl = true;

                message.IsBodyHtml = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("moataztreka@gmail.com", "350772350");
                smtp.Timeout = 200000;



                smtp.Send(message);

            }

            catch (Exception ex)
            {
                            }
        }
        #endregion

        #region sendEmailTOContactUS
        public static void SendEmail1(string mail , string body)
        {

            
                
                //StringBuilder sb = new StringBuilder();
                //sb.Append(body);
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Hi,<br/> Click on below given link to Activate Your Password <br/>");
                sb.Append(body+"<br>");
                sb.Append("<a href=http://localhost:1930/Monitor_Users_Page.aspx?username=" + mail + ">");
                sb.Append("Click here to Activate Acoount</a><br/>");
                sb.Append("<b>Thanks</b>,<br> Stock_Market <br/>");
                sb.Append("<br/><b> for more post </b> <br/>");
                sb.Append("<br/><a href=http://neerajcodesolution.blogspot.in");
                sb.Append("thanks");

                MailMessage message = new System.Net.Mail.MailMessage("moataztreka@gmail.com","atefdavid43@gmail.com", "Acivate This Account", sb.ToString());

                SmtpClient smtp = new SmtpClient();
                //string mailServerName = ("smtp.gmail.com,587");
                //smtp.Host = mailServerName;
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.EnableSsl = true;

                message.IsBodyHtml = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("moataztreka@gmail.com", "350772350");
                smtp.Timeout = 200000;



                smtp.Send(message);

            }

            catch (Exception ex)
            {
            }
        }
        #endregion


        #region Retrieve Image
        public void Retrieve_Image(string pImg)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.Connection = con;
            //string s;
            cmd.CommandText = "select  IMG from Clients where e_mail = :vmail";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("vmail", OracleDbType.Varchar2).Value = pImg;
            //cmd.Parameters.Add("s", OracleDbType.Varchar2, DBNull.Value, ParameterDirection.ReturnValue);
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Image = dr.GetString(0);
                }
                dr.Close();


            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                //dr.Close();
                //return false;
            }




        }
        #endregion

        #region Activate User
        public void Activate_User(string pMail)
        {
            con = new OracleConnection(_connectionString);
            cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "Activate_Specific_User";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", OracleDbType.Varchar2, ParameterDirection.Input).Value = pMail;
            
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion
    }
}

