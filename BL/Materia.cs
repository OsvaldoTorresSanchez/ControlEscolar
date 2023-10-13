using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var resultQuery = context.MateriaGetAll().ToList();


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = (decimal)obj.Costo;

                            result.Objects.Add(materia);
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

        public static ML.Result GetByIdEF(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var obj = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre;
                        materia.Costo = (decimal)obj.Costo;

                        result.Object = materia;
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

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var resultQuery = context.MateriaAdd(materia.Nombre, materia.Costo);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puede añadir la materia " + materia.Nombre;
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


        public static ML.Result UpdateEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var updateResult = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó la materia" + materia.Nombre;
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


        public static ML.Result DeleteEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var updateResult = context.MateriaDelete(materia.IdMateria);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al elimino el materia " + materia.Nombre;
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
