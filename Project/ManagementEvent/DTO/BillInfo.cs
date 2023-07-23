using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int idbill, int idfood, int count)
        {
            this.ID = id;
            this.IDBill = idbill;
            this.IDFood = idfood;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idBill"];
            this.IDFood = (int)row["idFood"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int iDBill;
        private int iDFood;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int Count { get => count; set => count = value; }
    }
}
