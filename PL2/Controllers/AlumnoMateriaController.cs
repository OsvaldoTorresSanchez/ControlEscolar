using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL2.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        string URLApi = System.Configuration.ConfigurationManager.AppSettings["Url"];
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult AlumnoGetAll()
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
        public ActionResult GetAlMateriaAsignadasByIdAlumno(int? IdAlumno)
        {
            ML.AsignarMateria asignar = new ML.AsignarMateria();
            asignar.AsignarMaterias = new List<object>();

            //Para mostar el nombre de los alumnos
            ML.Result resultPuesto = BL.Alumno.GetByIdSP(IdAlumno.Value);
            asignar.Alumno = new ML.Alumno();
            asignar.Alumno.Alumnos = resultPuesto.Objects;


            ML.Result resultEmpleado = new ML.Result();
            resultEmpleado.Objects = new List<Object>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);//Base de la ruta

                var responseTask = client.GetAsync("getbyalumno/" + IdAlumno);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.AsignarMateria resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.AsignarMateria>(resultItem.ToString());
                        resultEmpleado.Objects.Add(resultItemList);
                        asignar.AsignarMaterias = resultEmpleado.Objects;
                    }
                    Session["IdAlumno"] = IdAlumno;
                }
                else
                {
                    ViewBag.Message = resultEmpleado.ErrorMessage;
                }
            }

            return View(asignar);
        }

        [HttpGet]
        public ActionResult GetAlMateriaNoAsignadasByIdAlumno()
        {
            var IdAlumno = Session["IdAlumno"];
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();
            //asignar.Materia = new ML.Materia();
            //ML.Result resultEmpresa = BL.Materia.GetAllEF();
            //asignar.Materia.Materias = resultEmpresa.Objects;

            ML.Result resultEmpleado = new ML.Result();
            resultEmpleado.Objects = new List<Object>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);//Base de la ruta

                var responseTask = client.GetAsync("getbymateria/" + IdAlumno);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultEmpleado.Objects.Add(resultItemList);
                        materia.Materias = resultEmpleado.Objects;
                    }
                }
                else
                {
                    ViewBag.Message = resultEmpleado.ErrorMessage;
                }
            }

            return View(materia);
        }

        
        public ActionResult DeleteMateriasAsignadas(List<int> MateriasSeleccionar)
        {
            ML.AsignarMateria asignar = new ML.AsignarMateria();
            asignar.AsignarMaterias = new List<object>();
            //asignar.Materia = new ML.Materia();
            //ML.Result resultEmpresa = BL.Materia.GetAllEF();
            //asignar.Materia.Materias = resultEmpresa.Objects;

            ML.Result resultEmpleado = new ML.Result();
            resultEmpleado.Objects = new List<Object>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);

                var responseTask = client.PostAsJsonAsync("deletemateria",  MateriasSeleccionar);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente la materia";
                }
                else
                {
                    ViewBag.Message = "no se puede eliminar correctemnte la materia , Error: ";
                }
            }

            return PartialView("Modal");
        }


        public ActionResult AsignarMateriasAsignadas(List<int> MateriasAsignadas)
        {
            var IdAlumno = Session["IdAlumno"];
            ML.AsignarMateria asignar = new ML.AsignarMateria();
            asignar.AsignarMaterias = new List<object>();

            ML.Result resultEmpleado = new ML.Result();
            resultEmpleado.Objects = new List<Object>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);

                var responseTask = client.PostAsJsonAsync("asignarmateria/" + IdAlumno , MateriasAsignadas);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente la materia";
                }
                else
                {
                    ViewBag.Message = "no se puede eliminar correctemnte la materia , Error: ";
                }
            }

            return PartialView("Modal");
        }

    }
}