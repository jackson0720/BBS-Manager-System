using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PostsBLL
    {

        public Model.Posts GetPostsByPid(string pid)
        {
            return new DAL.PostsDAL().GetPostsByPid(pid);
        }

        public int DelPostsByPid(int state, string pid)
        {
            string sql = "update posts set p_state = '" + state + "' where p_id = " + pid;
            return SQLHelp.ExecQuery(sql);
        }

        public Model.Posts GetPostsTextByPid(string pid)
        {
            return new DAL.PostsDAL().GetPostsTextByPid(pid);
        }

        public List<Model.Posts> GetPosts()
        {
            return new DAL.PostsDAL().GetPosts();
            
        }

        public int CountPosts()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Posts");
        }
    }
}
