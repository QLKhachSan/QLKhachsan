using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKhachSan.DLL;
using QLKhachSan.Entities;
namespace QLKhachSan.DAL
{
       public class SQL_tblUser
    {
        KetNoiDB kn = new KetNoiDB();

        public int CheckLogin(string id, string pass) {
            return (int)kn.GetValue(@"select count(*) from account where Username = '" + id + "' and Password = '" + pass + "'");
        }
    }
}
