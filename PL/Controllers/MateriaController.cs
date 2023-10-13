using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62286/api/materia/");

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

            //get de Rol
            ML.Result resultEmpresas = BL.Materia.GetAllEF();

            if (IdMateria == null) // Add
            {
                return View(materia);
            }
            else //Update
            {
                ML.Result result = BL.Materia.GetByIdEF((int)IdMateria);

                ML.Result results = new ML.Result();

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:62286/api/materia/");
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
            if (materia.IdMateria == 0) // ADD
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62286/api/materia/");

                    //HTTP POST
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
                    client.BaseAddress = new Uri("http://localhost:62286/api/materia/");

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
            return PartialView("Modal");
        }

        public ActionResult Delete(ML.Materia materia)
        {

            int id = materia.IdMateria;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62286/api/materia/");

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