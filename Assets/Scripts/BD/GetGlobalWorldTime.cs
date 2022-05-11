using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class GetGlobalWorldTime : MonoBehaviour
    {
        private DateTime _time;
        private string _url = "http://worldtimeapi.org/api/timezone/Europe/London";
        private ResponseDataTime _responseTime;
        
        private void Start()
        {
            StartCoroutine(GetGlobalTime());
            
            // _time = СonversionTime();
            // Debug.Log("TimeWorld: " + _time);
            // Debug.Log("TimeWorld: " + _time.Hour);
            // Debug.Log("TimeWorld: " + _time.Minute);
            // Debug.Log("TimeWorld: " + _time.Second);
        }

        private IEnumerator GetGlobalTime()
        {
            UnityWebRequest request = UnityWebRequest.Get(this._url);

            yield return request.SendWebRequest();

            _responseTime = JsonUtility.FromJson<ResponseDataTime>(request.downloadHandler.text);
            
            Debug.Log("TimeWorld: " + _responseTime.utc_datetime);
           
            string dateTimeString = _responseTime.ToString();
            
            if (!DateTime.TryParse(dateTimeString, out _time)) 
            {
                yield return DateTime.MinValue;
            }
            
            yield return _time.ToUniversalTime();
            
            Debug.Log("TimeWorld: " + _time);
            Debug.Log("TimeWorld: " + _time.Hour);
            Debug.Log("TimeWorld: " + _time.Minute);
            Debug.Log("TimeWorld: " + _time.Second);
        }
        
        private DateTime СonversionTime()
        {
            string dateTimeString = _responseTime.ToString();
            if (!DateTime.TryParse(dateTimeString, out _time)) 
            {
                return DateTime.MinValue;
            }
            return _time.ToUniversalTime();
        }
    }
}
