using ManagementCoffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ManagementCoffee.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            set { AccountDAO.instance = value; } 
        }

        private AccountDAO()
        {

        }

        public bool Login(string username, string password)
        {
            //Ma hoa mat khau
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            var list = hasData.ToString();

            list.Reverse();
            
            string query = "EXEC dbo.USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {username,password });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from account where userName = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;        
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
        }

        public bool InsertAccount(string name, string displayname, int type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type ) VALUES  ( N'{0}',N'{1}', {2})", name, displayname, type);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayname, int type)
        {
            string query = string.Format("UPDATE Account SET  DisplayName = N'{0}', Type = {1} WHERE UserName = N'{2}'", displayname, type, name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("DELETE Account WHERE UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool RegisterAccount(string username, string displayname, string pass)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Password ) VALUES  ( N'{0}',N'{1}', N'{2}')", username, displayname, pass);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
