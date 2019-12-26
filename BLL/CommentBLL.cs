using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CommentBLL
    {

        public List<Model.Comment> ListCommentsByCid(string cid)
        {
            return new DAL.CommentDAL().ListCommentsByCid(cid);
        }

        public int DelCommentByCno(int state, int cno)
        {
            int i = SQLHelp.ExecQuery("update comment set c_state = "+state+" where c_no = '"+cno+"'");
            return i;
        }

        public List<Model.Comment> ListComment()
        {
            return new DAL.CommentDAL().ListComment();

        }

        public int CountComment()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Comment");
        }
    }
}
