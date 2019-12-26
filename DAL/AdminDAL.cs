using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {

        public int AddAdmin(Model.Admin admin)
        {
            return SQLHelp.ExecQuery("insert into admin(a_uid,a_account,a_pwd,a_name) values('"+GuidHelper.GetNewGuId().ToUpper()+"','"+admin.A_account+"','"+admin.A_pwd+"','"+admin.A_name+"')");

        }

        public int ChangeAdminStateByAid(int state,string Aid)
        {
            return SQLHelp.ExecQuery("update admin set a_state = '" + state + "' where a_uid = '" + Aid + "'");
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Admin");
        }



        public List<Model.Admin> ListAdmins()
        {
            List<Model.Admin> admins = new List<Model.Admin>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from Admin");

                if (dr != null)
                {
                    while (dr.Read())
                        admins.Add(new Model.Admin() { A_uid = dr["a_uid"] as string,A_account = dr["a_account"] as string,A_name = dr["a_name"] as string,A_state = (int)dr["a_state"]  });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return admins;
        }


        public Model.Admin Login(Model.Admin amin)
        {
            Model.Admin admin = new Model.Admin();

            if (SQLHelp.OpenConnection())
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@name", amin.A_account);
                parm[1] = new SqlParameter("@pwd", amin.A_pwd);
                parm[2] = new SqlParameter("@msg", "");
                parm[2].Direction = System.Data.ParameterDirection.Output;
                SqlDataReader dr = SQLHelp.ExecReader("p_SelectAdminByNameAndPwd", System.Data.CommandType.StoredProcedure, parm);

                string msg = parm[2].Value as string;

                if (dr != null)
                {
                    while (dr.Read())
                        return new Model.Admin() { A_uid = dr["a_uid"] as string, A_account = dr["a_account"] as string, A_pwd = msg as string, A_name = dr["a_name"] as string, A_state = Convert.ToInt32(dr["a_state"]) };
                }
                //admin.A_pwd = "错误";
                dr.Close();

                SQLHelp.CloseConnection();
            }
            return admin;
        }
    }

}
