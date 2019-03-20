
using BusinessEntity;
using BusinessLogic;
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

            AlumnoHelper AH = new AlumnoHelper();

            string resultado = AH.insertarAlumnoHelper(connection,"Nico","López",17,"5.150.533-0");

            Console.WriteLine(resultado);
            
            List<Alumno> colAlumos = AH.listarAlumnoHelper(connection);

            foreach (Alumno al in colAlumos)
            {

                Console.WriteLine(al.ToString());

            }


            Console.WriteLine("Ingrese el documento");
            Alumno alumn =AH.getAlumnoByDocHelper(connection,Console.ReadLine());
            Console.WriteLine(alumn.ToString());


            Console.ReadKey();



        }


    }
}
