﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Console_Desk.WCF_LibraryDesk {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_LibraryDesk.ILibraryDesk")]
    public interface ILibraryDesk {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILibraryDesk/BorrowBook", ReplyAction="http://tempuri.org/ILibraryDesk/BorrowBookResponse")]
        bool BorrowBook(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILibraryDesk/BorrowBook", ReplyAction="http://tempuri.org/ILibraryDesk/BorrowBookResponse")]
        System.Threading.Tasks.Task<bool> BorrowBookAsync(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILibraryDesk/ReturnBook", ReplyAction="http://tempuri.org/ILibraryDesk/ReturnBookResponse")]
        bool ReturnBook(string code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILibraryDesk/ReturnBook", ReplyAction="http://tempuri.org/ILibraryDesk/ReturnBookResponse")]
        System.Threading.Tasks.Task<bool> ReturnBookAsync(string code);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILibraryDeskChannel : Console_Desk.WCF_LibraryDesk.ILibraryDesk, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LibraryDeskClient : System.ServiceModel.ClientBase<Console_Desk.WCF_LibraryDesk.ILibraryDesk>, Console_Desk.WCF_LibraryDesk.ILibraryDesk {
        
        public LibraryDeskClient() {
        }
        
        public LibraryDeskClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LibraryDeskClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryDeskClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryDeskClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool BorrowBook(string code) {
            return base.Channel.BorrowBook(code);
        }
        
        public System.Threading.Tasks.Task<bool> BorrowBookAsync(string code) {
            return base.Channel.BorrowBookAsync(code);
        }
        
        public bool ReturnBook(string code) {
            return base.Channel.ReturnBook(code);
        }
        
        public System.Threading.Tasks.Task<bool> ReturnBookAsync(string code) {
            return base.Channel.ReturnBookAsync(code);
        }
    }
}