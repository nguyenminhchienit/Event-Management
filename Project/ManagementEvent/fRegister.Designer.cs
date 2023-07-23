
namespace ManagementCoffee
{
    partial class fRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbUser = new System.Windows.Forms.Label();
            this.txUser = new System.Windows.Forms.TextBox();
            this.lbShow = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.lbRePass = new System.Windows.Forms.Label();
            this.txShowName = new System.Windows.Forms.TextBox();
            this.txPass = new System.Windows.Forms.TextBox();
            this.txRePass = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbUser.Location = new System.Drawing.Point(35, 173);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(127, 25);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Tên tài khoản";
            // 
            // txUser
            // 
            this.txUser.Location = new System.Drawing.Point(168, 173);
            this.txUser.Name = "txUser";
            this.txUser.Size = new System.Drawing.Size(232, 31);
            this.txUser.TabIndex = 1;
            this.txUser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbShow
            // 
            this.lbShow.AutoSize = true;
            this.lbShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbShow.Location = new System.Drawing.Point(35, 223);
            this.lbShow.Name = "lbShow";
            this.lbShow.Size = new System.Drawing.Size(112, 25);
            this.lbShow.TabIndex = 2;
            this.lbShow.Text = "Tên hiển thị";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbPass.Location = new System.Drawing.Point(35, 273);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(93, 25);
            this.lbPass.TabIndex = 3;
            this.lbPass.Text = "Mật khẩu";
            // 
            // lbRePass
            // 
            this.lbRePass.AutoSize = true;
            this.lbRePass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRePass.Location = new System.Drawing.Point(35, 319);
            this.lbRePass.Name = "lbRePass";
            this.lbRePass.Size = new System.Drawing.Size(132, 25);
            this.lbRePass.TabIndex = 4;
            this.lbRePass.Text = "Re - Mật khẩu";
            // 
            // txShowName
            // 
            this.txShowName.Location = new System.Drawing.Point(168, 223);
            this.txShowName.Name = "txShowName";
            this.txShowName.Size = new System.Drawing.Size(232, 31);
            this.txShowName.TabIndex = 5;
            // 
            // txPass
            // 
            this.txPass.Location = new System.Drawing.Point(168, 273);
            this.txPass.Name = "txPass";
            this.txPass.Size = new System.Drawing.Size(232, 31);
            this.txPass.TabIndex = 6;
            // 
            // txRePass
            // 
            this.txRePass.Location = new System.Drawing.Point(168, 319);
            this.txRePass.Name = "txRePass";
            this.txRePass.Size = new System.Drawing.Size(232, 31);
            this.txRePass.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSubmit.Location = new System.Drawing.Point(275, 368);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(125, 51);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // fRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ManagementCoffee.Properties.Resources.register;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txRePass);
            this.Controls.Add(this.txPass);
            this.Controls.Add(this.txShowName);
            this.Controls.Add(this.lbRePass);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbShow);
            this.Controls.Add(this.txUser);
            this.Controls.Add(this.lbUser);
            this.DoubleBuffered = true;
            this.Name = "fRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.TextBox txUser;
        private System.Windows.Forms.Label lbShow;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Label lbRePass;
        private System.Windows.Forms.TextBox txShowName;
        private System.Windows.Forms.TextBox txPass;
        private System.Windows.Forms.TextBox txRePass;
        private System.Windows.Forms.Button btnSubmit;
    }
}