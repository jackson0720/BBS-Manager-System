using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserGroupDAL
    {

        public int UpdateStateByUcode(int state,string ucode)
        {
            int i = SQLHelp.ExecQuery("update usertype set utype_state = '" + state + "' where utype_code = '" + ucode + "'");
            return i;
        }


        public Model.UserGroup GetUserGroupByUid(string uid)
        {
            Model.UserGroup ug = new Model.UserGroup();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from usertype where utype_code = '" + uid + "'");

                if (dr != null)
                {
                    if (dr.Read())
                        ug.Utype_code = (int)dr["utype_code"];
                        ug.Utype_name = dr["utype_name"] as string;
                        ug.Utype_desc = dr["utype_desc"] as string;
                        ug.Utype_remark = dr["utype_remark"] as string;
                        ug.Utype_state = (int)dr["utype_state"];
                        dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return ug;
        }


        public List<Model.UserGroup> ListUserGroup()
        {
            List<Model.UserGroup> userGroups = new List<Model.UserGroup>();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from usertype");

                if (dr != null)
                {
                    while (dr.Read())
                        userGroups.Add(new Model.UserGroup() { Utype_code = (int)dr["utype_code"],Utype_name = dr["utype_name"] as string,Utype_desc = dr["utype_desc"] as string,Utype_remark = dr["utype_remark"] as string,Utype_state = (int)dr["utype_state"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return userGroups;
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from usertype");
        }

    }
}
