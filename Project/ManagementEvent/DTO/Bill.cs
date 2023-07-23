using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DTO
{
    public class Bill
    {
        public Bill(int status, int idTable, DateTime? DateCheckIn, DateTime? DateCheckOut)
        {
            this.DateCheckIn1 = DateCheckIn;
            this.DateCheckOut1 = DateCheckOut;
            this.IdTable = idTable;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.IdTable = (int)row["id"];
            this.Status = (int)row["status"];
            var dateCheckInTemp = row["DateCheckIn"];
            if(dateCheckInTemp.ToString() != "")
            {
                this.DateCheckIn1 = (DateTime?)dateCheckInTemp;
            }
            var dateCheckOutTemp = row["DateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
            {
                this.DateCheckOut1 = (DateTime?)dateCheckOutTemp;
            }
        }

        private DateTime? DateCheckOut;
        private DateTime? DateCheckIn;
        private int idTable;
        private int status;
        public int Status { get => status; set => status = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public DateTime? DateCheckIn1 { get => DateCheckIn; set => DateCheckIn = value; }
        public DateTime? DateCheckOut1 { get => DateCheckOut; set => DateCheckOut = value; }
    }
}
