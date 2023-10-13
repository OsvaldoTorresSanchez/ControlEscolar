using PL2.Alumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = new List<object>();
            
            Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
             var result = empleadoClient.GetAll();
           // ML.Result result = BL.Alumno.GetAllSP();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
                //alumno.Alumnos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage; //Mandar datos a Controller hacia la vista
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = new List<object>();
            //get de Rol

            if (IdAlumno == null) // Add
            {
                return View(alumno);
            }
            else //Update
            {
                Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
                var result = empleadoClient.GetById((int)IdAlumno);
                //ML.Result result = BL.Alumno.GetByIdSP((int)IdAlumno);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    //ViewBag.Message = "Se ha actualizado correctamente el alumno";
                }

                return View(alumno); // Vacio
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if (alumno.IdAlumno == 0)
                {
                    Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
                    var result = empleadoClient.AddEF(alumno);
                    //ML.Result result = BL.Alumno.AddSP(alumno);

                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha ingresado correctamente el alumno";

                    }
                    else
                    {
                        ViewBag.Message = "no se ingresado correctemnte el alumno , Error: " + result.ErrorMessage;
                    }
                }
                else
                {
                    Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
                    var result = empleadoClient.UpdateEF(alumno);
                    //ML.Result result = BL.Alumno.UpdateSP(alumno);
                    if (result.Correct)
                    {

                        ViewBag.Message = "Se ha actualizado correctamente el alumno";

                    }
                    else
                    {
                        ViewBag.Message = "no se actualizado correctemnte el alumno , Error: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                return View(alumno);
            }
        }

        public ActionResult Delete(ML.Alumno alumno)
        {
            Alumno.AlumnosClient empleadoClient = new Alumno.AlumnosClient();
            var result = empleadoClient.DeleteEF(alumno);
            //ML.Result result = BL.Alumno.DeleteSP(alumno);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el alumno";

            }
            else
            {
                ViewBag.Message = "no se puede eliminar correctemnte el alumno , Error: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}