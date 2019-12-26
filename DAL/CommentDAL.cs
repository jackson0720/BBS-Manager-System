using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentDAL
    {

        public List<Model.Comment> ListCommentsByCid(string cid)
        {
            List<Model.Comment> cmt = new List<Model.Comment>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from comment where c_cid = '"+cid+"'");

                if (dr != null)
                {
                    while (dr.Read())
                        cmt.Add(new Model.Comment() { C_no = (int)dr["c_no"], C_cid = dr["c_cid"] as string, C_text = dr["c_text"] as string, C_caccount = dr["c_caccount"] as string, C_ctime = (DateTime)dr["c_ctime"], C_state = (int)dr["c_state"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return cmt;
        }

        public int DelCommentByCno(int state, int cno)
        {
            int i = SQLHelp.ExecQuery("update comment set c_state = " + state + " where c_no = '" + cno + "'");
            return i;
        }

        public List<Model.Comment> ListComment()
        {
            List<Model.Comment> cmt = new List<Model.Comment>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from comment order by c_ctime desc");

                if (dr != null)
                {
                    while (dr.Read())
                        cmt.Add(new Model.Comment() { C_no = (int)dr["c_no"],C_cid = dr["c_cid"] as string,C_text = dr["c_text"] as string,C_caccount = dr["c_caccount"] as string, C_ctime = (DateTime)dr["c_ctime"],C_state = (int)dr["c_state"]});

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return cmt;
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Comment");
        }

    }
}
