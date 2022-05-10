using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class GetGlobalGoogleTime : MonoBehaviour
    {
        private DateTime _time;
        private string _url = "google.com";
        
        private void Start()
        {
            StartCoroutine(GetGlobalTime());
        }
        
        private IEnumerator GetGlobalTime()
        {
            UnityWebRequest request = UnityWebRequest.Head(_url);
            
            yield return request.SendWebRequest();

            var responseTime = request.GetResponseHeader("Date");
            Debug.Log("responseTime: " + responseTime);
        }
    }
}
