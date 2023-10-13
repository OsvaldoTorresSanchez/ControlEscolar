using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMateria" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        WCF.Result GetById(int IdAlumno);

        [OperationContract]
        WCF.Result AddEF(ML.Alumno alumno);

        [OperationContract]
        WCF.Result UpdateEF(ML.Alumno alumno);

        [OperationContract]
        WCF.Result DeleteEF(ML.Alumno  alumno);
    }
}
