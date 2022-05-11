using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class GetGlobalGoogleTime : MonoBehaviour
    {
        private DateTime _time;
        private string _url = "google.com";
        private string _responseTime;
        
        private void Start()
        {
            StartCoroutine(GetGlobalTime());
            
            // _time = СonversionTime();
            // Debug.Log("TimeGoogle: " + _time);
            // Debug.Log("TimeGoogle: " + _time.Hour);
            // Debug.Log("TimeGoogle: " + _time.Minute);
            // Debug.Log("TimeGoogle: " + _time.Second);
        }
        
        private IEnumerator GetGlobalTime()
        {
            UnityWebRequest request = UnityWebRequest.Head(_url);
            
            yield return request.SendWebRequest();

            var _responseTime = request.GetResponseHeader("Date");
            
            Debug.Log("TimeGoogle: " + _responseTime);
            
            if (!DateTime.TryParse(_responseTime, out _time)) 
            {
                yield return DateTime.MinValue;
            }
            yield return _time.ToUniversalTime();
            
            Debug.Log("TimeGoogle: " + _time);
            Debug.Log("TimeGoogle: " + _time.Hour);
            Debug.Log("TimeGoogle: " + _time.Minute);
            Debug.Log("TimeGoogle: " + _time.Second);
        }

        private DateTime СonversionTime()
        { 
            if (!DateTime.TryParse(_responseTime, out _time)) 
            {
                return DateTime.MinValue;
            }
            return _time.ToUniversalTime();
        }
    }
}