using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class Table
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string name;
        public string Name { get => name; set => name = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.name = name;
            this.Status = status;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }



    }
}
