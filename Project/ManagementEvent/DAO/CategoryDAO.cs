using ManagementCoffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ManagementCoffee.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance 
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            set { CategoryDAO.instance = value; } 
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from EventCategory";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;        
        }

        public DataTable GetListCategoryDTGV()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM EVENTCATEGORY");
        }

        public Category GetCategoryById(int id)
        {
            Category category = null;
            string query = "SELECT * FROM EVENTCATEGORY WHERE ID = " + id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }

        public bool InsertCategory(string nameCate)
        {
            string query = string.Format("Insert into EventCategory(name) values (N'{0}')", nameCate);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCategory(string name, int id)
        {
            string query = string.Format("Update EventCategory set name = N'{0}'Where id = {1}", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
