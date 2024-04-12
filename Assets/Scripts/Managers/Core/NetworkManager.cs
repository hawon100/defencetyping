using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public List<string> UrlJson;
    public UnityWebRequestAsyncOperation time;

    public void Awake()
    {
        StartCoroutine(UnityWebRequestGet("https://gist.githubusercontent.com/hawon100/41cb128955a18af161b8a57231edcd33/raw/a5174a47ea660e583b6c0529720d4ab4635f49bf/Typinhword.json"));
    }

    private IEnumerator UnityWebRequestGet(string path)
    {
        string url = path;

        UnityWebRequest www = UnityWebRequest.Get(url);

        time = www.SendWebRequest();

        yield return time;

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);
            UrlJson.Add(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("ERROR");
        }
    }
}