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

        public bool insertAlumnoAndMaterias(string connString, string nombre, string apellido, short edad, string documento,List<long> colIdMaterias)
        {

            try
            {
                SqlConnection context = new SqlConnection(connString);

                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;

                    cm.CommandText = "INSERT INTO Alumno (nombre, apellido , edad , documento) Values (@nom,@ap,@edad,@doc) SELECT SCOPE_IDENTITY()";
                    cm.Parameters.Add("@nom", SqlDbType.VarChar);
                    cm.Parameters.Add("@ap", SqlDbType.VarChar);
                    cm.Parameters.Add("@edad", SqlDbType.SmallInt);
                    cm.Parameters.Add("@doc", SqlDbType.VarChar);

                    cm.Parameters["@nom"].Value = nombre;
                    cm.Parameters["@ap"].Value = apellido;
                    cm.Parameters["@edad"].Value = edad;
                    cm.Parameters["@doc"].Value = documento;

                    int idAlumno = Convert.ToInt32(cm.ExecuteScalar());

                    cm.Parameters.Add("@idAl", SqlDbType.Int).Value = idAlumno;
                    cm.Parameters.Add("@idMat", SqlDbType.Int);
                    foreach (int idMateria in colIdMaterias)
                    {
                        cm.Parameters["@idMat"].Value = idMateria;
                        cm.CommandText = "INSERT INTO AlumnoMateria (idAlumno,idMateria) Values (@idAl,@idMat)";
                        cm.ExecuteNonQuery();


                    }

                    cm.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
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
                    SqlDataReader re = cm.ExecuteReader(CommandBehavior.SingleRow);


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

        public string updateAlumnoById(string connString, long idAlumno,string documento, string nombre, short edad, string apellido)
        {
           

            try
            {
                SqlConnection context = new SqlConnection(connString);

                using (context)
                {
                    context.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = context;

                    cm.CommandText = "Update Alumno SET nombre = @nom,apellido = @ap,edad = @edad,documento = @doc  Where idAlumno = @id";
                    cm.Parameters.Add("@doc", SqlDbType.VarChar).Value = documento ;
                    cm.Parameters.Add("@nom", SqlDbType.VarChar).Value = nombre;
                    cm.Parameters.Add("@ap", SqlDbType.VarChar).Value = apellido;
                    cm.Parameters.Add("@edad", SqlDbType.SmallInt).Value = edad;
                    cm.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;

                    cm.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                return null;

            }


            return "Alumno actualizado con exito";



        }

        public string eliminarAlumnoById(string connString,long idAlumno)
        {
                try
                {
                    SqlConnection context = new SqlConnection(connString);

                    using (context)
                    {
                        context.Open();

                        SqlCommand cm = new SqlCommand();
                        cm.Connection = context;

                        cm.CommandText = "Delete  from Alumno Where idAlumno = @id";
                        
                        cm.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;

                        cm.ExecuteNonQuery();

                    }

                }
                catch (Exception ex)
                {
                    return null;

                }


                return "Alumno borradp con exito";






        }



    }


}
