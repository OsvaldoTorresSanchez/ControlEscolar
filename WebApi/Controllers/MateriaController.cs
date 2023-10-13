using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: api/Materia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/materia/getall")]
        public IHttpActionResult GetAll()
        {
           // ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetAllEF();

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/materia/getbyid/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetByIdEF(IdMateria);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("api/materia/add")]
        public IHttpActionResult Add(ML.Materia materia)
        {
            ML.Materia materias = new ML.Materia();
            ML.Result result = BL.Materia.AddEF(materia);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        [Route("api/materia/update")]
        public IHttpActionResult Update(ML.Materia materia)
        {
            ML.Result result = BL.Materia.UpdateEF(materia);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/materia/delete/{IdMateria}")]
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;

            ML.Result result = BL.Materia.DeleteEF(materia);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        //Para las nuevas vistas

        [HttpGet]
        [Route("api/materia/getbyalumno/{IdAlumno}")]
        public IHttpActionResult GetMateriabyidAlumno(int IdAlumno)
        {
           // ML.AsignarMateria materia = new ML.AsignarMateria();
            ML.Result result = BL.AsignarMaterias.GetAllEF(IdAlumno);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/materia/getbymateria/{IdAlumno}")]
        public IHttpActionResult GetAlumnobyidMateria(int IdAlumno)
        {
            // ML.AsignarMateria materia = new ML.AsignarMateria();
            ML.Result result = BL.AsignarMaterias.GetAllMaterias(IdAlumno);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("api/materia/asignarmateria/{IdAlumno}")]
        public IHttpActionResult AddMateriasAlumno(int IdAlumno, [FromBody] List<int> MateriasSeleccionar)
        {
            // ML.AsignarMateria materia = new ML.AsignarMateria();
            ML.Result result = BL.AsignarMaterias.AddAsignarMateria(IdAlumno, MateriasSeleccionar);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/materia/deletemateria")]
        public IHttpActionResult DeleteMateriasAlumno([FromBody]  List<int> MateriasSeleccionar)
        {
            // ML.AsignarMateria materia = new ML.AsignarMateria();
            ML.Result result = BL.AsignarMaterias.DeleteMaterias(MateriasSeleccionar);

            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

    }
}
