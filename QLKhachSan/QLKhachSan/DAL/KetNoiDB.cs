using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLKhachSan.DLL
{
     public class KetNoiDB
    {
        SqlConnection conn;
        SqlCommand cmd;

        private SqlTransaction tran = null;
        public KetNoiDB() {
            conn = new SqlConnection(@"Data Source=DUC\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True");
        }

        //Open connect
        public void Open() {
            if (conn.State == System.Data.ConnectionState.Closed) {
                conn.Open();
            }
        }
        //Close Connect
        public void Close() {
            if (conn.State == System.Data.ConnectionState.Open) {
                conn.Close();
            }
        }
        /// <summary>
        /// Đếm số cột trả về khi select
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object GetValue(string query)
        {
            Open();
            cmd = new SqlCommand(query, conn);
            return cmd.ExecuteScalar();
        }
        //Excute Query
        public void ExcuteNonQuery(string query)
        {
            Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Close();
        }
        /// <summary>
        /// Trả về 1 bảng khi select
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// 
        public DataTable GetDataTable(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet GetDataSet(string query, string dsName)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, dsName);
            return ds;
        }



        /// <summary>
        /// Thực hiện lệnh sql truyền qua Parameter
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public int doSQL(string sql, params SqlParameter[] pr)
        {
            SqlCommand command = new SqlCommand();
            int ret = 0;
            Open();

            command.Connection = conn;
            command.CommandText = sql;

            foreach (SqlParameter p in pr)
            {
                command.Parameters.Add(p);
            }
            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            return ret;
        }

        public int doStoredProceduce(string storeName, params SqlParameter[] pr) // thực hiện thủ tục lưu trữ cho các tham số tương ứng
        {
            SqlCommand cm = new SqlCommand();
            int ret = 0;
            Open();
            if (ret < 0)
            {
                return -2;
            }
            cm.Connection = conn;
            cm.CommandText = storeName;
            cm.CommandType = CommandType.StoredProcedure; // các câu lệnh sql trước mặc định là command text nên không cần phải gọi commandtype
            if (tran != null) // neu co transaction roi thi chay.
            {
                cm.Transaction = tran;
            }
            foreach (SqlParameter p in pr)
            {
                cm.Parameters.Add(p);
            }
            try
            {
                ret = cm.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                ret = -1;
            }
            return ret;
        }


        //Lay Du Lieu Theo Lenh SQL
        public int getSQL(ref DataSet ds, string tableName, string sql)
        {
            int ret = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            Open();

            command.Connection = conn;
            command.CommandText = sql;
            da.SelectCommand = command;

            try
            {
                ret = da.Fill(ds, tableName);
            }
            catch (Exception ex)
            {
                da.Dispose();
                return -1;
            }
            da.Dispose();
            return ret;
        }
    }
}
