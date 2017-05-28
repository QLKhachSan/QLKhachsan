using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKhachSan.DAL;
using System.Data;


namespace QLKhachSan.BLL
{
    class BUS_Emp
    {
        SQL_Emp emp = new SQL_Emp();

        public void xoaNV(string id) {
            emp.xoaNv(id);
        }

        public DataSet timkiem(string param) {
            return emp.timkiem(param);
        }
       
        
    }
}
