using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liceo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            PAlumno pa = new PAlumno();

            pa.insertAlumno(connection);

        }
    }
}
