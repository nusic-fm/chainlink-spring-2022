using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// TODO: The naming convention might need an update
public class ApplicantData {
   // [Parameter("string", "id", 1)]
    public string ID { get; set; }
    //[Parameter("string", "firstName", 1)]
    public string FirstName { get; set; }
    //[Parameter("string", "lastName", 1)]
    public string LastName { get; set; }
    //[Parameter("string", "youtube", 1)]
    public string Email { get; set; }
    //[Parameter("string", "dob", 1)]
    public string Dob { get; set; }
}

// TODO: The naming convention might need an update. 
public class CreateApplicationData {
    //[Parameter("string", "firstName", 1)]
    public string FirstName { get; set; }
    //[Parameter("string", "lastName", 1)]
    public string LastName { get; set; }
}

public class WebRequestExample : MonoBehaviour
{
    // Where to send our request
    string CREATE_APPLICANT_URL = "https://nusic-onfido-server.herokuapp.com/applicant/create";
    string FETCH_APPLICANT_BY_ID_URL = "https://nusic-onfido-server.herokuapp.com/applicant/getapplicant";
    string targetUrl = "";
    // Keep track of what we got back
    string recentData = "";

    void Awake()
    {
        //this.StartCoroutine(this.RequestRoutine(this.targetUrl, this.ResponseCallback));
        this.StartCoroutine(this.CreateApplicant("Testing", "Dude", this.ResponseCallback));
        this.StartCoroutine(this.RequestApplicantById("f0150fbb-56e7-45a7-a1fd-06456fc3845c", this.ResponseCallback));
    }

    // Web requests are typially done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    //
    private IEnumerator RequestRoutine(string url, Action<string> callback = null)
    {
        // Using the static constructor
        var request = UnityWebRequest.Get(url);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }
    public IEnumerator CreateApplicant(string firstName, string lastName, Action<string> callback = null)
    {
    	WWWForm form = new WWWForm();
        form.AddField("firstName", firstName);
        form.AddField("lastName", lastName);
        // Using the static constructor
        var request = UnityWebRequest.Post(CREATE_APPLICANT_URL, form);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;
        // TODO: This needs to be uncommented once Json.Net.Unity3D package is added to the project: https://github.com/SaladLab/Json.Net.Unity3D
	//string response = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
    	//CreateApplicationData player = JsonConvert.DeserializeObject<CreateApplicationData>(response);
    	
        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }
    public IEnumerator RequestApplicantById(string id, Action<string> callback = null)
    {
    	WWWForm form = new WWWForm();
        form.AddField("applicantId", id);
        // Using the static constructor
        var request = UnityWebRequest.Post(FETCH_APPLICANT_BY_ID_URL, form);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;
        
        
        // TODO: This needs to be uncommented once Json.Net.Unity3D package is added to the project: https://github.com/SaladLab/Json.Net.Unity3D
	//string response = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
    	//ApplicantData player = JsonConvert.DeserializeObject<ApplicantData>(response);
    	
 
        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }
    // Callback to act on our response data
    private void ResponseCallback(string data)
    {
        Debug.Log(data);
        recentData = data;
    }

    // Old fashioned GUI system to show the example
    void OnGUI()
    {
        this.targetUrl = GUI.TextArea(new Rect(0, 0, 500, 100), this.targetUrl);
        GUI.TextArea(new Rect(0, 100, 500, 300), this.recentData);
        if (GUI.Button(new Rect(0, 400, 500, 100), "Resend Request"))
        {
            this.StartCoroutine(this.RequestRoutine(targetUrl, this.ResponseCallback));
        }
    }
}
