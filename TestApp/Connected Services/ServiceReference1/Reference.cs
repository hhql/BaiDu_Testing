﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebXml.com.cn/", ConfigurationName="ServiceReference1.WeatherWebServiceSoap")]
    public interface WeatherWebServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportCity", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string[]> getSupportCityAsync(string byProvinceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportProvince", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string[]> getSupportProvinceAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportDataSet", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.ArrayOfXElement> getSupportDataSetAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string[]> getWeatherbyCityNameAsync(string theCityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityNamePro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string[]> getWeatherbyCityNameProAsync(string theCityName, string theUserID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface WeatherWebServiceSoapChannel : ServiceReference1.WeatherWebServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class WeatherWebServiceSoapClient : System.ServiceModel.ClientBase<ServiceReference1.WeatherWebServiceSoap>, ServiceReference1.WeatherWebServiceSoap
    {
        
        /// <summary>
        /// 实现此分部方法，配置服务终结点。
        /// </summary>
        /// <param name="serviceEndpoint">要配置的终结点</param>
        /// <param name="clientCredentials">客户端凭据</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WeatherWebServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WeatherWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), WeatherWebServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherWebServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WeatherWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherWebServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WeatherWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WeatherWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string[]> getSupportCityAsync(string byProvinceName)
        {
            return base.Channel.getSupportCityAsync(byProvinceName);
        }
        
        public System.Threading.Tasks.Task<string[]> getSupportProvinceAsync()
        {
            return base.Channel.getSupportProvinceAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ArrayOfXElement> getSupportDataSetAsync()
        {
            return base.Channel.getSupportDataSetAsync();
        }
        
        public System.Threading.Tasks.Task<string[]> getWeatherbyCityNameAsync(string theCityName)
        {
            return base.Channel.getWeatherbyCityNameAsync(theCityName);
        }
        
        public System.Threading.Tasks.Task<string[]> getWeatherbyCityNameProAsync(string theCityName, string theUserID)
        {
            return base.Channel.getWeatherbyCityNameProAsync(theCityName, theUserID);
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
            if ((endpointConfiguration == EndpointConfiguration.WeatherWebServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WeatherWebServiceSoap12))
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
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WeatherWebServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://www.webxml.com.cn/WebServices/WeatherWebService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WeatherWebServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://www.webxml.com.cn/WebServices/WeatherWebService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WeatherWebServiceSoap,
            
            WeatherWebServiceSoap12,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil-lib", "2.0.3.0")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement()
        {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes
        {
            get
            {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            )
            {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            )
            {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element))
                {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else
                {
                    reader.Skip();
                }
            }
        }
    }
}