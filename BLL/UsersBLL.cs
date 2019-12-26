using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersBLL
    {

        public Model.Users GetUsers(string uid)
        {
            return new DAL.UsersDAL().GetUsers(uid);
        }

        public int UpdateStateByUid(int state, string uid)
        {
            return SQLHelp.ExecQuery("update [user] set u_state = '" + state + "' where u_uid = '" + uid + "'");

        }

        public Model.Users GetUserByUid(string account)
        {
            Model.Users user = new DAL.UsersDAL().GetUserByUid(account);
            return user;
        }

        public List<Model.Users> ListUsers()
        {
            return new DAL.UsersDAL().ListUsers();
        }

        public int CountUser()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from UserInfo");
        }

    }
}
