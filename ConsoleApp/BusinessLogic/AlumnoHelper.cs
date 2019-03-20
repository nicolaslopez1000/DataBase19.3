using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlumnoHelper
    {


        public List<Alumno> listarAlumnoHelper(string connString)
        {
            PAlumno DA = new PAlumno();
            List<Alumno> colReturn = new List<Alumno>();
            colReturn = DA.listarAlumnos(connString);

            return colReturn;

        }

        public string insertarAlumnoHelper(string connString, string nombre, string apellido, short edad, string documento)
        {

            PAlumno DA = new PAlumno();
            bool operacion = DA.insertAlumno( connString,  nombre,  apellido,  edad,  documento);
            if (operacion)
            {

                return "Alumno agregado con exito";

            }
            else
            {

                return "No se ha podido agregar el Alumno, intente denuevo más tarde";

            }

        }



    }
}
