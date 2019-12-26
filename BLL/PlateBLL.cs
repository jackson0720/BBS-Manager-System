using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PlateBLL
    {
        public List<Model.Plate> GetPlate()
        {
            return new DAL.PlateDAL().GetPlate();

        }

        public int CountPlate()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Plate");
        }
    }
}
