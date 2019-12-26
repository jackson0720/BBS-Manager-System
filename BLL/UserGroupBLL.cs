using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserGroupBLL
    {

        public int UpdateStateByUcode(int state, string ucode)
        {
            int i = new DAL.UserGroupDAL().UpdateStateByUcode(state, ucode);
            return i;
        }

        public Model.UserGroup GetUserGroupByUid(string uid)
        {
            return new DAL.UserGroupDAL().GetUserGroupByUid(uid);
        }

        public List<Model.UserGroup> ListUserGroup()
        {
            return new DAL.UserGroupDAL().ListUserGroup();
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from usertype");
        }

    }
}
