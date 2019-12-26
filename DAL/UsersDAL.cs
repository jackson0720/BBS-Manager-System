using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDAL
    {

        public Model.Users GetUsers(string uid)
        {
            Model.Users users = new Model.Users();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from [user] u,userinfo ui,usertype ut where u.u_uid = ui.u_uid and ui.u_code = ut.utype_code and u.u_uid = '"+uid+"'");

                if (dr != null)
                {
                    if (dr.Read())
                        users.U_uid = dr["u_uid"] as string;
                        users.U_account = dr["u_account"] as string;
                        users.U_email = dr["u_email"] as string;
                        users.U_ip = dr["u_ip"] as string;
                        users.U_codename = dr["utype_name"] as string;
                        users.U_birthday = (DateTime)dr["u_birthday"];
                        users.U_dev = dr["u_dev"] as string;
                        users.U_idcard = dr["u_idcard"] as string;
                        users.U_points = (int)dr["u_points"];
                        users.U_name = dr["u_name"] as string;
                        users.U_regtime = (DateTime)dr["u_regtime"];
                        users.U_sex = dr["u_sex"] as string;

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return users;
        }

        public int UpdateStateByUid(int state,string uid)
        {
            return SQLHelp.ExecQuery("update [user] set u_state = '"+state+"' where u_uid = '"+uid+"'");

        }

        public Model.Users GetUserByUid(string account)
        {
            Model.Users users = new Model.Users();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from [user] u,userinfo ui,usertype ut where ui.u_code = ut.utype_code and u.u_uid = ui.u_uid and u.u_state = 0 and u_account = '"+account+"'");

                if (dr != null)
                {
                    if (dr.Read())
                    users.U_uid = dr["u_uid"] as string;
                    users.U_account = dr["u_account"] as string;
                    users.U_email = dr["u_email"] as string;
                    users.U_ip = dr["u_ip"] as string;
                    users.U_state = (int)dr["u_state"];
                    users.U_name = dr["u_name"] as string;
                    users.U_codename = dr["utype_name"] as string;
                    users.U_regtime = (DateTime)dr["u_regtime"];

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return users;

        }



        public List<Model.Users> ListUsers()
        {
            List<Model.Users> users = new List<Model.Users>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from [user] u,userinfo ui,usertype ut where u.u_uid = ui.u_uid and ui.u_code = ut.utype_code");

                if (dr != null)
                {
                    while (dr.Read())
                        users.Add(new Model.Users() { U_uid = dr["u_uid"] as string, U_account = dr["u_account"] as string, U_email = dr["u_email"] as string, U_ip = dr["u_ip"] as string, U_state = (int)dr["u_state"], U_regtime = (DateTime)dr["u_regtime"],U_codename = dr["utype_name"] as string,U_name = dr["u_name"] as string,U_idcard = dr["u_idcard"] as string });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return users;
        }

        public int CountUser()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from UserInfo");
        }

    }
}
