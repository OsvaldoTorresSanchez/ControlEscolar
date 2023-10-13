using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AsignarMaterias
    {
        public static ML.Result GetAllEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var resultQuery = context.GetAlumnoByMateria(IdAlumno).ToList();


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.AsignarMateria asignar = new ML.AsignarMateria();
                            asignar.IdAlumnoMateria = obj.IdAlumnoMateria;
                            asignar.Materia = new ML.Materia();
                            asignar.Materia.Nombre = obj.Nombre;
                            asignar.Materia.Costo = (decimal)obj.Costo;

                            result.Objects.Add(asignar);
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

        public static ML.Result GetAllMaterias(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var resultQuery = context.GetMateriasNoAsignadas(IdAlumno).ToList();


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.Materia asignar = new ML.Materia();
                            asignar.IdMateria = obj.IdMateria;
                            asignar.Nombre = obj.Nombre;
                            asignar.Costo = (decimal)obj.Costo;

                            result.Objects.Add(asignar);
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

        public static ML.Result AddAsignarMateria(int IdAlumno, List<int> asignar)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    foreach (int idMateria in asignar)
                    {
                        var resultQuery = context.AlumnoMateriaAdd(IdAlumno,idMateria);

                        if (resultQuery > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se puede añadir la materia ";
                        }
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

        public static ML.Result DeleteMaterias(List<int> IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    foreach (int id in IdAlumno)
                    {
                        var resultQuery = context.AlumnoMateriaDelete(id);

                        if (resultQuery >= 1)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al elimino el materia ";
                        }
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
