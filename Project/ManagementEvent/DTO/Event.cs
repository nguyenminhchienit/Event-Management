using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class Event
    {
        public Event(string name, int idF, float priceF, int idC)
        {
            this.Name = name;
            this.IdEvent = idF;
            this.Price = priceF;
            this.IdCategory = idC;
        }

        public Event(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.Price = (float)(Convert.ToDouble(row["Price"].ToString()));
            this.IdEvent = (int)row["ID"];
            this.IdCategory = (int)row["IDCategory"];
        }
        private string name;
        private int idEvent;
        //private int idFood;
        private float price;
        private int idCategory;

        public string Name { get => name; set => name = value; }
        //public int IdFood { get => idFood; set => idFood = value; }
        public float Price { get => price; set => price = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdEvent { get => idEvent; set => idEvent = value; }
    }
}
