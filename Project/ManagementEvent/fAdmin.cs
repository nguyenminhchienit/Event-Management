using ManagementCoffee.DAO;
using ManagementCoffee.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManagementCoffee
{
    
    public partial class fAdmin : Form
    {
        BindingSource eventList = new BindingSource();
        BindingSource accList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableEventList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();

            Load();
        }

        void Load()
        {
            dtgvEvent.DataSource = eventList;
            dtgvCategory.DataSource = categoryList;
            dtgvAcc.DataSource = accList;
            dtgvTableEvent.DataSource = tableEventList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListEvent();
            LoadAccount();
            LoadCategory();
            LoadListTableEvent();
            LoadCategoryIntoCombobox(cbCategoryEvent);
            AddEventBinding();
            AddAccountBinding();
            AddCategoryBinding();
            AddTableEventBinding();
        }

        void AddAccountBinding()
        {
            txUserName.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txShowName.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAcc.DataBindings.Add(new Binding("Value", dtgvAcc.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void AddCategoryBinding()
        {
            txIDCate.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txCate.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void AddTableEventBinding()
        {
            txTableID.DataBindings.Add(new Binding("Text", dtgvTableEvent.DataSource, "id", true, DataSourceUpdateMode.Never));
            txTableName.DataBindings.Add(new Binding("Text", dtgvTableEvent.DataSource, "name", true, DataSourceUpdateMode.Never));
            txStatus.DataBindings.Add(new Binding("Text", dtgvTableEvent.DataSource, "status", true, DataSourceUpdateMode.Never));


        }
        void LoadListTableEvent()
        {
            tableEventList.DataSource = TableDAO.Instance.GetListTableDTGV();
        }

        void LoadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategoryDTGV();
        }
        void LoadAccount()
        {
            accList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        private void btnAccShow_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        void AddEventBinding()
        {
            txEvent.DataBindings.Add(new Binding("Text", dtgvEvent.DataSource, "name", true, DataSourceUpdateMode.Never));
            txIDEvent.DataBindings.Add(new Binding("Text", dtgvEvent.DataSource, "idEvent", true, DataSourceUpdateMode.Never));
            nmPriceEvent.DataBindings.Add(new Binding("Value", dtgvEvent.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember ="nameCategory";
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

     

        private void btnResult_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }


        void LoadListEvent()
        {
            eventList.DataSource = EventDAO.Instance.GetListEvent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadListEvent();
        }

        private void txIDEvent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvEvent.SelectedCells.Count > 0)
                {
                    
                        int id = (int)dtgvEvent.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;
                    
                        Category cateogory = CategoryDAO.Instance.GetCategoryById(id);

                        cbCategoryEvent.SelectedItem = cateogory;

                        int index = -1;
                        int i = 0;
                        foreach (Category item in cbCategoryEvent.Items)
                        {
                            if (item.Id == cateogory.Id)
                            {
                                index = i;
                                break;
                            }
                            i++;
                        }

                        cbCategoryEvent.SelectedIndex = index;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy");
            }
        }


        //Them su kiện
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txEvent.Text;
            int idCategory = (cbCategoryEvent.SelectedItem as Category).Id;
            float price = (float)nmPriceEvent.Value;

            if (EventDAO.Instance.InsertEvent(name, idCategory, price))
            {
                MessageBox.Show("Thêm sự kiện thành công");
                LoadListEvent();
                if(insertEvent != null)
                {
                    insertEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm sự kiện không thành công!!!");
            }
        }

        //Sửa sự kiện
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txEvent.Text;
            int idCategory = (cbCategoryEvent.SelectedItem as Category).Id;
            float price = (float)nmPriceEvent.Value;
            int id = Convert.ToInt32(txIDEvent.Text);

            if (EventDAO.Instance.UpdateEvent(name, idCategory, price,id))
            {
                MessageBox.Show("Sửa sự kiện thành công");
                LoadListEvent();
                if (updateEvent != null)
                {
                    updateEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa sự kiện không thành công!!!");
            }
        }

        //Xoa su kien
        private void button3_Click(object sender, EventArgs e)

        {
            int id = Convert.ToInt32(txIDEvent.Text);

            if (EventDAO.Instance.DeleteEvent(id))
            {
                MessageBox.Show("Xóa sự kiện thành công");
                LoadListEvent();
                if (deleteEvent != null)
                {
                    deleteEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa sự kiện không thành công!!!");
            }
        }


        //======================= Tao event ==================
        private event EventHandler insertEvent;
        public event EventHandler InsertEvent
        {
            add { insertEvent += value; }
            remove { insertEvent -= value; }
        }

        private event EventHandler deleteEvent;
        public event EventHandler DeleteEvent
        {
            add { deleteEvent += value; }
            remove { deleteEvent -= value; }
        }

        private event EventHandler updateEvent;
        public event EventHandler UpdateEvent
        {
            add { updateEvent += value; }
            remove { updateEvent -= value; }
        }

        List<Event> SearchEventByName(string name)
        {
            List<Event> list = new List<Event>();
            list = EventDAO.Instance.SearchEventByNames(name);
            return list;
        }

        private void btnSearchEvent_Click(object sender, EventArgs e)
        {
            eventList.DataSource =  SearchEventByName(txSearchEvent.Text);
        }


        void AddAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Không thêm tài khoản thành công");
            }
            LoadAccount();
        }

        private void btnAccAdd_Click(object sender, EventArgs e)
        {
            string username = txUserName.Text;
            string displayname = txShowName.Text;
            int type = Convert.ToInt32(nmTypeAcc.Value);

            AddAccount(username, displayname, type);
        }

        void UpdateAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }
        private void btnAccEdit_Click(object sender, EventArgs e)
        {
            string username = txUserName.Text;
            string displayname = txShowName.Text;
            int type = Convert.ToInt32(nmTypeAcc.Value);

            UpdateAccount(username, displayname, type);
        }

        void DeleteAccount(string username)
        {
            if (loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Không thể xóa chính bạn");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }
        private void btnAccDelete_Click(object sender, EventArgs e)
        {
            string username = txUserName.Text;
            DeleteAccount(username);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txPage.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txPage.Text = lastPage.ToString();
        }

        private void txPage_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txPage.Text));
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txPage.Text);

            if (page > 1)
                page--;

            txPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txPage.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            txPage.Text = page.ToString();
        }

        private void btnCateShow_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }


        //Nut xem tat ca cac san khau
        private void button10_Click(object sender, EventArgs e)
        {
            LoadListTableEvent();
        }

        void AddCategory()
        {
            string nameCate = txCate.Text;
            if (CategoryDAO.Instance.InsertCategory(nameCate))
            {
                MessageBox.Show("Thêm danh mục sự kiện thành công");
                LoadCategory();
                if (insertEvent != null)
                {
                    insertEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Không thêm danh mục sự kiện thành công");
            }
        }
        private void btnCateAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        void UpdateCategory()
        {
            string name = txCate.Text;
            int idCate = Convert.ToInt32(txIDCate.Text);
            if (CategoryDAO.Instance.UpdateCategory(name,idCate))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadCategory();
                if (updateEvent != null)
                {
                    updateEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        private void btnCateEdit_Click(object sender, EventArgs e)
        {
            UpdateCategory();
        }

        void AddStageEvent()
        {
            string name = txTableName.Text;
            if (TableDAO.Instance.InsertStage(name))
            {
                MessageBox.Show("Thêm sân khấu thành công");
                LoadListTableEvent();
                if (insertEvent != null)
                {
                    insertEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm sân khấu thất bại");
            }
        }
        private void btnSKAdd_Click(object sender, EventArgs e)
        {
            AddStageEvent();
        }

        void UpdateStage()
        {
            string name = txTableName.Text;
            int id = Convert.ToInt32(txTableID.Text);
            if (TableDAO.Instance.UpdateStage(name,id))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadListTableEvent();
                if (updateEvent != null)
                {
                    updateEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateStage();
        }









        /*void LoadDataList()
        {

            //string query = "SELECT * FROM Account";
            string query = "EXEC dbo.USP_GetAccountByUserName @userName";

            dtgvAcc.DataSource = DataProvider.Instance.ExcuteQuery(query,new object[] { "staff"});

        }*/
    }
}
