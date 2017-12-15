using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Market_Project
{
    public partial class Monitor_Page : System.Web.UI.Page
    {
        DataAccessLayer dal;
        DataTable vTable;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            dal = new DataAccessLayer();
            dal.Monitor_Summary_Order();
            if ( dal.numofOrders != -1 )
            { 
             vTable = new DataTable();
     
                vTable.Columns.Add("Transaction Date");
                vTable.Columns.Add("Stock");

             
            for (int i = 0; i < dal.stock_Names.Length ; i++)
            {
                if (dal.stock_Names[i] == null)
                    return;
                vTable.Rows.Add(dal.transationDate[i], dal.stock_Names[i]);

            }
            
                
            grd_view.DataSource = vTable;
            grd_view.DataBind();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int indx = e.Row.DataItemIndex;


                e.Row.ToolTip = "User Name : " + dal.userName[indx].ToString() + "\n" + "Transaction Date : " + (e.Row.DataItem as DataRowView)["Transaction Date"].ToString() + "\n" + "Stock Name : " + (e.Row.DataItem as DataRowView)["Stock"].ToString() + "\n" + "Quantity : " + dal.Quantity[indx].ToString() + "\n" + "Total Price : " + dal.totalPrice[indx].ToString();
                
            }
            
        }
    }
}