using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Drawing;
using System.Windows.Forms;

namespace QLBH.Classes
{
     class ConnectData
    {

        string strConnect = @"Data Source=DESKTOP-HU50TNN\SQLEXPRESS;Initial Catalog=BTL_BanQuanAo;Integrated Security=True";
        public static SqlConnection sqlConn = null;
        //PT OpenConnect de mo ket noi 
        void OpenConnect()
        {
            sqlConn = new SqlConnection(strConnect);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
        //PT CloseConnect để đóng kết nối
        void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }

        //PT thực hiện truy vấn dữ liệu trả về DataTable su dung DataAdapter
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConn);
            sqlData.Fill(dt);
            CloseConnect();
            sqlData.Dispose();
            return dt;
        }
        //PT thực hiện thay đổi dữ liệu insert, update, delete dung SqlCommand
        public void ChangeData(string sql)
        {
            OpenConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = sql;
            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
        public SqlDataReader ReaderLogin(string sqlSelect)
        {
            OpenConnect();
            SqlCommand sqlcommand = new SqlCommand(sqlSelect, sqlConn);
            SqlDataReader dt = sqlcommand.ExecuteReader();
            return dt;
            CloseConnect();
            sqlcommand.Dispose();
        }

        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            DataTable table = new DataTable();
            
            SqlDataAdapter dap = new SqlDataAdapter(sql, sqlConn);
            
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
            
        }





    }
   
    class staticdata
    {
        public static string userName = "";
        public static string LinkAvt = "";
        public static string TenNV = "";
        public static string To;
        public static string gt;
        public static string MaHDN = "";
        public static string MaHDB = "";
        public static int check = 1;
    }
}
