using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;


namespace PL2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(string correo, string password)
        //{
        //    if (correo != null)
        //    {
        //        ML.Result result = BL.Login.GetByLogin(correo);

        //        if (result.Correct)
        //        {
        //            ML.Login login = (ML.Login)result.Object;

        //            if (password == login.Password)
        //            {
        //                return View("Index");
        //            }
        //            else
        //            {

        //                return View();
        //            }

        //        }
        //        return View();

        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

        [HttpPost]
        public ActionResult Login(ML.Login login)
        {
            if (login.Nombre !=null)
            {
                //Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
                //var result = empleadoClient.AddEF(alumno);
                ML.Result result = BL.Login.AddEF(login);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha ingresado correctamente el usaurio";

                }
                else
                {
                    ViewBag.Message = "no se ingresado correctemnte el usaurio , Error: " + result.ErrorMessage;
                }

                return View("Login");
            }
            else
            {

                if (login.Nombre == null)
                {
                    ML.Result result = BL.Login.GetByLogin(login.Correo);

                    if (result.Correct)
                    {
                        ML.Login logins = (ML.Login)result.Object;

                        if (login.Password == logins.Password)
                        {
                            return View("Index");
                        }
                        else
                        {

                            return View();
                        }

                    }
                    return View();

                }
                else
                {
                    return View();
                }
            }

        }

        [HttpPost]
        public ActionResult LoginAdd(ML.Login login)
        {

            if (login.IdLogin == 0)
            {
                //Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
                //var result = empleadoClient.AddEF(alumno);
                ML.Result result = BL.Login.AddEF(login);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha ingresado correctamente el usaurio";

                }
                else
                {
                    ViewBag.Message = "no se ingresado correctemnte el usaurio , Error: " + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Correo()
        {

            return View() ;

        }

        [HttpPost]
        public ActionResult Correo(string destino, string asunto, string mensaje)
        {
            try
            {


            }catch (Exception ex) 
            { 


            }

            return View();

        }
    }
}