namespace btl_QLBanHang.FormBTL.SanPham
{
    partial class TimKiemSP
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MaSP = new System.Windows.Forms.TextBox();
            this.tb_TenSP = new System.Windows.Forms.TextBox();
            this.tb_KM_Min = new System.Windows.Forms.TextBox();
            this.tb_SL_Min = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_SL_Max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_KM_Max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_DGN_Max = new System.Windows.Forms.TextBox();
            this.tb_DGN_Min = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_DGB_Max = new System.Windows.Forms.TextBox();
            this.tb_DGB_Min = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_ChatLieu = new System.Windows.Forms.ComboBox();
            this.cb_NCC = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.errTim = new System.Windows.Forms.ErrorProvider(this.components);
            this.cb_MauSac = new System.Windows.Forms.ComboBox();
            this.cb_Size = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bt_TimKiem = new btl_QLBanHang.Classes.CustomButton.MyButton();
            this.bt_Huy = new btl_QLBanHang.Classes.CustomButton.MyButton();
            ((System.ComponentModel.ISupportInitialize)(this.errTim)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên SP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã SP:";
            // 
            // tb_MaSP
            // 
            this.tb_MaSP.Location = new System.Drawing.Point(64, 22);
            this.tb_MaSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_MaSP.Name = "tb_MaSP";
            this.tb_MaSP.Size = new System.Drawing.Size(76, 20);
            this.tb_MaSP.TabIndex = 3;
            // 
            // tb_TenSP
            // 
            this.tb_TenSP.Location = new System.Drawing.Point(211, 22);
            this.tb_TenSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_TenSP.Name = "tb_TenSP";
            this.tb_TenSP.Size = new System.Drawing.Size(151, 20);
            this.tb_TenSP.TabIndex = 5;
            // 
            // tb_KM_Min
            // 
            this.tb_KM_Min.Location = new System.Drawing.Point(268, 67);
            this.tb_KM_Min.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_KM_Min.Name = "tb_KM_Min";
            this.tb_KM_Min.Size = new System.Drawing.Size(24, 20);
            this.tb_KM_Min.TabIndex = 9;
            this.tb_KM_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // tb_SL_Min
            // 
            this.tb_SL_Min.Location = new System.Drawing.Point(76, 67);
            this.tb_SL_Min.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_SL_Min.Name = "tb_SL_Min";
            this.tb_SL_Min.Size = new System.Drawing.Size(46, 20);
            this.tb_SL_Min.TabIndex = 7;
            this.tb_SL_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Khuyến mãi:";
            // 
            // tb_SL_Max
            // 
            this.tb_SL_Max.Location = new System.Drawing.Point(138, 67);
            this.tb_SL_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_SL_Max.Name = "tb_SL_Max";
            this.tb_SL_Max.Size = new System.Drawing.Size(46, 20);
            this.tb_SL_Max.TabIndex = 10;
            this.tb_SL_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(125, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "-";
            // 
            // tb_KM_Max
            // 
            this.tb_KM_Max.Location = new System.Drawing.Point(308, 67);
            this.tb_KM_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_KM_Max.Name = "tb_KM_Max";
            this.tb_KM_Max.Size = new System.Drawing.Size(24, 20);
            this.tb_KM_Max.TabIndex = 13;
            this.tb_KM_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(293, 67);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(191, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "-";
            // 
            // tb_DGN_Max
            // 
            this.tb_DGN_Max.Location = new System.Drawing.Point(207, 89);
            this.tb_DGN_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_DGN_Max.Name = "tb_DGN_Max";
            this.tb_DGN_Max.Size = new System.Drawing.Size(91, 20);
            this.tb_DGN_Max.TabIndex = 21;
            this.tb_DGN_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // tb_DGN_Min
            // 
            this.tb_DGN_Min.Location = new System.Drawing.Point(97, 89);
            this.tb_DGN_Min.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_DGN_Min.Name = "tb_DGN_Min";
            this.tb_DGN_Min.Size = new System.Drawing.Size(91, 20);
            this.tb_DGN_Min.TabIndex = 18;
            this.tb_DGN_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 92);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Đơn giá nhập:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(192, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "-";
            // 
            // tb_DGB_Max
            // 
            this.tb_DGB_Max.Location = new System.Drawing.Point(207, 112);
            this.tb_DGB_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_DGB_Max.Name = "tb_DGB_Max";
            this.tb_DGB_Max.Size = new System.Drawing.Size(91, 20);
            this.tb_DGB_Max.TabIndex = 25;
            this.tb_DGB_Max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // tb_DGB_Min
            // 
            this.tb_DGB_Min.Location = new System.Drawing.Point(98, 112);
            this.tb_DGB_Min.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_DGB_Min.Name = "tb_DGB_Min";
            this.tb_DGB_Min.Size = new System.Drawing.Size(91, 20);
            this.tb_DGB_Min.TabIndex = 24;
            this.tb_DGB_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntOnly);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Đơn giá Bán:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 137);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Chất liệu:";
            // 
            // cb_ChatLieu
            // 
            this.cb_ChatLieu.FormattingEnabled = true;
            this.cb_ChatLieu.Location = new System.Drawing.Point(74, 135);
            this.cb_ChatLieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_ChatLieu.Name = "cb_ChatLieu";
            this.cb_ChatLieu.Size = new System.Drawing.Size(95, 21);
            this.cb_ChatLieu.TabIndex = 28;
            // 
            // cb_NCC
            // 
            this.cb_NCC.FormattingEnabled = true;
            this.cb_NCC.Location = new System.Drawing.Point(268, 135);
            this.cb_NCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_NCC.Name = "cb_NCC";
            this.cb_NCC.Size = new System.Drawing.Size(95, 21);
            this.cb_NCC.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 137);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Nhà cung cấp:";
            // 
            // errTim
            // 
            this.errTim.ContainerControl = this;
            // 
            // cb_MauSac
            // 
            this.cb_MauSac.FormattingEnabled = true;
            this.cb_MauSac.Location = new System.Drawing.Point(245, 44);
            this.cb_MauSac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_MauSac.Name = "cb_MauSac";
            this.cb_MauSac.Size = new System.Drawing.Size(105, 21);
            this.cb_MauSac.TabIndex = 47;
            // 
            // cb_Size
            // 
            this.cb_Size.FormattingEnabled = true;
            this.cb_Size.Location = new System.Drawing.Point(68, 44);
            this.cb_Size.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_Size.Name = "cb_Size";
            this.cb_Size.Size = new System.Drawing.Size(105, 21);
            this.cb_Size.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(195, 46);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Màu sắc:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 46);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Kích cỡ:";
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
            this.bt_TimKiem.Location = new System.Drawing.Point(46, 184);
            this.bt_TimKiem.Name = "bt_TimKiem";
            this.bt_TimKiem.Size = new System.Drawing.Size(123, 35);
            this.bt_TimKiem.TabIndex = 49;
            this.bt_TimKiem.Text = " Tìm Kiếm";
            this.bt_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_TimKiem.TextColor = System.Drawing.Color.White;
            this.bt_TimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_TimKiem.UseVisualStyleBackColor = false;
            this.bt_TimKiem.Click += new System.EventHandler(this.bt_TimKiem_Click);
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
            this.bt_Huy.Image = global::btl_QLBanHang.Properties.Resources.cancelnew;
            this.bt_Huy.Location = new System.Drawing.Point(198, 183);
            this.bt_Huy.Name = "bt_Huy";
            this.bt_Huy.Size = new System.Drawing.Size(123, 37);
            this.bt_Huy.TabIndex = 50;
            this.bt_Huy.Text = " Hủy";
            this.bt_Huy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Huy.TextColor = System.Drawing.Color.White;
            this.bt_Huy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Huy.UseVisualStyleBackColor = false;
            this.bt_Huy.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // TimKiemSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(387, 232);
            this.Controls.Add(this.bt_Huy);
            this.Controls.Add(this.bt_TimKiem);
            this.Controls.Add(this.cb_MauSac);
            this.Controls.Add(this.cb_Size);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cb_NCC);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_ChatLieu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_DGB_Max);
            this.Controls.Add(this.tb_DGB_Min);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_DGN_Max);
            this.Controls.Add(this.tb_DGN_Min);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_KM_Max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_SL_Max);
            this.Controls.Add(this.tb_KM_Min);
            this.Controls.Add(this.tb_SL_Min);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_TenSP);
            this.Controls.Add(this.tb_MaSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TimKiemSP";
            this.Text = "Tìm kiếm sản phẩm";
            this.Load += new System.EventHandler(this.TimKiemSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errTim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MaSP;
        private System.Windows.Forms.TextBox tb_TenSP;
        private System.Windows.Forms.TextBox tb_KM_Min;
        private System.Windows.Forms.TextBox tb_SL_Min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_SL_Max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_KM_Max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_DGN_Max;
        private System.Windows.Forms.TextBox tb_DGN_Min;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_DGB_Max;
        private System.Windows.Forms.TextBox tb_DGB_Min;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_ChatLieu;
        private System.Windows.Forms.ComboBox cb_NCC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errTim;
        private System.Windows.Forms.ComboBox cb_MauSac;
        private System.Windows.Forms.ComboBox cb_Size;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Classes.CustomButton.MyButton bt_TimKiem;
        private Classes.CustomButton.MyButton bt_Huy;
    }
}