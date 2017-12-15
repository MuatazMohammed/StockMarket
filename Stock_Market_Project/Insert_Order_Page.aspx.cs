using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Stock_Market_Project
{
    public partial class Insert_Order_Page : System.Web.UI.Page
    {
        DataAccessLayer dal;
        personal_Information pInf;
        Stock stock;
        string vUserName;
        static string vStockName;
        double totalPrice;
        int vDiffBetweenBuyingandSelling = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            int temp = (int)Session["log"];
            if (temp != 1)
            {
                Response.Redirect("Login_Page.aspx");
            }
            message.Text = " ";
            dal = new DataAccessLayer();
            dal.Retrieve_UserName((string)Session["mail"]);
            user_txt.Value = dal.user_name;
            vUserName = dal.user_name;
            tdate_txt.Value = DateTime.Now.ToString();

            dal.load_Names_of_Stocks();
            if (!IsPostBack)
            {
                dropdownliststocks.Items.Add(" ");
                for (int i = 0; i < dal.stock_Names.Length; i++)
                {
                    if (dal.stock_Names[i] == null)
                        break;
                    dropdownliststocks.Items.Add(dal.stock_Names[i]);
                    dal.stock_Names[i] = null;
                }
            }


        }
        //
        protected void on_Click_Logout_Button(object sender, EventArgs e)
        {
            Session.Add("log", 0);
            Response.Redirect("Insert_Order_Page.aspx");

        }
        protected void On_Selected_Index_Changed(object sender, EventArgs e)
        {
            stock = new Stock();
            if (dropdownliststocks.SelectedItem.ToString() == " ")
                return;
            vStockName = dropdownliststocks.SelectedItem.ToString();
            priceofstock_txt.Value = stock.retrieve_PriceOfStock(vStockName).ToString(); 
        }

        protected void On_Click_Buy_Btn(object sender, EventArgs e)
        {
            if (int.Parse(qty_txt.Value.ToString()) <= 0)
            {
                message.Text = "Not Allowed Negative Number ";
            }
            else
            {
                totalPrice = double.Parse(priceofstock_txt.Value.ToString()) * double.Parse(qty_txt.Value.ToString());
                dal = new DataAccessLayer();
                if (dal.Ensuring_Exsisting_Enough_Savings((string)Session["mail"], totalPrice))
                {
                    dal.Updating_Savings_For_Buying((string)Session["mail"], totalPrice);

                    dal.Insert_New_Order(vUserName, (string)Session["mail"], vStockName, DateTime.Parse(tdate_txt.Value.ToString()), totalPrice, int.Parse(qty_txt.Value.ToString()), "Buying");
                    if (dal.Ensuring_Exsisting_Specific_Data_in_Table_NumofStocksforspecificStock1((string)Session["mail"], vStockName))
                    {
                        dal.Updating_Data_in_Table_NumofStocksforSpecificStock1((string)Session["mail"], vStockName, int.Parse(qty_txt.Value.ToString()));
                    }
                    else
                    {
                        dal.Insert_Data_to_Table_NumofStocksforSpecificStock1((string)Session["mail"], vStockName, int.Parse(qty_txt.Value.ToString()));
                    }
                    message.Text = "Buying Process Performed Successfully :D ";

                }
                else
                    message.Text = "YOU DONT HAVE ENOUGH MONEY";
            }
        }

        protected void On_Click_Sell_Button(object sender, EventArgs e)
        {
            if (int.Parse(qty_txt.Value.ToString()) <= 0)
            {
                message.Text = "Not Allowed Negative Number ";
            }
            else
            {
                totalPrice = double.Parse(priceofstock_txt.Value.ToString()) * double.Parse(qty_txt.Value.ToString());
                dal = new DataAccessLayer();
                pInf = new personal_Information();
                vDiffBetweenBuyingandSelling = pInf.Ensuring_that_This_Client__Have_EnoughNumofStocks_for_Specific_Stock((string)Session["mail"], vStockName);
                if (vDiffBetweenBuyingandSelling != -1 && vDiffBetweenBuyingandSelling >= int.Parse(qty_txt.Value.ToString()))
                {
                    vDiffBetweenBuyingandSelling -= int.Parse(qty_txt.Value.ToString());
                    dal.Updating_Savings_For_Selling((string)Session["mail"], totalPrice);
                    dal.Updating_theDiffofNumofStocksBuyandSell_for_Specific_Stock(vStockName, (string)Session["mail"], vDiffBetweenBuyingandSelling);
                    dal.Insert_New_Order(vUserName, (string)Session["mail"], vStockName, DateTime.Parse(tdate_txt.Value.ToString()), totalPrice, int.Parse(qty_txt.Value.ToString()), "Selling");
                    message.Text = "Selling Process Performed Successfully :D ";
                }
                else
                    message.Text = " YOU DONT HAVE ENOUGH # STOCKS FOR " + vStockName;
            }
        }
    }
}