﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", ConfigurationName="ServiceReference.EnterpriseDataExchange_1_0_1_1PortType")]
    public interface EnterpriseDataExchange_1_0_1_1PortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:Ping", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PingResponse> PingAsync(ServiceReference.PingRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:TestConnection", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.TestConnectionResponse> TestConnectionAsync(ServiceReference.TestConnectionRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:PrepareDataForGetting", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PrepareDataForGettingResponse> PrepareDataForGettingAsync(ServiceReference.PrepareDataForGettingRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:PrepareDataActionResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PrepareDataActionResultResponse> PrepareDataActionResultAsync(ServiceReference.PrepareDataActionResultRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:GetDataPart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.GetDataPartResponse> GetDataPartAsync(ServiceReference.GetDataPartRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:ConfirmGettingFile", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.ConfirmGettingFileResponse> ConfirmGettingFileAsync(ServiceReference.ConfirmGettingFileRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:PutFilePart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PutFilePartResponse> PutFilePartAsync(ServiceReference.PutFilePartRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:PutData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PutDataResponse> PutDataAsync(ServiceReference.PutDataRequest request);
        
        // CODEGEN: Создается контракт сообщения, так как операция имеет много возвращаемых значений.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1#EnterpriseDataExchange_1_0_1_" +
            "1:PutDataActionResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.PutDataActionResultResponse> PutDataActionResultAsync(ServiceReference.PutDataActionResultRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Ping", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PingRequest
    {
        
        public PingRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PingResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PingResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public PingResponse()
        {
        }
        
        public PingResponse(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TestConnection", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class TestConnectionRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string ExchangePlanName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        public string PeerCode;
        
        public TestConnectionRequest()
        {
        }
        
        public TestConnectionRequest(string ExchangePlanName, string PeerCode)
        {
            this.ExchangePlanName = ExchangePlanName;
            this.PeerCode = PeerCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TestConnectionResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class TestConnectionResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public bool @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public TestConnectionResponse()
        {
        }
        
        public TestConnectionResponse(bool @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PrepareDataForGetting", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PrepareDataForGettingRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string ExchangePlanName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        public string PeerCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=2)]
        public decimal PartSize;
        
        public PrepareDataForGettingRequest()
        {
        }
        
        public PrepareDataForGettingRequest(string ExchangePlanName, string PeerCode, decimal PartSize)
        {
            this.ExchangePlanName = ExchangePlanName;
            this.PeerCode = PeerCode;
            this.PartSize = PartSize;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PrepareDataForGettingResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PrepareDataForGettingResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OperationID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public PrepareDataForGettingResponse()
        {
        }
        
        public PrepareDataForGettingResponse(string @return, string OperationID, string ErrorMessage)
        {
            this.@return = @return;
            this.OperationID = OperationID;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://v8.1c.ru/SSL/Exchange/EnterpriseDataExchange")]
    public partial class PrepareDataOperationResult
    {
        
        private string errorMessageField;
        
        private string fileIDField;
        
        private int partCountField;
        
        private bool partCountFieldSpecified;
        
        private string statusField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ErrorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FileID
        {
            get
            {
                return this.fileIDField;
            }
            set
            {
                this.fileIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PartCount
        {
            get
            {
                return this.partCountField;
            }
            set
            {
                this.partCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartCountSpecified
        {
            get
            {
                return this.partCountFieldSpecified;
            }
            set
            {
                this.partCountFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=4)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PrepareDataActionResult", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PrepareDataActionResultRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string OperationID;
        
        public PrepareDataActionResultRequest()
        {
        }
        
        public PrepareDataActionResultRequest(string OperationID)
        {
            this.OperationID = OperationID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PrepareDataActionResultResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PrepareDataActionResultResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public ServiceReference.PrepareDataOperationResult @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public PrepareDataActionResultResponse()
        {
        }
        
        public PrepareDataActionResultResponse(ServiceReference.PrepareDataOperationResult @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataPart", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class GetDataPartRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string FileID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        public int PartNumber;
        
        public GetDataPartRequest()
        {
        }
        
        public GetDataPartRequest(string FileID, int PartNumber)
        {
            this.FileID = FileID;
            this.PartNumber = PartNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataPartResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class GetDataPartResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", IsNullable=true)]
        public byte[] @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public GetDataPartResponse()
        {
        }
        
        public GetDataPartResponse(byte[] @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmGettingFile", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class ConfirmGettingFileRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string FileID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        public bool ClearDataPool;
        
        public ConfirmGettingFileRequest()
        {
        }
        
        public ConfirmGettingFileRequest(string FileID, bool ClearDataPool)
        {
            this.FileID = FileID;
            this.ClearDataPool = ClearDataPool;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmGettingFileResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class ConfirmGettingFileResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public ConfirmGettingFileResponse()
        {
        }
        
        public ConfirmGettingFileResponse(string @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutFilePart", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutFilePartRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string FileID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> PartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] PartData;
        
        public PutFilePartRequest()
        {
        }
        
        public PutFilePartRequest(string FileID, System.Nullable<int> PartNumber, byte[] PartData)
        {
            this.FileID = FileID;
            this.PartNumber = PartNumber;
            this.PartData = PartData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutFilePartResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutFilePartResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public PutFilePartResponse()
        {
        }
        
        public PutFilePartResponse(string @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutData", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutDataRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string ExchangePlanName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        public string PeerCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=2)]
        public string FileID;
        
        public PutDataRequest()
        {
        }
        
        public PutDataRequest(string ExchangePlanName, string PeerCode, string FileID)
        {
            this.ExchangePlanName = ExchangePlanName;
            this.PeerCode = PeerCode;
            this.FileID = FileID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutDataResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutDataResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OperationID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public PutDataResponse()
        {
        }
        
        public PutDataResponse(string @return, string OperationID, string ErrorMessage)
        {
            this.@return = @return;
            this.OperationID = OperationID;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutDataActionResult", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutDataActionResultRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string OperationID;
        
        public PutDataActionResultRequest()
        {
        }
        
        public PutDataActionResultRequest(string OperationID)
        {
            this.OperationID = OperationID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PutDataActionResultResponse", WrapperNamespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", IsWrapped=true)]
    public partial class PutDataActionResultResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=0)]
        public string @return;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.1c.ru/SSL/EnterpriseDataExchange_1_0_1_1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ErrorMessage;
        
        public PutDataActionResultResponse()
        {
        }
        
        public PutDataActionResultResponse(string @return, string ErrorMessage)
        {
            this.@return = @return;
            this.ErrorMessage = ErrorMessage;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    public interface EnterpriseDataExchange_1_0_1_1PortTypeChannel : ServiceReference.EnterpriseDataExchange_1_0_1_1PortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    public partial class EnterpriseDataExchange_1_0_1_1PortTypeClient : System.ServiceModel.ClientBase<ServiceReference.EnterpriseDataExchange_1_0_1_1PortType>, ServiceReference.EnterpriseDataExchange_1_0_1_1PortType
    {
        
        /// <summary>
        /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
        /// </summary>
        /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
        /// <param name="clientCredentials">Учетные данные клиента.</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public EnterpriseDataExchange_1_0_1_1PortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(EnterpriseDataExchange_1_0_1_1PortTypeClient.GetBindingForEndpoint(endpointConfiguration), EnterpriseDataExchange_1_0_1_1PortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EnterpriseDataExchange_1_0_1_1PortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(EnterpriseDataExchange_1_0_1_1PortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EnterpriseDataExchange_1_0_1_1PortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(EnterpriseDataExchange_1_0_1_1PortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EnterpriseDataExchange_1_0_1_1PortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.PingResponse> ServiceReference.EnterpriseDataExchange_1_0_1_1PortType.PingAsync(ServiceReference.PingRequest request)
        {
            return base.Channel.PingAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PingResponse> PingAsync()
        {
            ServiceReference.PingRequest inValue = new ServiceReference.PingRequest();
            return ((ServiceReference.EnterpriseDataExchange_1_0_1_1PortType)(this)).PingAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.TestConnectionResponse> TestConnectionAsync(ServiceReference.TestConnectionRequest request)
        {
            return base.Channel.TestConnectionAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PrepareDataForGettingResponse> PrepareDataForGettingAsync(ServiceReference.PrepareDataForGettingRequest request)
        {
            return base.Channel.PrepareDataForGettingAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PrepareDataActionResultResponse> PrepareDataActionResultAsync(ServiceReference.PrepareDataActionResultRequest request)
        {
            return base.Channel.PrepareDataActionResultAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.GetDataPartResponse> GetDataPartAsync(ServiceReference.GetDataPartRequest request)
        {
            return base.Channel.GetDataPartAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.ConfirmGettingFileResponse> ConfirmGettingFileAsync(ServiceReference.ConfirmGettingFileRequest request)
        {
            return base.Channel.ConfirmGettingFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PutFilePartResponse> PutFilePartAsync(ServiceReference.PutFilePartRequest request)
        {
            return base.Channel.PutFilePartAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PutDataResponse> PutDataAsync(ServiceReference.PutDataRequest request)
        {
            return base.Channel.PutDataAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.PutDataActionResultResponse> PutDataActionResultAsync(ServiceReference.PutDataActionResultRequest request)
        {
            return base.Channel.PutDataActionResultAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        #if !NET6_0_OR_GREATER
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        #endif
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.EnterpriseDataExchange_1_0_1_1Soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.EnterpriseDataExchange_1_0_1_1Soap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.EnterpriseDataExchange_1_0_1_1Soap))
            {
                return new System.ServiceModel.EndpointAddress("http://inf-3cserver.office.custis.ru/ERPUH/ws/EnterpriseDataExchange_1_0_1_1.1cws" +
                        "");
            }
            if ((endpointConfiguration == EndpointConfiguration.EnterpriseDataExchange_1_0_1_1Soap12))
            {
                return new System.ServiceModel.EndpointAddress("http://inf-3cserver.office.custis.ru/ERPUH/ws/EnterpriseDataExchange_1_0_1_1.1cws" +
                        "");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            EnterpriseDataExchange_1_0_1_1Soap,
            
            EnterpriseDataExchange_1_0_1_1Soap12,
        }
    }
}
