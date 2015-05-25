using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop
{
    class Connector
    {
        private SqlConnection _conn;

        public void MoKetNoi()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(@"ChuoiKetNoi");
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }
            }
        }

        public void DongKetNoi()
        {
            if ((_conn != null) && (_conn.State == ConnectionState.Open))
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
        
        
        // Trả về một DataTable .
        public DataTable getDataTable(string sql)
        {

            MoKetNoi();

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DongKetNoi();

            return dt;

        }

        // Thực thi câu lệnh truy vấn insert,delete,update
        public void ExecuteNonQuery(string sql)
        {

            MoKetNoi();

            SqlCommand cmd = new SqlCommand(sql, _conn);

            cmd.ExecuteNonQuery();

            DongKetNoi();

        }

        // Trả về DataReader
        public SqlDataReader getDataReader(string sql)
        {

            MoKetNoi();

            SqlCommand com = new SqlCommand(sql, _conn);

            SqlDataReader dr = com.ExecuteReader();
            DongKetNoi();

            return dr;

        }
    }

}
