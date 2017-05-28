using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKhachSan.DAL;


namespace QLKhachSan.BLL
{
     class BUS_tblUser
    {
        SQL_tblUser username = new SQL_tblUser();
        
        public int CheckLogin(string user, string pass) {
             return (int)username.CheckLogin(user, pass);
         }
    }
}
