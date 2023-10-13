using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL2.Controllers
{
    public class MateriaController : Controller
    {
        string URLApi = System.Configuration.ConfigurationManager.AppSettings["Url"];
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);

                var responseTask = client.GetAsync("getall");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        materia.Materias.Add(resultItemList);
                    }
                }
            }
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == null) // Add
            {
                return View(materia);
            }
            else //Update
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(URLApi);
                        var responseTask = client.GetAsync("getbyid/" + IdMateria);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            materia = (ML.Materia)result.Object;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla materia";

                        }

                    }

                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }
                return View(materia); // Vacio
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {

            bool reultNombre = ValidarNombre(materia.Nombre);

            if (!reultNombre)
            {
                if (materia.IdMateria == 0) // ADD
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(URLApi);

                        var postTask = client.PostAsJsonAsync<ML.Materia>("Add", materia);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se ha ingresado correctamente la materia";
                        }
                        else
                        {
                            ViewBag.Message = "no se ingresado correctemnte la materia , Error: " + result.StatusCode;
                        }
                    }
                }
                else // UPDATE
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(URLApi);

                        //HTTP POST
                        var postTask = client.PutAsJsonAsync<ML.Materia>("update", materia);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se ha actualizado correctamente la materia";
                        }
                        else
                        {
                            ViewBag.Message = "no se actualizado correctemnte la materia , Error: " + result.StatusCode;
                        }
                    }
                }
            }
            else
            {
                ViewBag.Message = "El nombre de la materia tiene un caracter invalido ";
            }
            return PartialView("Modal");
        }

        public bool ValidarNombre(string Nombre )
        {
            ML.Result result = new ML.Result();
            string palabrasNoAceptadas = System.Configuration.ConfigurationManager.AppSettings["ValoresNoPermitidos"];

            foreach (var name in Nombre)
            {
                foreach (var palabras in palabrasNoAceptadas)
                {
                    if (name == palabras)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puede intertar la materia";
                    }
                }
            }
           
            return true;
        }

        public ActionResult Delete(ML.Materia materia)
        {

            int id = materia.IdMateria;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLApi);

                //HTTP POST
                var postTask = client.DeleteAsync("delete/" + id);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente la materia";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ViewBag.Message = "no se puede eliminar correctemnte la materia , Error: ";
                }
            }
            return View("Modal");
        }



    }
}