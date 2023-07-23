using ManagementCoffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DAO
{
    public class EventDAO
    {
        private static EventDAO instance;

        public static EventDAO Instance 
        {
            get { if (instance == null) instance = new EventDAO(); return EventDAO.instance; }
            set { EventDAO.instance = value; }
        }

        private EventDAO()
        {

        }

        public List<Event> GetFoodByIDCategory(int id)
        {
            List<Event> list = new List<Event>();
            string query = "select * from event where idCategory"+ "=" + id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Event food = new Event(item);
                list.Add(food);
            }
            return list;
        }

        public List<Event> GetListEvent()
        {
            List<Event> list = new List<Event>();
            string query = "SELECT name as [Name], price as [Price], id as [ID],  idCategory as [IDCategory]  FROM event";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Event food = new Event(item);
                list.Add(food);
            }
            return list;
        }

        public bool InsertEvent(string name, int idCategory, float price)
        {
            string query = string.Format("INSERT dbo.Event ( name, idCategory, price ) VALUES  ( N'{0}',{1}, {2})", name, idCategory, price);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateEvent(string name, int idCategory, float price, int idEvent)
        {
            string query = string.Format("UPDATE EVENT SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, idCategory, price, idEvent);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteEvent(int idEvent)
        {
            BillInfoDAO.Instance.DeleteBillInfoByID(idEvent);
            string query = string.Format("DELETE EVENT WHERE id = {0}", idEvent);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<Event> SearchEventByNames(string name)
        {
            List<Event> list = new List<Event>();
            string query = string.Format("Select * from event where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Event food = new Event(item);
                list.Add(food);
            }
            return list;
        }
    }
}
