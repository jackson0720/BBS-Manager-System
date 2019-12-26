using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PortBLL
    {

        public int UpdateStateAndSuccessByPid(int state, int success, string pid)
        {
            int i = new DAL.PortDAL().UpdateStateAndSuccessByPid(state, success, pid);
            return i;
        }

        public Model.Port GetPortByPid(string pid)
        {
            return new DAL.PortDAL().GetPortByPid(pid);
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select Count(*) from Port");
        }

        public List<Model.Port> ListPort()
        {
            return new DAL.PortDAL().ListPort();
        }
    }
}
