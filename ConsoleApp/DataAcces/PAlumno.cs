using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PAlumno
    {
        public bool insertAlumno(string connString)
        {

            try { 
            SqlConnection context = new SqlConnection(connString);

            using (context)
            {
                context.Open();
                string nombre = "Pepe";
                string apellido = "Loco";
                short edad = 1;
                string documento = "5.150.533-0";
                SqlCommand cm = new SqlCommand();
                    cm.Connection = context;

                    cm.CommandText = "INSERT INTO Alumno (nombre, apellido , edad , documento) Values (@nom,@ap,@edad,@doc)";
                    cm.Parameters.Add("@nom", SqlDbType.VarChar);
                    cm.Parameters.Add("@ap", SqlDbType.VarChar);
                    cm.Parameters.Add("@edad", SqlDbType.SmallInt);
                    cm.Parameters.Add("@doc", SqlDbType.VarChar);

                    cm.Parameters["@nom"].Value = nombre;
                    cm.Parameters["@ap"].Value = apellido;
                    cm.Parameters["@edad"].Value = edad;
                    cm.Parameters["@doc"].Value = documento;

                    cm.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                return false;

            }
            
            
                return true;
        }


    }
}
