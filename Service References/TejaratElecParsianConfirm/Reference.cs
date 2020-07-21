﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlinePayment.TejaratElecParsianConfirm {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientConfirmRequestData", Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
    [System.SerializableAttribute()]
    public partial class ClientConfirmRequestData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginAccountField;
        
        private long TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string LoginAccount {
            get {
                return this.LoginAccountField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginAccountField, value) != true)) {
                    this.LoginAccountField = value;
                    this.RaisePropertyChanged("LoginAccount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long Token {
            get {
                return this.TokenField;
            }
            set {
                if ((this.TokenField.Equals(value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientConfirmResponseData", Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
    [System.SerializableAttribute()]
    public partial class ClientConfirmResponseData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private short StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CardNumberMaskedField;
        
        private long RRNField;
        
        private long TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string CardNumberMasked {
            get {
                return this.CardNumberMaskedField;
            }
            set {
                if ((object.ReferenceEquals(this.CardNumberMaskedField, value) != true)) {
                    this.CardNumberMaskedField = value;
                    this.RaisePropertyChanged("CardNumberMasked");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public long RRN {
            get {
                return this.RRNField;
            }
            set {
                if ((this.RRNField.Equals(value) != true)) {
                    this.RRNField = value;
                    this.RaisePropertyChanged("RRN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public long Token {
            get {
                return this.TokenField;
            }
            set {
                if ((this.TokenField.Equals(value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService", ConfigurationName="TejaratElecParsianConfirm.ConfirmServiceSoap")]
    public interface ConfirmServiceSoap {
        
        // CODEGEN: Generating message contract since element name requestData from namespace https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService/ConfirmPayment", ReplyAction="*")]
        OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse ConfirmPayment(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService/ConfirmPayment", ReplyAction="*")]
        System.Threading.Tasks.Task<OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse> ConfirmPaymentAsync(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConfirmPaymentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ConfirmPayment", Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService", Order=0)]
        public OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequestBody Body;
        
        public ConfirmPaymentRequest() {
        }
        
        public ConfirmPaymentRequest(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
    public partial class ConfirmPaymentRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public OnlinePayment.TejaratElecParsianConfirm.ClientConfirmRequestData requestData;
        
        public ConfirmPaymentRequestBody() {
        }
        
        public ConfirmPaymentRequestBody(OnlinePayment.TejaratElecParsianConfirm.ClientConfirmRequestData requestData) {
            this.requestData = requestData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConfirmPaymentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ConfirmPaymentResponse", Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService", Order=0)]
        public OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponseBody Body;
        
        public ConfirmPaymentResponse() {
        }
        
        public ConfirmPaymentResponse(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://pec.Shaparak.ir/NewIPGServices/Confirm/ConfirmService")]
    public partial class ConfirmPaymentResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public OnlinePayment.TejaratElecParsianConfirm.ClientConfirmResponseData ConfirmPaymentResult;
        
        public ConfirmPaymentResponseBody() {
        }
        
        public ConfirmPaymentResponseBody(OnlinePayment.TejaratElecParsianConfirm.ClientConfirmResponseData ConfirmPaymentResult) {
            this.ConfirmPaymentResult = ConfirmPaymentResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConfirmServiceSoapChannel : OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConfirmServiceSoapClient : System.ServiceModel.ClientBase<OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap>, OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap {
        
        public ConfirmServiceSoapClient() {
        }
        
        public ConfirmServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConfirmServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfirmServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfirmServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap.ConfirmPayment(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest request) {
            return base.Channel.ConfirmPayment(request);
        }
        
        public OnlinePayment.TejaratElecParsianConfirm.ClientConfirmResponseData ConfirmPayment(OnlinePayment.TejaratElecParsianConfirm.ClientConfirmRequestData requestData) {
            OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest inValue = new OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest();
            inValue.Body = new OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequestBody();
            inValue.Body.requestData = requestData;
            OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse retVal = ((OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap)(this)).ConfirmPayment(inValue);
            return retVal.Body.ConfirmPaymentResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse> OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap.ConfirmPaymentAsync(OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest request) {
            return base.Channel.ConfirmPaymentAsync(request);
        }
        
        public System.Threading.Tasks.Task<OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentResponse> ConfirmPaymentAsync(OnlinePayment.TejaratElecParsianConfirm.ClientConfirmRequestData requestData) {
            OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest inValue = new OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequest();
            inValue.Body = new OnlinePayment.TejaratElecParsianConfirm.ConfirmPaymentRequestBody();
            inValue.Body.requestData = requestData;
            return ((OnlinePayment.TejaratElecParsianConfirm.ConfirmServiceSoap)(this)).ConfirmPaymentAsync(inValue);
        }
    }
}
