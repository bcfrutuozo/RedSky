﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Abrasf2", ConfigurationName="SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort")]
    public interface CancelarNfseSoapPort {
        
        // CODEGEN: Generating message contract since the wrapper name (CancelarNfse.Execute) of message ExecuteRequest does not match the default value (Execute)
        [System.ServiceModel.OperationContractAttribute(Action="Abrasf2action/ACANCELARNFSE.Execute", ReplyAction="*")]
        RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse Execute(RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="Abrasf2action/ACANCELARNFSE.Execute", ReplyAction="*")]
        System.Threading.Tasks.Task<RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse> ExecuteAsync(RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelarNfse.Execute", WrapperNamespace="Abrasf2", IsWrapped=true)]
    public partial class ExecuteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="Abrasf2", Order=0)]
        public string Entrada;
        
        public ExecuteRequest() {
        }
        
        public ExecuteRequest(string Entrada) {
            this.Entrada = Entrada;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CancelarNfse.ExecuteResponse", WrapperNamespace="Abrasf2", IsWrapped=true)]
    public partial class ExecuteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="Abrasf2", Order=0)]
        public string Resposta;
        
        public ExecuteResponse() {
        }
        
        public ExecuteResponse(string Resposta) {
            this.Resposta = Resposta;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CancelarNfseSoapPortChannel : RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CancelarNfseSoapPortClient : System.ServiceModel.ClientBase<RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort>, RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort {
        
        public CancelarNfseSoapPortClient() {
        }
        
        public CancelarNfseSoapPortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CancelarNfseSoapPortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CancelarNfseSoapPortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CancelarNfseSoapPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort.Execute(RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest request) {
            return base.Channel.Execute(request);
        }
        
        public string Execute(string Entrada) {
            RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest inValue = new RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest();
            inValue.Entrada = Entrada;
            RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse retVal = ((RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort)(this)).Execute(inValue);
            return retVal.Resposta;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse> RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort.ExecuteAsync(RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest request) {
            return base.Channel.ExecuteAsync(request);
        }
        
        public System.Threading.Tasks.Task<RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteResponse> ExecuteAsync(string Entrada) {
            RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest inValue = new RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.ExecuteRequest();
            inValue.Entrada = Entrada;
            return ((RedSky.Infrastructure.NFSe.SPTatuiNFSeCancelarNFSe.CancelarNfseSoapPort)(this)).ExecuteAsync(inValue);
        }
    }
}
