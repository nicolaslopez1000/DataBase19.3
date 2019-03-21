
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
            List<long> colMaterias = new List<long>{ 1, 2, 3 };

            string resultado = AH.insertarAlumnoAndMateriaHelper(connection,"Nico","Capó",17,"5.100.100-0",colMaterias);

            Console.WriteLine(resultado);
            
            List<Alumno> colAlumos = AH.listarAlumnoHelper(connection);

            foreach (Alumno al in colAlumos)
            {

                Console.WriteLine(al.ToString());

            }

            Console.WriteLine("Ingrese el documento");
            string resultado1 = AH.eliminarAlumnoById(connection,long.Parse(Console.ReadLine()));
            Console.WriteLine(resultado1);


            /*Console.WriteLine("Ingrese el documento");
            Alumno alumn =AH.getAlumnoByDocHelper(connection,Console.ReadLine());
            Console.WriteLine(alumn.ToString());*/
            /*
            AH.editarAlumnoById(connection, 1, "carlos", "lacalle", "123456789", 80);

            Console.WriteLine();

            Console.ReadKey();
            */


            colAlumos = AH.listarAlumnoHelper(connection);

            foreach (Alumno al in colAlumos)
            {

                Console.WriteLine(al.ToString());

            }
            Console.ReadKey();

        }


    }
}
