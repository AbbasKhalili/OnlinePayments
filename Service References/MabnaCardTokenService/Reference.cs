﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlinePayment.MabnaCardTokenService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://token.ws.web.cnpg/", ConfigurationName="MabnaCardTokenService.TokenService")]
    public interface TokenService {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://token.ws.web.cnpg/TokenService/reservationRequest", ReplyAction="http://token.ws.web.cnpg/TokenService/reservationResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OnlinePayment.MabnaCardTokenService.reservationResponse reservation(OnlinePayment.MabnaCardTokenService.reservationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://token.ws.web.cnpg/TokenService/reservationRequest", ReplyAction="http://token.ws.web.cnpg/TokenService/reservationResponse")]
        System.Threading.Tasks.Task<OnlinePayment.MabnaCardTokenService.reservationResponse> reservationAsync(OnlinePayment.MabnaCardTokenService.reservationRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://token.ws.web.cnpg/")]
    public partial class tokenDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string aMOUNTField;
        
        private string cRNField;
        
        private string mIDField;
        
        private string rEFERALADRESSField;
        
        private string sIGNATUREField;
        
        private string tIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string AMOUNT {
            get {
                return this.aMOUNTField;
            }
            set {
                this.aMOUNTField = value;
                this.RaisePropertyChanged("AMOUNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string CRN {
            get {
                return this.cRNField;
            }
            set {
                this.cRNField = value;
                this.RaisePropertyChanged("CRN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string MID {
            get {
                return this.mIDField;
            }
            set {
                this.mIDField = value;
                this.RaisePropertyChanged("MID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string REFERALADRESS {
            get {
                return this.rEFERALADRESSField;
            }
            set {
                this.rEFERALADRESSField = value;
                this.RaisePropertyChanged("REFERALADRESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string SIGNATURE {
            get {
                return this.sIGNATUREField;
            }
            set {
                this.sIGNATUREField = value;
                this.RaisePropertyChanged("SIGNATURE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string TID {
            get {
                return this.tIDField;
            }
            set {
                this.tIDField = value;
                this.RaisePropertyChanged("TID");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://token.ws.web.cnpg/")]
    public partial class tokenResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int resultField;
        
        private string signatureField;
        
        private string tokenField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string signature {
            get {
                return this.signatureField;
            }
            set {
                this.signatureField = value;
                this.RaisePropertyChanged("signature");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string token {
            get {
                return this.tokenField;
            }
            set {
                this.tokenField = value;
                this.RaisePropertyChanged("token");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="reservation", WrapperNamespace="http://token.ws.web.cnpg/", IsWrapped=true)]
    public partial class reservationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://token.ws.web.cnpg/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OnlinePayment.MabnaCardTokenService.tokenDTO Token_param;
        
        public reservationRequest() {
        }
        
        public reservationRequest(OnlinePayment.MabnaCardTokenService.tokenDTO Token_param) {
            this.Token_param = Token_param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="reservationResponse", WrapperNamespace="http://token.ws.web.cnpg/", IsWrapped=true)]
    public partial class reservationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://token.ws.web.cnpg/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OnlinePayment.MabnaCardTokenService.tokenResponse @return;
        
        public reservationResponse() {
        }
        
        public reservationResponse(OnlinePayment.MabnaCardTokenService.tokenResponse @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TokenServiceChannel : OnlinePayment.MabnaCardTokenService.TokenService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TokenServiceClient : System.ServiceModel.ClientBase<OnlinePayment.MabnaCardTokenService.TokenService>, OnlinePayment.MabnaCardTokenService.TokenService {
        
        public TokenServiceClient() {
        }
        
        public TokenServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TokenServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OnlinePayment.MabnaCardTokenService.reservationResponse OnlinePayment.MabnaCardTokenService.TokenService.reservation(OnlinePayment.MabnaCardTokenService.reservationRequest request) {
            return base.Channel.reservation(request);
        }
        
        public OnlinePayment.MabnaCardTokenService.tokenResponse reservation(OnlinePayment.MabnaCardTokenService.tokenDTO Token_param) {
            OnlinePayment.MabnaCardTokenService.reservationRequest inValue = new OnlinePayment.MabnaCardTokenService.reservationRequest();
            inValue.Token_param = Token_param;
            OnlinePayment.MabnaCardTokenService.reservationResponse retVal = ((OnlinePayment.MabnaCardTokenService.TokenService)(this)).reservation(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OnlinePayment.MabnaCardTokenService.reservationResponse> OnlinePayment.MabnaCardTokenService.TokenService.reservationAsync(OnlinePayment.MabnaCardTokenService.reservationRequest request) {
            return base.Channel.reservationAsync(request);
        }
        
        public System.Threading.Tasks.Task<OnlinePayment.MabnaCardTokenService.reservationResponse> reservationAsync(OnlinePayment.MabnaCardTokenService.tokenDTO Token_param) {
            OnlinePayment.MabnaCardTokenService.reservationRequest inValue = new OnlinePayment.MabnaCardTokenService.reservationRequest();
            inValue.Token_param = Token_param;
            return ((OnlinePayment.MabnaCardTokenService.TokenService)(this)).reservationAsync(inValue);
        }
    }
}
