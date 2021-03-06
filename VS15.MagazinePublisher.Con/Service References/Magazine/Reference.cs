﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VS15.Magazine {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MagazineFault", Namespace="http://schemas.datacontract.org/2004/07/VS15")]
    [System.SerializableAttribute()]
    public partial class MagazineFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="VS15", ConfigurationName="Magazine.IMagazineService", CallbackContract=typeof(VS15.Magazine.IMagazineServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMagazineService {
        
        [System.ServiceModel.OperationContractAttribute(Action="VS15/IMagazineService/PublishMagazine", ReplyAction="VS15/IMagazineService/PublishMagazineResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(VS15.Magazine.MagazineFault), Action="http://VS15.MagazineFault", Name="MagazineFault", Namespace="http://schemas.datacontract.org/2004/07/VS15")]
        void PublishMagazine(string hyperLinkToIssue, string issueNumber, System.DateTime datePublished);
        
        [System.ServiceModel.OperationContractAttribute(Action="VS15/IMagazineService/PublishMagazine", ReplyAction="VS15/IMagazineService/PublishMagazineResponse")]
        System.Threading.Tasks.Task PublishMagazineAsync(string hyperLinkToIssue, string issueNumber, System.DateTime datePublished);
        
        [System.ServiceModel.OperationContractAttribute(Action="VS15/IMagazineService/Subscribe", ReplyAction="VS15/IMagazineService/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="VS15/IMagazineService/Subscribe", ReplyAction="VS15/IMagazineService/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="VS15/IMagazineService/Unsubscribe", ReplyAction="VS15/IMagazineService/UnsubscribeResponse")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, Action="VS15/IMagazineService/Unsubscribe", ReplyAction="VS15/IMagazineService/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMagazineServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="VS15/IMagazineService/MessageReceived", ReplyAction="VS15/IMagazineService/MessageReceivedResponse")]
        void MessageReceived(string hyperlinkToNewIssue, string issueNumber, System.DateTime datePublished);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMagazineServiceChannel : VS15.Magazine.IMagazineService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MagazineServiceClient : System.ServiceModel.DuplexClientBase<VS15.Magazine.IMagazineService>, VS15.Magazine.IMagazineService {
        
        public MagazineServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MagazineServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MagazineServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MagazineServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MagazineServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void PublishMagazine(string hyperLinkToIssue, string issueNumber, System.DateTime datePublished) {
            base.Channel.PublishMagazine(hyperLinkToIssue, issueNumber, datePublished);
        }
        
        public System.Threading.Tasks.Task PublishMagazineAsync(string hyperLinkToIssue, string issueNumber, System.DateTime datePublished) {
            return base.Channel.PublishMagazineAsync(hyperLinkToIssue, issueNumber, datePublished);
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
    }
}
