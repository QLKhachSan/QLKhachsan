using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKhachSan.DLL;
using System.Data;
namespace QLKhachSan.DAL
{
    public class SQL_Emp
    {
        KetNoiDB kn = new KetNoiDB();

        public void xoaNv(string id){
            try
            {
                kn.ExcuteNonQuery(@"delete from nhanvien where manhanvien ='" + id + "'");
            }
            catch {
               
            }
            }
        public DataSet timkiem(string param) {
            DataSet ds = new DataSet();
            ds = kn.GetDataSet(@"select manhanvien,tennhanvien,diachi,phone,chucvu from nhanvien where manhanvien like '%"+param +"%'", "emp");
            return ds;
        }
    }
}
