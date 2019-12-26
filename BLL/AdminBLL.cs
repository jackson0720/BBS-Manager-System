using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBLL
    {

        public int AddAdmin(Model.Admin admin)
        {
            return new DAL.AdminDAL().AddAdmin(admin);

        }

        public int ChangeAdminStateByAid(int state, string Aid)
        {
            return new DAL.AdminDAL().ChangeAdminStateByAid(state, Aid);
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Admin");
        }

        public List<Model.Admin> ListAdmins()
        {
            return new DAL.AdminDAL().ListAdmins();
        }


        public Model.Admin Login(Model.Admin amin)
        {
            Model.Admin admin = new DAL.AdminDAL().Login(amin);
            if (admin.A_uid == null)
            {
                return new Model.Admin() { A_uid = "", A_pwd = "用户账号不存在或密码错误！" };
            }
            admin.A_pwd = "登录成功！即将跳转到主页面！";
            return admin;
        }

    }
}
