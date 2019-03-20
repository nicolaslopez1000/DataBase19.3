using BusinessEntity;
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
        public bool insertAlumno(string connString, string nombre, string apellido, short edad, string documento)
        {

            try { 
            SqlConnection context = new SqlConnection(connString);

                using (context)
                {
                    context.Open();
                   
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


        public List<Alumno> listarAlumnos(string connString)
        {
            List<Alumno> colAlumnos = new List<Alumno>();

            try
            {
                SqlConnection context = new SqlConnection(connString);

                using (context)
                {
                    context.Open();
                    
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;

                    cm.CommandText = "Select idAlumno,nombre,apellido,edad,documento from Alumno";
                  
                    SqlDataReader re = cm.ExecuteReader();

                    
                    if (re.HasRows)
                    {
                        while (re.Read())
                        {
                            
                            int idUnAlumno = re.GetInt32(0);
                            string nombreUnAlumno = re.GetString(1);
                            string apellidoUnAlumno = re.GetString(2);
                            short edadUnAlumno = re.GetInt16(3);
                            string documentoUnAlumno = re.GetString(4);


                            Alumno al = new Alumno(nombreUnAlumno, apellidoUnAlumno, edadUnAlumno, documentoUnAlumno, idUnAlumno);
                            colAlumnos.Add(al);

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                return null;

            }


            return colAlumnos;

        }


        public Alumno getAlumnoByDoc(string connString, string documento)
        {
            Alumno al = null;

            try
            {
                SqlConnection context = new SqlConnection(connString);

                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;

                    cm.CommandText = "Select idAlumno,nombre,apellido,edad,documento from Alumno Where documento = @doc";
                    cm.Parameters.Add("@doc", SqlDbType.VarChar);
                    cm.Parameters["@doc"].Value = documento;
                    SqlDataReader re = cm.ExecuteReader();


                    if (re.HasRows)
                    {
                        while (re.Read())
                        {

                            int idUnAlumno = re.GetInt32(0);
                            string nombreUnAlumno = re.GetString(1);
                            string apellidoUnAlumno = re.GetString(2);
                            short edadUnAlumno = re.GetInt16(3);
                            string documentoUnAlumno = re.GetString(4);


                             al = new Alumno(nombreUnAlumno, apellidoUnAlumno, edadUnAlumno, documentoUnAlumno, idUnAlumno);
                            

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                return null;

            }


            return al;

        


    }
    }
}
