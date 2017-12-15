using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Text;


namespace Stock_Market_Project
{
   
  
    public class personal_Information
    {
        
      
        private string vfirst_Name;
        private string vlast_Name;
        private string ve_Mail;
        private DateTime vbirth_Date;
        private DateTime vexp_Date;
        private string vpassword;
        private double vsavings;
        private char vblocked;
        private DataAccessLayer dal;

        public string vFirst_Name
        {
            get
            {
                //logic here 
                return vfirst_Name;
            }
            set
            {
                //logic here
                vfirst_Name = value;
            }
        }

        public char vBlocked
        {
            get
            {
                //logic here 
                return vblocked;
            }
            set
            {
                //logic here
                vblocked = value;
            }
        }
        public string vLast_Name
        {
            get
            {
                //logic here 
                return vlast_Name;
            }
            set
            {
                //logic here
                vlast_Name = value;
            }
        }
        public string vE_Mail
        {
            get
            {
                //logic here 
                return ve_Mail;
            }
            set
            {
                //logic here
                ve_Mail = value;
            }
        }
        public DateTime vBirth_Date
        {
            get
            {
                //logic here 
                return vbirth_Date;
            }
            set
            {
                //logic here
                vbirth_Date = value;
            }
        }

        public DateTime vExp_Date
        {
            get
            {
                //logic here 
                return vexp_Date;
            }
            set
            {
                //logic here
                vexp_Date = value;
            }
        }

        public string vPassword
        {
            get
            {
                //logic here 
                return vpassword;
            }
            set
            {
                //logic here
                vpassword = value;
            }
        }

        public double vSavings
        {
            get
            {
                //logic here 
                return vsavings;
            }
            set
            {
                //logic here
                vsavings = value;
            }
        }






        #region Add_New_Client
        public void Add_New_Client(string pFirst_Name, string pLast_Name, string pEmail, DateTime pBirth_Date, string pPassword , double pSavings , char pBlocked , string pImg , DateTime pExp_Date)
        {
            dal = new DataAccessLayer();
            pPassword = this.leftRotateShift(pPassword, 4);
            dal.register_New_Client(pFirst_Name, pLast_Name, pEmail, pBirth_Date, pPassword , pSavings , pBlocked , pImg , pExp_Date);
          
            vfirst_Name = pFirst_Name;
            vlast_Name = pLast_Name;
            ve_Mail = pEmail;
            vbirth_Date = pBirth_Date;
            vpassword = pPassword;
            vsavings = pSavings;
            vexp_Date = pExp_Date;
        }
        #endregion

        #region Set_User_Blocked
        public void Set_User_to_Blocked(string pMail, char pBlocked)
        {
            dal = new DataAccessLayer();
            dal.Set_User_to_Be_Blocked(pMail, pBlocked);
            vBlocked = pBlocked;
        }
        #endregion

        #region Check Blocking the User
        public bool Check_User_Blocking(string pMail )
        {
            dal = new DataAccessLayer();
            if (dal.Check_User_Blocking(pMail))
                return true;
            else
                return false;
          
           
        }
        #endregion

        #region Update Exp Date
        public void Update_Exp_Date(string pMail, DateTime pExp_Date)
        {
            dal = new DataAccessLayer();
            dal.Insert_Exp_Date(pMail, pExp_Date);
            vexp_Date = pExp_Date;
        }
        #endregion

        #region Retrieve Expiration Date
        public DateTime Retrieve_Exp_Date(string pEmail)
        {
            dal = new DataAccessLayer();
            return dal.Retrieve_Expiration_Date(pEmail);
        }
        #endregion

        #region Ensure_Exsisting_E_Mail
        public bool ensure_Exsisting_E_Mail(string pEmail)
        {
            dal = new DataAccessLayer() ;
            return dal.ensure_exsisting_mail(pEmail);
        }
        #endregion

        #region Ensure Email With Password

        public bool ensure_Email_with_Password(string pEmail, string pPassword)
        {
            dal = new DataAccessLayer();
            pPassword = this.leftRotateShift(pPassword, 4);
            return dal.ensure_email_password_login(pEmail, pPassword);

        }
        #endregion

        #region confirmingChangePassword
        public void confirm_Change_Password(string pEmail, string pPassword)
        {
            dal = new DataAccessLayer();
            pPassword = this.leftRotateShift(pPassword, 4);
            dal.confirming_Change_Password( pEmail, pPassword ) ;

        }
        #endregion

        public int Ensuring_that_This_Client__Have_EnoughNumofStocks_for_Specific_Stock(string pMail, string pStock_Name)
        {
            dal = new DataAccessLayer();
            return dal.Ensuring_that_Client__Have_EnoughNumofStocks_for_Specific_Stock(pMail, pStock_Name );
        }

        #region leftRotateShift
        private string leftRotateShift(string pPassword, int pNumofCharacterstoShift)
        {
            pNumofCharacterstoShift %= pPassword.Length;
            return pPassword.Substring(pNumofCharacterstoShift) + pPassword.Substring(0, pNumofCharacterstoShift);
        }
        #endregion

        #region rightRotateShift
        private string rightRotateShift(string pPassword, int pNumofCharacterstoShift)
        {
            pNumofCharacterstoShift %= pPassword.Length;
            return pPassword.Substring(pPassword.Length - pNumofCharacterstoShift) + pPassword.Substring(0, pPassword.Length - pNumofCharacterstoShift);
        }
        #endregion
    }
}