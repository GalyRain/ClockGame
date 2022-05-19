using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class GetGlobalGoogleTime : MonoBehaviour
    {
        private static DateTime _time;
        private string _url = "google.com";
        private string _responseTime;
        
        public int Hours { get; private set; } = 0;
        public int Minutes { get; private set; } = 0;
        public int Seconds { get; private set; } = 0;
        
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
        }
        
        public void GetTime() 
        {
            StartCoroutine(GetGlobalTime());
            Debug.Log("TimeGoogle: " + _time);
            Debug.Log("TimeGoogle: " + _time.Hour);
            Debug.Log("TimeGoogle: " + _time.Minute);
            Debug.Log("TimeGoogle: " + _time.Second);
            Hours = _time.Hour;
            Minutes = _time.Minute;
            Seconds = _time.Second;
        }
    }
}