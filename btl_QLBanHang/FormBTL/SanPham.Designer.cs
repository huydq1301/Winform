namespace btl_QLBanHang
{
    partial class SanPham
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
            this.components = new System.ComponentModel.Container();
            this.cb_ChatLieu = new System.Windows.Forms.ComboBox();
            this.tb_SLuong = new System.Windows.Forms.TextBox();
            this.tb_DGB = new System.Windows.Forms.TextBox();
            this.tb_DGN = new System.Windows.Forms.TextBox();
            this.tb_MaSP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSanpham = new System.Windows.Forms.DataGridView();
            this.tb_TenSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_ThongTinSP = new System.Windows.Forms.GroupBox();
            this.bt_Anh = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_excel = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_TimKiem = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_Huy = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_Xoa = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_Sua = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_Them = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.cb_MauSac = new System.Windows.Forms.ComboBox();
            this.cb_Size = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_KM = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_NCC = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_MoTa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.picSanpham = new System.Windows.Forms.PictureBox();
            this.error_ThongTin = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanpham)).BeginInit();
            this.gb_ThongTinSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_ThongTin)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ChatLieu
            // 
            this.cb_ChatLieu.FormattingEnabled = true;
            this.cb_ChatLieu.Location = new System.Drawing.Point(97, 120);
            this.cb_ChatLieu.Name = "cb_ChatLieu";
            this.cb_ChatLieu.Size = new System.Drawing.Size(139, 21);
            this.cb_ChatLieu.TabIndex = 23;
            // 
            // tb_SLuong
            // 
            this.tb_SLuong.Location = new System.Drawing.Point(349, 30);
            this.tb_SLuong.Name = "tb_SLuong";
            this.tb_SLuong.Size = new System.Drawing.Size(70, 19);
            this.tb_SLuong.TabIndex = 15;
            // 
            // tb_DGB
            // 
            this.tb_DGB.Location = new System.Drawing.Point(360, 90);
            this.tb_DGB.Name = "tb_DGB";
            this.tb_DGB.Size = new System.Drawing.Size(120, 19);
            this.tb_DGB.TabIndex = 14;
            // 
            // tb_DGN
            // 
            this.tb_DGN.Location = new System.Drawing.Point(125, 90);
            this.tb_DGN.Name = "tb_DGN";
            this.tb_DGN.Size = new System.Drawing.Size(120, 19);
            this.tb_DGN.TabIndex = 13;
            // 
            // tb_MaSP
            // 
            this.tb_MaSP.Location = new System.Drawing.Point(125, 30);
            this.tb_MaSP.Name = "tb_MaSP";
            this.tb_MaSP.Size = new System.Drawing.Size(120, 19);
            this.tb_MaSP.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Chất liệu:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSanpham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 286);
            this.panel1.TabIndex = 9;
            // 
            // dgvSanpham
            // 
            this.dgvSanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanpham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanpham.Location = new System.Drawing.Point(0, 0);
            this.dgvSanpham.Name = "dgvSanpham";
            this.dgvSanpham.RowHeadersWidth = 51;
            this.dgvSanpham.RowTemplate.Height = 24;
            this.dgvSanpham.Size = new System.Drawing.Size(1182, 286);
            this.dgvSanpham.TabIndex = 1;
            this.dgvSanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanpham_CellClick);
            this.dgvSanpham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanpham_CellClick);
            // 
            // tb_TenSP
            // 
            this.tb_TenSP.Location = new System.Drawing.Point(135, 60);
            this.tb_TenSP.Name = "tb_TenSP";
            this.tb_TenSP.Size = new System.Drawing.Size(565, 19);
            this.tb_TenSP.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Số lượng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Đơn giá bán:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Đơn giá nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kích cỡ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // gb_ThongTinSP
            // 
            this.gb_ThongTinSP.Controls.Add(this.bt_Anh);
            this.gb_ThongTinSP.Controls.Add(this.bt_excel);
            this.gb_ThongTinSP.Controls.Add(this.bt_TimKiem);
            this.gb_ThongTinSP.Controls.Add(this.bt_Huy);
            this.gb_ThongTinSP.Controls.Add(this.bt_Xoa);
            this.gb_ThongTinSP.Controls.Add(this.bt_Sua);
            this.gb_ThongTinSP.Controls.Add(this.bt_Them);
            this.gb_ThongTinSP.Controls.Add(this.cb_MauSac);
            this.gb_ThongTinSP.Controls.Add(this.cb_Size);
            this.gb_ThongTinSP.Controls.Add(this.label12);
            this.gb_ThongTinSP.Controls.Add(this.cb_KM);
            this.gb_ThongTinSP.Controls.Add(this.label11);
            this.gb_ThongTinSP.Controls.Add(this.label3);
            this.gb_ThongTinSP.Controls.Add(this.cb_NCC);
            this.gb_ThongTinSP.Controls.Add(this.label10);
            this.gb_ThongTinSP.Controls.Add(this.tb_MoTa);
            this.gb_ThongTinSP.Controls.Add(this.label8);
            this.gb_ThongTinSP.Controls.Add(this.cb_ChatLieu);
            this.gb_ThongTinSP.Controls.Add(this.picSanpham);
            this.gb_ThongTinSP.Controls.Add(this.tb_SLuong);
            this.gb_ThongTinSP.Controls.Add(this.tb_DGB);
            this.gb_ThongTinSP.Controls.Add(this.tb_DGN);
            this.gb_ThongTinSP.Controls.Add(this.tb_TenSP);
            this.gb_ThongTinSP.Controls.Add(this.tb_MaSP);
            this.gb_ThongTinSP.Controls.Add(this.label9);
            this.gb_ThongTinSP.Controls.Add(this.label7);
            this.gb_ThongTinSP.Controls.Add(this.label6);
            this.gb_ThongTinSP.Controls.Add(this.label5);
            this.gb_ThongTinSP.Controls.Add(this.label4);
            this.gb_ThongTinSP.Controls.Add(this.label2);
            this.gb_ThongTinSP.Controls.Add(this.label1);
            this.gb_ThongTinSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_ThongTinSP.Location = new System.Drawing.Point(0, 0);
            this.gb_ThongTinSP.Name = "gb_ThongTinSP";
            this.gb_ThongTinSP.Size = new System.Drawing.Size(1182, 267);
            this.gb_ThongTinSP.TabIndex = 8;
            this.gb_ThongTinSP.TabStop = false;
            this.gb_ThongTinSP.Text = "Thông tin sản phẩm";
            // 
            // bt_Anh
            // 
            this.bt_Anh.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Anh.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_Anh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Anh.BorderRadius = 20;
            this.bt_Anh.BorderSize = 2;
            this.bt_Anh.FlatAppearance.BorderSize = 0;
            this.bt_Anh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Anh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Anh.ForeColor = System.Drawing.Color.White;
            this.bt_Anh.Image = global::btl_QLBanHang.Properties.Resources.editnew1;
            this.bt_Anh.Location = new System.Drawing.Point(759, 191);
            this.bt_Anh.Name = "bt_Anh";
            this.bt_Anh.Size = new System.Drawing.Size(116, 34);
            this.bt_Anh.TabIndex = 50;
            this.bt_Anh.Text = "Chọn Ảnh";
            this.bt_Anh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Anh.TextColor = System.Drawing.Color.White;
            this.bt_Anh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Anh.UseVisualStyleBackColor = false;
            // 
            // bt_excel
            // 
            this.bt_excel.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_excel.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_excel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_excel.BorderRadius = 19;
            this.bt_excel.BorderSize = 2;
            this.bt_excel.FlatAppearance.BorderSize = 0;
            this.bt_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_excel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_excel.ForeColor = System.Drawing.Color.White;
            this.bt_excel.Image = global::btl_QLBanHang.Properties.Resources.printnew;
            this.bt_excel.Location = new System.Drawing.Point(686, 231);
            this.bt_excel.Name = "bt_excel";
            this.bt_excel.Size = new System.Drawing.Size(123, 36);
            this.bt_excel.TabIndex = 49;
            this.bt_excel.Text = " In";
            this.bt_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_excel.TextColor = System.Drawing.Color.White;
            this.bt_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_excel.UseVisualStyleBackColor = false;
            // 
            // bt_TimKiem
            // 
            this.bt_TimKiem.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_TimKiem.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_TimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_TimKiem.BorderRadius = 20;
            this.bt_TimKiem.BorderSize = 2;
            this.bt_TimKiem.FlatAppearance.BorderSize = 0;
            this.bt_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_TimKiem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TimKiem.ForeColor = System.Drawing.Color.White;
            this.bt_TimKiem.Image = global::btl_QLBanHang.Properties.Resources.searchnew;
            this.bt_TimKiem.Location = new System.Drawing.Point(557, 233);
            this.bt_TimKiem.Name = "bt_TimKiem";
            this.bt_TimKiem.Size = new System.Drawing.Size(123, 35);
            this.bt_TimKiem.TabIndex = 48;
            this.bt_TimKiem.Text = " Tìm Kiếm";
            this.bt_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_TimKiem.TextColor = System.Drawing.Color.White;
            this.bt_TimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_TimKiem.UseVisualStyleBackColor = false;
            // 
            // bt_Huy
            // 
            this.bt_Huy.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Huy.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_Huy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Huy.BorderRadius = 20;
            this.bt_Huy.BorderSize = 2;
            this.bt_Huy.FlatAppearance.BorderSize = 0;
            this.bt_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Huy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Huy.ForeColor = System.Drawing.Color.White;
            this.bt_Huy.Image = global::btl_QLBanHang.Properties.Resources.skipnew;
            this.bt_Huy.Location = new System.Drawing.Point(33, 230);
            this.bt_Huy.Name = "bt_Huy";
            this.bt_Huy.Size = new System.Drawing.Size(123, 35);
            this.bt_Huy.TabIndex = 47;
            this.bt_Huy.Text = " Bỏ Qua";
            this.bt_Huy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Huy.TextColor = System.Drawing.Color.White;
            this.bt_Huy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Huy.UseVisualStyleBackColor = false;
            // 
            // bt_Xoa
            // 
            this.bt_Xoa.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Xoa.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_Xoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Xoa.BorderRadius = 20;
            this.bt_Xoa.BorderSize = 2;
            this.bt_Xoa.FlatAppearance.BorderSize = 0;
            this.bt_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Xoa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Xoa.ForeColor = System.Drawing.Color.White;
            this.bt_Xoa.Image = global::btl_QLBanHang.Properties.Resources.removenew;
            this.bt_Xoa.Location = new System.Drawing.Point(428, 232);
            this.bt_Xoa.Name = "bt_Xoa";
            this.bt_Xoa.Size = new System.Drawing.Size(123, 34);
            this.bt_Xoa.TabIndex = 46;
            this.bt_Xoa.Text = " Xóa";
            this.bt_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Xoa.TextColor = System.Drawing.Color.White;
            this.bt_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Xoa.UseVisualStyleBackColor = false;
            // 
            // bt_Sua
            // 
            this.bt_Sua.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Sua.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_Sua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Sua.BorderRadius = 20;
            this.bt_Sua.BorderSize = 2;
            this.bt_Sua.FlatAppearance.BorderSize = 0;
            this.bt_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Sua.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Sua.ForeColor = System.Drawing.Color.White;
            this.bt_Sua.Image = global::btl_QLBanHang.Properties.Resources.editnew;
            this.bt_Sua.Location = new System.Drawing.Point(291, 233);
            this.bt_Sua.Name = "bt_Sua";
            this.bt_Sua.Size = new System.Drawing.Size(123, 33);
            this.bt_Sua.TabIndex = 45;
            this.bt_Sua.Text = " Sửa";
            this.bt_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Sua.TextColor = System.Drawing.Color.White;
            this.bt_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Sua.UseVisualStyleBackColor = false;
            // 
            // bt_Them
            // 
            this.bt_Them.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Them.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.bt_Them.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Them.BorderRadius = 20;
            this.bt_Them.BorderSize = 2;
            this.bt_Them.FlatAppearance.BorderSize = 0;
            this.bt_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Them.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Them.ForeColor = System.Drawing.Color.White;
            this.bt_Them.Image = global::btl_QLBanHang.Properties.Resources.addnewwww;
            this.bt_Them.Location = new System.Drawing.Point(162, 231);
            this.bt_Them.Name = "bt_Them";
            this.bt_Them.Size = new System.Drawing.Size(123, 36);
            this.bt_Them.TabIndex = 44;
            this.bt_Them.Text = " Thêm";
            this.bt_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Them.TextColor = System.Drawing.Color.White;
            this.bt_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Them.UseVisualStyleBackColor = false;
            // 
            // cb_MauSac
            // 
            this.cb_MauSac.FormattingEnabled = true;
            this.cb_MauSac.Location = new System.Drawing.Point(567, 120);
            this.cb_MauSac.Name = "cb_MauSac";
            this.cb_MauSac.Size = new System.Drawing.Size(139, 21);
            this.cb_MauSac.TabIndex = 43;
            // 
            // cb_Size
            // 
            this.cb_Size.FormattingEnabled = true;
            this.cb_Size.Location = new System.Drawing.Point(331, 120);
            this.cb_Size.Name = "cb_Size";
            this.cb_Size.Size = new System.Drawing.Size(139, 21);
            this.cb_Size.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(500, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Màu sắc:";
            // 
            // cb_KM
            // 
            this.cb_KM.FormattingEnabled = true;
            this.cb_KM.Location = new System.Drawing.Point(585, 90);
            this.cb_KM.Name = "cb_KM";
            this.cb_KM.Size = new System.Drawing.Size(58, 21);
            this.cb_KM.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(641, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Khuyến mãi:";
            // 
            // cb_NCC
            // 
            this.cb_NCC.FormattingEnabled = true;
            this.cb_NCC.Location = new System.Drawing.Point(550, 30);
            this.cb_NCC.Name = "cb_NCC";
            this.cb_NCC.Size = new System.Drawing.Size(150, 21);
            this.cb_NCC.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Nhà cung cấp:";
            // 
            // tb_MoTa
            // 
            this.tb_MoTa.Location = new System.Drawing.Point(33, 171);
            this.tb_MoTa.Margin = new System.Windows.Forms.Padding(2);
            this.tb_MoTa.Multiline = true;
            this.tb_MoTa.Name = "tb_MoTa";
            this.tb_MoTa.Size = new System.Drawing.Size(667, 58);
            this.tb_MoTa.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Mô tả sản phẩm:";
            // 
            // picSanpham
            // 
            this.picSanpham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picSanpham.Location = new System.Drawing.Point(737, 21);
            this.picSanpham.Name = "picSanpham";
            this.picSanpham.Size = new System.Drawing.Size(167, 164);
            this.picSanpham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSanpham.TabIndex = 0;
            this.picSanpham.TabStop = false;
            // 
            // error_ThongTin
            // 
            this.error_ThongTin.ContainerControl = this;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_ThongTinSP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Name = "SanPham";
            this.Text = "Sản phẩm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanpham)).EndInit();
            this.gb_ThongTinSP.ResumeLayout(false);
            this.gb_ThongTinSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_ThongTin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_ChatLieu;
        private System.Windows.Forms.TextBox tb_SLuong;
        private System.Windows.Forms.TextBox tb_DGB;
        private System.Windows.Forms.TextBox tb_DGN;
        private System.Windows.Forms.TextBox tb_MaSP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_TenSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSanpham;
        private System.Windows.Forms.GroupBox gb_ThongTinSP;
        private System.Windows.Forms.DataGridView dgvSanpham;
        private System.Windows.Forms.TextBox tb_MoTa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider error_ThongTin;
        private System.Windows.Forms.ComboBox cb_NCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_KM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_MauSac;
        private System.Windows.Forms.ComboBox cb_Size;
        private Classes.CustomButton.MyButton bt_Xoa;
        private Classes.CustomButton.MyButton bt_Sua;
        private Classes.CustomButton.MyButton bt_Them;
        private Classes.CustomButton.MyButton bt_Huy;
        private Classes.CustomButton.MyButton bt_TimKiem;
        private Classes.CustomButton.MyButton bt_excel;
        private Classes.CustomButton.MyButton bt_Anh;
    }
}