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

        public Alumno getAlumnoByDocHelper(string connString, string documento)
        {
            PAlumno DA = new PAlumno();
            return DA.getAlumnoByDoc(connString, documento);

        }
        
        public string editarAlumnoById(string connString, long idAlumno,string nombre, string apellido,string documento, short edad)
        {


            PAlumno DA = new PAlumno();
            return DA.updateAlumnoById(connString, idAlumno,documento,nombre,edad,apellido);

        }

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

        public string insertarAlumnoAndMateriaHelper(string connString, string nombre, string apellido, short edad, string documento,List<long> colMaterias)
        {

            PAlumno DA = new PAlumno();
            bool operacion = DA.insertAlumnoAndMaterias(connString, nombre, apellido, edad, documento,colMaterias);
            if (operacion)
            {

                return "Alumno agregado con exito";

            }
            else
            {

                return "No se ha podido agregar el Alumno, intente denuevo más tarde";

            }

        }

        public string eliminarAlumnoById(string connString, long idAlumno)
        {

            PAlumno DA = new PAlumno();
            return DA.eliminarAlumnoById(connString,idAlumno);


        }


    }
}
