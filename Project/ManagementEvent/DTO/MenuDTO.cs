using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class MenuDTO
    {
        public MenuDTO(string foodname,int count, float price, float totalprice = 0)
        {
            this.FoodName = foodname;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }

        public MenuDTO(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)(Convert.ToDouble(row["price"].ToString()));
            this.TotalPrice = (float)(Convert.ToDouble(row["totalprice"].ToString()));
        }
        private string foodName;
        private int count;
        private float price;
        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
