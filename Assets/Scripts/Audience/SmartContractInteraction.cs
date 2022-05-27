using System.Collections;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.JsonRpc.UnityClient;
using UnityEngine;

public class SmartContractInteraction : MonoBehaviour
{
    public ulong AokiYouTubeAudienceNumber;
    public ulong AokiTikTiokAudienceNumber;
    public ulong AokiSpotifyAudienceNumber;

    public int DeadmouseYouTubeAudienceNumber;
    public int DeadMouseTikTiokAudienceNumber;
    public int DeadMouseSpotifyAudienceNumber;

    public int RacYouTubeAudienceNumber;
    public int RacTikTiokAudienceNumber;
    public int RacSpotifyAudienceNumber;

    public int JacquesYouTubeAudienceNumber;
    public int JacquesTikTiokAudienceNumber;
    public int JacquesSpotifyAudienceNumber;


    // --------------------Aoki------------------------------------
    [Function("aokiLatestRequestId", "bytes32")]
    public class AokiLatestRequestIdFunction : FunctionMessage
    {}

    [FunctionOutput]
    public class AokiLatestRequestIdFunctionOutput : IFunctionOutputDTO
    {
        [Parameter("bytes32", 1)]
        public byte[] AokiLatestRequestId { get; set; }
    }
    
    // --------------------Dead Mouse------------------------------------
    [Function("deadMouseLatestRequestId", "bytes32")]
    public class DeadMouseLatestRequestIdFunction : FunctionMessage
    {}

    [FunctionOutput]
    public class DeadMouseLatestRequestIdFunctionOutput : IFunctionOutputDTO
    {
        [Parameter("bytes32", 1)]
        public byte[] DeadMouseLatestRequestId { get; set; }
    }
    
    // --------------------Rac------------------------------------
    [Function("racLatestRequestId", "bytes32")]
    public class RacLatestRequestIdFunction : FunctionMessage
    {}

    [FunctionOutput]
    public class RacLatestRequestIdFunctionOutput : IFunctionOutputDTO
    {
        [Parameter("bytes32", 1)]
        public byte[] RacLatestRequestId { get; set; }
    }
    
    // --------------------Jacques------------------------------------
    [Function("jacquesLatestRequestId", "bytes32")]
    public class JacquesLatestRequestIdFunction : FunctionMessage
    {}

    [FunctionOutput]
    public class JacquesLatestRequestIdFunctionOutput : IFunctionOutputDTO
    {
        [Parameter("bytes32", 1)]
        public byte[] JacquesLatestRequestId { get; set; }
    }
  
    //---------------------------------------------------------------------------
    // RequestStatistics method to get the audience data from Artist Request Id   
    [Function("requestIdStatistics", typeof(RequestIdStatisticsOutputDTOBase))]
    public class RequestAudianceFunction : FunctionMessage
    {
	[Parameter("bytes32", "", 1)]
        public virtual byte[] RequestId { get; set; }
    }

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

    public string contractAddress = "0x640d0F31499e1D396d01E3dC5FB2752Cb5356f47";
    public int chainID = 42; //42 kovan

    private void Start()
    {      
     
        StartCoroutine(RequestAokiAudienceStats());
        StartCoroutine(RequestDeadMouseAudienceStats());
        StartCoroutine(RequestRacAudienceStats());
        StartCoroutine(RequestJacquesAudienceStats());
    }
   
    public IEnumerator RequestAokiAudienceStats()
    {
        var url = "https://kovan.infura.io/v3/c0a7207e810941879cd6ec997951ad6d";
        var privateKey = "52dd6f8bb7e59be19354c35ebc093e6e9ec64a24d017539213342139ecd624bf";
        var account = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
        //initialising the transaction request sender
        var transactionRequest = new TransactionSignedUnityRequest(url, privateKey);
        
        var queryRequestId = new QueryUnityRequest<AokiLatestRequestIdFunction, AokiLatestRequestIdFunctionOutput>(url, account);
        yield return queryRequestId.Query(new AokiLatestRequestIdFunction(), contractAddress);

        //Getting the dto response already decoded
        var AokiLatestRequestId = queryRequestId.Result.AokiLatestRequestId;

        var queryRequestStats = new QueryUnityRequest<RequestAudianceFunction, RequestIdStatisticsOutputDTOBase>(url, account);
        yield return queryRequestStats.Query(new RequestAudianceFunction() { RequestId = AokiLatestRequestId}, contractAddress);
        
        
        //Getting the dto response already decoded
        var dtoResult = queryRequestStats.Result;
        Debug.Log("Aoki Youtube :" + dtoResult.Youtube);
        Debug.Log("Aoki Spotify :" + dtoResult.Spotify);
        Debug.Log("Aoki Tiktok :" + dtoResult.Tiktok);

        AokiYouTubeAudienceNumber = dtoResult.Youtube;
        AokiTikTiokAudienceNumber = dtoResult.Tiktok;
        AokiSpotifyAudienceNumber = dtoResult.Spotify;
    }
    
    public IEnumerator RequestDeadMouseAudienceStats()
    {
        var url = "https://kovan.infura.io/v3/c0a7207e810941879cd6ec997951ad6d";
        var privateKey = "52dd6f8bb7e59be19354c35ebc093e6e9ec64a24d017539213342139ecd624bf";
        var account = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
        //initialising the transaction request sender
        var transactionRequest = new TransactionSignedUnityRequest(url, privateKey);
        
        var queryRequestId = new QueryUnityRequest<DeadMouseLatestRequestIdFunction, DeadMouseLatestRequestIdFunctionOutput>(url, account);
        yield return queryRequestId.Query(new DeadMouseLatestRequestIdFunction(), contractAddress);

        //Getting the dto response already decoded
        var DeadMouseLatestRequestId = queryRequestId.Result.DeadMouseLatestRequestId;

        var queryRequestStats = new QueryUnityRequest<RequestAudianceFunction, RequestIdStatisticsOutputDTOBase>(url, account);
        yield return queryRequestStats.Query(new RequestAudianceFunction() { RequestId = DeadMouseLatestRequestId}, contractAddress);
        
        
        //Getting the dto response already decoded
        var dtoResult = queryRequestStats.Result;
        Debug.Log("DeadMouse Youtube :" + dtoResult.Youtube);
        Debug.Log("DeadMouse Spotify :" + dtoResult.Spotify);
        Debug.Log("DeadMouse Tiktok :" + dtoResult.Tiktok);
    }
    
    public IEnumerator RequestRacAudienceStats()
    {
        var url = "https://kovan.infura.io/v3/c0a7207e810941879cd6ec997951ad6d";
        var privateKey = "52dd6f8bb7e59be19354c35ebc093e6e9ec64a24d017539213342139ecd624bf";
        var account = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
        //initialising the transaction request sender
        var transactionRequest = new TransactionSignedUnityRequest(url, privateKey);
        
        var queryRequestId = new QueryUnityRequest<RacLatestRequestIdFunction, RacLatestRequestIdFunctionOutput>(url, account);
        yield return queryRequestId.Query(new RacLatestRequestIdFunction(), contractAddress);

        //Getting the dto response already decoded
        var RacLatestRequestId = queryRequestId.Result.RacLatestRequestId;

        var queryRequestStats = new QueryUnityRequest<RequestAudianceFunction, RequestIdStatisticsOutputDTOBase>(url, account);
        yield return queryRequestStats.Query(new RequestAudianceFunction() { RequestId = RacLatestRequestId}, contractAddress);
        
        
        //Getting the dto response already decoded
        var dtoResult = queryRequestStats.Result;
        Debug.Log("Rac Youtube :" + dtoResult.Youtube);
        Debug.Log("Rac Spotify :" + dtoResult.Spotify);
        Debug.Log("Rac Tiktok :" + dtoResult.Tiktok);
    }
    
    public IEnumerator RequestJacquesAudienceStats()
    {
        var url = "https://kovan.infura.io/v3/c0a7207e810941879cd6ec997951ad6d";
        var privateKey = "52dd6f8bb7e59be19354c35ebc093e6e9ec64a24d017539213342139ecd624bf";
        var account = "0x6Dca0a9Fe73FC54F1BEcC4a53561E3173868C687";
        //initialising the transaction request sender
        var transactionRequest = new TransactionSignedUnityRequest(url, privateKey);
        
        var queryRequestId = new QueryUnityRequest<JacquesLatestRequestIdFunction, JacquesLatestRequestIdFunctionOutput>(url, account);
        yield return queryRequestId.Query(new JacquesLatestRequestIdFunction(), contractAddress);

        //Getting the dto response already decoded
        var JacquesLatestRequestId = queryRequestId.Result.JacquesLatestRequestId;

        var queryRequestStats = new QueryUnityRequest<RequestAudianceFunction, RequestIdStatisticsOutputDTOBase>(url, account);
        yield return queryRequestStats.Query(new RequestAudianceFunction() { RequestId = JacquesLatestRequestId}, contractAddress);
        
        
        //Getting the dto response already decoded
        var dtoResult = queryRequestStats.Result;
        Debug.Log("Jacques Youtube :" + dtoResult.Youtube);
        Debug.Log("Jacques Spotify :" + dtoResult.Spotify);
        Debug.Log("Jacques Tiktok :" + dtoResult.Tiktok);
    }
}
