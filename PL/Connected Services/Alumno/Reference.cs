﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.Alumno {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Alumno))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception exField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception ex {
            get {
                return this.exField;
            }
            set {
                if ((object.ReferenceEquals(this.exField, value) != true)) {
                    this.exField = value;
                    this.RaisePropertyChanged("ex");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Alumno.IAlumnos")]
    public interface IAlumnos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetAll", ReplyAction="http://tempuri.org/IAlumnos/GetAllResponse")]
        PL.Alumno.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetAll", ReplyAction="http://tempuri.org/IAlumnos/GetAllResponse")]
        System.Threading.Tasks.Task<PL.Alumno.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetById", ReplyAction="http://tempuri.org/IAlumnos/GetByIdResponse")]
        PL.Alumno.Result GetById(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/GetById", ReplyAction="http://tempuri.org/IAlumnos/GetByIdResponse")]
        System.Threading.Tasks.Task<PL.Alumno.Result> GetByIdAsync(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/AddEF", ReplyAction="http://tempuri.org/IAlumnos/AddEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.Alumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.Alumno.Result AddEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/AddEF", ReplyAction="http://tempuri.org/IAlumnos/AddEFResponse")]
        System.Threading.Tasks.Task<PL.Alumno.Result> AddEFAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/UpdateEF", ReplyAction="http://tempuri.org/IAlumnos/UpdateEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.Alumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.Alumno.Result UpdateEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/UpdateEF", ReplyAction="http://tempuri.org/IAlumnos/UpdateEFResponse")]
        System.Threading.Tasks.Task<PL.Alumno.Result> UpdateEFAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/DeleteEF", ReplyAction="http://tempuri.org/IAlumnos/DeleteEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.Alumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL.Alumno.Result DeleteEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnos/DeleteEF", ReplyAction="http://tempuri.org/IAlumnos/DeleteEFResponse")]
        System.Threading.Tasks.Task<PL.Alumno.Result> DeleteEFAsync(ML.Alumno alumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnosChannel : PL.Alumno.IAlumnos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnosClient : System.ServiceModel.ClientBase<PL.Alumno.IAlumnos>, PL.Alumno.IAlumnos {
        
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
        
        public PL.Alumno.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<PL.Alumno.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public PL.Alumno.Result GetById(int IdAlumno) {
            return base.Channel.GetById(IdAlumno);
        }
        
        public System.Threading.Tasks.Task<PL.Alumno.Result> GetByIdAsync(int IdAlumno) {
            return base.Channel.GetByIdAsync(IdAlumno);
        }
        
        public PL.Alumno.Result AddEF(ML.Alumno alumno) {
            return base.Channel.AddEF(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.Alumno.Result> AddEFAsync(ML.Alumno alumno) {
            return base.Channel.AddEFAsync(alumno);
        }
        
        public PL.Alumno.Result UpdateEF(ML.Alumno alumno) {
            return base.Channel.UpdateEF(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.Alumno.Result> UpdateEFAsync(ML.Alumno alumno) {
            return base.Channel.UpdateEFAsync(alumno);
        }
        
        public PL.Alumno.Result DeleteEF(ML.Alumno alumno) {
            return base.Channel.DeleteEF(alumno);
        }
        
        public System.Threading.Tasks.Task<PL.Alumno.Result> DeleteEFAsync(ML.Alumno alumno) {
            return base.Channel.DeleteEFAsync(alumno);
        }
    }
}