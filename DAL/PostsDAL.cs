using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PostsDAL
    {

        public Model.Posts GetPostsByPid(string pid)
        {
            Model.Posts posts = new Model.Posts();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from posts where p_id = '" + pid + "'");

                if (dr != null)
                {
                    if (dr.Read())
                        posts.P_id = dr["p_id"] as string;
                        posts.P_theme = dr["p_theme"] as string;
                        posts.P_time = (DateTime)dr["p_time"];
                        posts.P_account = dr["p_account"] as string;
                        posts.P_nick = dr["p_nick"] as string;
                        posts.P_text = dr["p_text"] as string;
                        posts.P_good = (int)dr["p_good"];
                        posts.P_view = (int)dr["p_view"];
                        posts.P_state = (int)dr["p_state"];
                    //users.Add( { U_uid = dr["u_uid"] as string, U_account = dr["u_account"] as string, U_email = dr["u_email"] as string, U_ip = dr["u_ip"] as string, U_state = (int)dr["u_state"], U_regtime = (DateTime)dr["u_regtime"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return posts;
        }

        public int DelPostsByPid(int state,string pid)
        {
            string sql = "update posts set p_state = '"+state+"' where p_id = "+pid;
            return SQLHelp.ExecQuery(sql);
        }

        public Model.Posts GetPostsTextByPid(string pid)
        {
            Model.Posts posts = new Model.Posts();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from posts where p_id = '" + pid + "'");

                if (dr != null)
                {
                    if (dr.Read())
                        posts.P_text = dr["p_text"] as string;
                    //users.Add( { U_uid = dr["u_uid"] as string, U_account = dr["u_account"] as string, U_email = dr["u_email"] as string, U_ip = dr["u_ip"] as string, U_state = (int)dr["u_state"], U_regtime = (DateTime)dr["u_regtime"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return posts;
        }

        public int CountPosts()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Posts");
        }

        public List<Model.Posts> GetPosts()
        {
            List<Model.Posts> books = new List<Model.Posts>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from posts p,plate pl where p.p_plate = pl.p_no order by p.p_view desc");

                if (dr != null)
                {
                    while (dr.Read())
                        books.Add(new Model.Posts() { P_id = dr["p_id"] as string,P_theme = dr["p_theme"] as string,P_time = (DateTime)dr["p_time"],P_account = dr["p_account"] as string,P_nick = dr["p_nick"] as string,P_text = dr["p_text"] as string,P_good = (int)dr["p_good"],P_view = (int)dr["p_view"], P_platename = dr["p_name"] as string,P_state = (int)dr["p_state"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return books;
        }
    }
}
