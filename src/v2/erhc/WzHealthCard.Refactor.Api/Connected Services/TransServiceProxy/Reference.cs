//------------------------------------------------------------------------------
// <自动生成>
//     此代码由工具生成。
//     //
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </自动生成>
//------------------------------------------------------------------------------

namespace TransServiceProxy
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservices.vcard.health.yjcloud.com/", ConfigurationName="TransServiceProxy.TransService")]
    public interface TransService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="doService", ReplyAction="*")]
        System.Threading.Tasks.Task<TransServiceProxy.doServiceResponse> doServiceAsync(TransServiceProxy.doService request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class doService
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="doService", Namespace="http://webservices.vcard.health.yjcloud.com/", Order=0)]
        public TransServiceProxy.doServiceBody Body;
        
        public doService()
        {
        }
        
        public doService(TransServiceProxy.doServiceBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class doServiceBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HeaderInParm;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string BodyInParm;
        
        public doServiceBody()
        {
        }
        
        public doServiceBody(string HeaderInParm, string BodyInParm)
        {
            this.HeaderInParm = HeaderInParm;
            this.BodyInParm = BodyInParm;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class doServiceResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="doServiceResponse", Namespace="http://webservices.vcard.health.yjcloud.com/", Order=0)]
        public TransServiceProxy.doServiceResponseBody Body;
        
        public doServiceResponse()
        {
        }
        
        public doServiceResponse(TransServiceProxy.doServiceResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class doServiceResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MsgOutParm;
        
        public doServiceResponseBody()
        {
        }
        
        public doServiceResponseBody(string MsgOutParm)
        {
            this.MsgOutParm = MsgOutParm;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface TransServiceChannel : TransServiceProxy.TransService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class TransServiceClient : System.ServiceModel.ClientBase<TransServiceProxy.TransService>, TransServiceProxy.TransService
    {
        
    /// <summary>
    /// 实现此分部方法，配置服务终结点。
    /// </summary>
    /// <param name="serviceEndpoint">要配置的终结点</param>
    /// <param name="clientCredentials">客户端凭据</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TransServiceClient() : 
                base(TransServiceClient.GetDefaultBinding(), TransServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.TransServiceImplPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TransServiceClient.GetBindingForEndpoint(endpointConfiguration), TransServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TransServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TransServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TransServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TransServiceProxy.doServiceResponse> TransServiceProxy.TransService.doServiceAsync(TransServiceProxy.doService request)
        {
            return base.Channel.doServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<TransServiceProxy.doServiceResponse> doServiceAsync(string HeaderInParm, string BodyInParm)
        {
            TransServiceProxy.doService inValue = new TransServiceProxy.doService();
            inValue.Body = new TransServiceProxy.doServiceBody();
            inValue.Body.HeaderInParm = HeaderInParm;
            inValue.Body.BodyInParm = BodyInParm;
            return ((TransServiceProxy.TransService)(this)).doServiceAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TransServiceImplPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TransServiceImplPort))
            {
                return new System.ServiceModel.EndpointAddress("http://ws.test.bechangedt.com:9080/ERHC/TransService");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TransServiceClient.GetBindingForEndpoint(EndpointConfiguration.TransServiceImplPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TransServiceClient.GetEndpointAddress(EndpointConfiguration.TransServiceImplPort);
        }
        
        public enum EndpointConfiguration
        {
            
            TransServiceImplPort,
        }
    }
}
