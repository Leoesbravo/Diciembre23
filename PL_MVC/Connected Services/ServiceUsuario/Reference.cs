﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceUsuario {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Usuario))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Direccion))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Colonia))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Colonia[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Municipio))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Estado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Estado[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Pais))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Pais[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Municipio[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Rol))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Rol[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Usuario[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultadoField;
        
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
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensaje {
            get {
                return this.MensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeField, value) != true)) {
                    this.MensajeField = value;
                    this.RaisePropertyChanged("Mensaje");
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
        public bool Resultado {
            get {
                return this.ResultadoField;
            }
            set {
                if ((this.ResultadoField.Equals(value) != true)) {
                    this.ResultadoField = value;
                    this.RaisePropertyChanged("Resultado");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUsuario.IServiceUsuario")]
    public interface IServiceUsuario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/Add", ReplyAction="http://tempuri.org/IServiceUsuario/AddResponse")]
        PL_MVC.ServiceUsuario.Result Add(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/Add", ReplyAction="http://tempuri.org/IServiceUsuario/AddResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceUsuario.Result> AddAsync(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/GetAll", ReplyAction="http://tempuri.org/IServiceUsuario/GetAllResponse")]
        PL_MVC.ServiceUsuario.Result GetAll(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUsuario/GetAll", ReplyAction="http://tempuri.org/IServiceUsuario/GetAllResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceUsuario.Result> GetAllAsync(ML.Usuario usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceUsuarioChannel : PL_MVC.ServiceUsuario.IServiceUsuario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceUsuarioClient : System.ServiceModel.ClientBase<PL_MVC.ServiceUsuario.IServiceUsuario>, PL_MVC.ServiceUsuario.IServiceUsuario {
        
        public ServiceUsuarioClient() {
        }
        
        public ServiceUsuarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceUsuarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUsuarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUsuarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL_MVC.ServiceUsuario.Result Add(ML.Usuario usuario) {
            return base.Channel.Add(usuario);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceUsuario.Result> AddAsync(ML.Usuario usuario) {
            return base.Channel.AddAsync(usuario);
        }
        
        public PL_MVC.ServiceUsuario.Result GetAll(ML.Usuario usuario) {
            return base.Channel.GetAll(usuario);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceUsuario.Result> GetAllAsync(ML.Usuario usuario) {
            return base.Channel.GetAllAsync(usuario);
        }
    }
}
