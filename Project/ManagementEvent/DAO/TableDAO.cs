using ManagementCoffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SwitchTable @idTable1 , @idTabel2", new object[] { id1, id2 });
        }
        private TableDAO()
        {

        }

        public static int TableWidth = 210;
        public static int TableHeight = 210;

        public List<Table> LoadTableList()
        {
            List<Table> listTable = new List<Table>();

            string query = "EXEC dbo.USP_GetTableList";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);

                listTable.Add(table);
            }

            return listTable;
        }

        public DataTable GetListTableDTGV()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM TABLEEVENT");
        }

        public bool InsertStage(string name)
        {
            string query = string.Format("Insert into TableEvent(name) values (N'{0}')", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateStage(string name, int id)
        {
            string query = string.Format("Update TableEvent set name = N'{0}' where id = {1}", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
