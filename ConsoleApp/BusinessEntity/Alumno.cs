using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Alumno
    {

        #region Propiedades
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private short edad;

        public short Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public Alumno(string nombre, string apellido, short edad, string documento,long idAlumno )
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.documento = documento;
            this.idAlumno = idAlumno;
        }

        private long idAlumno;

        public long IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        #endregion


        public override string ToString()
        {
            return "idAlumno: "+this.idAlumno.ToString()+ "  Nombre:" +this.nombre+ "  Apellido :" + this.apellido+"  Edad: "+ this.edad.ToString() +"  Documento: "+ this.documento;
        }
    }
}
