//------------------------------------------------------------------------------
// <自动生成>
//     此代码由工具生成。
//     //
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </自动生成>
//------------------------------------------------------------------------------

namespace SmsServiceProxy
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MOMsg", Namespace = "http://www.139130.net")]
    public partial class MOMsg : object
    {

        private string PhoneField;

        private string ContentField;

        private int MsgTypeField;

        private string SpecNumberField;

        private string ServiceTypeField;

        private System.Nullable<System.DateTime> ReceiveTimeField;

        private string ReserveField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                this.PhoneField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                this.ContentField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
        public int MsgType
        {
            get
            {
                return this.MsgTypeField;
            }
            set
            {
                this.MsgTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string SpecNumber
        {
            get
            {
                return this.SpecNumberField;
            }
            set
            {
                this.SpecNumberField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string ServiceType
        {
            get
            {
                return this.ServiceTypeField;
            }
            set
            {
                this.ServiceTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
        public System.Nullable<System.DateTime> ReceiveTime
        {
            get
            {
                return this.ReceiveTimeField;
            }
            set
            {
                this.ReceiveTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string Reserve
        {
            get
            {
                return this.ReserveField;
            }
            set
            {
                this.ReserveField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BusinessType", Namespace = "http://www.139130.net")]
    public partial class BusinessType : object
    {

        private int IdField;

        private string NameField;

        private int PriorityField;

        private string StartTimeField;

        private string EndTimeField;

        private bool ExtendFlagField;

        private int stateField;

        private SmsServiceProxy.BindChannel[] bindChsField;

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public int Priority
        {
            get
            {
                return this.PriorityField;
            }
            set
            {
                this.PriorityField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string StartTime
        {
            get
            {
                return this.StartTimeField;
            }
            set
            {
                this.StartTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string EndTime
        {
            get
            {
                return this.EndTimeField;
            }
            set
            {
                this.EndTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
        public bool ExtendFlag
        {
            get
            {
                return this.ExtendFlagField;
            }
            set
            {
                this.ExtendFlagField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 6)]
        public int state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 7)]
        public SmsServiceProxy.BindChannel[] bindChs
        {
            get
            {
                return this.bindChsField;
            }
            set
            {
                this.bindChsField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BindChannel", Namespace = "http://www.139130.net")]
    public partial class BindChannel : object
    {

        private string ChannelNumField;

        private string CarrierField;

        private string SendTypeField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string ChannelNum
        {
            get
            {
                return this.ChannelNumField;
            }
            set
            {
                this.ChannelNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Carrier
        {
            get
            {
                return this.CarrierField;
            }
            set
            {
                this.CarrierField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string SendType
        {
            get
            {
                return this.SendTypeField;
            }
            set
            {
                this.SendTypeField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AccountInfo", Namespace = "http://www.139130.net")]
    public partial class AccountInfo : object
    {

        private string AccountField;

        private string NameField;

        private string IdentifyField;

        private SmsServiceProxy.ArrayOfString BizNamesField;

        private string UserbriefField;

        private decimal BalanceField;

        private string ReserveField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Account
        {
            get
            {
                return this.AccountField;
            }
            set
            {
                this.AccountField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string Identify
        {
            get
            {
                return this.IdentifyField;
            }
            set
            {
                this.IdentifyField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public SmsServiceProxy.ArrayOfString BizNames
        {
            get
            {
                return this.BizNamesField;
            }
            set
            {
                this.BizNamesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string Userbrief
        {
            get
            {
                return this.UserbriefField;
            }
            set
            {
                this.UserbriefField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
        public decimal Balance
        {
            get
            {
                return this.BalanceField;
            }
            set
            {
                this.BalanceField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string Reserve
        {
            get
            {
                return this.ReserveField;
            }
            set
            {
                this.ReserveField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name = "ArrayOfString", Namespace = "http://www.139130.net", ItemName = "string")]
    public class ArrayOfString : System.Collections.Generic.List<string>
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MTPacks", Namespace = "http://www.139130.net")]
    public partial class MTPacks : object
    {

        private string uuidField;

        private string batchIDField;

        private string batchNameField;

        private int sendTypeField;

        private int msgTypeField;

        private SmsServiceProxy.MediaItems[] mediasField;

        private SmsServiceProxy.MessageData[] msgsField;

        private int bizTypeField;

        private bool distinctFlagField;

        private long scheduleTimeField;

        private string remarkField;

        private string customNumField;

        private long deadlineField;

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, EmitDefaultValue = false)]
        public string uuid
        {
            get
            {
                return this.uuidField;
            }
            set
            {
                this.uuidField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string batchID
        {
            get
            {
                return this.batchIDField;
            }
            set
            {
                this.batchIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string batchName
        {
            get
            {
                return this.batchNameField;
            }
            set
            {
                this.batchNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 3)]
        public int sendType
        {
            get
            {
                return this.sendTypeField;
            }
            set
            {
                this.sendTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 4)]
        public int msgType
        {
            get
            {
                return this.msgTypeField;
            }
            set
            {
                this.msgTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public SmsServiceProxy.MediaItems[] medias
        {
            get
            {
                return this.mediasField;
            }
            set
            {
                this.mediasField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public SmsServiceProxy.MessageData[] msgs
        {
            get
            {
                return this.msgsField;
            }
            set
            {
                this.msgsField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 7)]
        public int bizType
        {
            get
            {
                return this.bizTypeField;
            }
            set
            {
                this.bizTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 8)]
        public bool distinctFlag
        {
            get
            {
                return this.distinctFlagField;
            }
            set
            {
                this.distinctFlagField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 9)]
        public long scheduleTime
        {
            get
            {
                return this.scheduleTimeField;
            }
            set
            {
                this.scheduleTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 10)]
        public string remark
        {
            get
            {
                return this.remarkField;
            }
            set
            {
                this.remarkField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 11)]
        public string customNum
        {
            get
            {
                return this.customNumField;
            }
            set
            {
                this.customNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 12)]
        public long deadline
        {
            get
            {
                return this.deadlineField;
            }
            set
            {
                this.deadlineField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MediaItems", Namespace = "http://www.139130.net")]
    public partial class MediaItems : object
    {

        private string metaField;

        private byte[] dataField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string meta
        {
            get
            {
                return this.metaField;
            }
            set
            {
                this.metaField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public byte[] data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MessageData", Namespace = "http://www.139130.net")]
    public partial class MessageData : object
    {

        private string PhoneField;

        private string ContentField;

        private bool vipFlagField;

        private string customMsgIDField;

        private SmsServiceProxy.MediaItems[] mediasField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                this.PhoneField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                this.ContentField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
        public bool vipFlag
        {
            get
            {
                return this.vipFlagField;
            }
            set
            {
                this.vipFlagField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string customMsgID
        {
            get
            {
                return this.customMsgIDField;
            }
            set
            {
                this.customMsgIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public SmsServiceProxy.MediaItems[] medias
        {
            get
            {
                return this.mediasField;
            }
            set
            {
                this.mediasField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "GsmsResponse", Namespace = "http://www.139130.net")]
    public partial class GsmsResponse : object
    {

        private int resultField;

        private string uuidField;

        private string messageField;

        private string attributesField;

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public int result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, EmitDefaultValue = false)]
        public string uuid
        {
            get
            {
                return this.uuidField;
            }
            set
            {
                this.uuidField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MTResponse", Namespace = "http://www.139130.net")]
    public partial class MTResponse : object
    {

        private string batchIDField;

        private string msgIDField;

        private string customMsgIDField;

        private int stateField;

        private string phoneField;

        private System.Nullable<int> totalField;

        private System.Nullable<int> numberField;

        private System.Nullable<System.DateTime> submitRespTimeField;

        private string originResultField;

        private string reserveField;

        private long idField;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string batchID
        {
            get
            {
                return this.batchIDField;
            }
            set
            {
                this.batchIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string msgID
        {
            get
            {
                return this.msgIDField;
            }
            set
            {
                this.msgIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string customMsgID
        {
            get
            {
                return this.customMsgIDField;
            }
            set
            {
                this.customMsgIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 3)]
        public int state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
        public System.Nullable<int> total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 6)]
        public System.Nullable<int> number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 7)]
        public System.Nullable<System.DateTime> submitRespTime
        {
            get
            {
                return this.submitRespTimeField;
            }
            set
            {
                this.submitRespTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 8)]
        public string originResult
        {
            get
            {
                return this.originResultField;
            }
            set
            {
                this.originResultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 9)]
        public string reserve
        {
            get
            {
                return this.reserveField;
            }
            set
            {
                this.reserveField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 10)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MTReport", Namespace = "http://www.139130.net")]
    public partial class MTReport : object
    {

        private long idField;

        private string batchIDField;

        private string phoneField;

        private string msgIDField;

        private string customMsgIDField;

        private int stateField;

        private System.Nullable<int> totalField;

        private System.Nullable<int> numberField;

        private System.Nullable<System.DateTime> submitTimeField;

        private System.Nullable<System.DateTime> doneTimeField;

        private string originResultField;

        private string reserveField;

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string batchID
        {
            get
            {
                return this.batchIDField;
            }
            set
            {
                this.batchIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string msgID
        {
            get
            {
                return this.msgIDField;
            }
            set
            {
                this.msgIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string customMsgID
        {
            get
            {
                return this.customMsgIDField;
            }
            set
            {
                this.customMsgIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
        public int state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 6)]
        public System.Nullable<int> total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 7)]
        public System.Nullable<int> number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 8)]
        public System.Nullable<System.DateTime> submitTime
        {
            get
            {
                return this.submitTimeField;
            }
            set
            {
                this.submitTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 9)]
        public System.Nullable<System.DateTime> doneTime
        {
            get
            {
                return this.doneTimeField;
            }
            set
            {
                this.doneTimeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 10)]
        public string originResult
        {
            get
            {
                return this.originResultField;
            }
            set
            {
                this.originResultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 11)]
        public string reserve
        {
            get
            {
                return this.reserveField;
            }
            set
            {
                this.reserveField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.139130.net", ConfigurationName = "ServiceReference1.WebServiceSoap")]
    public interface WebServiceSoap
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/GetMOMessage", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.GetMOMessageResponse> GetMOMessageAsync(SmsServiceProxy.GetMOMessageRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/GetBusinessType", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.GetBusinessTypeResponse> GetBusinessTypeAsync(SmsServiceProxy.GetBusinessTypeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/GetAccountInfo", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.GetAccountInfoResponse> GetAccountInfoAsync(SmsServiceProxy.GetAccountInfoRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/ModifyPassword", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.ModifyPasswordResponse> ModifyPasswordAsync(SmsServiceProxy.ModifyPasswordRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/Post", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.PostResponse> PostAsync(SmsServiceProxy.PostRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/GetResponse", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.GetResponseResponse> GetResponseAsync(SmsServiceProxy.GetResponseRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/GetReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.GetReportResponse> GetReportAsync(SmsServiceProxy.GetReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/FindResponse", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.FindResponseResponse> FindResponseAsync(SmsServiceProxy.FindResponseRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/FindReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.FindReportResponse> FindReportAsync(SmsServiceProxy.FindReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.139130.net/SetMedias", ReplyAction = "*")]
        System.Threading.Tasks.Task<SmsServiceProxy.SetMediasResponse> SetMediasAsync(SmsServiceProxy.SetMediasRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetMOMessageRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetMOMessage", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetMOMessageRequestBody Body;

        public GetMOMessageRequest()
        {
        }

        public GetMOMessageRequest(SmsServiceProxy.GetMOMessageRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetMOMessageRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public int pagesize;

        public GetMOMessageRequestBody()
        {
        }

        public GetMOMessageRequestBody(string account, string password, int pagesize)
        {
            this.account = account;
            this.password = password;
            this.pagesize = pagesize;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetMOMessageResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetMOMessageResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetMOMessageResponseBody Body;

        public GetMOMessageResponse()
        {
        }

        public GetMOMessageResponse(SmsServiceProxy.GetMOMessageResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetMOMessageResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MOMsg[] GetMOMessageResult;

        public GetMOMessageResponseBody()
        {
        }

        public GetMOMessageResponseBody(SmsServiceProxy.MOMsg[] GetMOMessageResult)
        {
            this.GetMOMessageResult = GetMOMessageResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetBusinessTypeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetBusinessType", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetBusinessTypeRequestBody Body;

        public GetBusinessTypeRequest()
        {
        }

        public GetBusinessTypeRequest(SmsServiceProxy.GetBusinessTypeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetBusinessTypeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        public GetBusinessTypeRequestBody()
        {
        }

        public GetBusinessTypeRequestBody(string account, string password)
        {
            this.account = account;
            this.password = password;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetBusinessTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetBusinessTypeResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetBusinessTypeResponseBody Body;

        public GetBusinessTypeResponse()
        {
        }

        public GetBusinessTypeResponse(SmsServiceProxy.GetBusinessTypeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetBusinessTypeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.BusinessType[] GetBusinessTypeResult;

        public GetBusinessTypeResponseBody()
        {
        }

        public GetBusinessTypeResponseBody(SmsServiceProxy.BusinessType[] GetBusinessTypeResult)
        {
            this.GetBusinessTypeResult = GetBusinessTypeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAccountInfoRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetAccountInfo", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetAccountInfoRequestBody Body;

        public GetAccountInfoRequest()
        {
        }

        public GetAccountInfoRequest(SmsServiceProxy.GetAccountInfoRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetAccountInfoRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        public GetAccountInfoRequestBody()
        {
        }

        public GetAccountInfoRequestBody(string account, string password)
        {
            this.account = account;
            this.password = password;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAccountInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetAccountInfoResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetAccountInfoResponseBody Body;

        public GetAccountInfoResponse()
        {
        }

        public GetAccountInfoResponse(SmsServiceProxy.GetAccountInfoResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetAccountInfoResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.AccountInfo GetAccountInfoResult;

        public GetAccountInfoResponseBody()
        {
        }

        public GetAccountInfoResponseBody(SmsServiceProxy.AccountInfo GetAccountInfoResult)
        {
            this.GetAccountInfoResult = GetAccountInfoResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ModifyPasswordRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ModifyPassword", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.ModifyPasswordRequestBody Body;

        public ModifyPasswordRequest()
        {
        }

        public ModifyPasswordRequest(SmsServiceProxy.ModifyPasswordRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class ModifyPasswordRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string old_password;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string new_password;

        public ModifyPasswordRequestBody()
        {
        }

        public ModifyPasswordRequestBody(string account, string old_password, string new_password)
        {
            this.account = account;
            this.old_password = old_password;
            this.new_password = new_password;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ModifyPasswordResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ModifyPasswordResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.ModifyPasswordResponseBody Body;

        public ModifyPasswordResponse()
        {
        }

        public ModifyPasswordResponse(SmsServiceProxy.ModifyPasswordResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class ModifyPasswordResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public int ModifyPasswordResult;

        public ModifyPasswordResponseBody()
        {
        }

        public ModifyPasswordResponseBody(int ModifyPasswordResult)
        {
            this.ModifyPasswordResult = ModifyPasswordResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class PostRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "Post", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.PostRequestBody Body;

        public PostRequest()
        {
        }

        public PostRequest(SmsServiceProxy.PostRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class PostRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public SmsServiceProxy.MTPacks mtpack;

        public PostRequestBody()
        {
        }

        public PostRequestBody(string account, string password, SmsServiceProxy.MTPacks mtpack)
        {
            this.account = account;
            this.password = password;
            this.mtpack = mtpack;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class PostResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "PostResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.PostResponseBody Body;

        public PostResponse()
        {
        }

        public PostResponse(SmsServiceProxy.PostResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class PostResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.GsmsResponse PostResult;

        public PostResponseBody()
        {
        }

        public PostResponseBody(SmsServiceProxy.GsmsResponse PostResult)
        {
            this.PostResult = PostResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetResponseRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetResponseRequestBody Body;

        public GetResponseRequest()
        {
        }

        public GetResponseRequest(SmsServiceProxy.GetResponseRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetResponseRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public int PageSize;

        public GetResponseRequestBody()
        {
        }

        public GetResponseRequestBody(string account, string password, int PageSize)
        {
            this.account = account;
            this.password = password;
            this.PageSize = PageSize;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetResponseResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetResponseResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetResponseResponseBody Body;

        public GetResponseResponse()
        {
        }

        public GetResponseResponse(SmsServiceProxy.GetResponseResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetResponseResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MTResponse[] GetResponseResult;

        public GetResponseResponseBody()
        {
        }

        public GetResponseResponseBody(SmsServiceProxy.MTResponse[] GetResponseResult)
        {
            this.GetResponseResult = GetResponseResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetReport", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetReportRequestBody Body;

        public GetReportRequest()
        {
        }

        public GetReportRequest(SmsServiceProxy.GetReportRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetReportRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public int PageSize;

        public GetReportRequestBody()
        {
        }

        public GetReportRequestBody(string account, string password, int PageSize)
        {
            this.account = account;
            this.password = password;
            this.PageSize = PageSize;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetReportResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetReportResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.GetReportResponseBody Body;

        public GetReportResponse()
        {
        }

        public GetReportResponse(SmsServiceProxy.GetReportResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class GetReportResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MTReport[] GetReportResult;

        public GetReportResponseBody()
        {
        }

        public GetReportResponseBody(SmsServiceProxy.MTReport[] GetReportResult)
        {
            this.GetReportResult = GetReportResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class FindResponseRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "FindResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.FindResponseRequestBody Body;

        public FindResponseRequest()
        {
        }

        public FindResponseRequest(SmsServiceProxy.FindResponseRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class FindResponseRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string batchid;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string mobile;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public int pageindex;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public int flag;

        public FindResponseRequestBody()
        {
        }

        public FindResponseRequestBody(string account, string password, string batchid, string mobile, int pageindex, int flag)
        {
            this.account = account;
            this.password = password;
            this.batchid = batchid;
            this.mobile = mobile;
            this.pageindex = pageindex;
            this.flag = flag;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class FindResponseResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "FindResponseResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.FindResponseResponseBody Body;

        public FindResponseResponse()
        {
        }

        public FindResponseResponse(SmsServiceProxy.FindResponseResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class FindResponseResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MTResponse[] FindResponseResult;

        public FindResponseResponseBody()
        {
        }

        public FindResponseResponseBody(SmsServiceProxy.MTResponse[] FindResponseResult)
        {
            this.FindResponseResult = FindResponseResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class FindReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "FindReport", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.FindReportRequestBody Body;

        public FindReportRequest()
        {
        }

        public FindReportRequest(SmsServiceProxy.FindReportRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class FindReportRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string account;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string password;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string batchid;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string mobile;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public int pageindex;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public int flag;

        public FindReportRequestBody()
        {
        }

        public FindReportRequestBody(string account, string password, string batchid, string mobile, int pageindex, int flag)
        {
            this.account = account;
            this.password = password;
            this.batchid = batchid;
            this.mobile = mobile;
            this.pageindex = pageindex;
            this.flag = flag;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class FindReportResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "FindReportResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.FindReportResponseBody Body;

        public FindReportResponse()
        {
        }

        public FindReportResponse(SmsServiceProxy.FindReportResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class FindReportResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MTReport[] FindReportResult;

        public FindReportResponseBody()
        {
        }

        public FindReportResponseBody(SmsServiceProxy.MTReport[] FindReportResult)
        {
            this.FindReportResult = FindReportResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class SetMediasRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "SetMedias", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.SetMediasRequestBody Body;

        public SetMediasRequest()
        {
        }

        public SetMediasRequest(SmsServiceProxy.SetMediasRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class SetMediasRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string fullPath;

        public SetMediasRequestBody()
        {
        }

        public SetMediasRequestBody(string fullPath)
        {
            this.fullPath = fullPath;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class SetMediasResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "SetMediasResponse", Namespace = "http://www.139130.net", Order = 0)]
        public SmsServiceProxy.SetMediasResponseBody Body;

        public SetMediasResponse()
        {
        }

        public SetMediasResponse(SmsServiceProxy.SetMediasResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://www.139130.net")]
    public partial class SetMediasResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public SmsServiceProxy.MediaItems[] SetMediasResult;

        public SetMediasResponseBody()
        {
        }

        public SetMediasResponseBody(SmsServiceProxy.MediaItems[] SetMediasResult)
        {
            this.SetMediasResult = SetMediasResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface WebServiceSoapChannel : SmsServiceProxy.WebServiceSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<SmsServiceProxy.WebServiceSoap>, SmsServiceProxy.WebServiceSoap
    {

        /// <summary>
        /// 实现此分部方法，配置服务终结点。
        /// </summary>
        /// <param name="serviceEndpoint">要配置的终结点</param>
        /// <param name="clientCredentials">客户端凭据</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public WebServiceSoapClient() :
                base(WebServiceSoapClient.GetDefaultBinding(), WebServiceSoapClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.WebServiceSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration) :
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), WebServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public WebServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(WebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.GetMOMessageResponse> SmsServiceProxy.WebServiceSoap.GetMOMessageAsync(SmsServiceProxy.GetMOMessageRequest request)
        {
            return base.Channel.GetMOMessageAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.GetMOMessageResponse> GetMOMessageAsync(string account, string password, int pagesize)
        {
            SmsServiceProxy.GetMOMessageRequest inValue = new SmsServiceProxy.GetMOMessageRequest();
            inValue.Body = new SmsServiceProxy.GetMOMessageRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.pagesize = pagesize;
            return ((SmsServiceProxy.WebServiceSoap)(this)).GetMOMessageAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.GetBusinessTypeResponse> SmsServiceProxy.WebServiceSoap.GetBusinessTypeAsync(SmsServiceProxy.GetBusinessTypeRequest request)
        {
            return base.Channel.GetBusinessTypeAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.GetBusinessTypeResponse> GetBusinessTypeAsync(string account, string password)
        {
            SmsServiceProxy.GetBusinessTypeRequest inValue = new SmsServiceProxy.GetBusinessTypeRequest();
            inValue.Body = new SmsServiceProxy.GetBusinessTypeRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            return ((SmsServiceProxy.WebServiceSoap)(this)).GetBusinessTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.GetAccountInfoResponse> SmsServiceProxy.WebServiceSoap.GetAccountInfoAsync(SmsServiceProxy.GetAccountInfoRequest request)
        {
            return base.Channel.GetAccountInfoAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.GetAccountInfoResponse> GetAccountInfoAsync(string account, string password)
        {
            SmsServiceProxy.GetAccountInfoRequest inValue = new SmsServiceProxy.GetAccountInfoRequest();
            inValue.Body = new SmsServiceProxy.GetAccountInfoRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            return ((SmsServiceProxy.WebServiceSoap)(this)).GetAccountInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.ModifyPasswordResponse> SmsServiceProxy.WebServiceSoap.ModifyPasswordAsync(SmsServiceProxy.ModifyPasswordRequest request)
        {
            return base.Channel.ModifyPasswordAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.ModifyPasswordResponse> ModifyPasswordAsync(string account, string old_password, string new_password)
        {
            SmsServiceProxy.ModifyPasswordRequest inValue = new SmsServiceProxy.ModifyPasswordRequest();
            inValue.Body = new SmsServiceProxy.ModifyPasswordRequestBody();
            inValue.Body.account = account;
            inValue.Body.old_password = old_password;
            inValue.Body.new_password = new_password;
            return ((SmsServiceProxy.WebServiceSoap)(this)).ModifyPasswordAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.PostResponse> SmsServiceProxy.WebServiceSoap.PostAsync(SmsServiceProxy.PostRequest request)
        {
            return base.Channel.PostAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.PostResponse> PostAsync(string account, string password, SmsServiceProxy.MTPacks mtpack)
        {
            SmsServiceProxy.PostRequest inValue = new SmsServiceProxy.PostRequest();
            inValue.Body = new SmsServiceProxy.PostRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.mtpack = mtpack;
            return ((SmsServiceProxy.WebServiceSoap)(this)).PostAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.GetResponseResponse> SmsServiceProxy.WebServiceSoap.GetResponseAsync(SmsServiceProxy.GetResponseRequest request)
        {
            return base.Channel.GetResponseAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.GetResponseResponse> GetResponseAsync(string account, string password, int PageSize)
        {
            SmsServiceProxy.GetResponseRequest inValue = new SmsServiceProxy.GetResponseRequest();
            inValue.Body = new SmsServiceProxy.GetResponseRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.PageSize = PageSize;
            return ((SmsServiceProxy.WebServiceSoap)(this)).GetResponseAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.GetReportResponse> SmsServiceProxy.WebServiceSoap.GetReportAsync(SmsServiceProxy.GetReportRequest request)
        {
            return base.Channel.GetReportAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.GetReportResponse> GetReportAsync(string account, string password, int PageSize)
        {
            SmsServiceProxy.GetReportRequest inValue = new SmsServiceProxy.GetReportRequest();
            inValue.Body = new SmsServiceProxy.GetReportRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.PageSize = PageSize;
            return ((SmsServiceProxy.WebServiceSoap)(this)).GetReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.FindResponseResponse> SmsServiceProxy.WebServiceSoap.FindResponseAsync(SmsServiceProxy.FindResponseRequest request)
        {
            return base.Channel.FindResponseAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.FindResponseResponse> FindResponseAsync(string account, string password, string batchid, string mobile, int pageindex, int flag)
        {
            SmsServiceProxy.FindResponseRequest inValue = new SmsServiceProxy.FindResponseRequest();
            inValue.Body = new SmsServiceProxy.FindResponseRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.batchid = batchid;
            inValue.Body.mobile = mobile;
            inValue.Body.pageindex = pageindex;
            inValue.Body.flag = flag;
            return ((SmsServiceProxy.WebServiceSoap)(this)).FindResponseAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.FindReportResponse> SmsServiceProxy.WebServiceSoap.FindReportAsync(SmsServiceProxy.FindReportRequest request)
        {
            return base.Channel.FindReportAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.FindReportResponse> FindReportAsync(string account, string password, string batchid, string mobile, int pageindex, int flag)
        {
            SmsServiceProxy.FindReportRequest inValue = new SmsServiceProxy.FindReportRequest();
            inValue.Body = new SmsServiceProxy.FindReportRequestBody();
            inValue.Body.account = account;
            inValue.Body.password = password;
            inValue.Body.batchid = batchid;
            inValue.Body.mobile = mobile;
            inValue.Body.pageindex = pageindex;
            inValue.Body.flag = flag;
            return ((SmsServiceProxy.WebServiceSoap)(this)).FindReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SmsServiceProxy.SetMediasResponse> SmsServiceProxy.WebServiceSoap.SetMediasAsync(SmsServiceProxy.SetMediasRequest request)
        {
            return base.Channel.SetMediasAsync(request);
        }

        public System.Threading.Tasks.Task<SmsServiceProxy.SetMediasResponse> SetMediasAsync(string fullPath)
        {
            SmsServiceProxy.SetMediasRequest inValue = new SmsServiceProxy.SetMediasRequest();
            inValue.Body = new SmsServiceProxy.SetMediasRequestBody();
            inValue.Body.fullPath = fullPath;
            return ((SmsServiceProxy.WebServiceSoap)(this)).SetMediasAsync(inValue);
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
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap))
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
            if ((endpointConfiguration == EndpointConfiguration.WebServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://20.11.0.15:8888/Service/WebService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WebServiceSoapClient.GetBindingForEndpoint(EndpointConfiguration.WebServiceSoap);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WebServiceSoapClient.GetEndpointAddress(EndpointConfiguration.WebServiceSoap);
        }

        public enum EndpointConfiguration
        {

            WebServiceSoap,
        }
    }
}
