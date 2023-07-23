using ManagementCoffee.DAO;
using ManagementCoffee.DTO;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ManagementCoffee
{
    public partial class fManagerTable : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public fManagerTable(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbxTable);
        }


        #region

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += "( " + LoginAccount.DisplayName + " )";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> list = TableDAO.Instance.LoadTableList();

            foreach(Table item in list)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                flpTable.Controls.Add(btn);
                //btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                //btn.BackgroundImage = new Bitmap(Application.StartupPath + "\\Resources\\stage-empty-1.png");
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Tag = item; // lay ra the Tag btn de lay ID Table
                switch (item.Status)
                {
                    case "Trống":
                        {
                            //btn.BackColor = Color.Aqua;
                            btn.BackgroundImage = new Bitmap(Application.StartupPath + "\\Resources\\stage-empty-1.png");
                            break;
                        }
                    default:
                        {
                            //btn.BackColor = Color.Tomato;
                            btn.BackgroundImage = new Bitmap(Application.StartupPath + "\\Resources\\stage-full.png");
                            break;
                        }
                }
            }
        }

        void showBill(int idTable)
        {
            lVBill.Items.Clear();
            List<MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(idTable);
            float totalPrice = 0;
            foreach(MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice;

                lVBill.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            txTotalPrice.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.}", totalPrice + " VND");
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategoryFood.DataSource = listCategory;
            cbCategoryFood.DisplayMember = "nameCategory";
        }

        void LoadFoodCategoryID(int id)
        {
            List<Event> listFood = EventDAO.Instance.GetFoodByIDCategory(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }


        #endregion

        #region

        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).ID;
            lVBill.Tag = (sender as Button).Tag;
            showBill(idTable);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn đăng xuất","Thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateAccount += F_UpdateAccount;
            f.ShowDialog();
        }

        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản ( " + e.Acc.DisplayName + " )";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertEvent += F_InsertEvent;
            f.UpdateEvent += F_UpdateEvent;
            f.DeleteEvent += F_DeleteEvent;
            f.ShowDialog();
        }

        private void F_DeleteEvent(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if (lVBill.Tag != null)
                showBill((lVBill.Tag as Table).ID);
            LoadTable();
        }

        private void F_UpdateEvent(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if (lVBill.Tag != null)
                showBill((lVBill.Tag as Table).ID);
        }

        private void F_InsertEvent(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if (lVBill.Tag != null)
                showBill((lVBill.Tag as Table).ID);
        }
        #endregion

        private void lVBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }

            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodCategoryID(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Table table = lVBill.Tag as Table;

            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn !!");
                return;
            }

            int idBill = BillDAO.Instance.LoadBillUnCheckByIdTable(table.ID);
            int foodID = (cbFood.SelectedItem as Event).IdEvent;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            showBill(table.ID);
            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lVBill.Tag as Table;

            int idBill = BillDAO.Instance.LoadBillUnCheckByIdTable(table.ID);
            double totalPrice = Convert.ToDouble(txTotalPrice.Text.Split(' ')[0]);
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,(float)totalPrice);
                    showBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lVBill.Tag as Table;
            int id1 = table.ID;

            int id2 = (cbxTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển sân khấu {0} qua sân khấu {1}", (lVBill.Tag as Table).Name, (cbxTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

        private void thêmSựKiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }
    }
}
