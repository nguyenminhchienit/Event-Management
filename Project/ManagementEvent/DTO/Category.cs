using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class Category
    {

        public Category(int id, string name)
        {
            this.Id = id;
            this.NameCategory = name;
        }

        public Category(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NameCategory = row["name"].ToString();
        }
        private int id;
        private string nameCategory;

        public int Id { get => id; set => id = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
    }
}
