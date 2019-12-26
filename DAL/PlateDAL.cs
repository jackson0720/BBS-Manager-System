using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlateDAL
    {
        public int CountPlate()
        {
            return (int)SQLHelp.ExecScalar("select count(*) from Plate");
        }

        public List<Model.Plate> GetPlate()
        {
            List<Model.Plate> plates = new List<Model.Plate>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from plate");

                if (dr != null)
                {
                    while (dr.Read())
                        plates.Add(new Model.Plate() { P_no = dr["p_no"] as string, P_name = dr["p_name"] as string, P_state = (int)dr["p_state"] });

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return plates;
        }
    }
}
