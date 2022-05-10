using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace VSCode.Contracts.audience.ContractDefinition
{
    public partial class AudienceDeployment : AudienceDeploymentBase
    {
        public AudienceDeployment() : base(BYTECODE) { }
        public AudienceDeployment(string byteCode) : base(byteCode) { }
    }

    public class AudienceDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public AudienceDeploymentBase() : base(BYTECODE) { }
        public AudienceDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_link", 1)]
        public virtual string Link { get; set; }
        [Parameter("address", "_oracle", 2)]
        public virtual string Oracle { get; set; }
    }

    public partial class FulfillStatisticsFunction : FulfillStatisticsFunctionBase { }

    [Function("fulfillStatistics")]
    public class FulfillStatisticsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_requestId", 1)]
        public virtual byte[] RequestId { get; set; }
        [Parameter("bytes32", "_result", 2)]
        public virtual byte[] Result { get; set; }
    }

    public partial class RequestStatisticsFunction : RequestStatisticsFunctionBase { }

    [Function("requestStatistics")]
    public class RequestStatisticsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_specId", 1)]
        public virtual byte[] SpecId { get; set; }
        [Parameter("uint256", "_payment", 2)]
        public virtual BigInteger Payment { get; set; }
        [Parameter("uint256", "_artistId", 3)]
        public virtual BigInteger ArtistId { get; set; }
    }

    public partial class SetOracleFunction : SetOracleFunctionBase { }

    [Function("setOracle")]
    public class SetOracleFunctionBase : FunctionMessage
    {
        [Parameter("address", "_oracle", 1)]
        public virtual string Oracle { get; set; }
    }

    public partial class WithdrawLinkFunction : WithdrawLinkFunctionBase { }

    [Function("withdrawLink")]
    public class WithdrawLinkFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "_payee", 2)]
        public virtual string Payee { get; set; }
    }

    public partial class GetOracleAddressFunction : GetOracleAddressFunctionBase { }

    [Function("getOracleAddress", "address")]
    public class GetOracleAddressFunctionBase : FunctionMessage
    {

    }

    public partial class RequestIdStatisticsFunction : RequestIdStatisticsFunctionBase { }

    [Function("requestIdStatistics", typeof(RequestIdStatisticsOutputDTO))]
    public class RequestIdStatisticsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ChainlinkCancelledEventDTO : ChainlinkCancelledEventDTOBase { }

    [Event("ChainlinkCancelled")]
    public class ChainlinkCancelledEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "id", 1, true)]
        public virtual byte[] Id { get; set; }
    }

    public partial class ChainlinkFulfilledEventDTO : ChainlinkFulfilledEventDTOBase { }

    [Event("ChainlinkFulfilled")]
    public class ChainlinkFulfilledEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "id", 1, true)]
        public virtual byte[] Id { get; set; }
    }

    public partial class ChainlinkRequestedEventDTO : ChainlinkRequestedEventDTOBase { }

    [Event("ChainlinkRequested")]
    public class ChainlinkRequestedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "id", 1, true)]
        public virtual byte[] Id { get; set; }
    }

    public partial class FailedTransferLINKError : FailedTransferLINKErrorBase { }

    [Error("FailedTransferLINK")]
    public class FailedTransferLINKErrorBase : IErrorDTO
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }









    public partial class GetOracleAddressOutputDTO : GetOracleAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetOracleAddressOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RequestIdStatisticsOutputDTO : RequestIdStatisticsOutputDTOBase { }

    [FunctionOutput]
    public class RequestIdStatisticsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint64", "youtube", 1)]
        public virtual ulong Youtube { get; set; }
        [Parameter("uint64", "spotify", 2)]
        public virtual ulong Spotify { get; set; }
        [Parameter("uint64", "tiktok", 3)]
        public virtual ulong Tiktok { get; set; }
    }
}
