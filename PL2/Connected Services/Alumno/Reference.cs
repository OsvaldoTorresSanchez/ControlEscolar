﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL2.Alumno {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Alumno.IAlumnos")]
    public interface IAlumnos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetAll", ReplyAction="http://tempuri.org/IAlumnos/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        WCF.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetAll", ReplyAction="http://tempuri.org/IAlumnos/GetAllResponse")]
        System.Threading.Tasks.Task<WCF.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetById", ReplyAction="http://tempuri.org/IAlumnos/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        WCF.Result GetById(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetById", ReplyAction="http://tempuri.org/IAlumnos/GetByIdResponse")]
        System.Threading.Tasks.Task<WCF.Result> GetByIdAsync(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/AddEF", ReplyAction="http://tempuri.org/IAlumnos/AddEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        WCF.Result AddEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/AddEF", ReplyAction="http://tempuri.org/IAlumnos/AddEFResponse")]
        System.Threading.Tasks.Task<WCF.Result> AddEFAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/UpdateEF", ReplyAction="http://tempuri.org/IAlumnos/UpdateEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        WCF.Result UpdateEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/UpdateEF", ReplyAction="http://tempuri.org/IAlumnos/UpdateEFResponse")]
        System.Threading.Tasks.Task<WCF.Result> UpdateEFAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/DeleteEF", ReplyAction="http://tempuri.org/IAlumnos/DeleteEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WCF.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        WCF.Result DeleteEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/DeleteEF", ReplyAction="http://tempuri.org/IAlumnos/DeleteEFResponse")]
        System.Threading.Tasks.Task<WCF.Result> DeleteEFAsync(ML.Alumno alumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnosChannel : PL2.Alumno.IAlumnos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnosClient : System.ServiceModel.ClientBase<PL2.Alumno.IAlumnos>, PL2.Alumno.IAlumnos {
        
        public AlumnosClient() {
        }
        
        public AlumnosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCF.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<WCF.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public WCF.Result GetById(int IdAlumno) {
            return base.Channel.GetById(IdAlumno);
        }
        
        public System.Threading.Tasks.Task<WCF.Result> GetByIdAsync(int IdAlumno) {
            return base.Channel.GetByIdAsync(IdAlumno);
        }
        
        public WCF.Result AddEF(ML.Alumno alumno) {
            return base.Channel.AddEF(alumno);
        }
        
        public System.Threading.Tasks.Task<WCF.Result> AddEFAsync(ML.Alumno alumno) {
            return base.Channel.AddEFAsync(alumno);
        }
        
        public WCF.Result UpdateEF(ML.Alumno alumno) {
            return base.Channel.UpdateEF(alumno);
        }
        
        public System.Threading.Tasks.Task<WCF.Result> UpdateEFAsync(ML.Alumno alumno) {
            return base.Channel.UpdateEFAsync(alumno);
        }
        
        public WCF.Result DeleteEF(ML.Alumno alumno) {
            return base.Channel.DeleteEF(alumno);
        }
        
        public System.Threading.Tasks.Task<WCF.Result> DeleteEFAsync(ML.Alumno alumno) {
            return base.Channel.DeleteEFAsync(alumno);
        }
    }
}