using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Market_Project
{
    public class Stock
    {
        private string stock_Name;
        private double Stock_Price;
        private DataAccessLayer dal;

        public string vStock_Name
        {
            get
            {
                //logic here 
                return stock_Name;
            }
            set
            {
                //logic here
                stock_Name = value;
            }
        }

        public double vStock_Price
        {
            get
            {
                //logic here 
                return Stock_Price;
            }
            set
            {
                //logic here
                Stock_Price = value;
            }
        }

        public double retrieve_PriceOfStock(string pStock_Name)
        {
            dal = new DataAccessLayer();
            vStock_Price = dal.Retrieve_Corresponding_PriceOfStock(pStock_Name);
            return vStock_Price;
        }
    }
}