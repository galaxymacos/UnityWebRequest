using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BasicWebCall : MonoBehaviour
{
    public Text messageText;
    public InputField scoreToSend;

    private readonly string getURL = "http://get.php";
    private readonly string postURL = "http://post.php";

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = "Press the button to interact with web server";
    }

    public void OnButtonGetScore()
    {
        messageText.text = "Downloading data...";
        StartCoroutine(SimpleGetRequest());
    }

    IEnumerator SimpleGetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            messageText.text = www.downloadHandler.text;
        }
    }

    public void OnButtonSendScore()
    {
        if (scoreToSend.text == string.Empty)
        {
            messageText.text = "Error: No high score to send.\nEnter a value in the input field.";
        }
        else
        {
            messageText.text = "Sending data...";
            StartCoroutine(SimplePostRequest(scoreToSend.text));
        }
    }

    IEnumerator SimplePostRequest(string curScore)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("curScoreKey", curScore));

        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            messageText.text = www.downloadHandler.text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
