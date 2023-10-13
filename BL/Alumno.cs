using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetByIdSP(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    // SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "EXEC UsuariosGetById @IdUsuario";

                    SqlCommand cmd = new SqlCommand("AlumnoGetById ", context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAlumno", IdAlumno);
                    cmd.Connection = context;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        DataRow row = tabla.Rows[0];

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = int.Parse(row[0].ToString());
                        alumno.Nombre = row[1].ToString();
                        alumno.ApellidoPaterno = row[2].ToString();
                        alumno.ApellidoMaterno = row[3].ToString();

                        result.Object = alumno;

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    // SqlCommand cmd = new SqlCommand("EXEC UsuariosGetAll", conn);
                    //cmd.Connection = conn;

                    SqlCommand cmd = new SqlCommand("AlumnoGetAll ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        // foreach (var lista in tabla.Rows) // En caso que no se conosca un valor 
                        foreach (DataRow row in tabla.Rows)
                        {

                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            result.Objects.Add(alumno);

                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //Opcion 1
                    //SqlCommand cmd = new SqlCommand("EXEC UsuarioAdd @UserName,@Nombre,@ApellidoPaterno, @ApellidoMaterno,@Email,@Password,@Sexo,@Telefono,@Celular,@FechaNacimiento,@CURP", conn);

                    //Opcion 1 Recomendable
                    SqlCommand cmd = new SqlCommand("AlumnoAdd ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al insertar el alumno " + alumno.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result UpdateSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("EXEC UsuarioUpdate @IdUsuario, @UserName,@Nombre,@ApellidoPaterno, @ApellidoMaterno,@Email,@Password,@Sexo,@Telefono,@Celular,@FechaNacimiento,@CURP", conn);

                    SqlCommand cmd = new SqlCommand("AlumnoUpdate ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAlumno", alumno.IdAlumno);
                    cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al acualizar el alumno " + alumno.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result DeleteSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("exec UsuarioDelete  @IdUsuario", conn)

                    SqlCommand cmd = new SqlCommand("AlumnoDelete ", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAlumno", alumno.IdAlumno);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al elimino el alumno " + alumno.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
