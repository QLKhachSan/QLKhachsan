using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKhachSan.DAL;
using System.Data;
namespace QLKhachSan.BLL
{
    class BUS_Main
    {
        SQL_Main user = new SQL_Main();
        public DataSet inf(string id) {
            return user.main(id);
            
        }
    }
}
