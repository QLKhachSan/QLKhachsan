using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKhachSan.DLL;
using System.Data;
using System.Data.SqlClient;
namespace QLKhachSan.DAL
{
    public class SQL_Main
    {
        KetNoiDB kn = new KetNoiDB();
        string sql  = @"Select urlImage,idEmp,B.tennhanvien,B.ngaysinh,B.chucvu from account left join nhanvien B on manhanvien= IdEmp where IdEmp = '";
        public DataSet  main(string id) {
            DataSet ds = new DataSet();
            ds = kn.GetDataSet(sql + id +"'","emp");
            return ds;
       }
    }
}
