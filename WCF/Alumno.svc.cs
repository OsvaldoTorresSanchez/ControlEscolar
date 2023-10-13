using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Materia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Materia.svc or Materia.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public WCF.Result GetAll()
        {

            ML.Result result = BL.Alumno.GetAllSP();

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result GetById(int alumno)
        {
            ML.Result result = BL.Alumno.GetByIdSP(alumno);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddSP(alumno);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result UpdateEF(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.UpdateSP(alumno);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result DeleteEF(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.DeleteSP(alumno);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }
    }
}
