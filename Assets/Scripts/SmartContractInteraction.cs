using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Nethereum.ABI;
using Nethereum.ABI.Encoders;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.Extensions;
using Nethereum.JsonRpc.UnityClient;
using UnityEngine;

public class SmartContractInteraction : MonoBehaviour
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

    public string jobIDstring = "0x6164383735393138633461393434383962626531663965333465373938366366";
    public byte[] jobIDbytes = { 0x32, 0x39, 0x66, 0x35, 0x62, 0x66, 0x37, 0x31, 0x32, 0x37, 0x37, 0x33, 0x34, 0x64, 0x37, 0x36, 0x38, 0x65, 0x34, 0x30, 0x63, 0x38, 0x62, 0x65, 0x63, 0x35, 0x65, 0x34, 0x31, 0x65, 0x36, 0x62 };
    public Bytes32TypeEncoder jobID;
    public string contractAddress = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
    public int chainID = 42; //42 kovan

    private void Start()
    {      
     
        StartCoroutine(DeployAndRequestAudienceStats());
    }
    public IEnumerator DeployAndRequestAudienceStats()
    {
        var url = "https://kovan.infura.io/v3/c0a7207e810941879cd6ec997951ad6d";
        var privateKey = "52dd6f8bb7e59be19354c35ebc093e6e9ec64a24d017539213342139ecd624bf";
        var account = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
        //initialising the transaction request sender
        var transactionRequest = new TransactionSignedUnityRequest(url, privateKey);
      

        var deployContract = new AudienceDeployment()
        {
            Link = "0xa36085F69e2889c224210F603D836748e7dC0088",
            Oracle = "0xfF07C97631Ff3bAb5e5e5660Cdf47AdEd8D4d4Fd",
        };

        //deploy the contract 
        yield return transactionRequest.SignAndSendDeploymentContractTransaction<AudienceDeploymentBase>(deployContract);
       
        if (transactionRequest.Exception != null)
        {
            Debug.Log("Throw:" + transactionRequest.Exception.Message);
            yield break;
        }

        var transactionRequestStatistics = new TransactionSignedUnityRequest(url, privateKey, chainID);
        var artistID = 4904;

        var transactionMessage = new RequestStatisticsFunction
        {
            SpecId = jobIDbytes,
            Payment = 1,
            ArtistId = artistID,
        };

        yield return transactionRequestStatistics.SignAndSendTransaction(transactionMessage, contractAddress);

        Debug.Log("stats:" + transactionRequestStatistics);

         var queryRequest = new QueryUnityRequest<RequestIdStatisticsFunction, RequestIdStatisticsOutputDTO>(url, account);
        yield return queryRequest.Query(new RequestIdStatisticsFunction() { ReturnValue1 = jobIDbytes }, contractAddress);

        var dtoResult = queryRequest.Result;
        Debug.Log("Spotify :" + dtoResult.Spotify.ToString());

        var queryRequest2 = new QueryUnityRequest<RequestStatisticsFunction, RequestIdStatisticsOutputDTO>(url, account);
        yield return queryRequest2.Query(transactionMessage, contractAddress);

        var dtoResult2 = queryRequest2.Result;
        Debug.Log("Spotify :" + dtoResult2.Spotify.ToString());

    }
}
