using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        public static ML.Result GetByLogin(string correo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var obj = context.LoginGetById(correo).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Login materia = new ML.Login();
                        materia.Correo = obj.Correo;
                        materia.Password = obj.Contrasena;

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

        public static ML.Result AddEF(ML.Login login)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.OTorresControlEscolarEntities context = new DL_EF.OTorresControlEscolarEntities())
                {
                    var resultQuery = context.LoginAdd(login.Nombre, login.Correo, login.Password);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puede añadir el usuario " + login.Nombre;
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
